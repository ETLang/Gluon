/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;

namespace ABI.GluonTest
{
    [Guid("3c5ce7fe-d08b-3cbb-e6c5-d41c41cbae18")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ID3DBlob
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_ID3DBlob(out IntPtr newInstance);
    }
}
