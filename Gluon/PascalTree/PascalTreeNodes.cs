using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gluon.AST;

namespace Gluon
{
    public class PascalTree : PascalTreeNodes.INode
    {
        public List<PascalTreeNodes.INode> Children { get; private set; } = new List<PascalTreeNodes.INode>();

        public virtual void Resolve(PascalRender writer)
        {
            foreach (var child in Children)
                child.Resolve(writer);
        }

        public IEnumerable<PascalTreeNodes.INode> ForwardTraversal
        {
            get
            {
                yield return this;

                foreach (var node in Children)
                {
                    var branch = node as PascalTree;

                    if (branch == null)
                        yield return node;
                    else
                        foreach (var ft in branch.ForwardTraversal)
                            yield return ft;
                }
            }
        }

        public T FindFirst<T>() where T : class
        {
            foreach (var n in ForwardTraversal)
            {
                var t = n as T;
                if (t != null)
                    return t;
            }

            return null;
        }
    }
}

namespace Gluon.PascalTreeNodes
{
    public partial class PascalTreeWriter
    {
    }

    public interface INode
    {
        void Resolve(PascalRender writer);
    }

    public interface ITypedNode
    {
        IEnumerable<AST.Type> ReferencedTypes { get; }
    }

    public interface INoTextNode { }

    public class UsingsBlock : PascalTree { }

    public class TextNode : INode
    {
        public string Text { get; set; }

        public TextNode(string text) { Text = text; }

        public void Resolve(PascalRender writer)
        {
            writer.Code(Text);
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class LineNode : INode
    {
        public void Resolve(PascalRender writer)
        {
            writer.Line();
        }
    }

    public class IndentNode : INode
    {
        public int Delta { get; set; }

        public IndentNode(int delta) { Delta = delta; }

        public void Resolve(PascalRender writer)
        {
            writer.Indent += Delta;
        }
    }

    public class IndentStyleNode : INode, INoTextNode
    {
        public string Style { get; private set; }

        public IndentStyleNode(string style) { Style = style; }

        public void Resolve(PascalRender writer)
        {
            writer.IndentStyle = Style;
        }
    }

    public class UsingNode : INode
    {
        public AST.Namespace Namespace { get; private set; }
        public bool Abi { get; private set; }

        public UsingNode(AST.Namespace ns, bool abi = false) { Namespace = ns; Abi = abi; }

        public void Resolve(PascalRender writer)
        {
            writer.Use(Namespace, Abi);
        }
    }

    public class DirectiveNode : PascalTree
    {
        public string Text { get; private set; }

        public DirectiveNode(string text) { Text = text; }

        public override void Resolve(PascalRender writer)
        {
            writer.Directive(Text);
        }
    }

    public class BlockCommentNode : PascalTree
    {
        public override void Resolve(PascalRender writer)
        {
            writer.BeginBlockComment();
            base.Resolve(writer);
            writer.EndBlockComment();
        }
    }

    public class XmlDocNode : PascalTree
    {
        public override void Resolve(PascalRender writer)
        {
            writer.BeginXmlDoc();
            base.Resolve(writer);
            writer.EndXmlDoc();
        }
    }

    public class BlockNode : PascalTree
    {
        public string Postscript { get; private set; }

        public BlockNode(string postscript = "") { Postscript = postscript; }

        public override void Resolve(PascalRender writer)
        {
            writer.Block(() =>
            {
                base.Resolve(writer);
            }, Postscript);
        }
    }

    public class SpacerNode : INode
    {
        public void Resolve(PascalRender writer)
        {
            writer.Spacer();
        }
    }

    public class RegionNode : PascalTree
    {
        public override void Resolve(PascalRender writer)
        {
            writer.BeginRegion();
            base.Resolve(writer);
            writer.EndRegion();
        }
    }

    public class ListItemNode : PascalTree
    {
        public override void Resolve(PascalRender writer)
        {
            base.Resolve(writer);
        }
    }

    public class LineStyleNode : INode
    {
        public CodeLineStyle Style { get; private set; }

        public LineStyleNode(CodeLineStyle style) { Style = style; }

        public void Resolve(PascalRender writer)
        {
            writer.LineStyle = Style;
        }
    }

    public class ListNode : PascalTree
    {
        public CodeListStyle ListStyle { get; private set; } = CodeListStyle.SingleLine;

        public ListNode(CodeListStyle style) { ListStyle = style; }

        public override void Resolve(PascalRender writer)
        {
            writer.BeginList(ListStyle);
            foreach (var child in Children)
            {
                child.Resolve(writer);
                writer.NextListItem();
            }
            writer.EndList();
        }
    }

    public class TypeRefNode : INode, ITypedNode
    {
        public AST.IVariable Variable { get; private set; }
        public AST.Type Type { get; private set; }
        public bool? Abi { get; set; }

        public IEnumerable<AST.Type> ReferencedTypes { get { return Type.SelectReferencedTypes().Union(new AST.Type[] { Type }); } }

        public TypeRefNode(AST.Type type, bool? abi = null) { Type = type; Abi = abi; }
        public TypeRefNode(AST.IVariable variable, bool? abi = null) { Variable = variable; Type = Variable.Type; Abi = abi; }

        public void Resolve(PascalRender writer)
        {
            if (Variable != null)
                writer.Code(writer.TypeName(Variable, Abi));
            else
                writer.Code(writer.TypeName(Type, Abi));
        }
    }

    public class VariableTypeNode : INode, ITypedNode
    {
        public AST.IVariable Var { get; private set; }
        public bool? Abi { get; set; }

        public IEnumerable<AST.Type> ReferencedTypes { get { return Var.Type.SelectReferencedTypes(); } }

        public VariableTypeNode(AST.IVariable variable, bool? abi)
        {
            Var = variable;
            Abi = abi;
        }

        public void Resolve(PascalRender writer)
        {
            writer.ParameterType(Var, Abi);
        }
    }

    public class LiteralNode : INode, ITypedNode
    {
        public object Value { get; private set; }
        public AST.Type Type { get; private set; }

        public IEnumerable<AST.Type> ReferencedTypes { get { return Type.SelectReferencedTypes(); } }

        public LiteralNode(object value, AST.Type type) { Value = value; Type = type; }

        public void Resolve(PascalRender writer)
        {
            writer.Code(writer.ToLiteral(Value, Type));
        }
    }

    public class NamespaceNode : PascalTree
    {
        public AST.Namespace Namespace { get; set; }
        public bool Abi { get; set; }

        public NamespaceNode(AST.Namespace ns, bool abi) { Namespace = ns; Abi = abi; }

        public override void Resolve(PascalRender writer)
        {
            writer.Spacer();
            writer.Namespace(Namespace, Abi, () =>
            {
                var oldns = writer.WorkingNamespace;
                writer.WorkingNamespace = Namespace;
                base.Resolve(writer);
                writer.WorkingNamespace = oldns;
            });
            writer.Spacer();
        }
    }

    public class StrataNode : INode, INoTextNode
    {
        public ApiStrata Strata { get; private set; }

        public StrataNode(ApiStrata strata) { Strata = strata; }

        public void Resolve(PascalRender writer)
        {
            writer.Strata = Strata;
        }
    }
}
