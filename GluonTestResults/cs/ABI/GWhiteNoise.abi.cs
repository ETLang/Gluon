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
    [Guid("4f35eadf-d0ee-3cbb-e6c5-da0f1ae69811")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct GWhiteNoise
    {
        public readonly VTUnknown Unknown;
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_GWhiteNoise_1(out IntPtr newInstance);
    }
}
