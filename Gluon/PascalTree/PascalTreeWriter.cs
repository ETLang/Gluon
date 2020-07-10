using Gluon.PascalTreeNodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Gluon
{
    public partial class PascalTreeWriter
    {
        public PascalTree Tree { get; private set; }
        public PascalTree Target { get; private set; }
        public IReadOnlyList<PascalTree> Ancestors { get { return _ancestors; } }
        public int Index;

        public PascalTreeWriter() : this(new PascalTree()) { }

        public PascalTreeWriter(PascalTree tree)
        {
            Tree = tree;
            Target = tree;
            Index = tree.Children.Count;
        }

        #region Cursor Ops

        public void Insert(INode node)
        {
            Target.Children.Insert(Index, node);
            Index++;
        }

        public void InsertAndPushTarget(PascalTree node)
        {
            Target.Children.Insert(Index, node);
            _ancestors.Add(Target);
            Target = node;
            Index = node.Children.Count;
        }

        public void Delete()
        {
            if (Index < Target.Children.Count)
                Target.Children.RemoveAt(Index);
        }

        public void PopTarget()
        {
            if (_ancestors.Count == 0)
                throw new InvalidOperationException("Can't pop the root target");

            var newTarget = _ancestors.Last();
            _ancestors.RemoveAt(_ancestors.Count - 1);
            Index = newTarget.Children.IndexOf(Target) + 1;
            Target = newTarget;
        }

        public PascalTreeWriter Clone()
        {
            var ret = new PascalTreeWriter(Tree);
            ret.Index = Index;
            ret.Target = Target;

            foreach (var node in _ancestors)
                ret._ancestors.Add(node);

            return ret;
        }

        public INode NextNode
        {
            get
            {
                int traversalIndex = Index;
                var previousTarget = Target;
                for (int i = _ancestors.Count; i >= 0; i--)
                {
                    var p = i == _ancestors.Count ? Target : _ancestors[i];

                    if(previousTarget != p)
                        traversalIndex = p.Children.IndexOf(previousTarget);

                    if (traversalIndex < p.Children.Count)
                        return p.Children[traversalIndex];

                    previousTarget = p;
                }

                return null;
            }
        }

        public T FindNearestPrevious<T>() where T : class
        {
            T current = null;

            var last = NextNode;
            foreach (var node in Tree.ForwardTraversal)
            {
                var t = node as T;
                if (t != null)
                    current = t;

                if (node == last)
                    break;
            }

            return current;
        }

        public T FindContainer<T>() where T : class
        {
            return _ancestors.Reverse<PascalTree>().OfType<T>().FirstOrDefault();
        }

        public IEnumerable<PascalTree> AllAncestors
        {
            get
            {
                yield return Target;
                for (int i = _ancestors.Count - 1; i >= 0; i--)
                    yield return _ancestors[i];
            }
        }

        public IEnumerable<T> FilteredAncestors<T>() where T : class
        {
            foreach (var node in AllAncestors)
            {
                var t = node as T;
                if (t != null)
                    yield return t;
            }
        }

        #endregion

        #region Writer Ops

        public ApiStrata Strata
        {
            get
            {
                var node = FindNearestPrevious<StrataNode>();
                return node == null ? ApiStrata.Normal : node.Strata;
            }
            set
            {
                Insert(new StrataNode(value));
            }
        }

        public CodeLineStyle LineStyle
        {
            get
            {
                var node = FindContainer<LineStyleNode>();
                return node == null ? CodeLineStyle.Standard : node.Style;
            }
            set
            {
                Insert(new LineStyleNode(value));
            }
        }

        public string IndentStyle
        {
            get
            {
                var node = FindContainer<IndentStyleNode>();
                return node == null ? "    " : node.Style;
            }
            set
            {
                Insert(new IndentStyleNode(value));
            }
        }

        public CodeListStyle ListStyle
        {
            get
            {
                var node = FindContainer<ListNode>();
                return node == null ? CodeListStyle.SingleLine : node.ListStyle;
            }
        }

        #region Indent

        public int Indent
        {
            get { return _Indent; }
            set
            {
                if (_Indent == value) return;

                var delta = value - _Indent;
                _Indent = value;

                Insert(new IndentNode(delta));
            }
        }
        private int _Indent;

        #endregion

        public string TypeRef(AST.Type type, bool? abi = null)
        {
            return InlineNode(new TypeRefNode(type, abi));
        }

        public string TypeRef(AST.IVariable type, bool? abi = null)
        {
            return InlineNode(new TypeRefNode(type, abi));
        }

        public UsingsBlock DeferredUsings()
        {
            var block = new UsingsBlock();
            Insert(block);
            return block;
        }

        public void Code(string code)
        {
            int lastLineEnd = 0;

            foreach (var matchobj in _LineRegex.Matches(code))
            {
                var match = matchobj as Match;

                if (match == null) continue;

                if (LineStyle != CodeLineStyle.SingleLine)
                {
                    var indentGroup = match.Groups["indent"];
                    if (indentGroup.Success && indentGroup.Length != 0)
                    {
                        int len = indentGroup.Length;
                        int i;
                        for (i = 3; i < len; i += 4)
                            InternalText(IndentStyle);
                        if (i < len)
                            InternalText(new string(' ', len - i));
                    }
                }

                InternalText(match.Groups["text"].Value);
                Insert(new LineNode());

                lastLineEnd = match.Index + match.Length;
            }

            if (lastLineEnd != code.Length)
                InternalText(code.Substring(lastLineEnd));
        }

        public void Code(string fmt, params object[] args)
        {
            Code(string.Format(fmt, args));
        }

        public void Line()
        {
            Insert(new LineNode());
        }

        public void Line(string line)
        {
            Code(line);
            Line();
        }

        public void Line(string fmt, params object[] args)
        {
            Code(fmt, args);
            Line();
        }

        public void Region(Action contents)
        {
            InsertAndPushTarget(new RegionNode());
            contents();
            PopTarget();
        }

        public void Spacer()
        {
            Insert(new SpacerNode());
        }

        public void ListItem(Action content)
        {
            content();
            PopTarget();
            InsertAndPushTarget(new ListItemNode());
        }

        public void ListItem(string item)
        {
            Code(item);
            PopTarget();
            InsertAndPushTarget(new ListItemNode());
        }

        public void ListItem(string fmt, params object[] args)
        {
            ListItem(string.Format(fmt, args));
        }

        public void NextListItem()
        {
            PopTarget();
            InsertAndPushTarget(new ListItemNode());
        }

        public void LineComment(string comment)
        {
            Line("// " + comment);
        }

        public void LineComment(string fmt, params object[] args)
        {
            Line("// " + fmt, args);
        }

        public void BlockComment(Action content)
        {
            InsertAndPushTarget(new BlockCommentNode());
            content();
            PopTarget();
        }

        public void XmlDoc(Action content)
        {
            InsertAndPushTarget(new XmlDocNode());
            content();
            PopTarget();
        }

        public void WriteXmlDocumentation(XmlElement doc)
        {
            if (doc != null)
            {
                Spacer();
                XmlDoc(() =>
                {
                    foreach (var el in doc.ChildNodes.OfType<XmlElement>())
                    {
                        var txt = el.InnerXml.TrimIndent().Trim();

                        Code($"<{el.LocalName}");
                        foreach (var attr in el.Attributes.OfType<XmlAttribute>())
                            Code($" {attr.LocalName}=\"{attr.InnerText.Trim()}\"");

                        if (string.IsNullOrWhiteSpace(txt))
                            Line("/>");
                        else
                        {
                            Line(">");
                            Line(txt);
                            Line($"</{el.LocalName}>");
                        }
                    }
                });
            }
        }

        public void List(CodeListStyle style, Action content)
        {
            var list = new ListNode(style);

            InsertAndPushTarget(list);
            InsertAndPushTarget(new ListItemNode());
            content();
            PopTarget();
            PopTarget();

            if (list.Children.Count != 0 && ((PascalTree)list.Children.Last()).Children.Count == 0)
                list.Children.RemoveAt(list.Children.Count - 1);
        }

        public void List(Action content)
        {
            List(CodeListStyle.SingleLine, content);
        }

        public void Block(Action content, string postScript = "")
        {
            InsertAndPushTarget(new BlockNode(postScript));
            content();
            PopTarget();
        }

        public void Namespace(AST.Namespace ns, bool abi, Action content)
        {
            NamespaceNode prev = null;

            if (Index > 0)
                prev = Target.Children[Index - 1] as NamespaceNode;

            if (prev != null && prev.Namespace == ns && prev.Abi == abi)
            {
                _ancestors.Add(Target);
                Target = prev;
                Index = Target.Children.Count;
                content();
                PopTarget();
            }
            else if (prev != null && prev.Abi == abi && ns.IsWithin(prev.Namespace))
            {
                _ancestors.Add(Target);
                Target = prev;
                Index = Target.Children.Count;
                Namespace(ns, abi, content);
                PopTarget();
            }
            else
            {
                InsertAndPushTarget(new NamespaceNode(ns, abi));
                content();
                PopTarget();
            }
        }

        public string VariableType(AST.IVariable arg, AST.VariableContext ctx, bool? abi = null)
        {
            return VariableType(arg.InContext(ctx), abi);
        }

        public virtual string VariableType(AST.IVariable arg, bool? abi = null)
        {
            return InlineNode(new VariableTypeNode(arg, abi));
        }

        public string ForEach<T>(IEnumerable<T> items, Action<T> fn)
        {
            var argNode = new PascalTree();

            var currentTarget = Target;
            var currentIndex = Index;

            Target = argNode;
            Index = 0;

            foreach (var item in items)
                fn(item);

            Target = currentTarget;
            Index = currentIndex;

            return InlineNode(argNode);
        }

        public string List<T>(IEnumerable<T> items, Func<T, string> exp)
        {
            return List(items, CodeListStyle.SingleLine, exp);
        }

        public string List<T>(IEnumerable<T> items, CodeListStyle style, Func<T, string> exp)
        {
            var enumerator = items.GetEnumerator();
            if (!enumerator.MoveNext())
                return "";

            var argNode = new PascalTree();

            var currentTarget = Target;
            var currentIndex = Index;

            Target = argNode;
            Index = 0;

            List(style, () =>
            {
                foreach (var item in items)
                    ListItem(exp(item));
            });

            Target = currentTarget;
            Index = currentIndex;

            return InlineNode(argNode);
        }

        public string DeclParameters(params object[] args)
        {
            return DeclParameters(false, args);
        }

        public string DeclParameters(bool defaultValues, params object[] args)
        {
            var argNode = new PascalTree();

            var currentTarget = Target;
            var currentIndex = Index;

            Target = argNode;
            Index = 0;

            List(() =>
            {
                Action<object> handleObject = null;
                handleObject = o =>
                {
                    var str = o as string;
                    var ivar = o as AST.IVariable;
                    var coll = o as IEnumerable;

                    if (str != null)
                        ListItem(str);
                    if (ivar != null)
                    {
                        DeclParameter(ivar, defaultValues);
                        NextListItem();
                    }
                    if (coll != null)
                        foreach (var item in coll)
                            handleObject(item);
                };

                foreach (var arg in args)
                    handleObject(arg);
            });

            Target = currentTarget;
            Index = currentIndex;

            return InlineNode(argNode);
        }

        private void DeclParameter(AST.IVariable arg, bool declareDefaultValue = false)
        {
            bool hasDefault = false;
            object defaultValue = null;

            var p = arg as AST.Parameter;
            if (p != null && declareDefaultValue)
            {
                hasDefault = p.HasDefaultValue;
                defaultValue = p.DefaultValue;
            }

            Code("{0} {1}", VariableType(arg), arg.Name);

            if (hasDefault)
                Code(" = {0}", Literal(defaultValue, arg.Type));
        }

        public void Directive(string line)
        {
            Insert(new DirectiveNode(line));
        }

        public void Directive(string fmt, params object[] args)
        {
            Directive(string.Format(fmt, args));
        }

        public string Literal(object value, AST.Type type)
        {
            return InlineNode(new LiteralNode(value, type));
        }

        public void Use(AST.Namespace ns, bool abi = false)
        {
            Insert(new UsingNode(ns, abi));
        }

        public void InsertUsings()
        {
            var block = Tree.ForwardTraversal.OfType<UsingsBlock>().FirstOrDefault();

            if (block == null) return;

            var cursor = new PascalTreeWriter(block);

            var allTypeRefs = Tree.ForwardTraversal.OfType<ITypedNode>().SelectMany(t => t.ReferencedTypes).Distinct();

            var allNamespaces = allTypeRefs.Select(t => t.Namespace).Distinct().Where(ns => !ns.IsGlobal && ns != BasicTypes.SystemNamespace);

            foreach (var ns in allNamespaces)
                cursor.Use(ns);
        }

        #endregion

        #region Internal

        protected string InlineNode(INode node)
        {
            var index = _referencedTypes.Count;
            _referencedTypes.Add(node);
            return "`" + index.ToString() + "`";
        }

        private void InternalText(string code)
        {
            int matchCursor = 0;

            foreach(var matchobj in _TypeRefRegex.Matches(code))
            {
                int indents = 0;
                var match = matchobj as Match;

                if (match == null) continue;

                if (matchCursor != match.Index)
                {
                    var newline = code.LastIndexOf('\n', match.Index);

                    if (newline == -1)
                        newline = 0;

                    var indentMatch = _IndentRegex.Match(code, newline);
                    var last = match.Index;
                    if(indentMatch.Success && indentMatch.Index + indentMatch.Length == match.Index)
                    {
                        var grp = indentMatch.Groups["indent"];
                        last = grp.Index;
                        indents = grp.Length / 4;
                    }
                    Insert(new TextNode(code.Substring(matchCursor, last - matchCursor)));
                }

                matchCursor = match.Index + match.Length;

                if (indents != 0)
                    Insert(new IndentNode(indents));
                Insert(_referencedTypes[int.Parse(match.Groups["index"].Value)]);
                if (indents != 0)
                    Insert(new IndentNode(-indents));
            }

            if (matchCursor != code.Length)
                Insert(new TextNode(code.Substring(matchCursor)));
        }

        private static Regex _IndentRegex = new Regex(@"(^(?<indent>(    )+))|(\n(?<indent>(    )+))", RegexOptions.Compiled);
        private static Regex _LineRegex = new Regex(@"(?<text>[^\r\n]*)\r?\n", RegexOptions.Compiled);
        private static Regex _TypeRefRegex = new Regex(@"\`(?<index>[0-9]+)\`", RegexOptions.Compiled);

        private List<PascalTree> _ancestors = new List<PascalTree>();
        private List<INode> _referencedTypes = new List<INode>();
        
        #endregion
    }
}
