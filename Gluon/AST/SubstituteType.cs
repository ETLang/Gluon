using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class SubstituteType
    {
        public string TargetID { get; set; }
        public Type OriginalType { get; set; }
        public Type TargetType { get; set; }

        public override string ToString()
        {
            return OriginalType.FullName(".") + " -> " + TargetType.FullName(".") + (string.IsNullOrEmpty(TargetID) ? "" : "(" + TargetID + ")");
        }
    }
}
