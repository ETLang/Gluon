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
    [Guid("5d0be0fd-b5fd-53dd-94a8-c92a1bee8213")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TriangleWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_TriangleWaveform_1(out IntPtr newInstance);
    }
}
