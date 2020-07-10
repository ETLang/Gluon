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
    [Guid("5a3af0d3-a2ee-3cbb-e6c5-ce3115e18d18")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SignalBuffer
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo1_sig CopyTo1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo1_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo2_sig CopyTo2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo2_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CopyTo3_sig CopyTo3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int CopyTo3_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] short[] arr, int arr_count, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannelCount_sig GetChannelCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannelCount_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleCount_sig GetSampleCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleCount_sig(IntPtr __i_, out int ___ret);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SignalBuffer_1(int samples, int channels, int alignment, out IntPtr newInstance);

        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_SignalBuffer_2(int samples, out IntPtr newInstance);
    }
}
