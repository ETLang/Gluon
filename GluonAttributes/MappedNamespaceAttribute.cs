using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gluon
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class MappedNamespaceAttribute : Attribute
    {
        public string FromNamespace { get; set; }
        public string ToNamespace { get; set; }
        public string Target { get; set; }
    }
}
