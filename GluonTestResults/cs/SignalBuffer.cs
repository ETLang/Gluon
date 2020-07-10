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
}
