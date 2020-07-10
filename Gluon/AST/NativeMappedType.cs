using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class NativeMappedType
    {
        public string TargetID { get; set; }
        public Type ManagedType { get; set; }
        public string NativeType { get; set; }
        public string NativeHeader { get; set; }
        public string NativeLibrary { get; set; }

        public override string ToString()
        {
            var s = ManagedType.FullName(".") + " -> " + NativeType;
            var nh = !string.IsNullOrEmpty(NativeHeader);
            var nl = !string.IsNullOrEmpty(NativeLibrary);

            if (nh || nl)
            {
                s += "(";

                if(nh)
                    s += NativeHeader;

                if (nh && nl)
                    s += ", ";

                if (nl)
                    s += NativeLibrary;

                s += ")";
            }

            return s;
        }
    }
}
