using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class SubstituteNamespace
    {
        public string TargetID { get; set; }
        public Namespace FromNamespace { get; set; }
        public Namespace ToNamespace { get; set; }

        public override string ToString()
        {
            return FromNamespace.FullName(".") + " -> " + ToNamespace.FullName(".") + (string.IsNullOrEmpty(TargetID) ? "" : "(" + TargetID + ")");
        }
    }
}
