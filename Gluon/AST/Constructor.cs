using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Constructor : Member, ICallSignature
    {
        public List<Parameter> Parameters { get; private set; } = new List<Parameter>();

        bool ICallSignature.IsConst { get { return false; } }

        public Constructor() : base(Construct.Constructor)
        {
        }

        Parameter ICallSignature.Return
        {
            get { return null; }
            set => throw new NotImplementedException();
        }

        public int OverloadOrdinal { get; set; }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(base.Declarations, Parameters.SelectMany(arg => arg.Declarations));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            bool first = true;
            sb.Append(Name);
            sb.Append("(");
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
