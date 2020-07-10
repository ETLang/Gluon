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
    [Guid("550eede5-b8ec-6bcf-87b3-ab5f6a89ee1b")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SawtoothRightWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SawtoothRightWaveform_1(out IntPtr newInstance);
    }
}
