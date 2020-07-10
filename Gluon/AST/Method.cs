using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Method : Member, ICallSignature
    {
        public bool IsConst { get; set; }
        public Parameter Return { get; set; }
        public List<Parameter> Parameters { get; private set; } = new List<Parameter>();
        public int OverloadOrdinal { get; set; }

        public Method() : base(Construct.Method)
        {
        }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(
                    base.Declarations,
                    Return == null ? null : Return.Declarations,
                    Parameters.SelectMany(arg => arg.Declarations));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            bool first = true;
            sb.AppendFormat("{0}{1} {2}(", base.ToString(), Return, Name);

            foreach(var arg in Parameters)
            {
                if (!first)
                    sb.Append(", ");
                first = false;
                sb.Append(arg);
            }

            sb.Append(")");
            return sb.ToString();
        }
    }
}
