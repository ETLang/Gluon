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
    [Guid("592ae4c6-bfed-51c9-e6c5-ce2907ee9e11")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SquareWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SquareWaveform_1(out IntPtr newInstance);
    }
}
