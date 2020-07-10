/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;

[global::System.Runtime.InteropServices.ComImport]

[global::System.Runtime.InteropServices.Guid(@"8BA5FB08-5195-40e2-AC58-0D989C3A0102")]

[global::System.Runtime.InteropServices.InterfaceType(1)]

[Guid("3c45ab9f-8487-4fde-92eb-9d58728fec74")]
[StructLayout(LayoutKind.Sequential)]
internal struct IBlob
{
    public readonly VTUnknown Unknown;
}

internal static partial class Factory
{
    [DllImport(Native.DllPath)]
    public static extern int Create_IBlob(out IntPtr newInstance);
}
