using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Field : Member, IVariable
    {
        public Type Type { get; set; }
        public bool IsArray { get; set; }
        public bool IsVoid { get { return Type.IsVoid; } }
        public bool IsIn { get { return false; } }
        public bool IsRef { get { return false; } }
        public bool IsOut { get { return false; } }

        public VariableContext Context
        {
            get { return VariableContext.Member; }
            set { throw new NotImplementedException(); }
        }

        public Field() : base(Construct.Field)
        {
        }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(base.Declarations, With(Type));
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + Type.ToString() + (IsArray ? "[]" : "") + " " + Name;
        }
    }
}
