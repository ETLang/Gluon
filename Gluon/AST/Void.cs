using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Void : Type
    {
        public Void() : base(Construct.Void) { Name = "void"; }
    }
}
