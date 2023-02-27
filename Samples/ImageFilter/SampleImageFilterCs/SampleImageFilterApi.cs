/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.SampleImageFilterApi;
using ABI.Gluon;
using SampleImageFilterApi;
using SampleImageFilter;

namespace ABI.SampleImageFilterApi
{
    public static class Native
    {
        static Native()
        {
            GluonObject.RegisterType<global::SampleImageFilter.BlackAndWhiteFilter>(new Guid("0dfa7880-88d5-66c4-a63b-716e524d7a86"), native => new global::SampleImageFilter.BlackAndWhiteFilter(new AbiPtr(native)));
            GluonObject.RegisterType<global::SampleImageFilter.SampleImage>(new Guid("659f14e9-9bab-42c3-8132-47615e391fc0"), native => new global::SampleImageFilter.SampleImage(new AbiPtr(native)));
        }

        public const string DllPath = "SampleImageFilterCpp.dll";

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

    internal struct Thing
    {
        public IntPtr A;
        public int cc;
        public double boo;

        public static Thing ToABI(global::SampleImageFilterApi.Thing x)
        {
            return new Thing
            {
                A = MConv_.ToABI_string(x.A),
                cc = x.cc,
                boo = x.boo
            };
        }

        public static global::SampleImageFilterApi.Thing FromABI(Thing x)
        {
            return new global::SampleImageFilterApi.Thing
            {
                A = MConv_.FromABI_string(x.A),
                cc = x.cc,
                boo = x.boo
            };
        }

        public static Thing[] ToABI_Array(global::SampleImageFilterApi.Thing[] x)
        {
            if (x == null) return null;
            var r = new Thing[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = ToABI(x[i]);
            return r;
        }

        public static global::SampleImageFilterApi.Thing[] FromABI_Array(Thing[] x)
        {
            if (x == null) return null;
            var r = new global::SampleImageFilterApi.Thing[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = FromABI(x[i]);
            return r;
        }
    }

    public class D_5C0C3D4D : Gluon.D_Base
    {
        private NativeDel _abi;
        internal static readonly NativeDel FnDel = new NativeDel(Fn);
        public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
        internal delegate HResult NativeDel(IntPtr __i_, IntPtr obj);

        private static HResult Fn(IntPtr __i_, IntPtr obj)
        {
            var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as Action<global::SampleImageFilter.SampleImage>;

            try
            {
                del(GluonObject.Of<global::SampleImageFilter.SampleImage>(obj));
                return HResult.S_OK;
            }

            catch (Exception e)
            {
                return GluonObject.ExceptionToHResult(e);
            }
        }

        private D_5C0C3D4D(IntPtr fn, IntPtr ctx) : base(ctx)
        {
            _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
        }

        public static Action<global::SampleImageFilter.SampleImage> Wrap(IntPtr fn, IntPtr ctx)
        {
            if (fn == IntPtr.Zero)
                return null;
            else if (fn == D_5C0C3D4D.FnPtr)
                return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as Action<global::SampleImageFilter.SampleImage>;
            else
                return new D_5C0C3D4D(fn, ctx).Call;
        }

        public static DelegateBlob Unwrap(Action<global::SampleImageFilter.SampleImage> x)
        {
            return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
                new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
        }

        public static DelegateBlob[] ToABI_Array(Action<global::SampleImageFilter.SampleImage>[] x)
        {
            if (x == null) return null;
            var r = new DelegateBlob[x.Length];
            for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
            return r;
        }

        public static Action<global::SampleImageFilter.SampleImage>[] FromABI_Array(DelegateBlob[] x)
        {
            if (x == null) return null;
            var r = new Action<global::SampleImageFilter.SampleImage>[x.Length];

            for (int i = 0; i < x.Length; i++)
                r[i] = Wrap(x[i].Fn, x[i].Ctx);
            return r;
        }

        private void Call(global::SampleImageFilter.SampleImage obj)
        {
            Native.Throw((int)_abi(_ctx, (obj == null ? IntPtr.Zero : ((global::SampleImageFilter.SampleImage)obj).IPtr)));
        }
    }

    internal static partial class MConv
    {
    }
}

namespace ABI.SampleImageFilter
{
    [Guid("2a72ca9e-829a-63fc-9de8-af767297fd57")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BlackAndWhiteFilter
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly BeginFiltering_sig BeginFiltering;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int BeginFiltering_sig(IntPtr __i_, IntPtr image);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetIsFiltering_sig GetIsFiltering;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetIsFiltering_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] out bool ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly AddFilteringCompleteHandler_sig AddFilteringCompleteHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int AddFilteringCompleteHandler_sig(IntPtr __i_, IntPtr handler, IntPtr handler_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RemoveFilteringCompleteHandler_sig RemoveFilteringCompleteHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RemoveFilteringCompleteHandler_sig(IntPtr __i_, IntPtr handler, IntPtr handler_context);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_SampleImageFilter_BlackAndWhiteFilter_1(out IntPtr newInstance);
    }

    [Guid("4217a6f7-91e4-47fb-bae1-99797ee39811")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SampleImage
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyDataTo_sig CopyDataTo;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyDataTo_sig(IntPtr __i_, out IntPtr data, out int data_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Save_sig Save;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Save_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string path);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetThing_sig GetThing;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetThing_sig(IntPtr __i_, out ABI.SampleImageFilterApi.Thing ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly AnotherThing_sig AnotherThing;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int AnotherThing_sig(IntPtr __i_, out global::SampleImageFilterApi.Thing2 ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetWidth_sig GetWidth;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetWidth_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetHeight_sig GetHeight;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetHeight_sig(IntPtr __i_, out int ___ret);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_SampleImageFilter_SampleImage_1([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data, int data_count, int width, int height, out IntPtr newInstance);
    }
}

namespace SampleImageFilterApi
{
    public struct Thing
    {
        public string A;
        public int cc;
        public double boo;

        public Thing(string _A, int _cc, double _boo)
        {
            A = _A;
            cc = _cc;
            boo = _boo;
        }
    }

    public struct Thing2
    {
        public int a;
        public int b;

        public Thing2(int _a, int _b)
        {
            a = _a;
            b = _b;
        }
    }
}

namespace SampleImageFilter
{
    [Guid("0dfa7880-88d5-66c4-a63b-716e524d7a86")]
    [GluonGenerated(abi: typeof(global::ABI.SampleImageFilter.BlackAndWhiteFilter))]
    public partial class BlackAndWhiteFilter : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static BlackAndWhiteFilter()
        {
            ABI.SampleImageFilterApi.Native.RegisterTypes();
            StaticInit();
        }

        public BlackAndWhiteFilter() : this(new AbiPtr(Make())) { _FilteringComplete_abi = D_5C0C3D4D.Unwrap(_Call_FilteringComplete);  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);
            if(_FilteringComplete != null) _vt.RemoveFilteringCompleteHandler(IPtr, _FilteringComplete_abi.Fn, _FilteringComplete_abi.Ctx);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region FilteringComplete

        public event Action<SampleImage> FilteringComplete
        {
            add
            {
                Check();
                if(_FilteringComplete == null)
                    _vt.AddFilteringCompleteHandler(IPtr, _FilteringComplete_abi.Fn, _FilteringComplete_abi.Ctx);

                _FilteringComplete += value;
            }
            remove
            {
                Check();
                _FilteringComplete -= value;
                if(_FilteringComplete == null)
                    _vt.RemoveFilteringCompleteHandler(IPtr, _FilteringComplete_abi.Fn, _FilteringComplete_abi.Ctx);
            }
        }

        private void _Call_FilteringComplete(SampleImage obj)
        {
            try
            {
                _FilteringComplete(obj);
            }
            catch(Exception ___ex)
            {
                CallbackEventExceptionHandler?.Invoke(___ex);
            }
        }

        private Action<SampleImage> _FilteringComplete;
        private DelegateBlob _FilteringComplete_abi;

        #endregion

        public bool IsFiltering {  get {  Check(); bool x; Native.Throw(_vt.GetIsFiltering(IPtr, out x)); return x; }  }  

        public void BeginFiltering(SampleImage image)
        {
            Check();
            Native.Throw(_vt.BeginFiltering(IPtr, (image == null ? IntPtr.Zero : ((SampleImage)image).IPtr)));
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal BlackAndWhiteFilter(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.SampleImageFilter.BlackAndWhiteFilter>(IPtr);
            _FilteringComplete_abi = D_5C0C3D4D.Unwrap(_Call_FilteringComplete);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.SampleImageFilter.Factory.Create_SampleImageFilter_BlackAndWhiteFilter_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.SampleImageFilter.BlackAndWhiteFilter _vt;
        static Guid _ID = new Guid("2a72ca9e-829a-63fc-9de8-af767297fd57");

        #endregion
    }

    [Guid("659f14e9-9bab-42c3-8132-47615e391fc0")]
    [GluonGenerated(abi: typeof(global::ABI.SampleImageFilter.SampleImage))]
    public partial class SampleImage : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static SampleImage()
        {
            ABI.SampleImageFilterApi.Native.RegisterTypes();
            StaticInit();
        }

        public SampleImage(byte[] data, int width, int height)
            : this(new AbiPtr(Make(data, width, height)))
        {

            Init();
        }

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public int Width {  get {  Check(); int x; Native.Throw(_vt.GetWidth(IPtr, out x)); return x; }  }  

        public int Height {  get {  Check(); int x; Native.Throw(_vt.GetHeight(IPtr, out x)); return x; }  }  

        public void CopyDataTo(out byte[] data)
        {
            Check();
            ArrayBlob data_abi;
            Native.Throw(_vt.CopyDataTo(IPtr, out data_abi.Ptr, out data_abi.Count));
            data = MConv_.FromABI_byte(data_abi.Ptr, data_abi.Count);
        }

        public void Save(string path)
        {
            Check();
            Native.Throw(_vt.Save(IPtr, path));
        }

        public global::SampleImageFilterApi.Thing GetThing()
        {
            Check();
            ABI.SampleImageFilterApi.Thing ___ret_abi;
            Native.Throw(_vt.GetThing(IPtr, out ___ret_abi));
            return ABI.SampleImageFilterApi.Thing.FromABI(___ret_abi);
        }

        public global::SampleImageFilterApi.Thing2 AnotherThing()
        {
            Check();
            global::SampleImageFilterApi.Thing2 ___ret;
            Native.Throw(_vt.AnotherThing(IPtr, out ___ret));
            return ___ret;
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal SampleImage(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.SampleImageFilter.SampleImage>(IPtr);

            Init();
        }

        private static IntPtr Make(byte[] data, int width, int height)
        {
            IntPtr instance_abi;
            Native.Throw(ABI.SampleImageFilter.Factory.Create_SampleImageFilter_SampleImage_1(data, data.Length, width, height, out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.SampleImageFilter.SampleImage _vt;
        static Guid _ID = new Guid("4217a6f7-91e4-47fb-bae1-99797ee39811");

        #endregion
    }
}
