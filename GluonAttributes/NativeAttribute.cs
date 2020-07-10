using System;

namespace Gluon
{
    public class NativeAttribute : Attribute
    {
        public string Header { get; private set; }
        public string StaticLibrary { get; private set; }
        public string Target { get; set; }

        public NativeAttribute(string header = null, string staticLib = null)
        {
            Header = header;
            StaticLibrary = staticLib;
        }
    }
}
