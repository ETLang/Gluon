using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public struct ASTNamedValue
    {
        public string Name;
        public object Value;

        public ASTNamedValue(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }

    public class Attribute : Node
    {
        public Type Type { get; set; }

        public List<object> UnnamedParameters { get; private set; } = new List<object>();
        public List<ASTNamedValue> NamedParameters { get; private set; } = new List<ASTNamedValue>();

        public Attribute() : base(Construct.Attribute) { }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(base.Declarations, With(Type));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[{0}(", Type);
            bool first = true;
            foreach (var o in UnnamedParameters)
            {
                if (!first)
                    sb.Append(",");
                sb.Append(o);
                first = false;
            }
            foreach(var o in NamedParameters)
            {
                if (!first)
                    sb.Append(",");
                sb.AppendFormat("{0} = {1}", o.Name, o.Value);
            }
            sb.Append(")]");
            return sb.ToString();
        }
    }
}
