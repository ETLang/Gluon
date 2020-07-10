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
    [Guid("5910ede5-a4ed-5dec-90a0-a8567796831b")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SawtoothLeftWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SawtoothLeftWaveform_1(out IntPtr newInstance);
    }
}
