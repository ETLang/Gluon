/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;
using GluonTest;
using System.Runtime.CompilerServices;

namespace ABI.GluonTest
{
    [Guid("4f2fe4fd-d08b-3cbb-e6c5-d40c17fc9837")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ITestClass
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Methody_sig Methody;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Methody_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RetMethod_sig RetMethod;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RetMethod_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly OutMethod_sig OutMethod;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int OutMethod_sig(IntPtr __i_, out int x);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RefMethod_sig RefMethod;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RefMethod_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] ref string thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Ref2_sig Ref2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Ref2_sig(IntPtr __i_, ref IntPtr thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Ref3_sig Ref3;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Ref3_sig(IntPtr __i_, TestStruct thing);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexMethod_sig ComplexMethod;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexMethod_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] ref string a, IntPtr _dumb, IntPtr p, out IntPtr fart, out int fart_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetAdder_sig GetAdder;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetAdder_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetAdder_sig SetAdder;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetAdder_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetProperty_sig GetProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetProperty_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetProperty_sig SetProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetProperty_sig(IntPtr __i_, int value);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetReadOnlyProperty_sig GetReadOnlyProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetReadOnlyProperty_sig(IntPtr __i_, out int ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetHardProperty_sig GetHardProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetHardProperty_sig(IntPtr __i_, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetHardProperty_sig SetHardProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetHardProperty_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TestStruct[] value, int value_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetHarderProperty_sig GetHarderProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetHarderProperty_sig(IntPtr __i_, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetHarderProperty_sig SetHarderProperty;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetHarderProperty_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] value, int value_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetDumbDelegate_sig GetDumbDelegate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetDumbDelegate_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetDumbDelegate_sig SetDumbDelegate;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetDumbDelegate_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly AddBigEventHandler_sig AddBigEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int AddBigEventHandler_sig(IntPtr __i_, IntPtr handler, IntPtr handler_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly RemoveBigEventHandler_sig RemoveBigEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int RemoveBigEventHandler_sig(IntPtr __i_, IntPtr handler, IntPtr handler_context);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_ITestClass_1(out IntPtr newInstance);
    }
}
