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
    [Guid("72865ffb-b2a3-6ef7-bc60-75474a5369ca")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SawtoothRightWaveform))]
    public partial class SawtoothRightWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static SawtoothRightWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SawtoothRightWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal SawtoothRightWaveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SawtoothRightWaveform>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SawtoothRightWaveform_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.SawtoothRightWaveform _vt;
        static Guid _ID = new Guid("550eede5-b8ec-6bcf-87b3-ab5f6a89ee1b");

        #endregion
    }
}
