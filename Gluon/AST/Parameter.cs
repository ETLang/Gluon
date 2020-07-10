using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Parameter : Node, IVariable
    {
        public VariableContext Context { get; set; }
        public Type Type { get; set; }
        public bool IsArray { get; set; }
        public bool HasDefaultValue { get; set; }
        public object DefaultValue { get; set; }

        public bool IsVoid { get { return Type.IsVoid; } }
        public bool IsIn { get { return Context == VariableContext.In; } }
        public bool IsRef { get { return Context == VariableContext.Ref; } }
        public bool IsOut { get { return Context == VariableContext.Out; } }

        public string Documentation { get { return XmlDoc?.InnerText.Trim(); } }

        public Parameter() : base(Construct.Parameter) { }

        public Parameter(Type type, string name, VariableContext ctx, bool isArray, bool hasDefaultValue = false, object defaultValue = null) : base(Construct.Parameter)
        {
            Type = type;
            Name = name;
            Context = ctx;
            IsArray = isArray;
            HasDefaultValue = hasDefaultValue;
            DefaultValue = defaultValue;
        }

        public static Parameter Void { get; private set; } = new Parameter
        {
            Context = VariableContext.Return,
            Type = BasicTypes.Void
        };

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(base.Declarations, With(Type));
            }
        }

        public override bool Equals(object obj)
        {
            var other = (Parameter)obj;

            return Context == other.Context && Type == other.Type && IsArray == other.IsArray;
        }

        public override int GetHashCode()
        {
            return Context.GetHashCode() ^ (Type.GetHashCode() << 3) ^ (IsArray.GetHashCode() << 6);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Context == VariableContext.Ref)
                sb.Append("ref ");
            if (Context == VariableContext.Out)
                sb.Append("out ");

            sb.Append(Type.FullName("."));
            if (IsArray)
                sb.Append("[]");
            sb.Append(" ");
            sb.Append(Name);

            if (HasDefaultValue)
                sb.AppendFormat(" = {0}", DefaultValue);

            return sb.ToString();
        }
    }
}

namespace Gluon
{
    public static class IVariableExtensions
    {
        public static AST.Parameter InContext(this AST.IVariable v, AST.VariableContext newContext, string newName = null)
        {
            var p = new AST.Parameter();
            p.Context = newContext;
            p.Name = newName ?? v.Name;
            p.Type = v.Type;
            p.IsArray = v.IsArray;

            var vp = v as AST.Parameter;
            if (vp != null)
            {
                p.HasDefaultValue = vp.HasDefaultValue;
                p.DefaultValue = vp.DefaultValue;
            }

            return p;
        }
    }
}
