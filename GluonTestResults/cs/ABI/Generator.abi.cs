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
    [Guid("3c2eeae5-d08b-3cbb-e6c5-da3d1cea9e15")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct Generator
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Initialize1_sig Initialize1;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Initialize1_sig(IntPtr __i_, int channels, int sampleRate);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Eval2_sig Eval2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Eval2_sig(IntPtr __i_, double t, ref double outSample);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly EvalBuffer3_sig EvalBuffer3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int EvalBuffer3_sig(IntPtr __i_, double t, IntPtr inoutBuffer);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannelCount_sig GetChannelCount;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannelCount_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleRate_sig GetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleRate_sig(IntPtr __i_, out int ___ret);
    }
}
