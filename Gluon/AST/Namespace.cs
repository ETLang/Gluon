using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Namespace : Node
    {
        public Namespace Parent { get; set; }

        public bool IsGlobal { get { return Parent == null; } }

        public Namespace() : base(Construct.Namespace) { }

        public Namespace FindCommonRoot(Namespace other)
        {
            if (other == this) return this;

            List<Namespace> a = new List<Namespace>();
            List<Namespace> b = new List<Namespace>();

            for (Namespace ns = this; ns != null; ns = ns.Parent)
                a.Add(ns);

            for (Namespace ns = other; ns != null; ns = ns.Parent)
                b.Add(ns);

            int i;
            for (i = 1; i <= Math.Min(a.Count, b.Count); i++)
            {
                if (a[a.Count - i] != b[b.Count - i])
                    break;
            }

            return a[a.Count - i + 1];
        }
        
        public bool IsWithin(Namespace ancestor)
        {
            if (ancestor == null && IsGlobal) return true;
            if (ancestor == this) return true;
            if (IsGlobal) return false;
            return Parent.IsWithin(ancestor);
        }

        public override string ToString()
        {
            return "namespace " + Name + "{ }";
        }
    }
}
