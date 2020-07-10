using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Delegate : Type, ICallSignature
    {
        public Parameter Return { get; set; }
        public List<Parameter> Parameters { get; private set; } = new List<Parameter>();
        public bool IsGeneric { get; set; }

        bool ICallSignature.IsConst { get { return false; } }
        int ICallSignature.OverloadOrdinal { get; set; }

        public Delegate() : base(Construct.Delegate)
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
            sb.Append("delegate ");
            sb.Append(Return);
            sb.Append(" ");
            sb.Append(Name);
            sb.Append("(");
            foreach (var arg in Parameters)
            {
                if (!first)
                    sb.Append(", ");
                first = false;
                sb.Append(arg);
            }
            sb.Append(")");
            return sb.ToString();
        }

        public override string UniqueName
        {
            get
            {
                if (!IsGeneric) return base.UniqueName;

                var sb = new StringBuilder();

                sb.Append(Namespace.FullName("."));
                sb.Append(".Delegate<");
                sb.Append(Return.UniqueName);
                sb.Append("(");

                bool first = true;
                foreach (var arg in Parameters)
                {
                    if (!first)
                        sb.Append(",");
                    sb.Append(arg.UniqueName);
                    first = false;
                }

                sb.Append(")>");

                return sb.ToString();
            }
        }
    }
}
