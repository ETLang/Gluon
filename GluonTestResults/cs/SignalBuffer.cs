/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;

namespace GluonTest
{
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
}
