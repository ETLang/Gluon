using System;

namespace Gluon
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event)]
    public class VirtualAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event | AttributeTargets.Interface)]
    public class AbstractAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event)]
    public class StaticAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class PublicAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class ProtectedAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class PrivateAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class InternalAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class AsyncAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class UnconstAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class ConstAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class BackedAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class FactoryAttribute : Attribute { }
}
