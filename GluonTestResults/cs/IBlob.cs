/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;

[Guid("1bcd1981-8ec8-4ae6-a938-434052556ba5")]
[GluonGenerated(abi: typeof(global::ABI.IBlob))]
[global::System.Runtime.InteropServices.ComImport]

[global::System.Runtime.InteropServices.Guid(@"8BA5FB08-5195-40e2-AC58-0D989C3A0102")]

[global::System.Runtime.InteropServices.InterfaceType(1)]

public partial class IBlob : GluonObject
{
    static partial void StaticInit();
    partial void Init();

    static IBlob()
    {
        ABI.GluonTest.Native.RegisterTypes();
        StaticInit();
    }

    #region Internal

    internal IBlob(AbiPtr i) : base(i)
    {
        Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
        Marshal.Release(_i);
        _vt = VTUnknown.GetVTable<ABI.IBlob>(_i);
        Init();
    }

    IntPtr _i;
    ABI.IBlob _vt;
    static Guid _ID = new Guid("3c45ab9f-8487-4fde-92eb-9d58728fec74");

    #endregion
}
