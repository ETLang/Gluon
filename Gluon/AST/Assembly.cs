using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Assembly : Node, IHasAttributes
    {
        public bool IsBuildSource { get; set; }
        public bool IsGluonDefinition { get; set; }
        public List<Attribute> Attributes { get; private set; } = new List<Attribute>();

        public Assembly() : base(Construct.Assembly) { }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(base.Declarations, Attributes.SelectMany(attr => attr.Declarations));
            }
        }
    }
}