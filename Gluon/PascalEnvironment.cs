using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public abstract class PascalEnvironment
    {
        public AST.Namespace WorkingNamespace { get; set; }
        public bool WorkingABINamespace { get; set; }
        public ApiStrata Strata { get; set; }
        public HashSet<AST.Namespace> UsingNamespaces { get; private set; } = new HashSet<AST.Namespace>();
        public HashSet<AST.Namespace> UsingABINamespaces { get; private set; } = new HashSet<AST.Namespace>();

        public bool Use(AST.Namespace ns, bool abi)
        {
            if (!abi && !UsingNamespaces.Contains(ns))
                UsingNamespaces.Add(ns);
            else if (abi && !UsingABINamespaces.Contains(ns))
                UsingABINamespaces.Add(ns);
            else
                return false;
            return true;
        }

        public abstract string TypeName(AST.IVariable v, bool? abi = null);
        public abstract string TypeName(AST.Type v, bool? abi = null);
    }
}
