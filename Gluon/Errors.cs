using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public static class Errors
    {
        public static int ErrorCount { get; private set; }
        public static int WarningCount { get; private set; }

        public static void Generic(string msg)
        {
            Console.WriteLine("ERROR: " + msg);
            ErrorCount++;
        }

        public static void Warn(string msg)
        {
            Console.WriteLine("WARNING: " + msg);
            WarningCount++;
        }

        public static void Internal(string msg)
        {
            Console.WriteLine("INTERNAL ERROR: " + msg);
            ErrorCount++;
        }

        public static void UnblittableStruct(Type badtype)
        {
            Generic(badtype.FullName + " is not blittable. Add [StructLayout(LayoutKind.Sequential)] or [StructLayout(LayoutKind.Explicit)]");
        }

        public static void InvalidClassReference(Type badtype)
        {
            Generic(badtype.FullName + " cannot be referenced by a Gluon library. Classes must implement IUnknown or be Gluon-generated wrappers");
        }

        public static void MisunderstoodNamespace(Type badtype)
        {
            Generic(badtype.FullName + " - namespace not parsed correctly");
        }

        public static void IncompatibleType(AST.Type badtype)
        {
            Warn(badtype.Name + " - ignoring Gluon-incompatible type");
        }

        public static void UndeclaredType(Type badtype)
        {
            Generic(badtype.FullName + " - Referenced type is not properly declared.");
        }

        public static void InternalFailure()
        {
            Generic("Internal failure: \n" + new StackTrace().ToString());
        }

        internal static void ReturningArray()
        {
            Generic("Returning arrays is not supported");
        }

        internal static void StaticMember(MemberInfo info)
        {
            Generic("Unsupported Declaration: " + info.DeclaringType.FullName + "." + info.Name + "\n    Aside from constructors (which must be named Create and return class instance), static members are not supported.");
        }

        internal static void NoInput()
        {
            Generic("No input file specified!");
        }

        internal static void DelegateType(MemberInfo context, Type badType)
        {
            Generic("Unsupported Type: " + badType.Name + " in " + context.DeclaringType.FullName + "." + context.Name + ": Delegates are not yet supported");
        }

        internal static void WriteOnlyProperty(PropertyInfo prop)
        {
            Generic("Write-only properties are unsupported: " + prop.DeclaringType.FullName + "." + prop.Name);
        }

        internal static void UnsupportedTypeInAttribute(Type unsupported)
        {
            Generic("Type " + unsupported.FullName + " is not supported as an attribute argument");
        }

        internal static void AbstractConstructor(MethodInfo c)
        {
            Generic(c.DeclaringType.FullName + "." + c.Name + " - Constructors cannot be abstract");
        }

        internal static void AbstractAndVirtual(MethodInfo m)
        {
            Generic(m.DeclaringType.FullName + "." + m.Name + " - Methods cannot be both virtual and abstract");
        }

        internal static void OverrideAndAbstract(MethodInfo m)
        {
            Generic(m.DeclaringType.FullName + "." + m.Name + " - Method overrides cannot be abstract");
        }
    }
}
