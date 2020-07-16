/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;
using System.Runtime.CompilerServices;
using GluonTest;

namespace ABI.GluonTest
{
    internal struct ComplexStruct
    {
        public IntPtr Name;
        public global::GluonTest.BlittableStruct Sub;
        public IntPtr Obj;
        public DelegateBlob Del;

        public static ComplexStruct ToABI(global::GluonTest.ComplexStruct x)
        {
            return new ComplexStruct
            {
                Name = MConv_.ToABI_string(x.Name),
                Sub = x.Sub,
                Obj = MConv_.ToABI_Object(x.Obj == null ? IntPtr.Zero : ((global::GluonTest.DummyClass)x.Obj).IPtr),
                Del = ABI.GluonTest.D_827F05B3.Unwrap(x.Del)
            };
        }

        public static global::GluonTest.ComplexStruct FromABI(ComplexStruct x)
        {
            return new global::GluonTest.ComplexStruct
            {
                Name = MConv_.FromABI_string(x.Name),
                Sub = x.Sub,
                Obj = GluonObject.Of<global::GluonTest.DummyClass>(x.Obj),
                Del = ABI.GluonTest.D_827F05B3.Wrap(x.Del.Fn, x.Del.Ctx)
            };
        }

        public static ComplexStruct[] ToABI_Array(global::GluonTest.ComplexStruct[] x)
        {
            if (x == null) return null;
            var r = new ComplexStruct[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = ToABI(x[i]);
            return r;
        }

        public static global::GluonTest.ComplexStruct[] FromABI_Array(ComplexStruct[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.ComplexStruct[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = FromABI(x[i]);
            return r;
        }
    }

    internal struct StructMemberTest
    {
        public bool Boolean;
        public double Primitive;
        public IntPtr PrimitivePtr;
        public IntPtr String;
        public global::GluonTest.BlittableStruct BlittableSt;
        public ComplexStruct ComplexSt;
        public IntPtr Object;
        public DelegateBlob NamedDelegate;
        public DelegateBlob GenericDelegate;

        public static StructMemberTest ToABI(global::GluonTest.StructMemberTest x)
        {
            return new StructMemberTest
            {
                Boolean = x.Boolean,
                Primitive = x.Primitive,
                PrimitivePtr = x.PrimitivePtr,
                String = MConv_.ToABI_string(x.String),
                BlittableSt = x.BlittableSt,
                ComplexSt = ComplexStruct.ToABI(x.ComplexSt),
                Object = MConv_.ToABI_Object(x.Object == null ? IntPtr.Zero : ((global::GluonTest.DummyClass)x.Object).IPtr),
                NamedDelegate = ABI.GluonTest.D_BD6C0A4E.Unwrap(x.NamedDelegate),
                GenericDelegate = ABI.GluonTest.D_2945414F.Unwrap(x.GenericDelegate)
            };
        }

        public static global::GluonTest.StructMemberTest FromABI(StructMemberTest x)
        {
            return new global::GluonTest.StructMemberTest
            {
                Boolean = x.Boolean,
                Primitive = x.Primitive,
                PrimitivePtr = x.PrimitivePtr,
                String = MConv_.FromABI_string(x.String),
                BlittableSt = x.BlittableSt,
                ComplexSt = ComplexStruct.FromABI(x.ComplexSt),
                Object = GluonObject.Of<global::GluonTest.DummyClass>(x.Object),
                NamedDelegate = ABI.GluonTest.D_BD6C0A4E.Wrap(x.NamedDelegate.Fn, x.NamedDelegate.Ctx),
                GenericDelegate = ABI.GluonTest.D_2945414F.Wrap(x.GenericDelegate.Fn, x.GenericDelegate.Ctx)
            };
        }

        public static StructMemberTest[] ToABI_Array(global::GluonTest.StructMemberTest[] x)
        {
            if (x == null) return null;
            var r = new StructMemberTest[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = ToABI(x[i]);
            return r;
        }

        public static global::GluonTest.StructMemberTest[] FromABI_Array(StructMemberTest[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.StructMemberTest[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = FromABI(x[i]);
            return r;
        }
    }

    internal struct TestStruct
    {
        public char a;
        public int b;
        public long c;
        public int d;
        public IntPtr e;
        public ArrayBlob f;

        public static TestStruct ToABI(global::GluonTest.TestStruct x)
        {
            return new TestStruct
            {
                a = x.a,
                b = x.b,
                c = x.c,
                d = x.d,
                e = MConv_.ToABI_string(x.e),
                f = MConv_.ToABI_int(x.f)
            };
        }

        public static global::GluonTest.TestStruct FromABI(TestStruct x)
        {
            return new global::GluonTest.TestStruct
            {
                a = x.a,
                b = x.b,
                c = x.c,
                d = x.d,
                e = MConv_.FromABI_string(x.e),
                f = MConv_.FromABI_int(x.f.Ptr, x.f.Count)
            };
        }

        public static TestStruct[] ToABI_Array(global::GluonTest.TestStruct[] x)
        {
            if (x == null) return null;
            var r = new TestStruct[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = ToABI(x[i]);
            return r;
        }

        public static global::GluonTest.TestStruct[] FromABI_Array(TestStruct[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.TestStruct[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = FromABI(x[i]);
            return r;
        }
    }
}
