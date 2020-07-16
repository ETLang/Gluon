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
    [Guid("7e985ffb-aea2-58d4-ab73-764e574c04ca")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SawtoothLeftWaveform))]
    public partial class SawtoothLeftWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static SawtoothLeftWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SawtoothLeftWaveform() : this(new AbiPtr(Make())) {  Init(); }  

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

        internal SawtoothLeftWaveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SawtoothLeftWaveform>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SawtoothLeftWaveform_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.SawtoothLeftWaveform _vt;
        static Guid _ID = new Guid("5910ede5-a4ed-5dec-90a0-a8567796831b");

        #endregion
    }
}
