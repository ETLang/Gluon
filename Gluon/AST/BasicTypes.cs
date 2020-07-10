using Gluon.AST;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public static class BasicTypes
    {
        static BasicTypes()
        {
            SystemAssembly = new Assembly()
            {
                Name = typeof(int).Assembly.GetName().Name
            };

            GlobalNamespace = new Namespace();

            SystemNamespace = new Namespace
            {
                Name = typeof(int).Namespace,
                Parent = GlobalNamespace
            };

            Void = Build<Void>(typeof(void), "void");
            Boolean = Build<Primitive>(typeof(bool), "bool");
            Byte = Build<Primitive>(typeof(byte), "byte");
            SByte = Build<Primitive>(typeof(sbyte), "sbyte");
            Int16 = Build<Primitive>(typeof(short), "short");
            UInt16 = Build<Primitive>(typeof(ushort), "ushort");
            Int32 = Build<Primitive>(typeof(int), "int");
            UInt32 = Build<Primitive>(typeof(uint), "uint");
            Int64 = Build<Primitive>(typeof(System.Int64), "long");
            UInt64 = Build<Primitive>(typeof(System.UInt64), "ulong");
            IntPtr = Build<Primitive>(typeof(System.IntPtr));
            UIntPtr = Build<Primitive>(typeof(System.UIntPtr));
            Char = Build<Primitive>(typeof(char), "char");
            Single = Build<Primitive>(typeof(float), "float");
            Double = Build<Primitive>(typeof(double), "double");
            String = Build<String>(typeof(string), "string");
            IUnknown = Build<Object>(typeof(IUnknown));
            IObject = Build<Object>(typeof(IObject));
            Object = Build<Object>(typeof(object), "object");
            Attribute = Build<Object>(typeof(Attribute));
        }

        static T Build<T>(System.Type st, string name = null) where T : Type, new()
        {
            return Build<T>(st, null, name);
        }

        static T Build<T>(System.Type st, Type original, string name = null) where T : Type, new()
        {
            T t = original as T;

            if(t == null)
                t = new T();

            if (name != null)
                t.Name = name;
            else
                t.Name = st.Name;

            t.Namespace = SystemNamespace;
            t.Assembly = SystemAssembly;
            t.Origin = TypeOrigin.Managed;

            return t;
        }

        public static Type Of(System.Type type)
        {
            if (type == typeof(void))
                return Void;
            else if (type == typeof(bool))
                return Boolean;
            else if (type == typeof(byte))
                return Byte;
            else if (type == typeof(sbyte))
                return SByte;
            else if (type == typeof(short))
                return Int16;
            else if (type == typeof(ushort))
                return UInt16;
            else if (type == typeof(int))
                return Int32;
            else if (type == typeof(uint))
                return UInt32;
            else if (type == typeof(System.Int64))
                return Int64;
            else if (type == typeof(System.UInt64))
                return UInt64;
            else if (type == typeof(System.IntPtr))
                return IntPtr;
            else if (type == typeof(System.UIntPtr))
                return UIntPtr;
            else if (type == typeof(char))
                return Char;
            else if (type == typeof(float))
                return Single;
            else if (type == typeof(double))
                return Double;
            else if (type == typeof(string))
                return String;
            else if (type == typeof(IUnknown))
                return IUnknown;
            else if (type == typeof(IObject))
                return IObject;
            else if (type == typeof(object))
                return Object;
            else if (type == typeof(Attribute))
                return Attribute;
            else
                return null;
        }
        
        public static void Reset()
        {
            SystemAssembly.Name = typeof(int).Assembly.GetName().Name;
            SystemNamespace.Name = typeof(int).Namespace;
            SystemNamespace.Parent = GlobalNamespace;

            Build<Void>(typeof(void), Void, "void");
            Boolean = Build<Primitive>(typeof(bool), Boolean, "bool");
            Byte = Build<Primitive>(typeof(byte), Byte, "byte");
            SByte = Build<Primitive>(typeof(sbyte), SByte, "sbyte");
            Int16 = Build<Primitive>(typeof(short), Int16, "short");
            UInt16 = Build<Primitive>(typeof(ushort), UInt16, "ushort");
            Int32 = Build<Primitive>(typeof(int), Int32, "int");
            UInt32 = Build<Primitive>(typeof(uint), UInt32, "uint");
            Int64 = Build<Primitive>(typeof(System.Int64), Int64, "long");
            UInt64 = Build<Primitive>(typeof(System.UInt64), UInt64, "ulong");
            IntPtr = Build<Primitive>(typeof(System.IntPtr), IntPtr);
            UIntPtr = Build<Primitive>(typeof(System.UIntPtr), UIntPtr);
            Char = Build<Primitive>(typeof(char), Char, "char");
            Single = Build<Primitive>(typeof(float), Single, "float");
            Double = Build<Primitive>(typeof(double), Double, "double");
            String = Build<String>(typeof(string), String, "string");
            IUnknown = Build<Object>(typeof(IUnknown), IUnknown);
            IObject = Build<Object>(typeof(IObject), IObject);
            Object = Build<Object>(typeof(object), Object, "object");
            Attribute = Build<Object>(typeof(Attribute), Attribute);
        }

        public static Namespace GlobalNamespace { get; private set; }
        public static Namespace SystemNamespace { get; private set; }
        public static Assembly SystemAssembly { get; private set; }

        public static Type Void { get; private set; }
        public static Type Boolean { get; private set; }
        public static Type Byte { get; private set; }
        public static Type SByte { get; private set; }
        public static Type Int16 { get; private set; }
        public static Type UInt16 { get; private set; }
        public static Type Int32 { get; private set; }
        public static Type UInt32 { get; private set; }
        public static Type Int64 { get; private set; }
        public static Type UInt64 { get; private set; }
        public static Type IntPtr { get; private set; }
        public static Type UIntPtr { get; private set; }
        public static Type Char { get; private set; }
        public static Type Single { get; private set; }
        public static Type Double { get; private set; }
        public static Type String { get; private set; }
        public static Type IUnknown { get; private set; }
        public static Type IObject { get; private set; }
        public static Type Object { get; private set; }
        public static Object Attribute { get; private set; }

        public static IEnumerable<Type> AllBasicTypes
        {
            get
            {
                yield return Void;
                yield return Boolean;
                yield return Byte;
                yield return SByte;
                yield return Int16;
                yield return UInt16;
                yield return Int32;
                yield return UInt32;
                yield return Int64;
                yield return UInt64;
                yield return IntPtr;
                yield return UIntPtr;
                yield return Char;
                yield return Single;
                yield return Double;
                yield return String;
                yield return IUnknown;
                yield return IObject;
                yield return Object;
                yield return Attribute;
            }
        }
    }
}
