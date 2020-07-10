using System;
using System.Runtime.InteropServices;

namespace Gluon
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class GluonLibraryDefinitionAttribute : Attribute
    {
        public string[] DefaultTargets { get; private set; }

        public GluonLibraryDefinitionAttribute()
        {
            DefaultTargets = new string[0];
        }

        public GluonLibraryDefinitionAttribute(params string[] defaultTargets)
        {
            DefaultTargets = defaultTargets;
        }
    }
}
