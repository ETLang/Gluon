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
    internal static class Native
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
                Obj = MConv_.ToABI_Object(x.Obj),
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
                Object = MConv_.ToABI_Object(x.Object),
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

    public class D_827F05B3 : Gluon.D_Base
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

        private D_827F05B3(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_827F05B3.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int,int>;
            else
                return new D_827F05B3(fn, ctx).Call;
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

    public class D_BD6C0A4E : Gluon.D_Base
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

        private D_BD6C0A4E(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegate Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_BD6C0A4E.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegate;
            else
                return new D_BD6C0A4E(fn, ctx).Call;
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

    public class D_67C6D6E0 : Gluon.D_Base
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

        private D_67C6D6E0(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitivesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_67C6D6E0.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitivesCB;
            else
                return new D_67C6D6E0(fn, ctx).Call;
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

    public class D_7A2B6D2C : Gluon.D_Base
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

        private D_7A2B6D2C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_7A2B6D2C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringsCB;
            else
                return new D_7A2B6D2C(fn, ctx).Call;
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

    public class D_DF8B3B29 : Gluon.D_Base
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

        private D_DF8B3B29(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_DF8B3B29.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructsCB;
            else
                return new D_DF8B3B29(fn, ctx).Call;
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

    public class D_625CB5F : Gluon.D_Base
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

        private D_625CB5F(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_625CB5F.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructsCB;
            else
                return new D_625CB5F(fn, ctx).Call;
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

    public class D_87064FFB : Gluon.D_Base
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
                outTest = (outTest_wrap == null ? IntPtr.Zero : outTest_wrap.NativePtr);
                var refTest_old = refTest; refTest = MConv_.ToABI_Object(refTest_wrap); if(refTest_old != IntPtr.Zero) Marshal.Release(refTest_old);
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

        private D_87064FFB(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_87064FFB.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectsCB;
            else
                return new D_87064FFB(fn, ctx).Call;
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
            var refTest_abi = MConv_.ToABI_Object(refTest);
            IntPtr ___ret_abi;
            Native.Throw((int)_abi(_ctx, (inTest == null ? IntPtr.Zero : inTest.NativePtr), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = GluonObject.Of<global::GluonTest.DummyClass>(outTest_abi);
            refTest = MConv_.FromABI_Object<global::GluonTest.DummyClass>(refTest_abi);
            return GluonObject.Of<global::GluonTest.DummyClass>(___ret_abi);
        }
    }

    public class D_7451AE97 : Gluon.D_Base
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
                var inTest_wrap = D_BD6C0A4E.Wrap(inTest, inTest_context);
                global::GluonTest.NamedDelegate outTest_wrap;
                var refTest_wrap = D_BD6C0A4E.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_BD6C0A4E.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_BD6C0A4E.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_BD6C0A4E.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
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

        private D_7451AE97(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_7451AE97.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegatesCB;
            else
                return new D_7451AE97(fn, ctx).Call;
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
            var inTest_abi = D_BD6C0A4E.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_BD6C0A4E.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_BD6C0A4E.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_BD6C0A4E.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_BD6C0A4E.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }
    }

    public class D_61217488 : Gluon.D_Base
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
                var inTest_wrap = D_5D02415D.Wrap(inTest, inTest_context);
                Action<Func<int,int>> outTest_wrap;
                var refTest_wrap = D_29454150.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_5D02415E.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_29454150.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_29454151.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
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

        private D_61217488(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_61217488.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegatesCB;
            else
                return new D_61217488(fn, ctx).Call;
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
            var inTest_abi = D_5D02415D.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_29454150.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_5D02415E.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_29454150.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_29454151.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }
    }

    public class D_29454151 : Gluon.D_Base
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

        private D_29454151(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_29454151.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int>;
            else
                return new D_29454151(fn, ctx).Call;
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

    public class D_5D02415D : Gluon.D_Base
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

        private D_5D02415D(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5D02415D.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<string>;
            else
                return new D_5D02415D(fn, ctx).Call;
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

    public class D_5D02415E : Gluon.D_Base
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
                var obj_wrap = D_29454151.Wrap(obj, obj_context);
                del(obj_wrap);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_5D02415E(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<Func<int,int>> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5D02415E.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<Func<int,int>>;
            else
                return new D_5D02415E(fn, ctx).Call;
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
            var obj_abi = D_29454151.Unwrap(obj);
            Native.Throw((int)_abi(_ctx, obj_abi.Fn, obj_abi.Ctx));
        }
    }

    public class D_29454150 : Gluon.D_Base
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

        private D_29454150(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string[]> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_29454150.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string[]>;
            else
                return new D_29454150(fn, ctx).Call;
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

    public class D_2C74C8B5 : Gluon.D_Base
    {
        private NativeDel _abi;
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

        private D_2C74C8B5(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitiveArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_2C74C8B5.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitiveArraysCB;
            else
                return new D_2C74C8B5(fn, ctx).Call;
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

    public class D_1061E85A : Gluon.D_Base
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

        private D_1061E85A(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1061E85A.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringArraysCB;
            else
                return new D_1061E85A(fn, ctx).Call;
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

    public class D_1C12DC58 : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_6FB3D834(refTest, refTest_count);
                var ___ret_wrap = del(inTest, out global::GluonTest.BlittableStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_6FB3D834(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_6FB3D834(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_6FB3D834(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_1C12DC58(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1C12DC58.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructArraysCB;
            else
                return new D_1C12DC58(fn, ctx).Call;
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
            var refTest_abi = MConv.ToABI_6FB3D834(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_6FB3D834(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_6FB3D834(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_6FB3D834(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_14F875F8 : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_7301BA3D(refTest, refTest_count);
                var ___ret_wrap = del(ComplexStruct.FromABI_Array(inTest), out global::GluonTest.ComplexStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_7301BA3D(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_7301BA3D(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_7301BA3D(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_14F875F8(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_14F875F8.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructArraysCB;
            else
                return new D_14F875F8(fn, ctx).Call;
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
            var refTest_abi = MConv.ToABI_7301BA3D(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7301BA3D(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7301BA3D(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7301BA3D(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_A1A08E74 : Gluon.D_Base
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

        private D_A1A08E74(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_A1A08E74.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectArraysCB;
            else
                return new D_A1A08E74(fn, ctx).Call;
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
            ArrayBlob refTest_abi = MConv_.ToABI_Object(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_Object<global::GluonTest.DummyClass>(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_Object<global::GluonTest.DummyClass>(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_Object<global::GluonTest.DummyClass>(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_B2A7C512 : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_BD6C0A4E(refTest, refTest_count);
                var ___ret_wrap = del(D_BD6C0A4E.FromABI_Array(inTest), out global::GluonTest.NamedDelegate[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_BD6C0A4E(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_BD6C0A4E(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_BD6C0A4E(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_B2A7C512(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_B2A7C512.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegateArraysCB;
            else
                return new D_B2A7C512(fn, ctx).Call;
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
            var inTest_abi = D_BD6C0A4E.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_BD6C0A4E(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_BD6C0A4E(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_BD6C0A4E(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_BD6C0A4E(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_DC21B22C : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_29454150(refTest, refTest_count);
                var ___ret_wrap = del(D_5D02415D.FromABI_Array(inTest), out Action<Func<int,int>>[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_5D02415E(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_29454150(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_29454151(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_DC21B22C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_DC21B22C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegateArraysCB;
            else
                return new D_DC21B22C(fn, ctx).Call;
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
            var inTest_abi = D_5D02415D.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_29454150(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_5D02415E(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_29454150(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_29454151(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_2945414F : Gluon.D_Base
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

        private D_2945414F(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<double,double> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_2945414F.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<double,double>;
            else
                return new D_2945414F(fn, ctx).Call;
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

    public class D_29454152 : Gluon.D_Base
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

        private D_29454152(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_29454152.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string>;
            else
                return new D_29454152(fn, ctx).Call;
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

    public class D_668509AE : Gluon.D_Base
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
                ___ret = (___ret_wrap == null ? IntPtr.Zero : ___ret_wrap.NativePtr);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                ___ret = default(IntPtr);
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_668509AE(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.AddSomeShit Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_668509AE.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.AddSomeShit;
            else
                return new D_668509AE(fn, ctx).Call;
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

    public class D_827F05B4 : Gluon.D_Base
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

        private D_827F05B4(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char,int,string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_827F05B4.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char,int,string>;
            else
                return new D_827F05B4(fn, ctx).Call;
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

    public class D_29454153 : Gluon.D_Base
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

        private D_29454153(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<string,char> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_29454153.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<string,char>;
            else
                return new D_29454153(fn, ctx).Call;
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

    public class D_5D02415F : Gluon.D_Base
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

        private D_5D02415F(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5D02415F.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<int>;
            else
                return new D_5D02415F(fn, ctx).Call;
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
        public static global::GluonTest.BlittableStruct[] FromABI_6FB3D834(IntPtr data, int count)
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

        public static ArrayBlob ToABI_6FB3D834(global::GluonTest.BlittableStruct[] arr)
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

        public static void FreeABI_6FB3D834(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.ComplexStruct[] FromABI_7301BA3D(IntPtr data, int count)
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

        public static ArrayBlob ToABI_7301BA3D(global::GluonTest.ComplexStruct[] arr)
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

        public static void FreeABI_7301BA3D(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.NamedDelegate[] FromABI_BD6C0A4E(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new global::GluonTest.NamedDelegate[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_BD6C0A4E.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_BD6C0A4E(global::GluonTest.NamedDelegate[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_BD6C0A4E.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_BD6C0A4E(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<int,int>[] FromABI_29454151(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<int,int>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_29454151.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_29454151(Func<int,int>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_29454151.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_29454151(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<string>[] FromABI_5D02415D(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_5D02415D.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5D02415D(Action<string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_5D02415D.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_5D02415D(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<Func<int,int>>[] FromABI_5D02415E(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<Func<int,int>>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_5D02415E.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5D02415E(Action<Func<int,int>>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_5D02415E.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_5D02415E(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string[]>[] FromABI_29454150(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string[]>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_29454150.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_29454150(Func<char[],string[]>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_29454150.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_29454150(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string>[] FromABI_29454152(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_29454152.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_29454152(Func<char[],string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_29454152.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_29454152(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.TestStruct[] FromABI_463C8218(IntPtr data, int count)
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

        public static ArrayBlob ToABI_463C8218(global::GluonTest.TestStruct[] arr)
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

        public static void FreeABI_463C8218(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char,int,string>[] FromABI_827F05B4(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char,int,string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_827F05B4.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_827F05B4(Func<char,int,string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_827F05B4.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_827F05B4(IntPtr data, int count)
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
        public readonly Primitives1_sig Primitives1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Primitives1_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool inTest, out char outTest, ref int refTest, out double ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Strings2_sig Strings2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Strings2_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string inTest, [MarshalAs(UnmanagedType.LPStr)] out string outTest, [MarshalAs(UnmanagedType.LPStr)] ref string refTest, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

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
        public delegate int StringArrays9_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

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
        public delegate int RefMethod4_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] ref string thing);

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
        public delegate int ComplexMethod7_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] ref string a, IntPtr _dumb, IntPtr p, out IntPtr fart, out int fart_count, out IntPtr ___ret, out int ___ret_count);

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
        public readonly Phase1_sig Phase1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Phase1_sig(IntPtr __i_, double t, out double ___ret);
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
        public delegate int GetPlot3_sig(IntPtr __i_, double durationSeconds, global::GluonTest.PlotType type, out IntPtr ___ret);

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

        static DummyClass()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public DummyClass() : this(new AbiPtr(Make())) {  Init(); }  

        public string Nugget
        {
            get {  string x; Native.Throw(_vt.GetNugget(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetNugget(_i, value)); }  
        }

        #region Internal

        internal DummyClass(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.DummyClass>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_DummyClass_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static ConversionUnitTest()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public ConversionUnitTest() : this(new AbiPtr(Make())) {  Init(); }  

        public PrimitivesCB PrimitivesCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetPrimitivesCB(_i, out x_abi_fn, out x_abi_ctx)); return D_67C6D6E0.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_67C6D6E0.Unwrap(value); Native.Throw(_vt.SetPrimitivesCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StringsCB StringsCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetStringsCB(_i, out x_abi_fn, out x_abi_ctx)); return D_7A2B6D2C.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_7A2B6D2C.Unwrap(value); Native.Throw(_vt.SetStringsCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public SimpleStructsCB SimpleStructsCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetSimpleStructsCB(_i, out x_abi_fn, out x_abi_ctx)); return D_DF8B3B29.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_DF8B3B29.Unwrap(value); Native.Throw(_vt.SetSimpleStructsCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ComplexStructsCB ComplexStructsCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetComplexStructsCB(_i, out x_abi_fn, out x_abi_ctx)); return D_625CB5F.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_625CB5F.Unwrap(value); Native.Throw(_vt.SetComplexStructsCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ObjectsCB ObjectsCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetObjectsCB(_i, out x_abi_fn, out x_abi_ctx)); return D_87064FFB.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_87064FFB.Unwrap(value); Native.Throw(_vt.SetObjectsCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public NamedDelegatesCB NamedDelegatesCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetNamedDelegatesCB(_i, out x_abi_fn, out x_abi_ctx)); return D_7451AE97.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_7451AE97.Unwrap(value); Native.Throw(_vt.SetNamedDelegatesCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public GenericDelegatesCB GenericDelegatesCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetGenericDelegatesCB(_i, out x_abi_fn, out x_abi_ctx)); return D_61217488.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_61217488.Unwrap(value); Native.Throw(_vt.SetGenericDelegatesCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public PrimitiveArraysCB PrimitiveArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetPrimitiveArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_2C74C8B5.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_2C74C8B5.Unwrap(value); Native.Throw(_vt.SetPrimitiveArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StringArraysCB StringArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetStringArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_1061E85A.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_1061E85A.Unwrap(value); Native.Throw(_vt.SetStringArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public SimpleStructArraysCB SimpleStructArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetSimpleStructArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_1C12DC58.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_1C12DC58.Unwrap(value); Native.Throw(_vt.SetSimpleStructArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ComplexStructArraysCB ComplexStructArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetComplexStructArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_14F875F8.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_14F875F8.Unwrap(value); Native.Throw(_vt.SetComplexStructArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ObjectArraysCB ObjectArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetObjectArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_A1A08E74.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_A1A08E74.Unwrap(value); Native.Throw(_vt.SetObjectArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public NamedDelegateArraysCB NamedDelegateArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetNamedDelegateArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_B2A7C512.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_B2A7C512.Unwrap(value); Native.Throw(_vt.SetNamedDelegateArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public GenericDelegateArraysCB GenericDelegateArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetGenericDelegateArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_DC21B22C.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_DC21B22C.Unwrap(value); Native.Throw(_vt.SetGenericDelegateArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StructMemberTest StructMembers
        {
            get {  ABI.GluonTest.StructMemberTest x_abi; Native.Throw(_vt.GetStructMembers(_i, out x_abi)); return ABI.GluonTest.StructMemberTest.FromABI(x_abi); }   
            set {  Native.Throw(_vt.SetStructMembers(_i, ABI.GluonTest.StructMemberTest.ToABI(value))); }  
        }

        public double Primitives(bool inTest, out char outTest, ref int refTest)
        {
            double ___ret;
            Native.Throw(_vt.Primitives1(_i, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public string Strings(string inTest, out string outTest, ref string refTest)
        {
            string ___ret;
            Native.Throw(_vt.Strings2(_i, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public BlittableStruct SimpleStructs(BlittableStruct inTest, out BlittableStruct outTest, ref BlittableStruct refTest)
        {
            BlittableStruct ___ret;
            Native.Throw(_vt.SimpleStructs3(_i, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public ComplexStruct ComplexStructs(ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest)
        {
            ABI.GluonTest.ComplexStruct outTest_abi;
            var refTest_abi = ABI.GluonTest.ComplexStruct.ToABI(refTest);
            ABI.GluonTest.ComplexStruct ___ret_abi;
            Native.Throw(_vt.ComplexStructs4(_i, ABI.GluonTest.ComplexStruct.ToABI(inTest), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = ABI.GluonTest.ComplexStruct.FromABI(outTest_abi);
            refTest = ABI.GluonTest.ComplexStruct.FromABI(refTest_abi);
            return ABI.GluonTest.ComplexStruct.FromABI(___ret_abi);
        }

        public DummyClass Objects(DummyClass inTest, out DummyClass outTest, ref DummyClass refTest)
        {
            IntPtr outTest_abi;
            var refTest_abi = MConv_.ToABI_Object(refTest);
            IntPtr ___ret_abi;
            Native.Throw(_vt.Objects5(_i, (inTest == null ? IntPtr.Zero : inTest.NativePtr), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = GluonObject.Of<DummyClass>(outTest_abi);
            refTest = MConv_.FromABI_Object<DummyClass>(refTest_abi);
            return GluonObject.Of<DummyClass>(___ret_abi);
        }

        public NamedDelegate NamedDelegates(NamedDelegate inTest, out NamedDelegate outTest, ref NamedDelegate refTest)
        {
            var inTest_abi = D_BD6C0A4E.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_BD6C0A4E.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw(_vt.NamedDelegates6(_i, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_BD6C0A4E.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_BD6C0A4E.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_BD6C0A4E.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        public Func<int,int> GenericDelegates(Action<string> inTest, out Action<Func<int,int>> outTest, ref Func<char[],string> refTest)
        {
            var inTest_abi = D_5D02415D.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_29454152.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw(_vt.GenericDelegates7(_i, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_5D02415E.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_29454152.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_29454151.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        public double[] PrimitiveArrays(bool[] inTest, out char[] outTest, ref int[] refTest)
        {
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_int(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.PrimitiveArrays8(_i, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_char(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_int(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_double(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public string[] StringArrays(string[] inTest, out string[] outTest, ref string[] refTest)
        {
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_string(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.StringArrays9(_i, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_string(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_string(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_string(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public BlittableStruct[] SimpleStructArrays(BlittableStruct[] inTest, out BlittableStruct[] outTest, ref BlittableStruct[] refTest)
        {
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_6FB3D834(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.SimpleStructArrays10(_i, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_6FB3D834(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_6FB3D834(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_6FB3D834(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public ComplexStruct[] ComplexStructArrays(ComplexStruct[] inTest, out ComplexStruct[] outTest, ref ComplexStruct[] refTest)
        {
            var inTest_abi = ABI.GluonTest.ComplexStruct.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_7301BA3D(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ComplexStructArrays11(_i, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7301BA3D(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7301BA3D(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7301BA3D(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public DummyClass[] ObjectArrays(DummyClass[] inTest, out DummyClass[] outTest, ref DummyClass[] refTest)
        {
            var inTest_abi = GluonObject.ArrayUnwrap(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_Object(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ObjectArrays12(_i, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_Object<DummyClass>(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_Object<DummyClass>(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_Object<DummyClass>(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public NamedDelegate[] NamedDelegateArrays(NamedDelegate[] inTest, out NamedDelegate[] outTest, ref NamedDelegate[] refTest)
        {
            var inTest_abi = D_BD6C0A4E.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_BD6C0A4E(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.NamedDelegateArrays13(_i, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_BD6C0A4E(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_BD6C0A4E(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_BD6C0A4E(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public Func<int,int>[] GenericDelegateArrays(Action<string>[] inTest, out Action<Func<int,int>>[] outTest, ref Func<char[],string>[] refTest)
        {
            var inTest_abi = D_5D02415D.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_29454152(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.GenericDelegateArrays14(_i, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_5D02415E(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_29454152(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_29454151(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public void ExCheckNullReference()
        {
            Native.Throw(_vt.ExCheckNullReference15(_i));
        }

        public void ExCheckArgumentNull()
        {
            Native.Throw(_vt.ExCheckArgumentNull16(_i));
        }

        public void ExCheckArgument()
        {
            Native.Throw(_vt.ExCheckArgument17(_i));
        }

        public void ExCheckInvalidOperation()
        {
            Native.Throw(_vt.ExCheckInvalidOperation18(_i));
        }

        public void ExCheckAccessDenied()
        {
            Native.Throw(_vt.ExCheckAccessDenied19(_i));
        }

        public void ExCheckGeneric()
        {
            Native.Throw(_vt.ExCheckGeneric20(_i));
        }

        public void ExCheckGenericStd()
        {
            Native.Throw(_vt.ExCheckGenericStd21(_i));
        }

        public void ExCheckNotImplemented()
        {
            Native.Throw(_vt.ExCheckNotImplemented22(_i));
        }

        #region Internal

        internal ConversionUnitTest(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ConversionUnitTest>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_ConversionUnitTest_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static ITestClass()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public ITestClass() : this(new AbiPtr(Make())) {  _BigEvent_abi = D_5D02415F.Unwrap(_Call_BigEvent); Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            if(_BigEvent != null) _vt.RemoveBigEventHandler(_i, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);

            base.OnDispose(finalizing);
        }

        #region BigEvent

        public event Action<int> BigEvent
        {
            add
            {
                if(_BigEvent == null)
                    _vt.AddBigEventHandler(_i, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);

                _BigEvent += value;
            }

            remove
            {
                _BigEvent -= value;
                if(_BigEvent == null)
                    _vt.RemoveBigEventHandler(_i, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);
            }
        }

        private void _Call_BigEvent(int obj)
        {
            _BigEvent(obj);
        }

        private Action<int> _BigEvent;
        private DelegateBlob _BigEvent_abi;

        #endregion

        public AddSomeShit Adder
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetAdder(_i, out x_abi_fn, out x_abi_ctx)); return D_668509AE.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_668509AE.Unwrap(value); Native.Throw(_vt.SetAdder(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public int Property
        {
            get {  int x; Native.Throw(_vt.GetProperty(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetProperty(_i, value)); }  
        }

        public int ReadOnlyProperty {  get {  int x; Native.Throw(_vt.GetReadOnlyProperty(_i, out x)); return x; }  }  

        public TestStruct[] HardProperty
        {
            get {  ArrayBlob x_abi; Native.Throw(_vt.GetHardProperty(_i, out x_abi.Ptr, out x_abi.Count)); return MConv.FromABI_463C8218(x_abi.Ptr, x_abi.Count); }   
            set {  var value_abi = ABI.GluonTest.TestStruct.ToABI_Array(value); Native.Throw(_vt.SetHardProperty(_i, value_abi, value_abi.Length)); }  
        }

        public Func<char,int,string>[] HarderProperty
        {
            get {  ArrayBlob x_abi; Native.Throw(_vt.GetHarderProperty(_i, out x_abi.Ptr, out x_abi.Count)); return MConv.FromABI_827F05B4(x_abi.Ptr, x_abi.Count); }   
            set {  var value_abi = D_827F05B4.ToABI_Array(value); Native.Throw(_vt.SetHarderProperty(_i, value_abi, value_abi.Length)); }  
        }

        public Func<string,char> DumbDelegate
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetDumbDelegate(_i, out x_abi_fn, out x_abi_ctx)); return D_29454153.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_29454153.Unwrap(value); Native.Throw(_vt.SetDumbDelegate(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public void Methody()
        {
            Native.Throw(_vt.Methody1(_i));
        }

        public int RetMethod()
        {
            int ___ret;
            Native.Throw(_vt.RetMethod2(_i, out ___ret));
            return ___ret;
        }

        public void OutMethod(out int x)
        {
            Native.Throw(_vt.OutMethod3(_i, out x));
        }

        public void RefMethod(ref string thing)
        {
            Native.Throw(_vt.RefMethod4(_i, ref thing));
        }

        public void Ref2(ref ITestClass thing)
        {
            var thing_abi = MConv_.ToABI_Object(thing);
            Native.Throw(_vt.Ref25(_i, ref thing_abi));
            thing = MConv_.FromABI_Object<ITestClass>(thing_abi);
        }

        public void Ref3(TestStruct thing)
        {
            Native.Throw(_vt.Ref36(_i, ABI.GluonTest.TestStruct.ToABI(thing)));
        }

        public int[] ComplexMethod(ref string a, IntPtr _dumb, IntPtr p, out char[] fart)
        {
            ArrayBlob fart_abi;
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ComplexMethod7(_i, ref a, _dumb, p, out fart_abi.Ptr, out fart_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            fart = MConv_.FromABI_char(fart_abi.Ptr, fart_abi.Count);
            return MConv_.FromABI_int(___ret_abi.Ptr, ___ret_abi.Count);
        }

        #region Internal

        internal ITestClass(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ITestClass>(_i);
            _BigEvent_abi = D_5D02415F.Unwrap(_Call_BigEvent);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_ITestClass_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static ID3DBlob()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        #region Internal

        internal ID3DBlob(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ID3DBlob>(_i);
            Init();
        }

        IntPtr _i;
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

        static Generator()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public int ChannelCount {  get {  int x; Native.Throw(_vt.GetChannelCount(_i, out x)); return x; }  }  

        public int SampleRate {  get {  int x; Native.Throw(_vt.GetSampleRate(_i, out x)); return x; }  }  

        public void Initialize(int channels, int sampleRate)
        {
            Native.Throw(_vt.Initialize1(_i, channels, sampleRate));
        }

        public void Eval(double t, ref double outSample)
        {
            Native.Throw(_vt.Eval2(_i, t, ref outSample));
        }

        public void EvalBuffer(double t, SignalBuffer inoutBuffer)
        {
            Native.Throw(_vt.EvalBuffer3(_i, t, (inoutBuffer == null ? IntPtr.Zero : inoutBuffer.NativePtr)));
        }

        #region Internal

        internal Generator(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.Generator>(_i);
            Init();
        }

        IntPtr _i;
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

        public int ChannelCount {  get {  int x; Native.Throw(_vt.GetChannelCount(_i, out x)); return x; }  }  

        public int SampleCount {  get {  int x; Native.Throw(_vt.GetSampleCount(_i, out x)); return x; }  }  

        public int CopyTo(double[] arr)
        {
            int ___ret;
            Native.Throw(_vt.CopyTo1(_i, arr, arr.Length, out ___ret));
            return ___ret;
        }

        public int CopyTo(float[] arr)
        {
            int ___ret;
            Native.Throw(_vt.CopyTo2(_i, arr, arr.Length, out ___ret));
            return ___ret;
        }

        public int CopyTo(short[] arr)
        {
            int ___ret;
            Native.Throw(_vt.CopyTo3(_i, arr, arr.Length, out ___ret));
            return ___ret;
        }

        #region Internal

        internal SignalBuffer(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SignalBuffer>(_i);
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

        IntPtr _i;
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

        public double Phase(double t)
        {
            double ___ret;
            Native.Throw(_vt.Phase1(_i, t, out ___ret));
            return ___ret;
        }

        #region Internal

        internal Waveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.Waveform>(_i);
            Init();
        }

        private static IntPtr Make(double[] samples)
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_Waveform_1(samples, samples.Length, out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static SinusoidalWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SinusoidalWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal SinusoidalWaveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SinusoidalWaveform>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SinusoidalWaveform_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static SquareWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SquareWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal SquareWaveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SquareWaveform>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SquareWaveform_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static TriangleWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public TriangleWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal TriangleWaveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.TriangleWaveform>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_TriangleWaveform_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static SawtoothRightWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SawtoothRightWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal SawtoothRightWaveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SawtoothRightWaveform>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SawtoothRightWaveform_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static SawtoothLeftWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SawtoothLeftWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal SawtoothLeftWaveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SawtoothLeftWaveform>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SawtoothLeftWaveform_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static GTone()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public GTone() : this(new AbiPtr(Make())) {  Init(); }  

        public double Frequency
        {
            get {  double x; Native.Throw(_vt.GetFrequency(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetFrequency(_i, value)); }  
        }

        public Waveform Waveform
        {
            get {  IntPtr x_abi; Native.Throw(_vt.GetWaveform(_i, out x_abi)); return GluonObject.Of<Waveform>(x_abi); }   
            set {  Native.Throw(_vt.SetWaveform(_i, (value == null ? IntPtr.Zero : value.NativePtr))); }  
        }

        public double Amplitude
        {
            get {  double x; Native.Throw(_vt.GetAmplitude(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetAmplitude(_i, value)); }  
        }

        #region Internal

        internal GTone(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.GTone>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_GTone_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static GWhiteNoise()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public GWhiteNoise() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal GWhiteNoise(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.GWhiteNoise>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_GWhiteNoise_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
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

        static NoiseEngine()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public NoiseEngine() : this(new AbiPtr(Make())) {  Init(); }  

        public string Error {  get {  string x; Native.Throw(_vt.GetError(_i, out x)); return x; }  }  

        public NoiseEngineState State {  get {  NoiseEngineState x; Native.Throw(_vt.GetState(_i, out x)); return x; }  }  

        public int SampleRate
        {
            get {  int x; Native.Throw(_vt.GetSampleRate(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetSampleRate(_i, value)); }  
        }

        public NoiseChannels Channels
        {
            get {  NoiseChannels x; Native.Throw(_vt.GetChannels(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetChannels(_i, value)); }  
        }

        public int BlockDuration
        {
            get {  int x; Native.Throw(_vt.GetBlockDuration(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetBlockDuration(_i, value)); }  
        }

        public NoiseDistribution Distribution
        {
            get {  NoiseDistribution x; Native.Throw(_vt.GetDistribution(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetDistribution(_i, value)); }  
        }

        public bool IsFilterEnabled
        {
            get {  bool x; Native.Throw(_vt.GetIsFilterEnabled(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetIsFilterEnabled(_i, value)); }  
        }

        public void Play()
        {
            Native.Throw(_vt.Play1(_i));
        }

        public void Pause()
        {
            Native.Throw(_vt.Pause2(_i));
        }

        public SignalBuffer GetPlot(double durationSeconds, PlotType type)
        {
            IntPtr ___ret_abi;
            Native.Throw(_vt.GetPlot3(_i, durationSeconds, type, out ___ret_abi));
            return GluonObject.Of<SignalBuffer>(___ret_abi);
        }

        #region Internal

        internal NoiseEngine(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.NoiseEngine>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_NoiseEngine_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.NoiseEngine _vt;
        static Guid _ID = new Guid("5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931");

        #endregion
    }
}
