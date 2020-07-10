/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;
using GluonTest;

namespace ABI.GluonTest
{
    internal static class Native
    {
        static Native()
        {
            GluonObject.RegisterTypeMono<global::GluonTest.DummyClass>(new Guid("1ba744ee-dac4-3983-dd7c-362d3f2c28c9"), native => new global::GluonTest.DummyClass(native));
            GluonObject.RegisterTypeMono<global::GluonTest.ConversionUnitTest>(new Guid("4eba58e6-b3aa-6df7-b808-582e243019d6"), native => new global::GluonTest.ConversionUnitTest(native));
            GluonObject.RegisterTypeMono<global::GluonTest.ITestClass>(new Guid("1ba744ee-dac4-3983-dd71-1725212128c9"), native => new global::GluonTest.ITestClass(native));
            GluonObject.RegisterTypeMono<global::GluonTest.SignalBuffer>(new Guid("7eb251fa-dab6-3983-dd6b-2a273c3407e7"), native => new global::GluonTest.SignalBuffer(native));
            GluonObject.RegisterTypeMono<global::GluonTest.Waveform>(new Guid("1bd437e2-dac4-3983-dd6f-2236373304d7"), native => new global::GluonTest.Waveform(native));
            GluonObject.RegisterTypeMono<global::GluonTest.SinusoidalWaveform>(new Guid("4cb856eb-aca5-5fe6-b219-472e272604cc"), native => new global::GluonTest.SinusoidalWaveform(native));
            GluonObject.RegisterTypeMono<global::GluonTest.SquareWaveform>(new Guid("7db141ee-a8ab-39ee-dd6b-323533270ef2"), native => new global::GluonTest.SquareWaveform(native));
            GluonObject.RegisterTypeMono<global::GluonTest.TriangleWaveform>(new Guid("6db560ea-bca1-4bec-b06c-3129333b0cc9"), native => new global::GluonTest.TriangleWaveform(native));
            GluonObject.RegisterTypeMono<global::GluonTest.SawtoothRightWaveform>(new Guid("7cbd65e7-aeac-58d4-ab0e-4458545704d1"), native => new global::GluonTest.SawtoothRightWaveform(native));
            GluonObject.RegisterTypeMono<global::GluonTest.SawtoothLeftWaveform>(new Guid("7db17be7-8db0-4fe2-b80d-4d454b3a04d1"), native => new global::GluonTest.SawtoothLeftWaveform(native));
            GluonObject.RegisterTypeMono<global::GluonTest.GTone>(new Guid("1bd4378f-dac4-3983-dd7f-172f3c306ba5"), native => new global::GluonTest.GTone(native));
            GluonObject.RegisterTypeMono<global::GluonTest.GWhiteNoise>(new Guid("7ea75ee0-dac4-3983-dd7f-14283b210eeb"), native => new global::GluonTest.GWhiteNoise(native));
            GluonObject.RegisterTypeMono<global::GluonTest.NoiseEngine>(new Guid("7eba5ee8-dac4-3983-dd76-2c2921302ecb"), native => new global::GluonTest.NoiseEngine(native));
        }

        public const string DllPath = "GluonTestResultsCpp.dll";

        [DllImport(DllPath, EntryPoint = "$_GetGluonExceptionDetails")]
        private static extern int GetGluonExceptionDetails(out int outHR, out ExceptionType outType, out IntPtr outText);

        public static void RegisterTypes() { }

        internal static void Throw(int hr)
        {
            if (hr == (int)HResult.S_OK) return;

            int checkhr;
            ExceptionType type;
            IntPtr msgPtr;
            string msg;
            var chk = GetGluonExceptionDetails(out checkhr, out type, out msgPtr);
            if (chk != 0 || hr != checkhr) throw new GluonExceptionAssertionFail();
            msg = Marshal.PtrToStringAnsi(msgPtr);
            Translate.Exception(type, msg);
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
                Obj = MConv_.ToABI_ObjectPtr(x.Obj),
                Del = D_6F2B7D3C.Unwrap(x.Del)
            };
        }

        public static global::GluonTest.ComplexStruct FromABI(ComplexStruct x)
        {
            return new global::GluonTest.ComplexStruct
            {
                Name = MConv_.FromABI_string(x.Name),
                Sub = x.Sub,
                Obj = GluonObject.Of<global::GluonTest.DummyClass>(x.Obj),
                Del = D_6F2B7D3C.Wrap(x.Del.Fn, x.Del.Ctx)
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
                Object = MConv_.ToABI_ObjectPtr(x.Object),
                NamedDelegate = D_164AAD4.Unwrap(x.NamedDelegate),
                GenericDelegate = D_1635054.Unwrap(x.GenericDelegate)
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
                NamedDelegate = D_164AAD4.Wrap(x.NamedDelegate.Fn, x.NamedDelegate.Ctx),
                GenericDelegate = D_1635054.Wrap(x.GenericDelegate.Fn, x.GenericDelegate.Ctx)
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

    public class D_6F2B7D3C : Gluon.D_Base
    {
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

        private D_6F2B7D3C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_6F2B7D3C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int,int>;
            else
                return new D_6F2B7D3C(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164AAD4 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string a, [MarshalAs(UnmanagedType.LPWStr)] string b, out int ___ret);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string a, [MarshalAs(UnmanagedType.LPWStr)] string b, out int ___ret)
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

        private D_164AAD4(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegate Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164AAD4.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegate;
            else
                return new D_164AAD4(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164ABC8 : Gluon.D_Base
    {
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

        private D_164ABC8(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitivesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164ABC8.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitivesCB;
            else
                return new D_164ABC8(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164ACBC : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string inTest, [MarshalAs(UnmanagedType.LPWStr)] out string outTest, [MarshalAs(UnmanagedType.LPWStr)] ref string refTest, [MarshalAs(UnmanagedType.LPWStr)] out string ___ret);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string inTest, [MarshalAs(UnmanagedType.LPWStr)] out string outTest, [MarshalAs(UnmanagedType.LPWStr)] ref string refTest, [MarshalAs(UnmanagedType.LPWStr)] out string ___ret)
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

        private D_164ACBC(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164ACBC.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringsCB;
            else
                return new D_164ACBC(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164ADB0 : Gluon.D_Base
    {
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

        private D_164ADB0(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164ADB0.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructsCB;
            else
                return new D_164ADB0(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164AEA4 : Gluon.D_Base
    {
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

        private D_164AEA4(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164AEA4.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructsCB;
            else
                return new D_164AEA4(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164AF98 : Gluon.D_Base
    {
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
                outTest = (outTest_wrap == null ? IntPtr.Zero : outTest_wrap.NativePtr);
                refTest = (refTest_wrap == null ? IntPtr.Zero : refTest_wrap.NativePtr);
                ___ret = (___ret_wrap == null ? IntPtr.Zero : ___ret_wrap.NativePtr);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                outTest = default(IntPtr);
                ___ret = default(IntPtr);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_164AF98(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164AF98.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectsCB;
            else
                return new D_164AF98(fn, ctx).Call;
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
            var refTest_abi = (refTest == null ? IntPtr.Zero : refTest.NativePtr);
            IntPtr ___ret_abi;
            Native.Throw((int)_abi(_ctx, (inTest == null ? IntPtr.Zero : inTest.NativePtr), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = GluonObject.Of<global::GluonTest.DummyClass>(outTest_abi);
            refTest = GluonObject.Of<global::GluonTest.DummyClass>(refTest_abi);
            return GluonObject.Of<global::GluonTest.DummyClass>(___ret_abi);
        }

        private NativeDel _abi;
    }

    public class D_164B08C : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);
        private static HResult Fn(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.NamedDelegatesCB;

            try
            {
                var inTest_wrap = D_164AAD4.Wrap(inTest, inTest_context);
                global::GluonTest.NamedDelegate outTest_wrap;
                var refTest_wrap = D_164AAD4.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_164AAD4.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_164AAD4.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_164AAD4.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
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

        private D_164B08C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B08C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegatesCB;
            else
                return new D_164B08C(fn, ctx).Call;
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
            var inTest_abi = D_164AAD4.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_164AAD4.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_164AAD4.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_164AAD4.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_164AAD4.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        private NativeDel _abi;
    }

    public class D_164B180 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);
        private static HResult Fn(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.GenericDelegatesCB;

            try
            {
                var inTest_wrap = D_6F2702D4.Wrap(inTest, inTest_context);
                Action<Func<int,int>> outTest_wrap;
                var refTest_wrap = D_1634C4C.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_1634BAC.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_1634C4C.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_6F2C28D4.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
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

        private D_164B180(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B180.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegatesCB;
            else
                return new D_164B180(fn, ctx).Call;
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
            var inTest_abi = D_6F2702D4.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_1634C4C.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_1634BAC.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_1634C4C.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_6F2C28D4.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        private NativeDel _abi;
    }

    public class D_6F2C28D4 : Gluon.D_Base
    {
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

        private D_6F2C28D4(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_6F2C28D4.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int>;
            else
                return new D_6F2C28D4(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_6F2702D4 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string obj);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string obj)
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

        private D_6F2702D4(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_6F2702D4.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<string>;
            else
                return new D_6F2702D4(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_1634BAC : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, IntPtr obj, IntPtr obj_context);
        private static HResult Fn(IntPtr __i_, IntPtr obj, IntPtr obj_context)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Action<Func<int,int>>;

            try
            {
                var obj_wrap = D_6F2C28D4.Wrap(obj, obj_context);
                del(obj_wrap);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_1634BAC(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<Func<int,int>> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1634BAC.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<Func<int,int>>;
            else
                return new D_1634BAC(fn, ctx).Call;
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
            var obj_abi = D_6F2C28D4.Unwrap(obj);
            Native.Throw((int)_abi(_ctx, obj_abi.Fn, obj_abi.Ctx));
        }

        private NativeDel _abi;
    }

    public class D_1634C4C : Gluon.D_Base
    {
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

        private D_1634C4C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string[]> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1634C4C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string[]>;
            else
                return new D_1634C4C(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164B274 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] bool[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] bool[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
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

        private D_164B274(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitiveArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B274.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitiveArraysCB;
            else
                return new D_164B274(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164B368 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
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

        private D_164B368(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B368.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringArraysCB;
            else
                return new D_164B368(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164B45C : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] global::GluonTest.BlittableStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] global::GluonTest.BlittableStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.SimpleStructArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_164A918(refTest, refTest_count);
                var ___ret_wrap = del(inTest, out global::GluonTest.BlittableStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_164A918(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_164A918(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_164A918(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_164B45C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B45C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructArraysCB;
            else
                return new D_164B45C(fn, ctx).Call;
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
            var refTest_abi = MConv.ToABI_164A918(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_164A918(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_164A918(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_164A918(___ret_abi.Ptr, ___ret_abi.Count);
        }

        private NativeDel _abi;
    }

    public class D_164B550 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ComplexStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ComplexStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.ComplexStructArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_164AA1C(refTest, refTest_count);
                var ___ret_wrap = del(ComplexStruct.FromABI_Array(inTest), out global::GluonTest.ComplexStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_164AA1C(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_164AA1C(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_164AA1C(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_164B550(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B550.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructArraysCB;
            else
                return new D_164B550(fn, ctx).Call;
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
            var refTest_abi = MConv.ToABI_164AA1C(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_164AA1C(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_164AA1C(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_164AA1C(___ret_abi.Ptr, ___ret_abi.Count);
        }

        private NativeDel _abi;
    }

    public class D_164B644 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.ObjectArraysCB;

            try
            {
                var refTest_wrap = MConv_.FromABI_Object<global::GluonTest.DummyClass>(refTest, refTest_count);
                var ___ret_wrap = del(GluonObject.ArrayWrap<global::GluonTest.DummyClass>(inTest), out global::GluonTest.DummyClass[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv_.ToABI_Object(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv_.ToABI_Object(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv_.ToABI_Object(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_164B644(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B644.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectArraysCB;
            else
                return new D_164B644(fn, ctx).Call;
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
            var inTest_abi = GluonObject.ArrayUnwrapPtr(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_Object(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_Object<global::GluonTest.DummyClass>(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_Object<global::GluonTest.DummyClass>(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_Object<global::GluonTest.DummyClass>(___ret_abi.Ptr, ___ret_abi.Count);
        }

        private NativeDel _abi;
    }

    public class D_164B738 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.NamedDelegateArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_164AAD4(refTest, refTest_count);
                var ___ret_wrap = del(D_164AAD4.FromABI_Array(inTest), out global::GluonTest.NamedDelegate[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_164AAD4(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_164AAD4(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_164AAD4(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_164B738(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B738.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegateArraysCB;
            else
                return new D_164B738(fn, ctx).Call;
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
            var inTest_abi = D_164AAD4.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_164AAD4(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_164AAD4(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_164AAD4(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_164AAD4(___ret_abi.Ptr, ___ret_abi.Count);
        }

        private NativeDel _abi;
    }

    public class D_164B82C : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.GenericDelegateArraysCB;

            try
            {
                var refTest_wrap = MConv.FromABI_1634C4C(refTest, refTest_count);
                var ___ret_wrap = del(D_6F2702D4.FromABI_Array(inTest), out Action<Func<int,int>>[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_1634BAC(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_1634C4C(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_6F2C28D4(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_164B82C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164B82C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegateArraysCB;
            else
                return new D_164B82C(fn, ctx).Call;
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
            var inTest_abi = D_6F2702D4.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_1634C4C(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_1634BAC(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_1634C4C(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_6F2C28D4(___ret_abi.Ptr, ___ret_abi.Count);
        }

        private NativeDel _abi;
    }

    public class D_1635054 : Gluon.D_Base
    {
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

        private D_1635054(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<double,double> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1635054.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<double,double>;
            else
                return new D_1635054(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_16350FC : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] arg, int arg_count, [MarshalAs(UnmanagedType.LPWStr)] out string ___ret);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] arg, int arg_count, [MarshalAs(UnmanagedType.LPWStr)] out string ___ret)
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

        private D_16350FC(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_16350FC.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string>;
            else
                return new D_16350FC(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_164C1C8 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, int a, int b, out IntPtr ___ret);
        private static HResult Fn(IntPtr __i_, int a, int b, out IntPtr ___ret)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as global::GluonTest.AddSomeShit;

            try
            {
                var ___ret_wrap = del(a, b);
                ___ret = (___ret_wrap == null ? IntPtr.Zero : ___ret_wrap.NativePtr);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(IntPtr);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_164C1C8(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.AddSomeShit Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_164C1C8.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.AddSomeShit;
            else
                return new D_164C1C8(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_1635374 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, char arg1, int arg2, [MarshalAs(UnmanagedType.LPWStr)] out string ___ret);
        private static HResult Fn(IntPtr __i_, char arg1, int arg2, [MarshalAs(UnmanagedType.LPWStr)] out string ___ret)
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

        private D_1635374(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char,int,string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1635374.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char,int,string>;
            else
                return new D_1635374(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_16354B4 : Gluon.D_Base
    {
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string arg, out char ___ret);
        private static HResult Fn(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string arg, out char ___ret)
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

        private D_16354B4(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<string,char> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_16354B4.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<string,char>;
            else
                return new D_16354B4(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    public class D_6F2C9998 : Gluon.D_Base
    {
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

        private D_6F2C9998(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_6F2C9998.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<int>;
            else
                return new D_6F2C9998(fn, ctx).Call;
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

        private NativeDel _abi;
    }

    internal static class MConv
    {
        public static global::GluonTest.BlittableStruct[] FromABI_164A918(IntPtr data, int count)
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

        public static ArrayBlob ToABI_164A918(global::GluonTest.BlittableStruct[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<global::GluonTest.BlittableStruct>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                Marshal.StructureToPtr(arr[i], r.Ptr + sz * i, false);
            }

            return r;
        }

        public static void FreeABI_164A918(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.ComplexStruct[] FromABI_164AA1C(IntPtr data, int count)
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

        public static ArrayBlob ToABI_164AA1C(global::GluonTest.ComplexStruct[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<ComplexStruct>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                Marshal.StructureToPtr(ComplexStruct.ToABI(arr[i]), r.Ptr + sz * i, false);
            }

            return r;
        }

        public static void FreeABI_164AA1C(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.NamedDelegate[] FromABI_164AAD4(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;

            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new global::GluonTest.NamedDelegate[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_164AAD4.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_164AAD4(global::GluonTest.NamedDelegate[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_164AAD4.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_164AAD4(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<int,int>[] FromABI_6F2C28D4(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;

            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<int,int>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_6F2C28D4.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_6F2C28D4(Func<int,int>[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_6F2C28D4.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_6F2C28D4(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<string>[] FromABI_6F2702D4(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;

            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_6F2702D4.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_6F2702D4(Action<string>[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_6F2702D4.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_6F2702D4(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<Func<int,int>>[] FromABI_1634BAC(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;

            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<Func<int,int>>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_1634BAC.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_1634BAC(Action<Func<int,int>>[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_1634BAC.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_1634BAC(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string[]>[] FromABI_1634C4C(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;

            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string[]>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_1634C4C.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_1634C4C(Func<char[],string[]>[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_1634C4C.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_1634C4C(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string>[] FromABI_16350FC(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;

            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_16350FC.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_16350FC(Func<char[],string>[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_16350FC.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_16350FC(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.TestStruct[] FromABI_164C110(IntPtr data, int count)
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

        public static ArrayBlob ToABI_164C110(global::GluonTest.TestStruct[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<TestStruct>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                Marshal.StructureToPtr(TestStruct.ToABI(arr[i]), r.Ptr + sz * i, false);
            }

            return r;
        }

        public static void FreeABI_164C110(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char,int,string>[] FromABI_1635374(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;

            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char,int,string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_1635374.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_1635374(Func<char,int,string>[] arr)
        {
            var r = new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            if(arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz * arr.Length);

            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_1635374.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_1635374(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }
    }

    [Guid("3c2ff6f0-d08b-3cbb-e6af-e8351ff6af18")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct DummyClass
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNugget_sig GetNugget;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNugget_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] out string retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNugget_sig SetNugget;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNugget_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_DummyClass_1(out IntPtr newInstance);
    }

    [Guid("6932eaf8-b9e5-68cf-83db-863604ea9e07")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ConversionUnitTest
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Primitives1_sig Primitives1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Primitives1_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool inTest, out char outTest, ref int refTest, out double ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Strings2_sig Strings2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Strings2_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] string inTest, [MarshalAs(UnmanagedType.LPWStr)] out string outTest, [MarshalAs(UnmanagedType.LPWStr)] ref string refTest, [MarshalAs(UnmanagedType.LPWStr)] out string ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SimpleStructs3_sig SimpleStructs3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SimpleStructs3_sig(IntPtr __i_, global::GluonTest.BlittableStruct inTest, out global::GluonTest.BlittableStruct outTest, ref global::GluonTest.BlittableStruct refTest, out global::GluonTest.BlittableStruct ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexStructs4_sig ComplexStructs4;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexStructs4_sig(IntPtr __i_, ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest, out ComplexStruct ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Objects5_sig Objects5;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Objects5_sig(IntPtr __i_, IntPtr inTest, out IntPtr outTest, ref IntPtr refTest, out IntPtr ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly NamedDelegates6_sig NamedDelegates6;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int NamedDelegates6_sig(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GenericDelegates7_sig GenericDelegates7;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GenericDelegates7_sig(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly PrimitiveArrays8_sig PrimitiveArrays8;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int PrimitiveArrays8_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] bool[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly StringArrays9_sig StringArrays9;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int StringArrays9_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SimpleStructArrays10_sig SimpleStructArrays10;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SimpleStructArrays10_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] global::GluonTest.BlittableStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexStructArrays11_sig ComplexStructArrays11;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexStructArrays11_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ComplexStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ObjectArrays12_sig ObjectArrays12;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ObjectArrays12_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly NamedDelegateArrays13_sig NamedDelegateArrays13;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int NamedDelegateArrays13_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GenericDelegateArrays14_sig GenericDelegateArrays14;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GenericDelegateArrays14_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckNullReference15_sig ExCheckNullReference15;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckNullReference15_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckArgumentNull16_sig ExCheckArgumentNull16;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckArgumentNull16_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckArgument17_sig ExCheckArgument17;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckArgument17_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckInvalidOperation18_sig ExCheckInvalidOperation18;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckInvalidOperation18_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckAccessDenied19_sig ExCheckAccessDenied19;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckAccessDenied19_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckGeneric20_sig ExCheckGeneric20;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckGeneric20_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckGenericStd21_sig ExCheckGenericStd21;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckGenericStd21_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckNotImplemented22_sig ExCheckNotImplemented22;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckNotImplemented22_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPrimitivesCB_sig GetPrimitivesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPrimitivesCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetPrimitivesCB_sig SetPrimitivesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetPrimitivesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStringsCB_sig GetStringsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStringsCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStringsCB_sig SetStringsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStringsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSimpleStructsCB_sig GetSimpleStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSimpleStructsCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSimpleStructsCB_sig SetSimpleStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSimpleStructsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetComplexStructsCB_sig GetComplexStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetComplexStructsCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetComplexStructsCB_sig SetComplexStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetComplexStructsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetObjectsCB_sig GetObjectsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetObjectsCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetObjectsCB_sig SetObjectsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetObjectsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNamedDelegatesCB_sig GetNamedDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNamedDelegatesCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNamedDelegatesCB_sig SetNamedDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNamedDelegatesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetGenericDelegatesCB_sig GetGenericDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetGenericDelegatesCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetGenericDelegatesCB_sig SetGenericDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetGenericDelegatesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPrimitiveArraysCB_sig GetPrimitiveArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPrimitiveArraysCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetPrimitiveArraysCB_sig SetPrimitiveArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetPrimitiveArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStringArraysCB_sig GetStringArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStringArraysCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStringArraysCB_sig SetStringArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStringArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSimpleStructArraysCB_sig GetSimpleStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSimpleStructArraysCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSimpleStructArraysCB_sig SetSimpleStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSimpleStructArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetComplexStructArraysCB_sig GetComplexStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetComplexStructArraysCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetComplexStructArraysCB_sig SetComplexStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetComplexStructArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetObjectArraysCB_sig GetObjectArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetObjectArraysCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetObjectArraysCB_sig SetObjectArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetObjectArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNamedDelegateArraysCB_sig GetNamedDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNamedDelegateArraysCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNamedDelegateArraysCB_sig SetNamedDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNamedDelegateArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetGenericDelegateArraysCB_sig GetGenericDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetGenericDelegateArraysCB_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetGenericDelegateArraysCB_sig SetGenericDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetGenericDelegateArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStructMembers_sig GetStructMembers;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStructMembers_sig(IntPtr __i_, out StructMemberTest retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStructMembers_sig SetStructMembers;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStructMembers_sig(IntPtr __i_, StructMemberTest value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_ConversionUnitTest_1(out IntPtr newInstance);
    }

    [Guid("3c2ff6f0-d08b-3cbb-e6a2-c93d01fbaf18")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ITestClass
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Methody1_sig Methody1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Methody1_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RetMethod2_sig RetMethod2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RetMethod2_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly OutMethod3_sig OutMethod3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int OutMethod3_sig(IntPtr __i_, out int x);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RefMethod4_sig RefMethod4;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RefMethod4_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] ref string thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Ref25_sig Ref25;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Ref25_sig(IntPtr __i_, ref IntPtr thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Ref36_sig Ref36;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Ref36_sig(IntPtr __i_, TestStruct thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexMethod7_sig ComplexMethod7;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexMethod7_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] ref string a, IntPtr _dumb, IntPtr p, out IntPtr fart, out int fart_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetAdder_sig GetAdder;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetAdder_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetAdder_sig SetAdder;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetAdder_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetProperty_sig GetProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetProperty_sig(IntPtr __i_, out int retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetProperty_sig SetProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetProperty_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetReadOnlyProperty_sig GetReadOnlyProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetReadOnlyProperty_sig(IntPtr __i_, out int retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetHardProperty_sig GetHardProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetHardProperty_sig(IntPtr __i_, out IntPtr retVal, out int retVal_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetHardProperty_sig SetHardProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetHardProperty_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TestStruct[] value, int value_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetHarderProperty_sig GetHarderProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetHarderProperty_sig(IntPtr __i_, out IntPtr retVal, out int retVal_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetHarderProperty_sig SetHarderProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetHarderProperty_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] value, int value_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetDumbDelegate_sig GetDumbDelegate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetDumbDelegate_sig(IntPtr __i_, out IntPtr retVal, out IntPtr retVal_context);

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
        public static extern int Create_ITestClass_1(out IntPtr newInstance);
    }

    [Guid("3c5cf7fe-d08b-3cbb-e6ac-f83617fd8d00")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct Generator
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Initialize1_sig Initialize1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Initialize1_sig(IntPtr __i_, int channels, int sampleRate);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Eval2_sig Eval2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Eval2_sig(IntPtr __i_, double t, ref double outSample);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly EvalBuffer3_sig EvalBuffer3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int EvalBuffer3_sig(IntPtr __i_, double t, IntPtr inoutBuffer);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannelCount_sig GetChannelCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannelCount_sig(IntPtr __i_, out int retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleRate_sig GetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleRate_sig(IntPtr __i_, out int retVal);
    }

    [Guid("593ae3e4-d0f9-3cbb-e6b8-f43f1cee8036")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SignalBuffer
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo1_sig CopyTo1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo1_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo2_sig CopyTo2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo2_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo3_sig CopyTo3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo3_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] short[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannelCount_sig GetChannelCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannelCount_sig(IntPtr __i_, out int retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleCount_sig GetSampleCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleCount_sig(IntPtr __i_, out int retVal);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_SignalBuffer_1(int samples, int channels, int alignment, out IntPtr newInstance);

        [DllImport(Native.DllPath)]
        public static extern int Create_SignalBuffer_2(int samples, out IntPtr newInstance);
    }

    [Guid("3c5c85fc-d08b-3cbb-e6bc-fc2e17e98306")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct Waveform
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Phase1_sig Phase1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Phase1_sig(IntPtr __i_, double t, out double ___ret);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_Waveform_1([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] samples, int samples_count, out IntPtr newInstance);
    }

    [Guid("6b30e4f5-a6ea-5ade-89ca-993607fc831d")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SinusoidalWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_SinusoidalWaveform_1(out IntPtr newInstance);
    }

    [Guid("5a39f3f0-a2e4-3cd6-e6b8-ec2d13fd8923")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SquareWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_SquareWaveform_1(out IntPtr newInstance);
    }

    [Guid("4a3dd2f4-b6ee-4ed4-8bbf-ef3113e18b18")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TriangleWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_TriangleWaveform_1(out IntPtr newInstance);
    }

    [Guid("5b35d7f9-a4e3-5dec-90dd-9a40748d8300")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SawtoothRightWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_SawtoothRightWaveform_1(out IntPtr newInstance);
    }

    [Guid("5a39c9f9-87ff-4ada-83de-935d6be08300")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SawtoothLeftWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_SawtoothLeftWaveform_1(out IntPtr newInstance);
    }

    [Guid("3c5c8591-d08b-3cbb-e6ac-c9371ceaec74")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct GTone
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetFrequency_sig GetFrequency;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetFrequency_sig(IntPtr __i_, out double retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetFrequency_sig SetFrequency;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetFrequency_sig(IntPtr __i_, double value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetWaveform_sig GetWaveform;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetWaveform_sig(IntPtr __i_, out IntPtr retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetWaveform_sig SetWaveform;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetWaveform_sig(IntPtr __i_, IntPtr value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetAmplitude_sig GetAmplitude;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetAmplitude_sig(IntPtr __i_, out double retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetAmplitude_sig SetAmplitude;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetAmplitude_sig(IntPtr __i_, double value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GTone_1(out IntPtr newInstance);
    }

    [Guid("592fecfe-d08b-3cbb-e6ac-ca301bfb893a")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct GWhiteNoise
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GWhiteNoise_1(out IntPtr newInstance);
    }

    [Guid("5932ecf6-d08b-3cbb-e6a5-f23101eaa91a")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct NoiseEngine
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Play1_sig Play1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Play1_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Pause2_sig Pause2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Pause2_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPlot3_sig GetPlot3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPlot3_sig(IntPtr __i_, double durationSeconds, PlotType type, out IntPtr ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetError_sig GetError;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetError_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPWStr)] out string retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetState_sig GetState;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetState_sig(IntPtr __i_, out NoiseEngineState retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleRate_sig GetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleRate_sig(IntPtr __i_, out int retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSampleRate_sig SetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSampleRate_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannels_sig GetChannels;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannels_sig(IntPtr __i_, out NoiseChannels retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetChannels_sig SetChannels;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetChannels_sig(IntPtr __i_, NoiseChannels value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetBlockDuration_sig GetBlockDuration;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetBlockDuration_sig(IntPtr __i_, out int retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetBlockDuration_sig SetBlockDuration;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetBlockDuration_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetDistribution_sig GetDistribution;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetDistribution_sig(IntPtr __i_, out NoiseDistribution retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetDistribution_sig SetDistribution;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetDistribution_sig(IntPtr __i_, NoiseDistribution value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetIsFilterEnabled_sig GetIsFilterEnabled;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetIsFilterEnabled_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] out bool retVal);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetIsFilterEnabled_sig SetIsFilterEnabled;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetIsFilterEnabled_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_NoiseEngine_1(out IntPtr newInstance);
    }
}
