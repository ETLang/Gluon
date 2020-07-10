using System;

namespace Gluon
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class MappedTypeAttribute : Attribute
    {
        public Type OriginType
        {
            [Async]
            get;
            private set;
        }

        public Type ManagedType { get; private set; }
        public string NativeType { get; private set; }
        public string NativeHeader { get; private set; }
        public string NativeLibrary { get; private set; }

        public string Target { get; set; }

        public MappedTypeAttribute(Type managedType, string nativeType, string nativeHeader = null, string nativeLibrary = null)
        {
            OriginType = managedType;
            ManagedType = null;
            NativeType = nativeType;
            NativeHeader = nativeHeader;
            NativeLibrary = nativeLibrary;
        }

        public MappedTypeAttribute(Type originType, Type targetType)
        {
            OriginType = originType;
            ManagedType = targetType;
        }
    }
}
