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
    [Guid("4f2fe4fd-d08b-3cbb-e6c5-d92d1fe29537")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct DummyClass
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNugget_sig GetNugget;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNugget_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNugget_sig SetNugget;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNugget_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_DummyClass_1(out IntPtr newInstance);
    }
}
