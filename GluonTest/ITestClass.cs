using Gluon;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GluonTest
{
    // Supported constructs: 
    // Constructors
    // Methods
    // Properties
    // Read-Only Properties
    // Events
    // output parameters
    // ref parameters

    // Supported data types:
    // primitives
    // strings
    // blittable structs
    // Gluon interfaces/classes
    // IUnknown derivatives
    // arrays of any of these

    // Targets:
    // standard C#/.net
    // Unity would be cool (mono 2.x)
    // C++/Sharpish

    // Output:
    // .net library wrapping c++ library
    // C++ headers defining classes and interfaces
    // C++ skeleton source files

    // Need to be careful to segregate generated C++ from human C++

    public interface ITestClass
    {
        AddSomeShit Adder { get; set; }

        void Methody();
        int RetMethod();
        void OutMethod(out int x);
        int Property { get; set; }
        int ReadOnlyProperty { get; }
        TestStruct[] HardProperty { get; set; }
        Func<char,int,string>[] HarderProperty { get; set; }
        event Action<int> BigEvent;
        Func<string,char> DumbDelegate { get; set; }
        void RefMethod(ref string thing);
        void Ref2(ref ITestClass thing);
        void Ref3(TestStruct thing);
        int[] ComplexMethod(ref string a, IUnknown _dumb, IntPtr p, out char[] fart);
    }

    public enum Foo
    {
        Doo,
        Boo,
        Blu = 5,
        Noo = 3
    }

    [Native(header: "d3d11.h", staticLib: "d3d11.lib")]
    public interface ID3DBlob { }

    public struct TestStruct
    {
        public char a;
        public int b;
        public long c;
        public Int32 d;
        public string e;
        public int[] f;
    }

    public delegate ITestClass AddSomeShit(int a, int b);
}
