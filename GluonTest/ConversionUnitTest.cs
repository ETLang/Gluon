using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GluonTest
{
    public struct BlittableStruct
    {
        public int x, y;
        public double u, v;
    }

    public struct ComplexStruct
    {
        public string Name;
        public BlittableStruct Sub;
        public DummyClass Obj;
        public Func<int, int, int> Del;
    }

    public interface DummyClass
    {
        DummyClass Create();

        string Nugget { get; set; }
    }

    public delegate int NamedDelegate(string a, string b);

    public delegate double PrimitivesCB(bool inTest, out char outTest, ref int refTest);
    public delegate string StringsCB(string inTest, out string outTest, ref string refTest);
    public delegate BlittableStruct SimpleStructsCB(BlittableStruct inTest, out BlittableStruct outTest, ref BlittableStruct refTest);
    public delegate ComplexStruct ComplexStructsCB(ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest);
    public delegate DummyClass ObjectsCB(DummyClass inTest, out DummyClass outTest, ref DummyClass refTest);
    public delegate NamedDelegate NamedDelegatesCB(NamedDelegate inTest, out NamedDelegate outTest, ref NamedDelegate refTest);
    public delegate Func<int, int> GenericDelegatesCB(Action<string> inTest, out Action<Func<int, int>> outTest, ref Func<char[], string[]> refTest);

    public delegate double[] PrimitiveArraysCB(bool[] inTest, out char[] outTest, ref int[] refTest);
    public delegate string[] StringArraysCB(string[] inTest, out string[] outTest, ref string[] refTest);
    public delegate BlittableStruct[] SimpleStructArraysCB(BlittableStruct[] inTest, out BlittableStruct[] outTest, ref BlittableStruct[] refTest);
    public delegate ComplexStruct[] ComplexStructArraysCB(ComplexStruct[] inTest, out ComplexStruct[] outTest, ref ComplexStruct[] refTest);
    public delegate DummyClass[] ObjectArraysCB(DummyClass[] inTest, out DummyClass[] outTest, ref DummyClass[] refTest);
    public delegate NamedDelegate[] NamedDelegateArraysCB(NamedDelegate[] inTest, out NamedDelegate[] outTest, ref NamedDelegate[] refTest);
    public delegate Func<int, int>[] GenericDelegateArraysCB(Action<string>[] inTest, out Action<Func<int, int>>[] outTest, ref Func<char[], string[]>[] refTest);

    public struct StructMemberTest
    {
        public bool Boolean;
        public double Primitive;
        public IntPtr PrimitivePtr;
        public string String;
        public BlittableStruct BlittableSt;
        public ComplexStruct ComplexSt;
        public DummyClass Object;
        public NamedDelegate NamedDelegate;
        public Func<double, double> GenericDelegate;
    }

    public interface ConversionUnitTest
    {
        ConversionUnitTest Create();

        double Primitives(bool inTest, out char outTest, ref int refTest);
        string Strings(string inTest, out string outTest, ref string refTest);
        BlittableStruct SimpleStructs(BlittableStruct inTest, out BlittableStruct outTest, ref BlittableStruct refTest);
        ComplexStruct ComplexStructs(ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest);
        DummyClass Objects(DummyClass inTest, out DummyClass outTest, ref DummyClass refTest);
        NamedDelegate NamedDelegates(NamedDelegate inTest, out NamedDelegate outTest, ref NamedDelegate refTest);
        Func<int, int> GenericDelegates(Action<string> inTest, out Action<Func<int, int>> outTest, ref Func<char[], string> refTest);

        double[] PrimitiveArrays(bool[] inTest, out char[] outTest, ref int[] refTest);
        string[] StringArrays(string[] inTest, out string[] outTest, ref string[] refTest);
        BlittableStruct[] SimpleStructArrays(BlittableStruct[] inTest, out BlittableStruct[] outTest, ref BlittableStruct[] refTest);
        ComplexStruct[] ComplexStructArrays(ComplexStruct[] inTest, out ComplexStruct[] outTest, ref ComplexStruct[] refTest);
        DummyClass[] ObjectArrays(DummyClass[] inTest, out DummyClass[] outTest, ref DummyClass[] refTest);
        NamedDelegate[] NamedDelegateArrays(NamedDelegate[] inTest, out NamedDelegate[] outTest, ref NamedDelegate[] refTest);
        Func<int, int>[] GenericDelegateArrays(Action<string>[] inTest, out Action<Func<int, int>>[] outTest, ref Func<char[], string>[] refTest);

        PrimitivesCB PrimitivesCB { get; set; }
        StringsCB StringsCB { get; set; }
        SimpleStructsCB SimpleStructsCB { get; set; }
        ComplexStructsCB ComplexStructsCB { get; set; }
        ObjectsCB ObjectsCB { get; set; }
        NamedDelegatesCB NamedDelegatesCB { get; set; }
        GenericDelegatesCB GenericDelegatesCB { get; set; }

        PrimitiveArraysCB PrimitiveArraysCB { get; set; }
        StringArraysCB StringArraysCB { get; set; }
        SimpleStructArraysCB SimpleStructArraysCB { get; set; }
        ComplexStructArraysCB ComplexStructArraysCB { get; set; }
        ObjectArraysCB ObjectArraysCB { get; set; }
        NamedDelegateArraysCB NamedDelegateArraysCB { get; set; }
        GenericDelegateArraysCB GenericDelegateArraysCB { get; set; }

        StructMemberTest StructMembers { get; set; }

        void ExCheckNullReference();
        void ExCheckArgumentNull();
        void ExCheckArgument();
        void ExCheckInvalidOperation();
        void ExCheckAccessDenied();
        void ExCheckGeneric();
        void ExCheckGenericStd();
        void ExCheckNotImplemented();
    }
}
