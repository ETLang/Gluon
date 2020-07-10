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
    [Guid("503de1f8-b1dc-59cd-80aa-bc5c1cfa9f1b")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SinusoidalWaveform
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SinusoidalWaveform_1(out IntPtr newInstance);
    }
}
