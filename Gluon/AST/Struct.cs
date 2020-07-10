using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Struct : Type
    {
        public List<Field> Fields { get; private set; } = new List<Field>();
        public bool PredefinedFullConstructor { get; set; }

        public Struct() : base(Construct.Struct)
        {
        }
        
        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(
                    base.Declarations,
                    Fields.SelectMany(f => f.Declarations));
            }
        }
    }
}
