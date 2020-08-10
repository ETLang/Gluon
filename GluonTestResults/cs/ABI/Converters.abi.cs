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
    public class D_6FD213D8 : Gluon.D_Base
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

        private D_6FD213D8(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_6FD213D8.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int,int>;
            else
                return new D_6FD213D8(fn, ctx).Call;
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

    public class D_F8ED26DC : Gluon.D_Base
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

        private D_F8ED26DC(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegate Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F8ED26DC.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegate;
            else
                return new D_F8ED26DC(fn, ctx).Call;
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

    public class D_1B83CCC7 : Gluon.D_Base
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

        private D_1B83CCC7(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitivesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_1B83CCC7.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitivesCB;
            else
                return new D_1B83CCC7(fn, ctx).Call;
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

    public class D_E24BCA45 : Gluon.D_Base
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

        private D_E24BCA45(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_E24BCA45.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringsCB;
            else
                return new D_E24BCA45(fn, ctx).Call;
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

    public class D_CA433403 : Gluon.D_Base
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

        private D_CA433403(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_CA433403.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructsCB;
            else
                return new D_CA433403(fn, ctx).Call;
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

    public class D_10105E23 : Gluon.D_Base
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

        private D_10105E23(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_10105E23.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructsCB;
            else
                return new D_10105E23(fn, ctx).Call;
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

    public class D_95E0837B : Gluon.D_Base
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

        private D_95E0837B(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectsCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_95E0837B.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectsCB;
            else
                return new D_95E0837B(fn, ctx).Call;
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

    public class D_F2E7AE0E : Gluon.D_Base
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
                var inTest_wrap = D_F8ED26DC.Wrap(inTest, inTest_context);
                global::GluonTest.NamedDelegate outTest_wrap;
                var refTest_wrap = D_F8ED26DC.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_F8ED26DC.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_F8ED26DC.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_F8ED26DC.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
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

        private D_F2E7AE0E(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F2E7AE0E.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegatesCB;
            else
                return new D_F2E7AE0E(fn, ctx).Call;
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
            var inTest_abi = D_F8ED26DC.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_F8ED26DC.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_F8ED26DC.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_F8ED26DC.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_F8ED26DC.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }
    }

    public class D_D744D574 : Gluon.D_Base
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
                var inTest_wrap = D_5C0C3D4F.Wrap(inTest, inTest_context);
                Action<Func<int,int>> outTest_wrap;
                var refTest_wrap = D_F757A1F1.Wrap(refTest, refTest_context);
                var ___ret_wrap = del(inTest_wrap, out outTest_wrap, ref refTest_wrap);
                var outTest_abi = D_5C0C3D50.Unwrap(outTest_wrap); outTest = outTest_abi.Fn; outTest_context = outTest_abi.Ctx;
                var refTest_abi = D_F757A1F1.Unwrap(refTest_wrap); refTest = refTest_abi.Fn; refTest_context = refTest_abi.Ctx;
                var ___ret_abi = D_F757A1F2.Unwrap(___ret_wrap); ___ret = ___ret_abi.Fn; ___ret_context = ___ret_abi.Ctx;
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

        private D_D744D574(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegatesCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_D744D574.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegatesCB;
            else
                return new D_D744D574(fn, ctx).Call;
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
            var inTest_abi = D_5C0C3D4F.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_F757A1F1.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw((int)_abi(_ctx, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_5C0C3D50.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_F757A1F1.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_F757A1F2.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }
    }

    public class D_F757A1F2 : Gluon.D_Base
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

        private D_F757A1F2(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<int,int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F2.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<int,int>;
            else
                return new D_F757A1F2(fn, ctx).Call;
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

    public class D_5C0C3D4F : Gluon.D_Base
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

        private D_5C0C3D4F(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5C0C3D4F.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<string>;
            else
                return new D_5C0C3D4F(fn, ctx).Call;
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

    public class D_5C0C3D50 : Gluon.D_Base
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
                var obj_wrap = D_F757A1F2.Wrap(obj, obj_context);
                del(obj_wrap);
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_5C0C3D50(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<Func<int,int>> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5C0C3D50.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<Func<int,int>>;
            else
                return new D_5C0C3D50(fn, ctx).Call;
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
            var obj_abi = D_F757A1F2.Unwrap(obj);
            Native.Throw((int)_abi(_ctx, obj_abi.Fn, obj_abi.Ctx));
        }
    }

    public class D_F757A1F1 : Gluon.D_Base
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

        private D_F757A1F1(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string[]> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F1.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string[]>;
            else
                return new D_F757A1F1(fn, ctx).Call;
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

    public class D_C30682FE : Gluon.D_Base
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

        private D_C30682FE(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.PrimitiveArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_C30682FE.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.PrimitiveArraysCB;
            else
                return new D_C30682FE(fn, ctx).Call;
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

    public class D_B2F37842 : Gluon.D_Base
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

        private D_B2F37842(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.StringArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_B2F37842.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.StringArraysCB;
            else
                return new D_B2F37842(fn, ctx).Call;
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

    public class D_B28180A6 : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_7480843D(refTest, refTest_count);
                var ___ret_wrap = del(inTest, out global::GluonTest.BlittableStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_7480843D(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_7480843D(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_7480843D(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_B28180A6(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.SimpleStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_B28180A6.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.SimpleStructArraysCB;
            else
                return new D_B28180A6(fn, ctx).Call;
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
            var refTest_abi = MConv.ToABI_7480843D(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7480843D(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7480843D(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7480843D(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_EE6D3DFC : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_A11DF27A(refTest, refTest_count);
                var ___ret_wrap = del(ComplexStruct.FromABI_Array(inTest), out global::GluonTest.ComplexStruct[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_A11DF27A(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_A11DF27A(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_A11DF27A(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_EE6D3DFC(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ComplexStructArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_EE6D3DFC.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ComplexStructArraysCB;
            else
                return new D_EE6D3DFC(fn, ctx).Call;
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
            var refTest_abi = MConv.ToABI_A11DF27A(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_A11DF27A(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_A11DF27A(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_A11DF27A(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_4388047E : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_7C319F65(refTest, refTest_count);
                var ___ret_wrap = del(GluonObject.ArrayWrap<global::GluonTest.DummyClass>(inTest), out global::GluonTest.DummyClass[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_7C319F65(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_7C319F65(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_7C319F65(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_4388047E(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.ObjectArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_4388047E.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.ObjectArraysCB;
            else
                return new D_4388047E(fn, ctx).Call;
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
            ArrayBlob refTest_abi = MConv.ToABI_7C319F65(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7C319F65(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7C319F65(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7C319F65(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_CCD79227 : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_F8ED26DC(refTest, refTest_count);
                var ___ret_wrap = del(D_F8ED26DC.FromABI_Array(inTest), out global::GluonTest.NamedDelegate[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_F8ED26DC(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_F8ED26DC(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_F8ED26DC(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_CCD79227(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.NamedDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_CCD79227.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.NamedDelegateArraysCB;
            else
                return new D_CCD79227(fn, ctx).Call;
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
            var inTest_abi = D_F8ED26DC.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_F8ED26DC(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_F8ED26DC(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_F8ED26DC(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_F8ED26DC(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_F5BD3F9B : Gluon.D_Base
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
                var refTest_wrap = MConv.FromABI_F757A1F1(refTest, refTest_count);
                var ___ret_wrap = del(D_5C0C3D4F.FromABI_Array(inTest), out Action<Func<int,int>>[] outTest_wrap, ref refTest_wrap);
                var outTest_abi = MConv.ToABI_5C0C3D50(outTest_wrap); outTest = outTest_abi.Ptr; outTest_count = outTest_abi.Count;
                var refTest_abi = MConv.ToABI_F757A1F1(refTest_wrap); refTest = refTest_abi.Ptr; refTest_count = refTest_abi.Count;
                var ___ret_abi = MConv.ToABI_F757A1F2(___ret_wrap); ___ret = ___ret_abi.Ptr; ___ret_count = ___ret_abi.Count;
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

        private D_F5BD3F9B(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.GenericDelegateArraysCB Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F5BD3F9B.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.GenericDelegateArraysCB;
            else
                return new D_F5BD3F9B(fn, ctx).Call;
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
            var inTest_abi = D_5C0C3D4F.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_F757A1F1(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw((int)_abi(_ctx, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_5C0C3D50(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_F757A1F1(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_F757A1F2(___ret_abi.Ptr, ___ret_abi.Count);
        }
    }

    public class D_F757A1F0 : Gluon.D_Base
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

        private D_F757A1F0(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<double,double> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F0.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<double,double>;
            else
                return new D_F757A1F0(fn, ctx).Call;
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

    public class D_F757A1F3 : Gluon.D_Base
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

        private D_F757A1F3(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char[],string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F3.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char[],string>;
            else
                return new D_F757A1F3(fn, ctx).Call;
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

    public class D_FBC9C527 : Gluon.D_Base
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

        private D_FBC9C527(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static global::GluonTest.AddSomeShit Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_FBC9C527.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as global::GluonTest.AddSomeShit;
            else
                return new D_FBC9C527(fn, ctx).Call;
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

    public class D_6FD213D9 : Gluon.D_Base
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

        private D_6FD213D9(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<char,int,string> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_6FD213D9.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<char,int,string>;
            else
                return new D_6FD213D9(fn, ctx).Call;
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

    public class D_F757A1F4 : Gluon.D_Base
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

        private D_F757A1F4(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Func<string,char> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_F757A1F4.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Func<string,char>;
            else
                return new D_F757A1F4(fn, ctx).Call;
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

    public class D_5C0C3D51 : Gluon.D_Base
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

        private D_5C0C3D51(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<int> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5C0C3D51.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<int>;
            else
                return new D_5C0C3D51(fn, ctx).Call;
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
        public static global::GluonTest.BlittableStruct[] FromABI_7480843D(IntPtr data, int count)
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

        public static ArrayBlob ToABI_7480843D(global::GluonTest.BlittableStruct[] arr)
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

        public static void FreeABI_7480843D(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.ComplexStruct[] FromABI_A11DF27A(IntPtr data, int count)
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

        public static ArrayBlob ToABI_A11DF27A(global::GluonTest.ComplexStruct[] arr)
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

        public static void FreeABI_A11DF27A(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.DummyClass[] FromABI_7C319F65(IntPtr data, int count)
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

        public static ArrayBlob ToABI_7C319F65(global::GluonTest.DummyClass[] arr)
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

        public static void FreeABI_7C319F65(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.NamedDelegate[] FromABI_F8ED26DC(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new global::GluonTest.NamedDelegate[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_F8ED26DC.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_F8ED26DC(global::GluonTest.NamedDelegate[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_F8ED26DC.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_F8ED26DC(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<int,int>[] FromABI_F757A1F2(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<int,int>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_F757A1F2.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_F757A1F2(Func<int,int>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_F757A1F2.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_F757A1F2(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<string>[] FromABI_5C0C3D4F(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_5C0C3D4F.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5C0C3D4F(Action<string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_5C0C3D4F.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_5C0C3D4F(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Action<Func<int,int>>[] FromABI_5C0C3D50(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Action<Func<int,int>>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_5C0C3D50.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_5C0C3D50(Action<Func<int,int>>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_5C0C3D50.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_5C0C3D50(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string[]>[] FromABI_F757A1F1(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string[]>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_F757A1F1.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_F757A1F1(Func<char[],string[]>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_F757A1F1.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_F757A1F1(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char[],string>[] FromABI_F757A1F3(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char[],string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_F757A1F3.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_F757A1F3(Func<char[],string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_F757A1F3.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_F757A1F3(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static global::GluonTest.TestStruct[] FromABI_5E297C84(IntPtr data, int count)
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

        public static ArrayBlob ToABI_5E297C84(global::GluonTest.TestStruct[] arr)
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

        public static void FreeABI_5E297C84(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

        public static Func<char,int,string>[] FromABI_6FD213D9(IntPtr data, int count)
        {
            if(data == IntPtr.Zero) return null;
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new Func<char,int,string>[count];
            for(int i = 0;i < count;i++)
            {
                var blob = Marshal.PtrToStructure<DelegateBlob>((IntPtr)((long)data + i * sz));
                r[i] = D_6FD213D9.Wrap(blob.Fn, blob.Ctx);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_6FD213D9(Func<char,int,string>[] arr)
        {
            if(arr == null) return new ArrayBlob();
            var sz = Marshal.SizeOf<DelegateBlob>();
            var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);
            for(int i = 0;i < arr.Length;i++)
            {
                var blob = D_6FD213D9.Unwrap(arr[i]);
                Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);
            }

            return r;
        }

        public static void FreeABI_6FD213D9(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }
    }
}
