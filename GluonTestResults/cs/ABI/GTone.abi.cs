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
    [Guid("3c5c8591-d08b-3cbb-e6c5-da0c1de18974")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct GTone
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetFrequency_sig GetFrequency;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetFrequency_sig(IntPtr __i_, out double ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetFrequency_sig SetFrequency;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetFrequency_sig(IntPtr __i_, double value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetWaveform_sig GetWaveform;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetWaveform_sig(IntPtr __i_, out IntPtr ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetWaveform_sig SetWaveform;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetWaveform_sig(IntPtr __i_, IntPtr value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetAmplitude_sig GetAmplitude;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetAmplitude_sig(IntPtr __i_, out double ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetAmplitude_sig SetAmplitude;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetAmplitude_sig(IntPtr __i_, double value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_GTone_1(out IntPtr newInstance);
    }
}
