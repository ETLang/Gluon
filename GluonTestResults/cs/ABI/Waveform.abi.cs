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
    [Guid("3c5ce8e3-d08b-3cbb-e6c5-ca3904ea8a1b")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct Waveform
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Phase_sig Phase;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Phase_sig(IntPtr __i_, double t, out double ___ret);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_Waveform_1([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] samples, int samples_count, out IntPtr newInstance);
    }
}
