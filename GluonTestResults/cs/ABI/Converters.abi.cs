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
    public class D_827F05B1 : Gluon.D_Base
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

        private D_827F05B1(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_827F05B1.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int,int>;
            else
                return new D_827F05B1(fn, ctx).Call;
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

    public class D_BD6C0A4D : Gluon.D_Base
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

        private D_BD6C0A4D(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegate Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_BD6C0A4D.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegate;
            else
                return new D_BD6C0A4D(fn, ctx).Call;
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

    public class D_67C6D6DF : Gluon.D_Base
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

        private D_67C6D6DF(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitivesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_67C6D6DF.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitivesCB;
            else
                return new D_67C6D6DF(fn, ctx).Call;
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

    public class D_7A2B6D2B : Gluon.D_Base
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

        private D_7A2B6D2B(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_7A2B6D2B.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringsCB;
            else
                return new D_7A2B6D2B(fn, ctx).Call;
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

    public class D_DF8B3B28 : Gluon.D_Base
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

        private D_DF8B3B28(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_DF8B3B28.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructsCB;
            else
                return new D_DF8B3B28(fn, ctx).Call;
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

    public class D_625CB5E : Gluon.D_Base
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

        private D_625CB5E(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_625CB5E.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructsCB;
            else
                return new D_625CB5E(fn, ctx).Call;
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

    public class D_87064FFA : Gluon.D_Base
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

        private D_87064FFA(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_87064FFA.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectsCB;
            else
                return new D_87064FFA(fn, ctx).Call;
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

    public class D_7451AE96 : Gluon.D_Base
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
                var inTest_wrap = D_BD6C0A4D.Wrap(inTest, inTest_context);
                global::GluonTest.NamedDelegate outTest_wrap;
                var refTest_wrap = D_BD6C0A4D.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_BD6C0A4D.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_BD6C0A4D.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_BD6C0A4D.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
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

        private D_7451AE96(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_7451AE96.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegatesCB;
            else
                return new D_7451AE96(fn, ctx).Call;
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
            var inTest_abi = D_BD6C0A4D.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_BD6C0A4D.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_BD6C0A4D.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_BD6C0A4D.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_BD6C0A4D.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }
    }

    public class D_61217487 : Gluon.D_Base
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
                var inTest_wrap = D_5D02415A.Wrap(inTest, inTest_context);
                Action<Func<int,int>> outTest_wrap;
                var refTest_wrap = D_2945414B.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_5D02415B.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_2945414B.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_2945414C.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
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

        private D_61217487(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_61217487.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegatesCB;
            else
                return new D_61217487(fn, ctx).Call;
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
            var inTest_abi = D_5D02415A.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_2945414B.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_5D02415B.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_2945414B.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_2945414C.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }
    }

    public class D_2945414C : Gluon.D_Base
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

        private D_2945414C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_2945414C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int>;
            else
                return new D_2945414C(fn, ctx).Call;
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

    public class D_5D02415A : Gluon.D_Base
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

        private D_5D02415A(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5D02415A.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<string>;
            else
                return new D_5D02415A(fn, ctx).Call;
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

    public class D_5D02415B : Gluon.D_Base
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
                var obj_wrap = D_2945414C.Wrap(obj, obj_context);
                del(obj_wrap);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_5D02415B(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<Func<int,int>> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5D02415B.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<Func<int,int>>;
            else
                return new D_5D02415B(fn, ctx).Call;
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
            var obj_abi = D_2945414C.Unwrap(obj);
            Native.Throw((int)_abi(_ctx, obj_abi.Fn, obj_abi.Ctx));
        }
    }

    public class D_2945414B : Gluon.D_Base
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

        private D_2945414B(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string[]> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_2945414B.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string[]>;
            else
                return new D_2945414B(fn, ctx).Call;
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

    public class D_2C74C8B4 : Gluon.D_Base
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

        private D_2C74C8B4(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitiveArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_2C74C8B4.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitiveArraysCB;
            else
                return new D_2C74C8B4(fn, ctx).Call;
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

    public class D_1061E859 : Gluon.D_Base
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

        private D_1061E859(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1061E859.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringArraysCB;
            else
                return new D_1061E859(fn, ctx).Call;
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

    public class D_1C12DC57 : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_6FB3D833(refTest, refTest_count);
                var ___ret_wrap = del(inTest, out global::GluonTest.BlittableStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_6FB3D833(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_6FB3D833(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_6FB3D833(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_1C12DC57(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1C12DC57.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructArraysCB;
            else
                return new D_1C12DC57(fn, ctx).Call;
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
            var refTest_abi = MConv.ToABI_6FB3D833(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_6FB3D833(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_6FB3D833(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_6FB3D833(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_14F875F7 : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_7301BA3C(refTest, refTest_count);
                var ___ret_wrap = del(ComplexStruct.FromABI_Array(inTest), out global::GluonTest.ComplexStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_7301BA3C(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_7301BA3C(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_7301BA3C(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_14F875F7(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_14F875F7.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructArraysCB;
            else
                return new D_14F875F7(fn, ctx).Call;
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
            var refTest_abi = MConv.ToABI_7301BA3C(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7301BA3C(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7301BA3C(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7301BA3C(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_A1A08E73 : Gluon.D_Base
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

        private D_A1A08E73(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_A1A08E73.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectArraysCB;
            else
                return new D_A1A08E73(fn, ctx).Call;
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

    public class D_B2A7C511 : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_BD6C0A4D(refTest, refTest_count);
                var ___ret_wrap = del(D_BD6C0A4D.FromABI_Array(inTest), out global::GluonTest.NamedDelegate[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_BD6C0A4D(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_BD6C0A4D(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_BD6C0A4D(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_B2A7C511(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_B2A7C511.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegateArraysCB;
            else
                return new D_B2A7C511(fn, ctx).Call;
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
            var inTest_abi = D_BD6C0A4D.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_BD6C0A4D(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_BD6C0A4D(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_BD6C0A4D(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_BD6C0A4D(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_DC21B22B : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_2945414B(refTest, refTest_count);
                var ___ret_wrap = del(D_5D02415A.FromABI_Array(inTest), out Action<Func<int,int>>[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_5D02415B(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_2945414B(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_2945414C(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_DC21B22B(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_DC21B22B.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegateArraysCB;
            else
                return new D_DC21B22B(fn, ctx).Call;
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
            var inTest_abi = D_5D02415A.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_2945414B(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_5D02415B(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_2945414B(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_2945414C(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_2945414A : Gluon.D_Base
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

        private D_2945414A(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<double,double> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_2945414A.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<double,double>;
            else
                return new D_2945414A(fn, ctx).Call;
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

    public class D_2945414D : Gluon.D_Base
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

        private D_2945414D(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_2945414D.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string>;
            else
                return new D_2945414D(fn, ctx).Call;
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

    public class D_668509AD : Gluon.D_Base
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

        private D_668509AD(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.AddSomeShit Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_668509AD.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.AddSomeShit;
            else
                return new D_668509AD(fn, ctx).Call;
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

    public class D_827F05B2 : Gluon.D_Base
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

        private D_827F05B2(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char,int,string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_827F05B2.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char,int,string>;
            else
                return new D_827F05B2(fn, ctx).Call;
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

    public class D_2945414E : Gluon.D_Base
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

        private D_2945414E(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<string,char> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_2945414E.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<string,char>;
            else
                return new D_2945414E(fn, ctx).Call;
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

    public class D_5D02415C : Gluon.D_Base
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

        private D_5D02415C(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5D02415C.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<int>;
            else
                return new D_5D02415C(fn, ctx).Call;
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
        public static global::GluonTest.BlittableStruct[] FromABI_6FB3D833(IntPtr data, int count)
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

        public static ArrayBlob ToABI_6FB3D833(global::GluonTest.BlittableStruct[] arr)
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

        public static void FreeABI_6FB3D833(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.ComplexStruct[] FromABI_7301BA3C(IntPtr data, int count)
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

        public static ArrayBlob ToABI_7301BA3C(global::GluonTest.ComplexStruct[] arr)
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

        public static void FreeABI_7301BA3C(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.NamedDelegate[] FromABI_BD6C0A4D(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new global::GluonTest.NamedDelegate[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_BD6C0A4D.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_BD6C0A4D(global::GluonTest.NamedDelegate[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_BD6C0A4D.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_BD6C0A4D(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<int,int>[] FromABI_2945414C(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<int,int>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_2945414C.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_2945414C(Func<int,int>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_2945414C.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_2945414C(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<string>[] FromABI_5D02415A(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_5D02415A.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5D02415A(Action<string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_5D02415A.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_5D02415A(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<Func<int,int>>[] FromABI_5D02415B(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<Func<int,int>>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_5D02415B.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5D02415B(Action<Func<int,int>>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_5D02415B.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_5D02415B(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string[]>[] FromABI_2945414B(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string[]>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_2945414B.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_2945414B(Func<char[],string[]>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_2945414B.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_2945414B(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string>[] FromABI_2945414D(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_2945414D.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_2945414D(Func<char[],string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_2945414D.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_2945414D(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.TestStruct[] FromABI_463C8217(IntPtr data, int count)
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

        public static ArrayBlob ToABI_463C8217(global::GluonTest.TestStruct[] arr)
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

        public static void FreeABI_463C8217(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char,int,string>[] FromABI_827F05B2(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char,int,string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_827F05B2.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_827F05B2(Func<char,int,string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_827F05B2.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_827F05B2(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }
    }
}
