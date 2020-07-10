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
    [Guid("1bd455e0-dac4-3983-dd16-0a04611129c9")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.ID3DBlob))]
    public partial class ID3DBlob : GluonObject
    {
        static partial void StaticInit();
        partial void Init();

        static ID3DBlob()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        #region Internal

        internal ID3DBlob(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ID3DBlob>(_i);
            Init();
        }

        IntPtr _i;
        ABI.GluonTest.ID3DBlob _vt;
        static Guid _ID = new Guid("3c5ce7fe-d08b-3cbb-e6c5-d41c41cbae18");

        #endregion
    }
}
