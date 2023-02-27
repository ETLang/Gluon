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
}
