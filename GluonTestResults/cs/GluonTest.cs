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
    public static class Native
    {
        static Native()
        {
            GluonObject.RegisterType<global::GluonTest.DummyClass>(new Guid("68a756e3-dac4-3983-dd16-07353f3812e6"), native => new global::GluonTest.DummyClass(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.ConversionUnitTest>(new Guid("75bb5efc-b491-4dea-8973-735b3c230ed7"), native => new global::GluonTest.ConversionUnitTest(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.ITestClass>(new Guid("68a756e3-dac4-3983-dd16-0a1437261fe6"), native => new global::GluonTest.ITestClass(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SignalBuffer>(new Guid("7db242cd-a8a1-3983-dd16-1029353b0ac9"), native => new global::GluonTest.SignalBuffer(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.Waveform>(new Guid("1bd45afd-dac4-3983-dd16-142124300dca"), native => new global::GluonTest.Waveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SinusoidalWaveform>(new Guid("77b553e6-bb93-5cf5-bb79-62443c2018ca"), native => new global::GluonTest.SinusoidalWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SquareWaveform>(new Guid("7ea256d8-b5a2-54f1-dd16-1031273419c0"), native => new global::GluonTest.SquareWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.TriangleWaveform>(new Guid("7a8352e3-bfb2-56e5-af7b-17323b3405c2"), native => new global::GluonTest.TriangleWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SawtoothRightWaveform>(new Guid("72865ffb-b2a3-6ef7-bc60-75474a5369ca"), native => new global::GluonTest.SawtoothRightWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SawtoothLeftWaveform>(new Guid("7e985ffb-aea2-58d4-ab73-764e574c04ca"), native => new global::GluonTest.SawtoothLeftWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.GTone>(new Guid("1bd4378f-dac4-3983-dd16-04143d3b0ea5"), native => new global::GluonTest.GTone(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.GWhiteNoise>(new Guid("68bd58c1-daa1-3983-dd16-04173a3c1fc0"), native => new global::GluonTest.GWhiteNoise(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.NoiseEngine>(new Guid("75bd50e1-daa1-3983-dd16-0d2f3b260ee0"), native => new global::GluonTest.NoiseEngine(new AbiPtr(native)));
        }

        public const string DllPath = "GluonTestResultsCpp.dll";

        [DllImport(DllPath, EntryPoint = "$_GetGluonExceptionDetails")]
        private static extern int GetGluonExceptionDetails(out int outHR, out ExceptionType outType, out IntPtr outText);

        internal static void RegisterTypes() { }

        public static void Throw(int hr)
        {
            if (hr == (int)HResult.S_OK) return;

            int checkhr;
            ExceptionType type;
            IntPtr msgPtr;
            string msg;
            var chk = GetGluonExceptionDetails(out checkhr, out type, out msgPtr);
            if (chk != 0 || hr != checkhr) throw new GluonExceptionAssertionFail();
            msg = Marshal.PtrToStringAnsi(msgPtr);
            throw Translate.Exception(type, msg);
        }
    }

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
                Del = ABI.GluonTest.D_6FD213DA.Unwrap(x.Del)
            };
        }

        public static global::GluonTest.ComplexStruct FromABI(ComplexStruct x)
        {
            return new global::GluonTest.ComplexStruct
            {
                Name = MConv_.FromABI_string(x.Name),
                Sub = x.Sub,
                Obj = GluonObject.Of<global::GluonTest.DummyClass>(x.Obj),
                Del = ABI.GluonTest.D_6FD213DA.Wrap(x.Del.Fn, x.Del.Ctx)
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
                NamedDelegate = ABI.GluonTest.D_F8ED26DD.Unwrap(x.NamedDelegate),
                GenericDelegate = ABI.GluonTest.D_F757A1F5.Unwrap(x.GenericDelegate)
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
                NamedDelegate = ABI.GluonTest.D_F8ED26DD.Wrap(x.NamedDelegate.Fn, x.NamedDelegate.Ctx),
                GenericDelegate = ABI.GluonTest.D_F757A1F5.Wrap(x.GenericDelegate.Fn, x.GenericDelegate.Ctx)
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

    public class D_6FD213DA : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, int arg1, int arg2, out int ___ret);

        private static HResult Fn(IntPtr __i_, int arg1, int arg2, out int ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Func<int,int,int>;

            try
            {
                ___ret = del(arg1, arg2);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_6FD213DA(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_6FD213DA.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int,int>;
            else
                return new D_6FD213DA(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Func<int,int,int> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Func<int,int,int>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Func<int,int,int>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Func<int,int,int>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private int Call(int arg1, int arg2)
        {
            int ___ret;
            Native.Throw((int)_abi(_ctx, arg1, arg2, out ___ret));
            return ___ret;
        }
    }

    public class D_F8ED26DD : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string a, [MarshalAs(UnmanagedType.LPStr)] string b, out int ___ret);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string a, [MarshalAs(UnmanagedType.LPStr)] string b, out int ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.NamedDelegate;

            try
            {
                ___ret = del(a, b);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_F8ED26DD(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegate Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F8ED26DD.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegate;
            else
                return new D_F8ED26DD(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.NamedDelegate x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.NamedDelegate[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.NamedDelegate[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.NamedDelegate[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private int Call(string a, string b)
        {
            int ___ret;
            Native.Throw((int)_abi(_ctx, a, b, out ___ret));
            return ___ret;
        }
    }

    public class D_1B83CCC8 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool inTest, out char outTest, ref int refTest, out double ___ret);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool inTest, out char outTest, ref int refTest, out double ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.PrimitivesCB;

            try
            {
                ___ret = del(inTest, out outTest, ref refTest);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(char);
                ___ret = default(double);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_1B83CCC8(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitivesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1B83CCC8.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitivesCB;
            else
                return new D_1B83CCC8(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.PrimitivesCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.PrimitivesCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.PrimitivesCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.PrimitivesCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private double Call(bool inTest, out char outTest, ref int refTest)
        {
            double ___ret;
            Native.Throw((int)_abi(_ctx, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }
    }

    public class D_E24BCA46 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string inTest, [MarshalAs(UnmanagedType.LPStr)] out string outTest, [MarshalAs(UnmanagedType.LPStr)] ref string refTest, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string inTest, [MarshalAs(UnmanagedType.LPStr)] out string outTest, [MarshalAs(UnmanagedType.LPStr)] ref string refTest, [MarshalAs(UnmanagedType.LPStr)] out string ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.StringsCB;

            try
            {
                ___ret = del(inTest, out outTest, ref refTest);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(string);
                ___ret = default(string);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_E24BCA46(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_E24BCA46.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringsCB;
            else
                return new D_E24BCA46(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.StringsCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.StringsCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.StringsCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.StringsCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private string Call(string inTest, out string outTest, ref string refTest)
        {
            string ___ret;
            Native.Throw((int)_abi(_ctx, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }
    }

    public class D_CA433404 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, global::GluonTest.BlittableStruct inTest, out global::GluonTest.BlittableStruct outTest, ref global::GluonTest.BlittableStruct refTest, out global::GluonTest.BlittableStruct ___ret);

        private static HResult Fn(IntPtr __i_, global::GluonTest.BlittableStruct inTest, out global::GluonTest.BlittableStruct outTest, ref global::GluonTest.BlittableStruct refTest, out global::GluonTest.BlittableStruct ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.SimpleStructsCB;

            try
            {
                ___ret = del(inTest, out outTest, ref refTest);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(global::GluonTest.BlittableStruct);
                ___ret = default(global::GluonTest.BlittableStruct);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_CA433404(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_CA433404.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructsCB;
            else
                return new D_CA433404(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.SimpleStructsCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.SimpleStructsCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.SimpleStructsCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.SimpleStructsCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.BlittableStruct Call(global::GluonTest.BlittableStruct inTest, out global::GluonTest.BlittableStruct outTest, ref global::GluonTest.BlittableStruct refTest)
        {
            global::GluonTest.BlittableStruct ___ret;
            Native.Throw((int)_abi(_ctx, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }
    }

    public class D_10105E24 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest, out ComplexStruct ___ret);

        private static HResult Fn(IntPtr __i_, ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest, out ComplexStruct ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.ComplexStructsCB;

            try
            {
                global::GluonTest.ComplexStruct outTest_wrap;
                var refTest_wrap = ComplexStruct.FromABI(refTest);
                var ___ret_wrap = del(ComplexStruct.FromABI(inTest), out outTest_wrap, ref refTest_wrap);
                outTest = ComplexStruct.ToABI(outTest_wrap);
                refTest = ComplexStruct.ToABI(refTest_wrap);
                ___ret = ComplexStruct.ToABI(___ret_wrap);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(ComplexStruct);
                ___ret = default(ComplexStruct);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_10105E24(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_10105E24.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructsCB;
            else
                return new D_10105E24(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.ComplexStructsCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.ComplexStructsCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.ComplexStructsCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.ComplexStructsCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.ComplexStruct Call(global::GluonTest.ComplexStruct inTest, out global::GluonTest.ComplexStruct outTest, ref global::GluonTest.ComplexStruct refTest)
        {
            ComplexStruct outTest_abi;
            var refTest_abi = ComplexStruct.ToABI(refTest);
            ComplexStruct ___ret_abi;
            Native.Throw((int)_abi(_ctx, ComplexStruct.ToABI(inTest), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = ComplexStruct.FromABI(outTest_abi);
            refTest = ComplexStruct.FromABI(refTest_abi);
            return ComplexStruct.FromABI(___ret_abi);
        }
    }

    public class D_95E0837C : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, IntPtr inTest, out IntPtr outTest, ref IntPtr refTest, out IntPtr ___ret);

        private static HResult Fn(IntPtr __i_, IntPtr inTest, out IntPtr outTest, ref IntPtr refTest, out IntPtr ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.ObjectsCB;

            try
            {
                global::GluonTest.DummyClass outTest_wrap;
                var refTest_wrap = GluonObject.Of<global::GluonTest.DummyClass>(refTest);
                var ___ret_wrap = del(GluonObject.Of<global::GluonTest.DummyClass>(inTest), out outTest_wrap, ref refTest_wrap);
                outTest = (outTest_wrap == null ? IntPtr.Zero : ((global::GluonTest.DummyClass)outTest_wrap).IPtr);
                var refTest_old = refTest; refTest = MConv_.ToABI_Object(refTest_wrap == null ? IntPtr.Zero : ((global::GluonTest.DummyClass)refTest_wrap).IPtr); if(refTest_old != IntPtr.Zero) Marshal.Release(refTest_old);
                ___ret = (___ret_wrap == null ? IntPtr.Zero : ((global::GluonTest.DummyClass)___ret_wrap).IPtr);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                ___ret = default(IntPtr);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_95E0837C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_95E0837C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectsCB;
            else
                return new D_95E0837C(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.ObjectsCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.ObjectsCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.ObjectsCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.ObjectsCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.DummyClass Call(global::GluonTest.DummyClass inTest, out global::GluonTest.DummyClass outTest, ref global::GluonTest.DummyClass refTest)
        {
            IntPtr outTest_abi;
            var refTest_abi = MConv_.ToABI_Object(refTest == null ? IntPtr.Zero : ((global::GluonTest.DummyClass)refTest).IPtr);
            IntPtr ___ret_abi;
            Native.Throw((int)_abi(_ctx, (inTest == null ? IntPtr.Zero : ((global::GluonTest.DummyClass)inTest).IPtr), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = GluonObject.Of<global::GluonTest.DummyClass>(outTest_abi);
            refTest = MConv_.FromABI_Object<global::GluonTest.DummyClass>(refTest_abi);
            return GluonObject.Of<global::GluonTest.DummyClass>(___ret_abi);
        }
    }

    public class D_F2E7AE0F : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);

        private static HResult Fn(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.NamedDelegatesCB;

            try
            {
                var inTest_wrap = D_F8ED26DD.Wrap(inTest, inTest_context);
                global::GluonTest.NamedDelegate outTest_wrap;
                var refTest_wrap = D_F8ED26DD.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_F8ED26DD.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_F8ED26DD.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_F8ED26DD.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_context = default(IntPtr);
                ___ret = default(IntPtr);
                ___ret_context = default(IntPtr);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_F2E7AE0F(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F2E7AE0F.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegatesCB;
            else
                return new D_F2E7AE0F(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.NamedDelegatesCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.NamedDelegatesCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.NamedDelegatesCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.NamedDelegatesCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.NamedDelegate Call(global::GluonTest.NamedDelegate inTest, out global::GluonTest.NamedDelegate outTest, ref global::GluonTest.NamedDelegate refTest)
        {
            var inTest_abi = D_F8ED26DD.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_F8ED26DD.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_F8ED26DD.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_F8ED26DD.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_F8ED26DD.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }
    }

    public class D_D744D575 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);

        private static HResult Fn(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.GenericDelegatesCB;

            try
            {
                var inTest_wrap = D_5C0C3D52.Wrap(inTest, inTest_context);
                Action<Func<int,int>> outTest_wrap;
                var refTest_wrap = D_F757A1F6.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_5C0C3D53.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_F757A1F6.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_F757A1F7.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_context = default(IntPtr);
                ___ret = default(IntPtr);
                ___ret_context = default(IntPtr);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_D744D575(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_D744D575.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegatesCB;
            else
                return new D_D744D575(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.GenericDelegatesCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.GenericDelegatesCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.GenericDelegatesCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.GenericDelegatesCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private Func<int,int> Call(Action<string> inTest, out Action<Func<int,int>> outTest, ref Func<char[],string[]> refTest)
        {
            var inTest_abi = D_5C0C3D52.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_F757A1F6.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_5C0C3D53.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_F757A1F6.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_F757A1F7.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }
    }

    public class D_F757A1F7 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, int arg, out int ___ret);

        private static HResult Fn(IntPtr __i_, int arg, out int ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Func<int,int>;

            try
            {
                ___ret = del(arg);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_F757A1F7(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F7.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int>;
            else
                return new D_F757A1F7(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Func<int,int> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Func<int,int>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Func<int,int>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Func<int,int>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private int Call(int arg)
        {
            int ___ret;
            Native.Throw((int)_abi(_ctx, arg, out ___ret));
            return ___ret;
        }
    }

    public class D_5C0C3D52 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string obj);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string obj)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Action<string>;

            try
            {
                del(obj);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_5C0C3D52(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5C0C3D52.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<string>;
            else
                return new D_5C0C3D52(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Action<string> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Action<string>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Action<string>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Action<string>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private void Call(string obj)
        {
            Native.Throw((int)_abi(_ctx, obj));
        }
    }

    public class D_5C0C3D53 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, IntPtr obj, IntPtr obj_context);

        private static HResult Fn(IntPtr __i_, IntPtr obj, IntPtr obj_context)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Action<Func<int,int>>;

            try
            {
                var obj_wrap = D_F757A1F7.Wrap(obj, obj_context);
                del(obj_wrap);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_5C0C3D53(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<Func<int,int>> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5C0C3D53.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<Func<int,int>>;
            else
                return new D_5C0C3D53(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Action<Func<int,int>> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Action<Func<int,int>>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Action<Func<int,int>>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Action<Func<int,int>>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private void Call(Func<int,int> obj)
        {
            var obj_abi = D_F757A1F7.Unwrap(obj);
            Native.Throw((int)_abi(_ctx, obj_abi.Fn, obj_abi.Ctx));
        }
    }

    public class D_F757A1F6 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] arg, int arg_count, out IntPtr ___ret, out int ___ret_count);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] arg, int arg_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Func<char[],string[]>;

            try
            {
                var ___ret_wrap = del(arg);
                var ___ret_abi = MConv_.ToABI_string(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(IntPtr);
                ___ret_count = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_F757A1F6(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string[]> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F6.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string[]>;
            else
                return new D_F757A1F6(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Func<char[],string[]> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Func<char[],string[]>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Func<char[],string[]>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Func<char[],string[]>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private string[] Call(char[] arg)
        {
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, arg, arg.Length, out ___ret_abi.Ptr, out ___ret_abi.Count));
            return MConv_.FromABI_string(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_C30682FF : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 2)] bool[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 2)] bool[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.PrimitiveArraysCB;

            try
            {
                int[] refTest_wrap = MConv_.FromABI_int(refTest, refTest_count);
                var ___ret_wrap = del(inTest, out char[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv_.ToABI_char(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv_.ToABI_int(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv_.ToABI_double(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_count = default(int);
                ___ret = default(IntPtr);
                ___ret_count = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_C30682FF(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitiveArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_C30682FF.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitiveArraysCB;
            else
                return new D_C30682FF(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.PrimitiveArraysCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.PrimitiveArraysCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.PrimitiveArraysCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.PrimitiveArraysCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private double[] Call(bool[] inTest, out char[] outTest, ref int[] refTest)
        {
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_int(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_char(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_int(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_double(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_B2F37843 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.StringArraysCB;

            try
            {
                string[] refTest_wrap = MConv_.FromABI_string(refTest, refTest_count);
                var ___ret_wrap = del(inTest, out string[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv_.ToABI_string(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv_.ToABI_string(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv_.ToABI_string(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_count = default(int);
                ___ret = default(IntPtr);
                ___ret_count = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_B2F37843(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_B2F37843.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringArraysCB;
            else
                return new D_B2F37843(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.StringArraysCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.StringArraysCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.StringArraysCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.StringArraysCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private string[] Call(string[] inTest, out string[] outTest, ref string[] refTest)
        {
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_string(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_string(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_string(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_string(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_B28180A7 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] global::GluonTest.BlittableStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] global::GluonTest.BlittableStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.SimpleStructArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_7480843E(refTest, refTest_count);
                var ___ret_wrap = del(inTest, out global::GluonTest.BlittableStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_7480843E(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_7480843E(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_7480843E(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_count = default(int);
                ___ret = default(IntPtr);
                ___ret_count = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_B28180A7(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_B28180A7.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructArraysCB;
            else
                return new D_B28180A7(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.SimpleStructArraysCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.SimpleStructArraysCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.SimpleStructArraysCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.SimpleStructArraysCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.BlittableStruct[] Call(global::GluonTest.BlittableStruct[] inTest, out global::GluonTest.BlittableStruct[] outTest, ref global::GluonTest.BlittableStruct[] refTest)
        {
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_7480843E(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7480843E(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7480843E(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7480843E(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_EE6D3DFD : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ComplexStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ComplexStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.ComplexStructArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_A11DF27B(refTest, refTest_count);
                var ___ret_wrap = del(ComplexStruct.FromABI_Array(inTest), out global::GluonTest.ComplexStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_A11DF27B(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_A11DF27B(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_A11DF27B(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_count = default(int);
                ___ret = default(IntPtr);
                ___ret_count = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_EE6D3DFD(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_EE6D3DFD.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructArraysCB;
            else
                return new D_EE6D3DFD(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.ComplexStructArraysCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.ComplexStructArraysCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.ComplexStructArraysCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.ComplexStructArraysCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.ComplexStruct[] Call(global::GluonTest.ComplexStruct[] inTest, out global::GluonTest.ComplexStruct[] outTest, ref global::GluonTest.ComplexStruct[] refTest)
        {
            var inTest_abi = ComplexStruct.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_A11DF27B(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_A11DF27B(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_A11DF27B(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_A11DF27B(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_4388047F : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.ObjectArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_7C319F66(refTest, refTest_count);
                var ___ret_wrap = del(GluonObject.ArrayWrap<global::GluonTest.DummyClass>(inTest), out global::GluonTest.DummyClass[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_7C319F66(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_7C319F66(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_7C319F66(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_count = default(int);
                ___ret = default(IntPtr);
                ___ret_count = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_4388047F(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_4388047F.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectArraysCB;
            else
                return new D_4388047F(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.ObjectArraysCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.ObjectArraysCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.ObjectArraysCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.ObjectArraysCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.DummyClass[] Call(global::GluonTest.DummyClass[] inTest, out global::GluonTest.DummyClass[] outTest, ref global::GluonTest.DummyClass[] refTest)
        {
            var inTest_abi = GluonObject.ArrayUnwrap(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_7C319F66(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7C319F66(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7C319F66(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7C319F66(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_CCD79228 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.NamedDelegateArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_F8ED26DD(refTest, refTest_count);
                var ___ret_wrap = del(D_F8ED26DD.FromABI_Array(inTest), out global::GluonTest.NamedDelegate[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_F8ED26DD(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_F8ED26DD(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_F8ED26DD(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_count = default(int);
                ___ret = default(IntPtr);
                ___ret_count = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_CCD79228(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_CCD79228.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegateArraysCB;
            else
                return new D_CCD79228(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.NamedDelegateArraysCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.NamedDelegateArraysCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.NamedDelegateArraysCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.NamedDelegateArraysCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.NamedDelegate[] Call(global::GluonTest.NamedDelegate[] inTest, out global::GluonTest.NamedDelegate[] outTest, ref global::GluonTest.NamedDelegate[] refTest)
        {
            var inTest_abi = D_F8ED26DD.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_F8ED26DD(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_F8ED26DD(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_F8ED26DD(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_F8ED26DD(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_F5BD3F9C : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.GenericDelegateArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_F757A1F6(refTest, refTest_count);
                var ___ret_wrap = del(D_5C0C3D52.FromABI_Array(inTest), out Action<Func<int,int>>[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_5C0C3D53(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_F757A1F6(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_F757A1F7(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                outTest_count = default(int);
                ___ret = default(IntPtr);
                ___ret_count = default(int);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_F5BD3F9C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F5BD3F9C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegateArraysCB;
            else
                return new D_F5BD3F9C(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.GenericDelegateArraysCB x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.GenericDelegateArraysCB[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.GenericDelegateArraysCB[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.GenericDelegateArraysCB[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private Func<int,int>[] Call(Action<string>[] inTest, out Action<Func<int,int>>[] outTest, ref Func<char[],string[]>[] refTest)
        {
            var inTest_abi = D_5C0C3D52.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_F757A1F6(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_5C0C3D53(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_F757A1F6(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_F757A1F7(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_F757A1F5 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, double arg, out double ___ret);

        private static HResult Fn(IntPtr __i_, double arg, out double ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Func<double,double>;

            try
            {
                ___ret = del(arg);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(double);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_F757A1F5(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<double,double> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F5.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<double,double>;
            else
                return new D_F757A1F5(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Func<double,double> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Func<double,double>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Func<double,double>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Func<double,double>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private double Call(double arg)
        {
            double ___ret;
            Native.Throw((int)_abi(_ctx, arg, out ___ret));
            return ___ret;
        }
    }

    public class D_F757A1F8 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] arg, int arg_count, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] arg, int arg_count, [MarshalAs(UnmanagedType.LPStr)] out string ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Func<char[],string>;

            try
            {
                ___ret = del(arg);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(string);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_F757A1F8(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F8.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string>;
            else
                return new D_F757A1F8(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Func<char[],string> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Func<char[],string>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Func<char[],string>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Func<char[],string>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private string Call(char[] arg)
        {
            string ___ret;
            Native.Throw((int)_abi(_ctx, arg, arg.Length, out ___ret));
            return ___ret;
        }
    }

    public class D_FBC9C528 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, int a, int b, out IntPtr ___ret);

        private static HResult Fn(IntPtr __i_, int a, int b, out IntPtr ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.AddSomeShit;

            try
            {
                var ___ret_wrap = del(a, b);
                ___ret = (___ret_wrap == null ? IntPtr.Zero : ((global::GluonTest.ITestClass)___ret_wrap).IPtr);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(IntPtr);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_FBC9C528(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.AddSomeShit Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_FBC9C528.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.AddSomeShit;
            else
                return new D_FBC9C528(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(global::GluonTest.AddSomeShit x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(global::GluonTest.AddSomeShit[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static global::GluonTest.AddSomeShit[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new global::GluonTest.AddSomeShit[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private global::GluonTest.ITestClass Call(int a, int b)
        {
            IntPtr ___ret_abi;
            Native.Throw((int)_abi(_ctx, a, b, out ___ret_abi));
            return GluonObject.Of<global::GluonTest.ITestClass>(___ret_abi);
        }
    }

    public class D_6FD213DB : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, char arg1, int arg2, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        private static HResult Fn(IntPtr __i_, char arg1, int arg2, [MarshalAs(UnmanagedType.LPStr)] out string ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Func<char,int,string>;

            try
            {
                ___ret = del(arg1, arg2);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(string);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_6FD213DB(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char,int,string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_6FD213DB.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char,int,string>;
            else
                return new D_6FD213DB(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Func<char,int,string> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Func<char,int,string>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Func<char,int,string>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Func<char,int,string>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private string Call(char arg1, int arg2)
        {
            string ___ret;
            Native.Throw((int)_abi(_ctx, arg1, arg2, out ___ret));
            return ___ret;
        }
    }

    public class D_F757A1F9 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string arg, out char ___ret);

        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string arg, out char ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Func<string,char>;

            try
            {
                ___ret = del(arg);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(char);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_F757A1F9(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<string,char> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F9.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<string,char>;
            else
                return new D_F757A1F9(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Func<string,char> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Func<string,char>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Func<string,char>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Func<string,char>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private char Call(string arg)
        {
            char ___ret;
            Native.Throw((int)_abi(_ctx, arg, out ___ret));
            return ___ret;
        }
    }

    public class D_5C0C3D54 : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, int obj);

        private static HResult Fn(IntPtr __i_, int obj)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Action<int>;

            try
            {
                del(obj);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_5C0C3D54(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5C0C3D54.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<int>;
            else
                return new D_5C0C3D54(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Action<int> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Action<int>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Action<int>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Action<int>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private void Call(int obj)
        {
            Native.Throw((int)_abi(_ctx, obj));
        }
    }

    internal static partial class MConv
    {
        public static global::GluonTest.BlittableStruct[] FromABI_7480843E(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<global::GluonTest.BlittableStruct>();
            var r = new global::GluonTest.BlittableStruct[count];
            for(int i = 0;i < count;i++)
            {
                r[i] = Marshal.PtrToStructure<global::GluonTest.BlittableStruct>((IntPtr)((long)data + i * sz));
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_7480843E(global::GluonTest.BlittableStruct[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<global::GluonTest.BlittableStruct>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                Marshal.StructureToPtr(arr[i], r.Ptr + sz * i, false);
            }

            return r;
        }

        public static void FreeABI_7480843E(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.ComplexStruct[] FromABI_A11DF27B(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<ComplexStruct>();
            var r = new global::GluonTest.ComplexStruct[count];
            for(int i = 0;i < count;i++)
            {
                r[i] = ComplexStruct.FromABI(Marshal.PtrToStructure<ComplexStruct>((IntPtr)((long)data + i * sz)));
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_A11DF27B(global::GluonTest.ComplexStruct[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<ComplexStruct>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                Marshal.StructureToPtr(ComplexStruct.ToABI(arr[i]), r.Ptr + sz * i, false);
            }

            return r;
        }

        public static void FreeABI_A11DF27B(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.DummyClass[] FromABI_7C319F66(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<IntPtr>();
            var r = new global::GluonTest.DummyClass[count];
            for(int i = 0;i < count;i++)
            {
                r[i] = GluonObject.Of<global::GluonTest.DummyClass>(Marshal.ReadIntPtr((IntPtr)((long)data + i * sz)));
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_7C319F66(global::GluonTest.DummyClass[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<IntPtr>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var item = arr[i];
                Marshal.WriteIntPtr((IntPtr)((long)r.Ptr + sz * i), item == null ? IntPtr.Zero : item.IPtr);
            }

            return r;
        }

        public static void FreeABI_7C319F66(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.NamedDelegate[] FromABI_F8ED26DD(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new global::GluonTest.NamedDelegate[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_F8ED26DD.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_F8ED26DD(global::GluonTest.NamedDelegate[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_F8ED26DD.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_F8ED26DD(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<int,int>[] FromABI_F757A1F7(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<int,int>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_F757A1F7.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_F757A1F7(Func<int,int>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_F757A1F7.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_F757A1F7(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<string>[] FromABI_5C0C3D52(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_5C0C3D52.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5C0C3D52(Action<string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_5C0C3D52.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_5C0C3D52(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<Func<int,int>>[] FromABI_5C0C3D53(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<Func<int,int>>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_5C0C3D53.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5C0C3D53(Action<Func<int,int>>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_5C0C3D53.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_5C0C3D53(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string[]>[] FromABI_F757A1F6(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string[]>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_F757A1F6.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_F757A1F6(Func<char[],string[]>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_F757A1F6.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_F757A1F6(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string>[] FromABI_F757A1F8(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_F757A1F8.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_F757A1F8(Func<char[],string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_F757A1F8.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_F757A1F8(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.TestStruct[] FromABI_5E297C85(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<TestStruct>();
            var r = new global::GluonTest.TestStruct[count];
            for(int i = 0;i < count;i++)
            {
                r[i] = TestStruct.FromABI(Marshal.PtrToStructure<TestStruct>((IntPtr)((long)data + i * sz)));
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5E297C85(global::GluonTest.TestStruct[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<TestStruct>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                Marshal.StructureToPtr(TestStruct.ToABI(arr[i]), r.Ptr + sz * i, false);
            }

            return r;
        }

        public static void FreeABI_5E297C85(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char,int,string>[] FromABI_6FD213DB(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char,int,string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_6FD213DB.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_6FD213DB(Func<char,int,string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_6FD213DB.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_6FD213DB(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }
    }

    [Guid("4f2fe4fd-d08b-3cbb-e6c5-d92d1fe29537")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct DummyClass
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNugget_sig GetNugget;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNugget_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNugget_sig SetNugget;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNugget_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_DummyClass_1(out IntPtr newInstance);
    }

    [Guid("5233ece2-bede-48d2-b2a0-ad431cf98906")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ConversionUnitTest
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Primitives_sig Primitives;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Primitives_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool inTest, out char outTest, ref int refTest, out double ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Strings_sig Strings;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Strings_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string inTest, [MarshalAs(UnmanagedType.LPStr)] out string outTest, [MarshalAs(UnmanagedType.LPStr)] ref string refTest, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SimpleStructs_sig SimpleStructs;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SimpleStructs_sig(IntPtr __i_, global::GluonTest.BlittableStruct inTest, out global::GluonTest.BlittableStruct outTest, ref global::GluonTest.BlittableStruct refTest, out global::GluonTest.BlittableStruct ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexStructs_sig ComplexStructs;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexStructs_sig(IntPtr __i_, ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest, out ComplexStruct ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Objects_sig Objects;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Objects_sig(IntPtr __i_, IntPtr inTest, out IntPtr outTest, ref IntPtr refTest, out IntPtr ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly NamedDelegates_sig NamedDelegates;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int NamedDelegates_sig(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GenericDelegates_sig GenericDelegates;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GenericDelegates_sig(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly PrimitiveArrays_sig PrimitiveArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int PrimitiveArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 2)] bool[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly StringArrays_sig StringArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int StringArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SimpleStructArrays_sig SimpleStructArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SimpleStructArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] global::GluonTest.BlittableStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexStructArrays_sig ComplexStructArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexStructArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ComplexStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ObjectArrays_sig ObjectArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ObjectArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly NamedDelegateArrays_sig NamedDelegateArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int NamedDelegateArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GenericDelegateArrays_sig GenericDelegateArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GenericDelegateArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckNullReference_sig ExCheckNullReference;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckNullReference_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckArgumentNull_sig ExCheckArgumentNull;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckArgumentNull_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckArgument_sig ExCheckArgument;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckArgument_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckInvalidOperation_sig ExCheckInvalidOperation;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckInvalidOperation_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckAccessDenied_sig ExCheckAccessDenied;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckAccessDenied_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckGeneric_sig ExCheckGeneric;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckGeneric_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckGenericStd_sig ExCheckGenericStd;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckGenericStd_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckNotImplemented_sig ExCheckNotImplemented;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckNotImplemented_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPrimitivesCB_sig GetPrimitivesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPrimitivesCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetPrimitivesCB_sig SetPrimitivesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetPrimitivesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStringsCB_sig GetStringsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStringsCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStringsCB_sig SetStringsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStringsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSimpleStructsCB_sig GetSimpleStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSimpleStructsCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSimpleStructsCB_sig SetSimpleStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSimpleStructsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetComplexStructsCB_sig GetComplexStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetComplexStructsCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetComplexStructsCB_sig SetComplexStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetComplexStructsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetObjectsCB_sig GetObjectsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetObjectsCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetObjectsCB_sig SetObjectsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetObjectsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNamedDelegatesCB_sig GetNamedDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNamedDelegatesCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNamedDelegatesCB_sig SetNamedDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNamedDelegatesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetGenericDelegatesCB_sig GetGenericDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetGenericDelegatesCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetGenericDelegatesCB_sig SetGenericDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetGenericDelegatesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPrimitiveArraysCB_sig GetPrimitiveArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPrimitiveArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetPrimitiveArraysCB_sig SetPrimitiveArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetPrimitiveArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStringArraysCB_sig GetStringArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStringArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStringArraysCB_sig SetStringArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStringArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSimpleStructArraysCB_sig GetSimpleStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSimpleStructArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSimpleStructArraysCB_sig SetSimpleStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSimpleStructArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetComplexStructArraysCB_sig GetComplexStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetComplexStructArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetComplexStructArraysCB_sig SetComplexStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetComplexStructArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetObjectArraysCB_sig GetObjectArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetObjectArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetObjectArraysCB_sig SetObjectArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetObjectArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNamedDelegateArraysCB_sig GetNamedDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNamedDelegateArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNamedDelegateArraysCB_sig SetNamedDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNamedDelegateArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetGenericDelegateArraysCB_sig GetGenericDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetGenericDelegateArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetGenericDelegateArraysCB_sig SetGenericDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetGenericDelegateArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStructMembers_sig GetStructMembers;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStructMembers_sig(IntPtr __i_, out StructMemberTest ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStructMembers_sig SetStructMembers;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStructMembers_sig(IntPtr __i_, StructMemberTest value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_ConversionUnitTest_1(out IntPtr newInstance);
    }

    [Guid("4f2fe4fd-d08b-3cbb-e6c5-d40c17fc9837")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ITestClass
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Methody_sig Methody;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Methody_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RetMethod_sig RetMethod;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RetMethod_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly OutMethod_sig OutMethod;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int OutMethod_sig(IntPtr __i_, out int x);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RefMethod_sig RefMethod;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RefMethod_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] ref string thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Ref2_sig Ref2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Ref2_sig(IntPtr __i_, ref IntPtr thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Ref3_sig Ref3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Ref3_sig(IntPtr __i_, TestStruct thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexMethod_sig ComplexMethod;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexMethod_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] ref string a, IntPtr _dumb, IntPtr p, out IntPtr fart, out int fart_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetAdder_sig GetAdder;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetAdder_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetAdder_sig SetAdder;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetAdder_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetProperty_sig GetProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetProperty_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetProperty_sig SetProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetProperty_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetReadOnlyProperty_sig GetReadOnlyProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetReadOnlyProperty_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetHardProperty_sig GetHardProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetHardProperty_sig(IntPtr __i_, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetHardProperty_sig SetHardProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetHardProperty_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TestStruct[] value, int value_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetHarderProperty_sig GetHarderProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetHarderProperty_sig(IntPtr __i_, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetHarderProperty_sig SetHarderProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetHarderProperty_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] value, int value_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetDumbDelegate_sig GetDumbDelegate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetDumbDelegate_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetDumbDelegate_sig SetDumbDelegate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetDumbDelegate_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly AddBigEventHandler_sig AddBigEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int AddBigEventHandler_sig(IntPtr __i_, IntPtr handler, IntPtr handler_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RemoveBigEventHandler_sig RemoveBigEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RemoveBigEventHandler_sig(IntPtr __i_, IntPtr handler, IntPtr handler_context);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_ITestClass_1(out IntPtr newInstance);
    }

    [Guid("3c5ce7fe-d08b-3cbb-e6c5-d41c41cbae18")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ID3DBlob
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_ID3DBlob(out IntPtr newInstance);
    }

    [Guid("3c2eeae5-d08b-3cbb-e6c5-da3d1cea9e15")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct Generator
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Initialize_sig Initialize;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Initialize_sig(IntPtr __i_, int channels, int sampleRate);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Eval_sig Eval;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Eval_sig(IntPtr __i_, double t, ref double outSample);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly EvalBuffer_sig EvalBuffer;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int EvalBuffer_sig(IntPtr __i_, double t, IntPtr inoutBuffer);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannelCount_sig GetChannelCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannelCount_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleRate_sig GetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleRate_sig(IntPtr __i_, out int ___ret);
    }

    [Guid("5a3af0d3-a2ee-3cbb-e6c5-ce3115e18d18")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SignalBuffer
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo_sig CopyTo;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo_1_sig CopyTo_1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo_1_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo_2_sig CopyTo_2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo_2_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] short[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannelCount_sig GetChannelCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannelCount_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleCount_sig GetSampleCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleCount_sig(IntPtr __i_, out int ___ret);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SignalBuffer_1(int samples, int channels, int alignment, out IntPtr newInstance);

        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SignalBuffer_2(int samples, out IntPtr newInstance);
    }

    [Guid("3c5ce8e3-d08b-3cbb-e6c5-ca3904ea8a1b")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct Waveform
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Phase_sig Phase;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Phase_sig(IntPtr __i_, double t, out double ___ret);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_Waveform_1([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] samples, int samples_count, out IntPtr newInstance);
    }

    [Guid("503de1f8-b1dc-59cd-80aa-bc5c1cfa9f1b")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SinusoidalWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SinusoidalWaveform_1(out IntPtr newInstance);
    }

    [Guid("592ae4c6-bfed-51c9-e6c5-ce2907ee9e11")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SquareWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SquareWaveform_1(out IntPtr newInstance);
    }

    [Guid("5d0be0fd-b5fd-53dd-94a8-c92a1bee8213")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TriangleWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_TriangleWaveform_1(out IntPtr newInstance);
    }

    [Guid("550eede5-b8ec-6bcf-87b3-ab5f6a89ee1b")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SawtoothRightWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SawtoothRightWaveform_1(out IntPtr newInstance);
    }

    [Guid("5910ede5-a4ed-5dec-90a0-a8567796831b")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SawtoothLeftWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SawtoothLeftWaveform_1(out IntPtr newInstance);
    }

    [Guid("3c5c8591-d08b-3cbb-e6c5-da0c1de18974")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct GTone
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetFrequency_sig GetFrequency;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetFrequency_sig(IntPtr __i_, out double ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetFrequency_sig SetFrequency;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetFrequency_sig(IntPtr __i_, double value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetWaveform_sig GetWaveform;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetWaveform_sig(IntPtr __i_, out IntPtr ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetWaveform_sig SetWaveform;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetWaveform_sig(IntPtr __i_, IntPtr value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetAmplitude_sig GetAmplitude;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetAmplitude_sig(IntPtr __i_, out double ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetAmplitude_sig SetAmplitude;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetAmplitude_sig(IntPtr __i_, double value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_GTone_1(out IntPtr newInstance);
    }

    [Guid("4f35eadf-d0ee-3cbb-e6c5-da0f1ae69811")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct GWhiteNoise
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_GWhiteNoise_1(out IntPtr newInstance);
    }

    [Guid("5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct NoiseEngine
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Play_sig Play;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Play_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Pause_sig Pause;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Pause_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPlot_sig GetPlot;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPlot_sig(IntPtr __i_, double durationSeconds, global::GluonTest.PlotType type, out IntPtr ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetError_sig GetError;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetError_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetState_sig GetState;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetState_sig(IntPtr __i_, out global::GluonTest.NoiseEngineState ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleRate_sig GetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleRate_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSampleRate_sig SetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSampleRate_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannels_sig GetChannels;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannels_sig(IntPtr __i_, out global::GluonTest.NoiseChannels ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetChannels_sig SetChannels;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetChannels_sig(IntPtr __i_, global::GluonTest.NoiseChannels value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetBlockDuration_sig GetBlockDuration;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetBlockDuration_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetBlockDuration_sig SetBlockDuration;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetBlockDuration_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetDistribution_sig GetDistribution;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetDistribution_sig(IntPtr __i_, out global::GluonTest.NoiseDistribution ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetDistribution_sig SetDistribution;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetDistribution_sig(IntPtr __i_, global::GluonTest.NoiseDistribution value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetIsFilterEnabled_sig GetIsFilterEnabled;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetIsFilterEnabled_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] out bool ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetIsFilterEnabled_sig SetIsFilterEnabled;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetIsFilterEnabled_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_NoiseEngine_1(out IntPtr newInstance);
    }
}

public enum DXGI_FORMAT : int
{
    DXGI_FORMAT_UNKNOWN,
    DXGI_FORMAT_R32G32B32A32_TYPELESS,
    DXGI_FORMAT_R32G32B32A32_FLOAT,
    DXGI_FORMAT_R32G32B32A32_UINT,
    DXGI_FORMAT_R32G32B32A32_SINT,
    DXGI_FORMAT_R32G32B32_TYPELESS,
    DXGI_FORMAT_R32G32B32_FLOAT,
    DXGI_FORMAT_R32G32B32_UINT,
    DXGI_FORMAT_R32G32B32_SINT,
    DXGI_FORMAT_R16G16B16A16_TYPELESS,
    DXGI_FORMAT_R16G16B16A16_FLOAT,
    DXGI_FORMAT_R16G16B16A16_UNORM,
    DXGI_FORMAT_R16G16B16A16_UINT,
    DXGI_FORMAT_R16G16B16A16_SNORM,
    DXGI_FORMAT_R16G16B16A16_SINT,
    DXGI_FORMAT_R32G32_TYPELESS,
    DXGI_FORMAT_R32G32_FLOAT,
    DXGI_FORMAT_R32G32_UINT,
    DXGI_FORMAT_R32G32_SINT,
    DXGI_FORMAT_R32G8X24_TYPELESS,
    DXGI_FORMAT_D32_FLOAT_S8X24_UINT,
    DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS,
    DXGI_FORMAT_X32_TYPELESS_G8X24_UINT,
    DXGI_FORMAT_R10G10B10A2_TYPELESS,
    DXGI_FORMAT_R10G10B10A2_UNORM,
    DXGI_FORMAT_R10G10B10A2_UINT,
    DXGI_FORMAT_R11G11B10_FLOAT,
    DXGI_FORMAT_R8G8B8A8_TYPELESS,
    DXGI_FORMAT_R8G8B8A8_UNORM,
    DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,
    DXGI_FORMAT_R8G8B8A8_UINT,
    DXGI_FORMAT_R8G8B8A8_SNORM,
    DXGI_FORMAT_R8G8B8A8_SINT,
    DXGI_FORMAT_R16G16_TYPELESS,
    DXGI_FORMAT_R16G16_FLOAT,
    DXGI_FORMAT_R16G16_UNORM,
    DXGI_FORMAT_R16G16_UINT,
    DXGI_FORMAT_R16G16_SNORM,
    DXGI_FORMAT_R16G16_SINT,
    DXGI_FORMAT_R32_TYPELESS,
    DXGI_FORMAT_D32_FLOAT,
    DXGI_FORMAT_R32_FLOAT,
    DXGI_FORMAT_R32_UINT,
    DXGI_FORMAT_R32_SINT,
    DXGI_FORMAT_R24G8_TYPELESS,
    DXGI_FORMAT_D24_UNORM_S8_UINT,
    DXGI_FORMAT_R24_UNORM_X8_TYPELESS,
    DXGI_FORMAT_X24_TYPELESS_G8_UINT,
    DXGI_FORMAT_R8G8_TYPELESS,
    DXGI_FORMAT_R8G8_UNORM,
    DXGI_FORMAT_R8G8_UINT,
    DXGI_FORMAT_R8G8_SNORM,
    DXGI_FORMAT_R8G8_SINT,
    DXGI_FORMAT_R16_TYPELESS,
    DXGI_FORMAT_R16_FLOAT,
    DXGI_FORMAT_D16_UNORM,
    DXGI_FORMAT_R16_UNORM,
    DXGI_FORMAT_R16_UINT,
    DXGI_FORMAT_R16_SNORM,
    DXGI_FORMAT_R16_SINT,
    DXGI_FORMAT_R8_TYPELESS,
    DXGI_FORMAT_R8_UNORM,
    DXGI_FORMAT_R8_UINT,
    DXGI_FORMAT_R8_SNORM,
    DXGI_FORMAT_R8_SINT,
    DXGI_FORMAT_A8_UNORM,
    DXGI_FORMAT_R1_UNORM,
    DXGI_FORMAT_R9G9B9E5_SHAREDEXP,
    DXGI_FORMAT_R8G8_B8G8_UNORM,
    DXGI_FORMAT_G8R8_G8B8_UNORM,
    DXGI_FORMAT_BC1_TYPELESS,
    DXGI_FORMAT_BC1_UNORM,
    DXGI_FORMAT_BC1_UNORM_SRGB,
    DXGI_FORMAT_BC2_TYPELESS,
    DXGI_FORMAT_BC2_UNORM,
    DXGI_FORMAT_BC2_UNORM_SRGB,
    DXGI_FORMAT_BC3_TYPELESS,
    DXGI_FORMAT_BC3_UNORM,
    DXGI_FORMAT_BC3_UNORM_SRGB,
    DXGI_FORMAT_BC4_TYPELESS,
    DXGI_FORMAT_BC4_UNORM,
    DXGI_FORMAT_BC4_SNORM,
    DXGI_FORMAT_BC5_TYPELESS,
    DXGI_FORMAT_BC5_UNORM,
    DXGI_FORMAT_BC5_SNORM,
    DXGI_FORMAT_B5G6R5_UNORM,
    DXGI_FORMAT_B5G5R5A1_UNORM,
    DXGI_FORMAT_B8G8R8A8_UNORM,
    DXGI_FORMAT_B8G8R8X8_UNORM,
    DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM,
    DXGI_FORMAT_B8G8R8A8_TYPELESS,
    DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,
    DXGI_FORMAT_B8G8R8X8_TYPELESS,
    DXGI_FORMAT_B8G8R8X8_UNORM_SRGB,
    DXGI_FORMAT_BC6H_TYPELESS,
    DXGI_FORMAT_BC6H_UF16,
    DXGI_FORMAT_BC6H_SF16,
    DXGI_FORMAT_BC7_TYPELESS,
    DXGI_FORMAT_BC7_UNORM,
    DXGI_FORMAT_BC7_UNORM_SRGB,
    DXGI_FORMAT_AYUV,
    DXGI_FORMAT_Y410,
    DXGI_FORMAT_Y416,
    DXGI_FORMAT_NV12,
    DXGI_FORMAT_P010,
    DXGI_FORMAT_P016,
    DXGI_FORMAT_420_OPAQUE,
    DXGI_FORMAT_YUY2,
    DXGI_FORMAT_Y210,
    DXGI_FORMAT_Y216,
    DXGI_FORMAT_NV11,
    DXGI_FORMAT_AI44,
    DXGI_FORMAT_IA44,
    DXGI_FORMAT_P8,
    DXGI_FORMAT_A8P8,
    DXGI_FORMAT_B4G4R4A4_UNORM,
    DXGI_FORMAT_P208 = 130,
    DXGI_FORMAT_V208 = 131,
    DXGI_FORMAT_V408 = 132
}

public enum D3D11_USAGE : int
{
    D3D11_USAGE_DEFAULT,
    D3D11_USAGE_IMMUTABLE,
    D3D11_USAGE_DYNAMIC,
    D3D11_USAGE_STAGING
}

namespace GluonTest
{
    public enum Foo : int
    {
        Doo,
        Boo,
        Noo = 3,
        Blu = 5
    }

    public enum NoiseEngineState : int
    {
        Idle,
        Running,
        Failed
    }

    public enum NoiseChannels : int
    {
        Mono,
        Stereo
    }

    public enum NoiseDistribution : int
    {
        Uniform,
        Gaussian
    }

    public enum PlotType : int
    {
        Signal,
        FFT
    }

    public delegate int NamedDelegate(string a, string b);
    public delegate double PrimitivesCB(bool inTest, out char outTest, ref int refTest);
    public delegate string StringsCB(string inTest, out string outTest, ref string refTest);
    public delegate BlittableStruct SimpleStructsCB(BlittableStruct inTest, out BlittableStruct outTest, ref BlittableStruct refTest);
    public delegate ComplexStruct ComplexStructsCB(ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest);
    public delegate DummyClass ObjectsCB(DummyClass inTest, out DummyClass outTest, ref DummyClass refTest);
    public delegate NamedDelegate NamedDelegatesCB(NamedDelegate inTest, out NamedDelegate outTest, ref NamedDelegate refTest);
    public delegate Func<int,int> GenericDelegatesCB(Action<string> inTest, out Action<Func<int,int>> outTest, ref Func<char[],string[]> refTest);
    public delegate double[] PrimitiveArraysCB(bool[] inTest, out char[] outTest, ref int[] refTest);
    public delegate string[] StringArraysCB(string[] inTest, out string[] outTest, ref string[] refTest);
    public delegate BlittableStruct[] SimpleStructArraysCB(BlittableStruct[] inTest, out BlittableStruct[] outTest, ref BlittableStruct[] refTest);
    public delegate ComplexStruct[] ComplexStructArraysCB(ComplexStruct[] inTest, out ComplexStruct[] outTest, ref ComplexStruct[] refTest);
    public delegate DummyClass[] ObjectArraysCB(DummyClass[] inTest, out DummyClass[] outTest, ref DummyClass[] refTest);
    public delegate NamedDelegate[] NamedDelegateArraysCB(NamedDelegate[] inTest, out NamedDelegate[] outTest, ref NamedDelegate[] refTest);
    public delegate Func<int,int>[] GenericDelegateArraysCB(Action<string>[] inTest, out Action<Func<int,int>>[] outTest, ref Func<char[],string[]>[] refTest);
    public delegate ITestClass AddSomeShit(int a, int b);
}

public struct DXGI_SAMPLE_DESC
{
    public uint Count;
    public uint Quality;

    public DXGI_SAMPLE_DESC(uint _Count, uint _Quality)
    {
        Count = _Count;
        Quality = _Quality;
    }
}

public struct D3D11_TEXTURE2D_DESC
{
    public uint Width;
    public uint Height;
    public uint MipLevels;
    public uint ArraySize;
    public DXGI_FORMAT Format;
    public global::DXGI_SAMPLE_DESC SampleDesc;
    public D3D11_USAGE Usage;
    public uint BindFlags;
    public uint CPUAccessFlags;
    public uint MiscFlags;

    public D3D11_TEXTURE2D_DESC(uint _Width, uint _Height, uint _MipLevels, uint _ArraySize, DXGI_FORMAT _Format, global::DXGI_SAMPLE_DESC _SampleDesc, D3D11_USAGE _Usage, uint _BindFlags, uint _CPUAccessFlags, uint _MiscFlags)
    {
        Width = _Width;
        Height = _Height;
        MipLevels = _MipLevels;
        ArraySize = _ArraySize;
        Format = _Format;
        SampleDesc = _SampleDesc;
        Usage = _Usage;
        BindFlags = _BindFlags;
        CPUAccessFlags = _CPUAccessFlags;
        MiscFlags = _MiscFlags;
    }
}

namespace GluonTest
{
    public struct BlittableStruct
    {
        public int x;
        public int y;
        public double u;
        public double v;

        public BlittableStruct(int _x, int _y, double _u, double _v)
        {
            x = _x;
            y = _y;
            u = _u;
            v = _v;
        }
    }

    public struct ComplexStruct
    {
        public string Name;
        public BlittableStruct Sub;
        public DummyClass Obj;
        public Func<int,int,int> Del;

        public ComplexStruct(string _Name, BlittableStruct _Sub, DummyClass _Obj, Func<int,int,int> _Del)
        {
            Name = _Name;
            Sub = _Sub;
            Obj = _Obj;
            Del = _Del;
        }
    }

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
        public Func<double,double> GenericDelegate;

        public StructMemberTest(bool _Boolean, double _Primitive, IntPtr _PrimitivePtr, string _String, BlittableStruct _BlittableSt, ComplexStruct _ComplexSt, DummyClass _Object, NamedDelegate _NamedDelegate, Func<double,double> _GenericDelegate)
        {
            Boolean = _Boolean;
            Primitive = _Primitive;
            PrimitivePtr = _PrimitivePtr;
            String = _String;
            BlittableSt = _BlittableSt;
            ComplexSt = _ComplexSt;
            Object = _Object;
            NamedDelegate = _NamedDelegate;
            GenericDelegate = _GenericDelegate;
        }
    }

    public struct TestStruct
    {
        public char a;
        public int b;
        public long c;
        public int d;
        public string e;
        public int[] f;

        public TestStruct(char _a, int _b, long _c, int _d, string _e, int[] _f)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
            e = _e;
            f = _f;
        }
    }

    [Guid("68a756e3-dac4-3983-dd16-07353f3812e6")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.DummyClass))]
    public partial class DummyClass : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static DummyClass()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public DummyClass() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public string Nugget
        {
            get {  Check(); string x; Native.Throw(_vt.GetNugget(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetNugget(IPtr, value)); }  
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal DummyClass(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.DummyClass>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_DummyClass_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.DummyClass _vt;
        static Guid _ID = new Guid("4f2fe4fd-d08b-3cbb-e6c5-d92d1fe29537");

        #endregion
    }

    [Guid("75bb5efc-b491-4dea-8973-735b3c230ed7")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.ConversionUnitTest))]
    public partial class ConversionUnitTest : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static ConversionUnitTest()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public ConversionUnitTest() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public PrimitivesCB PrimitivesCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetPrimitivesCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_1B83CCC8.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_1B83CCC8.Unwrap(value); Native.Throw(_vt.SetPrimitivesCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StringsCB StringsCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetStringsCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_E24BCA46.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_E24BCA46.Unwrap(value); Native.Throw(_vt.SetStringsCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public SimpleStructsCB SimpleStructsCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetSimpleStructsCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_CA433404.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_CA433404.Unwrap(value); Native.Throw(_vt.SetSimpleStructsCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ComplexStructsCB ComplexStructsCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetComplexStructsCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_10105E24.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_10105E24.Unwrap(value); Native.Throw(_vt.SetComplexStructsCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ObjectsCB ObjectsCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetObjectsCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_95E0837C.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_95E0837C.Unwrap(value); Native.Throw(_vt.SetObjectsCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public NamedDelegatesCB NamedDelegatesCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetNamedDelegatesCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_F2E7AE0F.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_F2E7AE0F.Unwrap(value); Native.Throw(_vt.SetNamedDelegatesCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public GenericDelegatesCB GenericDelegatesCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetGenericDelegatesCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_D744D575.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_D744D575.Unwrap(value); Native.Throw(_vt.SetGenericDelegatesCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public PrimitiveArraysCB PrimitiveArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetPrimitiveArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_C30682FF.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_C30682FF.Unwrap(value); Native.Throw(_vt.SetPrimitiveArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StringArraysCB StringArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetStringArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_B2F37843.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_B2F37843.Unwrap(value); Native.Throw(_vt.SetStringArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public SimpleStructArraysCB SimpleStructArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetSimpleStructArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_B28180A7.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_B28180A7.Unwrap(value); Native.Throw(_vt.SetSimpleStructArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ComplexStructArraysCB ComplexStructArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetComplexStructArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_EE6D3DFD.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_EE6D3DFD.Unwrap(value); Native.Throw(_vt.SetComplexStructArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ObjectArraysCB ObjectArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetObjectArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_4388047F.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_4388047F.Unwrap(value); Native.Throw(_vt.SetObjectArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public NamedDelegateArraysCB NamedDelegateArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetNamedDelegateArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_CCD79228.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_CCD79228.Unwrap(value); Native.Throw(_vt.SetNamedDelegateArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public GenericDelegateArraysCB GenericDelegateArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetGenericDelegateArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_F5BD3F9C.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_F5BD3F9C.Unwrap(value); Native.Throw(_vt.SetGenericDelegateArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StructMemberTest StructMembers
        {
            get {  Check(); ABI.GluonTest.StructMemberTest x_abi; Native.Throw(_vt.GetStructMembers(IPtr, out x_abi)); return ABI.GluonTest.StructMemberTest.FromABI(x_abi); }   
            set {  Check(); Native.Throw(_vt.SetStructMembers(IPtr, ABI.GluonTest.StructMemberTest.ToABI(value))); }  
        }

        public double Primitives(bool inTest, out char outTest, ref int refTest)
        {
            Check();
            double ___ret;
            Native.Throw(_vt.Primitives(IPtr, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public string Strings(string inTest, out string outTest, ref string refTest)
        {
            Check();
            string ___ret;
            Native.Throw(_vt.Strings(IPtr, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public BlittableStruct SimpleStructs(BlittableStruct inTest, out BlittableStruct outTest, ref BlittableStruct refTest)
        {
            Check();
            BlittableStruct ___ret;
            Native.Throw(_vt.SimpleStructs(IPtr, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public ComplexStruct ComplexStructs(ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest)
        {
            Check();
            ABI.GluonTest.ComplexStruct outTest_abi;
            var refTest_abi = ABI.GluonTest.ComplexStruct.ToABI(refTest);
            ABI.GluonTest.ComplexStruct ___ret_abi;
            Native.Throw(_vt.ComplexStructs(IPtr, ABI.GluonTest.ComplexStruct.ToABI(inTest), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = ABI.GluonTest.ComplexStruct.FromABI(outTest_abi);
            refTest = ABI.GluonTest.ComplexStruct.FromABI(refTest_abi);
            return ABI.GluonTest.ComplexStruct.FromABI(___ret_abi);
        }

        public DummyClass Objects(DummyClass inTest, out DummyClass outTest, ref DummyClass refTest)
        {
            Check();
            IntPtr outTest_abi;
            var refTest_abi = MConv_.ToABI_Object(refTest == null ? IntPtr.Zero : ((DummyClass)refTest).IPtr);
            IntPtr ___ret_abi;
            Native.Throw(_vt.Objects(IPtr, (inTest == null ? IntPtr.Zero : ((DummyClass)inTest).IPtr), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = GluonObject.Of<DummyClass>(outTest_abi);
            refTest = MConv_.FromABI_Object<DummyClass>(refTest_abi);
            return GluonObject.Of<DummyClass>(___ret_abi);
        }

        public NamedDelegate NamedDelegates(NamedDelegate inTest, out NamedDelegate outTest, ref NamedDelegate refTest)
        {
            Check();
            var inTest_abi = D_F8ED26DD.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_F8ED26DD.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw(_vt.NamedDelegates(IPtr, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_F8ED26DD.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_F8ED26DD.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_F8ED26DD.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        public Func<int,int> GenericDelegates(Action<string> inTest, out Action<Func<int,int>> outTest, ref Func<char[],string> refTest)
        {
            Check();
            var inTest_abi = D_5C0C3D52.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_F757A1F8.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw(_vt.GenericDelegates(IPtr, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_5C0C3D53.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_F757A1F8.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_F757A1F7.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        public double[] PrimitiveArrays(bool[] inTest, out char[] outTest, ref int[] refTest)
        {
            Check();
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_int(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.PrimitiveArrays(IPtr, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_char(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_int(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_double(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public string[] StringArrays(string[] inTest, out string[] outTest, ref string[] refTest)
        {
            Check();
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_string(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.StringArrays(IPtr, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_string(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_string(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_string(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public BlittableStruct[] SimpleStructArrays(BlittableStruct[] inTest, out BlittableStruct[] outTest, ref BlittableStruct[] refTest)
        {
            Check();
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_7480843E(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.SimpleStructArrays(IPtr, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7480843E(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7480843E(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7480843E(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public ComplexStruct[] ComplexStructArrays(ComplexStruct[] inTest, out ComplexStruct[] outTest, ref ComplexStruct[] refTest)
        {
            Check();
            var inTest_abi = ABI.GluonTest.ComplexStruct.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_A11DF27B(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ComplexStructArrays(IPtr, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_A11DF27B(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_A11DF27B(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_A11DF27B(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public DummyClass[] ObjectArrays(DummyClass[] inTest, out DummyClass[] outTest, ref DummyClass[] refTest)
        {
            Check();
            var inTest_abi = GluonObject.ArrayUnwrap(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_7C319F66(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ObjectArrays(IPtr, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7C319F66(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7C319F66(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7C319F66(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public NamedDelegate[] NamedDelegateArrays(NamedDelegate[] inTest, out NamedDelegate[] outTest, ref NamedDelegate[] refTest)
        {
            Check();
            var inTest_abi = D_F8ED26DD.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_F8ED26DD(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.NamedDelegateArrays(IPtr, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_F8ED26DD(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_F8ED26DD(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_F8ED26DD(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public Func<int,int>[] GenericDelegateArrays(Action<string>[] inTest, out Action<Func<int,int>>[] outTest, ref Func<char[],string>[] refTest)
        {
            Check();
            var inTest_abi = D_5C0C3D52.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_F757A1F8(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.GenericDelegateArrays(IPtr, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_5C0C3D53(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_F757A1F8(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_F757A1F7(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public void ExCheckNullReference()
        {
            Check();
            Native.Throw(_vt.ExCheckNullReference(IPtr));
        }

        public void ExCheckArgumentNull()
        {
            Check();
            Native.Throw(_vt.ExCheckArgumentNull(IPtr));
        }

        public void ExCheckArgument()
        {
            Check();
            Native.Throw(_vt.ExCheckArgument(IPtr));
        }

        public void ExCheckInvalidOperation()
        {
            Check();
            Native.Throw(_vt.ExCheckInvalidOperation(IPtr));
        }

        public void ExCheckAccessDenied()
        {
            Check();
            Native.Throw(_vt.ExCheckAccessDenied(IPtr));
        }

        public void ExCheckGeneric()
        {
            Check();
            Native.Throw(_vt.ExCheckGeneric(IPtr));
        }

        public void ExCheckGenericStd()
        {
            Check();
            Native.Throw(_vt.ExCheckGenericStd(IPtr));
        }

        public void ExCheckNotImplemented()
        {
            Check();
            Native.Throw(_vt.ExCheckNotImplemented(IPtr));
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal ConversionUnitTest(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ConversionUnitTest>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_ConversionUnitTest_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.ConversionUnitTest _vt;
        static Guid _ID = new Guid("5233ece2-bede-48d2-b2a0-ad431cf98906");

        #endregion
    }

    [Guid("68a756e3-dac4-3983-dd16-0a1437261fe6")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.ITestClass))]
    public partial class ITestClass : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static ITestClass()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public ITestClass() : this(new AbiPtr(Make())) { _BigEvent_abi = D_5C0C3D54.Unwrap(_Call_BigEvent);  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);
            if(_BigEvent != null) _vt.RemoveBigEventHandler(IPtr, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region BigEvent

        public event Action<int> BigEvent
        {
            add
            {
                Check();
                if(_BigEvent == null)
                    _vt.AddBigEventHandler(IPtr, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);

                _BigEvent += value;
            }
            remove
            {
                Check();
                _BigEvent -= value;
                if(_BigEvent == null)
                    _vt.RemoveBigEventHandler(IPtr, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);
            }
        }

        private void _Call_BigEvent(int obj)
        {
            try
            {
                _BigEvent(obj);
            }
            catch(Exception ___ex)
            {
                CallbackEventExceptionHandler?.Invoke(___ex);
            }
        }

        private Action<int> _BigEvent;
        private DelegateBlob _BigEvent_abi;

        #endregion

        public AddSomeShit Adder
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetAdder(IPtr, out x_abi_fn, out x_abi_ctx)); return D_FBC9C528.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_FBC9C528.Unwrap(value); Native.Throw(_vt.SetAdder(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public int Property
        {
            get {  Check(); int x; Native.Throw(_vt.GetProperty(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetProperty(IPtr, value)); }  
        }

        public int ReadOnlyProperty {  get {  Check(); int x; Native.Throw(_vt.GetReadOnlyProperty(IPtr, out x)); return x; }  }  

        public TestStruct[] HardProperty
        {
            get {  Check(); ArrayBlob x_abi; Native.Throw(_vt.GetHardProperty(IPtr, out x_abi.Ptr, out x_abi.Count)); return MConv.FromABI_5E297C85(x_abi.Ptr, x_abi.Count); }   
            set {  Check(); var value_abi = ABI.GluonTest.TestStruct.ToABI_Array(value); Native.Throw(_vt.SetHardProperty(IPtr, value_abi, value_abi.Length)); }  
        }

        public Func<char,int,string>[] HarderProperty
        {
            get {  Check(); ArrayBlob x_abi; Native.Throw(_vt.GetHarderProperty(IPtr, out x_abi.Ptr, out x_abi.Count)); return MConv.FromABI_6FD213DB(x_abi.Ptr, x_abi.Count); }   
            set {  Check(); var value_abi = D_6FD213DB.ToABI_Array(value); Native.Throw(_vt.SetHarderProperty(IPtr, value_abi, value_abi.Length)); }  
        }

        public Func<string,char> DumbDelegate
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetDumbDelegate(IPtr, out x_abi_fn, out x_abi_ctx)); return D_F757A1F9.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_F757A1F9.Unwrap(value); Native.Throw(_vt.SetDumbDelegate(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public void Methody()
        {
            Check();
            Native.Throw(_vt.Methody(IPtr));
        }

        public int RetMethod()
        {
            Check();
            int ___ret;
            Native.Throw(_vt.RetMethod(IPtr, out ___ret));
            return ___ret;
        }

        public void OutMethod(out int x)
        {
            Check();
            Native.Throw(_vt.OutMethod(IPtr, out x));
        }

        public void RefMethod(ref string thing)
        {
            Check();
            Native.Throw(_vt.RefMethod(IPtr, ref thing));
        }

        public void Ref2(ref ITestClass thing)
        {
            Check();
            var thing_abi = MConv_.ToABI_Object(thing == null ? IntPtr.Zero : ((ITestClass)thing).IPtr);
            Native.Throw(_vt.Ref2(IPtr, ref thing_abi));
            thing = MConv_.FromABI_Object<ITestClass>(thing_abi);
        }

        public void Ref3(TestStruct thing)
        {
            Check();
            Native.Throw(_vt.Ref3(IPtr, ABI.GluonTest.TestStruct.ToABI(thing)));
        }

        public int[] ComplexMethod(ref string a, IntPtr _dumb, IntPtr p, out char[] fart)
        {
            Check();
            ArrayBlob fart_abi;
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ComplexMethod(IPtr, ref a, _dumb, p, out fart_abi.Ptr, out fart_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            fart = MConv_.FromABI_char(fart_abi.Ptr, fart_abi.Count);
            return MConv_.FromABI_int(___ret_abi.Ptr, ___ret_abi.Count);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal ITestClass(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ITestClass>(IPtr);
            _BigEvent_abi = D_5C0C3D54.Unwrap(_Call_BigEvent);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_ITestClass_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.ITestClass _vt;
        static Guid _ID = new Guid("4f2fe4fd-d08b-3cbb-e6c5-d40c17fc9837");

        #endregion
    }

    [Guid("1bd455e0-dac4-3983-dd16-0a04611129c9")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.ID3DBlob))]
    public partial class ID3DBlob : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static ID3DBlob()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal ID3DBlob(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ID3DBlob>(IPtr);

            Init();
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.ID3DBlob _vt;
        static Guid _ID = new Guid("3c5ce7fe-d08b-3cbb-e6c5-d41c41cbae18");

        #endregion
    }

    [Guid("1ba658fb-dac4-3983-dd16-04253c3019c4")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.Generator))]
    public abstract partial class Generator : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static Generator()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public int ChannelCount {  get {  Check(); int x; Native.Throw(_vt.GetChannelCount(IPtr, out x)); return x; }  }  

        public int SampleRate {  get {  Check(); int x; Native.Throw(_vt.GetSampleRate(IPtr, out x)); return x; }  }  

        public void Initialize(int channels, int sampleRate)
        {
            Check();
            Native.Throw(_vt.Initialize(IPtr, channels, sampleRate));
        }

        public void Eval(double t, ref double outSample)
        {
            Check();
            Native.Throw(_vt.Eval(IPtr, t, ref outSample));
        }

        public void EvalBuffer(double t, SignalBuffer inoutBuffer)
        {
            Check();
            Native.Throw(_vt.EvalBuffer(IPtr, t, (inoutBuffer == null ? IntPtr.Zero : ((SignalBuffer)inoutBuffer).IPtr)));
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal Generator(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.Generator>(IPtr);

            Init();
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.Generator _vt;
        static Guid _ID = new Guid("3c2eeae5-d08b-3cbb-e6c5-da3d1cea9e15");

        #endregion
    }

    [Guid("7db242cd-a8a1-3983-dd16-1029353b0ac9")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SignalBuffer))]
    public partial class SignalBuffer : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static SignalBuffer()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SignalBuffer(int samples, int channels, int alignment)
            : this(new AbiPtr(Make(samples, channels, alignment)))
        {

            Init();
        }

        public SignalBuffer(int samples)
            : this(new AbiPtr(Make(samples)))
        {

            Init();
        }

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public int ChannelCount {  get {  Check(); int x; Native.Throw(_vt.GetChannelCount(IPtr, out x)); return x; }  }  

        public int SampleCount {  get {  Check(); int x; Native.Throw(_vt.GetSampleCount(IPtr, out x)); return x; }  }  

        public int CopyTo(double[] arr)
        {
            Check();
            int ___ret;
            Native.Throw(_vt.CopyTo(IPtr, arr, arr.Length, out ___ret));
            return ___ret;
        }

        public int CopyTo(float[] arr)
        {
            Check();
            int ___ret;
            Native.Throw(_vt.CopyTo_1(IPtr, arr, arr.Length, out ___ret));
            return ___ret;
        }

        public int CopyTo(short[] arr)
        {
            Check();
            int ___ret;
            Native.Throw(_vt.CopyTo_2(IPtr, arr, arr.Length, out ___ret));
            return ___ret;
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal SignalBuffer(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SignalBuffer>(IPtr);

            Init();
        }

        private static IntPtr Make(int samples, int channels, int alignment)
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SignalBuffer_1(samples, channels, alignment, out instance_abi));
            return instance_abi;
        }

        private static IntPtr Make(int samples)
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SignalBuffer_2(samples, out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.SignalBuffer _vt;
        static Guid _ID = new Guid("5a3af0d3-a2ee-3cbb-e6c5-ce3115e18d18");

        #endregion
    }

    [Guid("1bd45afd-dac4-3983-dd16-142124300dca")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.Waveform))]
    public partial class Waveform : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static Waveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public Waveform(double[] samples)
            : this(new AbiPtr(Make(samples)))
        {

            Init();
        }

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public double Phase(double t)
        {
            Check();
            double ___ret;
            Native.Throw(_vt.Phase(IPtr, t, out ___ret));
            return ___ret;
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal Waveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.Waveform>(IPtr);

            Init();
        }

        private static IntPtr Make(double[] samples)
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_Waveform_1(samples, samples.Length, out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.Waveform _vt;
        static Guid _ID = new Guid("3c5ce8e3-d08b-3cbb-e6c5-ca3904ea8a1b");

        #endregion
    }

    [Guid("77b553e6-bb93-5cf5-bb79-62443c2018ca")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SinusoidalWaveform))]
    public partial class SinusoidalWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static SinusoidalWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SinusoidalWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal SinusoidalWaveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SinusoidalWaveform>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SinusoidalWaveform_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.SinusoidalWaveform _vt;
        static Guid _ID = new Guid("503de1f8-b1dc-59cd-80aa-bc5c1cfa9f1b");

        #endregion
    }

    [Guid("7ea256d8-b5a2-54f1-dd16-1031273419c0")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SquareWaveform))]
    public partial class SquareWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static SquareWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SquareWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal SquareWaveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SquareWaveform>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SquareWaveform_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.SquareWaveform _vt;
        static Guid _ID = new Guid("592ae4c6-bfed-51c9-e6c5-ce2907ee9e11");

        #endregion
    }

    [Guid("7a8352e3-bfb2-56e5-af7b-17323b3405c2")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.TriangleWaveform))]
    public partial class TriangleWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static TriangleWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public TriangleWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal TriangleWaveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.TriangleWaveform>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_TriangleWaveform_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.TriangleWaveform _vt;
        static Guid _ID = new Guid("5d0be0fd-b5fd-53dd-94a8-c92a1bee8213");

        #endregion
    }

    [Guid("72865ffb-b2a3-6ef7-bc60-75474a5369ca")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SawtoothRightWaveform))]
    public partial class SawtoothRightWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static SawtoothRightWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SawtoothRightWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal SawtoothRightWaveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SawtoothRightWaveform>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SawtoothRightWaveform_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.SawtoothRightWaveform _vt;
        static Guid _ID = new Guid("550eede5-b8ec-6bcf-87b3-ab5f6a89ee1b");

        #endregion
    }

    [Guid("7e985ffb-aea2-58d4-ab73-764e574c04ca")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SawtoothLeftWaveform))]
    public partial class SawtoothLeftWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static SawtoothLeftWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SawtoothLeftWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal SawtoothLeftWaveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SawtoothLeftWaveform>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SawtoothLeftWaveform_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.SawtoothLeftWaveform _vt;
        static Guid _ID = new Guid("5910ede5-a4ed-5dec-90a0-a8567796831b");

        #endregion
    }

    [Guid("1bd4378f-dac4-3983-dd16-04143d3b0ea5")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.GTone))]
    public partial class GTone : Generator
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static GTone()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public GTone() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public double Frequency
        {
            get {  Check(); double x; Native.Throw(_vt.GetFrequency(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetFrequency(IPtr, value)); }  
        }

        public Waveform Waveform
        {
            get {  Check(); IntPtr x_abi; Native.Throw(_vt.GetWaveform(IPtr, out x_abi)); return GluonObject.Of<Waveform>(x_abi); }   
            set {  Check(); Native.Throw(_vt.SetWaveform(IPtr, (value == null ? IntPtr.Zero : ((Waveform)value).IPtr))); }  
        }

        public double Amplitude
        {
            get {  Check(); double x; Native.Throw(_vt.GetAmplitude(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetAmplitude(IPtr, value)); }  
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal GTone(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.GTone>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_GTone_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.GTone _vt;
        static Guid _ID = new Guid("3c5c8591-d08b-3cbb-e6c5-da0c1de18974");

        #endregion
    }

    [Guid("68bd58c1-daa1-3983-dd16-04173a3c1fc0")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.GWhiteNoise))]
    public partial class GWhiteNoise : Generator
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static GWhiteNoise()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public GWhiteNoise() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal GWhiteNoise(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.GWhiteNoise>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_GWhiteNoise_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.GWhiteNoise _vt;
        static Guid _ID = new Guid("4f35eadf-d0ee-3cbb-e6c5-da0f1ae69811");

        #endregion
    }

    [Guid("75bd50e1-daa1-3983-dd16-0d2f3b260ee0")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.NoiseEngine))]
    public partial class NoiseEngine : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static NoiseEngine()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public NoiseEngine() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public string Error {  get {  Check(); string x; Native.Throw(_vt.GetError(IPtr, out x)); return x; }  }  

        public NoiseEngineState State {  get {  Check(); NoiseEngineState x; Native.Throw(_vt.GetState(IPtr, out x)); return x; }  }  

        public int SampleRate
        {
            get {  Check(); int x; Native.Throw(_vt.GetSampleRate(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetSampleRate(IPtr, value)); }  
        }

        public NoiseChannels Channels
        {
            get {  Check(); NoiseChannels x; Native.Throw(_vt.GetChannels(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetChannels(IPtr, value)); }  
        }

        public int BlockDuration
        {
            get {  Check(); int x; Native.Throw(_vt.GetBlockDuration(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetBlockDuration(IPtr, value)); }  
        }

        public NoiseDistribution Distribution
        {
            get {  Check(); NoiseDistribution x; Native.Throw(_vt.GetDistribution(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetDistribution(IPtr, value)); }  
        }

        public bool IsFilterEnabled
        {
            get {  Check(); bool x; Native.Throw(_vt.GetIsFilterEnabled(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetIsFilterEnabled(IPtr, value)); }  
        }

        public void Play()
        {
            Check();
            Native.Throw(_vt.Play(IPtr));
        }

        public void Pause()
        {
            Check();
            Native.Throw(_vt.Pause(IPtr));
        }

        public SignalBuffer GetPlot(double durationSeconds, PlotType type)
        {
            Check();
            IntPtr ___ret_abi;
            Native.Throw(_vt.GetPlot(IPtr, durationSeconds, type, out ___ret_abi));
            return GluonObject.Of<SignalBuffer>(___ret_abi);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal NoiseEngine(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.NoiseEngine>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_NoiseEngine_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.NoiseEngine _vt;
        static Guid _ID = new Guid("5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931");

        #endregion
    }
}
