using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Event : Member, ICallSignature
    {
        public Delegate HandlerType { get; set; }

        public Parameter Return { get; set; }
        public List<Parameter> Parameters { get; private set; } = new List<Parameter>();

        bool ICallSignature.IsConst { get { return false; } }
        int ICallSignature.OverloadOrdinal { get; set; }

        public Event() : base(Construct.Event) { }

        public Method CreateAdder()
        {
            var m = new Method
            {
                Access = Access,
                Nature = Nature,
                Name = "Add" + Name + "Handler",
                Return = Parameter.Void,
            };

            m.Parameters.Add(new Parameter
            {
                Type = HandlerType,
                Name = "handler"
            });

            return m;
        }

        public Method CreateRemover()
        {
            var m = new Method
            {
                Access = Access,
                Nature = Nature,
                Name = "Remove" + Name + "Handler",
                Return = Parameter.Void,
            };

            m.Parameters.Add(new Parameter
            {
                Type = HandlerType,
                Name = "handler"
            });

            return m;
        }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(base.Declarations, With(HandlerType), Return == null ? null : Return.Declarations, Parameters.SelectMany(p => p.Declarations));
            }
        }

        public override void Analyze()
        {
            base.Analyze();

            if(HandlerType != null)
            {
                Return = null;
                Parameters.Clear();
            }
        }

        public override string ToString()
        {
            if (HandlerType != null)
            {
                return "event " + HandlerType.Name + " " + Name;
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendFormat("event Sig<{0}(", Return);
                bool first = true;
                foreach(var arg in Parameters)
                {
                    if (!first)
                        sb.Append(", ");
                    sb.Append(arg);
                }
                sb.Append(")> ");
                sb.Append(Name);
                return sb.ToString();
            }
        }
    }
}
