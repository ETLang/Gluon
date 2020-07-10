using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public abstract class Member : Node, IHasAttributes
    {
        public List<Attribute> Attributes { get; private set; } = new List<Attribute>();

        public Access Access { get; set; } = Access.Public;
        public MemberNature Nature { get; set; } = MemberNature.Instance;

        public bool IsAbstract { get { return Nature == MemberNature.Abstract; } }
        public bool IsVirtual { get { return Nature == MemberNature.Virtual; } }
        public bool IsStatic { get { return Nature == MemberNature.Static; } }

        public string Summary
        {
            get { return XmlDoc?["summary"]?.InnerText.Trim(); }
        }

        public string Remarks
        {
            get { return XmlDoc?["remarks"]?.InnerText.Trim(); }
        }

        protected Member(Construct construct) : base(construct) { Debug.Assert(construct.HasFlag(Construct.Member)); }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(
                    base.Declarations,
                    Attributes.SelectMany(attr => attr.Declarations));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Attributes.Count != 0)
                sb.AppendFormat("[Attrs({0})] ", Attributes.Count);

            sb.Append(Access.ToString().ToLower());
            sb.Append(" ");
            if (Nature != MemberNature.Instance)
            {
                sb.Append(Nature.ToString().ToLower());
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}
