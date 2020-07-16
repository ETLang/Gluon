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
    [Guid("5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct NoiseEngine
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Play_sig Play;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Play_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Pause_sig Pause;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Pause_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPlot_sig GetPlot;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPlot_sig(IntPtr __i_, double durationSeconds, global::GluonTest.PlotType type, out IntPtr ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetError_sig GetError;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetError_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetState_sig GetState;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetState_sig(IntPtr __i_, out global::GluonTest.NoiseEngineState ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSampleRate_sig GetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSampleRate_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSampleRate_sig SetSampleRate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSampleRate_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetChannels_sig GetChannels;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetChannels_sig(IntPtr __i_, out global::GluonTest.NoiseChannels ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetChannels_sig SetChannels;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetChannels_sig(IntPtr __i_, global::GluonTest.NoiseChannels value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetBlockDuration_sig GetBlockDuration;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetBlockDuration_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetBlockDuration_sig SetBlockDuration;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetBlockDuration_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetDistribution_sig GetDistribution;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetDistribution_sig(IntPtr __i_, out global::GluonTest.NoiseDistribution ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetDistribution_sig SetDistribution;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetDistribution_sig(IntPtr __i_, global::GluonTest.NoiseDistribution value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetIsFilterEnabled_sig GetIsFilterEnabled;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetIsFilterEnabled_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] out bool ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetIsFilterEnabled_sig SetIsFilterEnabled;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetIsFilterEnabled_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_NoiseEngine_1(out IntPtr newInstance);
    }
}
