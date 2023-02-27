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
    [Guid("1bd455e0-dac4-3983-dd16-0a04611129c9")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.ID3DBlob))]
    public partial class ID3DBlob : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static ID3DBlob()
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

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal ID3DBlob(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ID3DBlob>(IPtr);

            Init();
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.ID3DBlob _vt;
        static Guid _ID = new Guid("3c5ce7fe-d08b-3cbb-e6c5-d41c41cbae18");

        #endregion
    }
}
