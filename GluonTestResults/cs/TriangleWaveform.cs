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
    [Guid("7a8352e3-bfb2-56e5-af7b-17323b3405c2")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.TriangleWaveform))]
    public partial class TriangleWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static TriangleWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public TriangleWaveform() : this(new AbiPtr(Make())) {  Init(); }  

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

        internal TriangleWaveform(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.TriangleWaveform>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_TriangleWaveform_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.TriangleWaveform _vt;
        static Guid _ID = new Guid("5d0be0fd-b5fd-53dd-94a8-c92a1bee8213");

        #endregion
    }
}
