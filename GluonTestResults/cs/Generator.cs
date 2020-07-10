/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;
using GluonTest;

namespace GluonTest
{
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
}
