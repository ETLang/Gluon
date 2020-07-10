using System;

namespace Gluon
{
    public class GluonGeneratedAttribute : Attribute
    {
        public string CppHeader { get; private set; }
        public string CppLib { get; private set; }
        public Type ABI { get; private set; }

        public GluonGeneratedAttribute(Type abi, string cppHeader = null, string cppLib = null)
        {
            CppHeader = cppHeader;
            CppLib = cppLib;
            ABI = ABI;
        }
    }
}
