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
}
