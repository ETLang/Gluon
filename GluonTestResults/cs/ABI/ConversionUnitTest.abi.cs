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
    [Guid("5233ece2-bede-48d2-b2a0-ad431cf98906")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ConversionUnitTest
    {
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Primitives_sig Primitives;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Primitives_sig(IntPtr __i_, [MarshalAs(UnmanagedType.I1)] bool inTest, out char outTest, ref int refTest, out double ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Strings_sig Strings;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Strings_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPStr)] string inTest, [MarshalAs(UnmanagedType.LPStr)] out string outTest, [MarshalAs(UnmanagedType.LPStr)] ref string refTest, [MarshalAs(UnmanagedType.LPStr)] out string ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SimpleStructs_sig SimpleStructs;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SimpleStructs_sig(IntPtr __i_, global::GluonTest.BlittableStruct inTest, out global::GluonTest.BlittableStruct outTest, ref global::GluonTest.BlittableStruct refTest, out global::GluonTest.BlittableStruct ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexStructs_sig ComplexStructs;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexStructs_sig(IntPtr __i_, ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest, out ComplexStruct ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Objects_sig Objects;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Objects_sig(IntPtr __i_, IntPtr inTest, out IntPtr outTest, ref IntPtr refTest, out IntPtr ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly NamedDelegates_sig NamedDelegates;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int NamedDelegates_sig(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GenericDelegates_sig GenericDelegates;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GenericDelegates_sig(IntPtr __i_, IntPtr inTest, IntPtr inTest_context, out IntPtr outTest, out IntPtr outTest_context, ref IntPtr refTest, ref IntPtr refTest_context, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly PrimitiveArrays_sig PrimitiveArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int PrimitiveArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 2)] bool[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly StringArrays_sig StringArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int StringArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SimpleStructArrays_sig SimpleStructArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SimpleStructArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] global::GluonTest.BlittableStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ComplexStructArrays_sig ComplexStructArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ComplexStructArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ComplexStruct[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ObjectArrays_sig ObjectArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ObjectArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly NamedDelegateArrays_sig NamedDelegateArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int NamedDelegateArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GenericDelegateArrays_sig GenericDelegateArrays;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GenericDelegateArrays_sig(IntPtr __i_, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DelegateBlob[] inTest, int inTest_count, out IntPtr outTest, out int outTest_count, ref IntPtr refTest, ref int refTest_count, out IntPtr ___ret, out int ___ret_count);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckNullReference_sig ExCheckNullReference;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckNullReference_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckArgumentNull_sig ExCheckArgumentNull;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckArgumentNull_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckArgument_sig ExCheckArgument;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckArgument_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckInvalidOperation_sig ExCheckInvalidOperation;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckInvalidOperation_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckAccessDenied_sig ExCheckAccessDenied;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckAccessDenied_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckGeneric_sig ExCheckGeneric;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckGeneric_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckGenericStd_sig ExCheckGenericStd;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckGenericStd_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly ExCheckNotImplemented_sig ExCheckNotImplemented;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ExCheckNotImplemented_sig(IntPtr __i_);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPrimitivesCB_sig GetPrimitivesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPrimitivesCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetPrimitivesCB_sig SetPrimitivesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetPrimitivesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStringsCB_sig GetStringsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStringsCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStringsCB_sig SetStringsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStringsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSimpleStructsCB_sig GetSimpleStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSimpleStructsCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSimpleStructsCB_sig SetSimpleStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSimpleStructsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetComplexStructsCB_sig GetComplexStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetComplexStructsCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetComplexStructsCB_sig SetComplexStructsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetComplexStructsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetObjectsCB_sig GetObjectsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetObjectsCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetObjectsCB_sig SetObjectsCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetObjectsCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNamedDelegatesCB_sig GetNamedDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNamedDelegatesCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNamedDelegatesCB_sig SetNamedDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNamedDelegatesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetGenericDelegatesCB_sig GetGenericDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetGenericDelegatesCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetGenericDelegatesCB_sig SetGenericDelegatesCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetGenericDelegatesCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetPrimitiveArraysCB_sig GetPrimitiveArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetPrimitiveArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetPrimitiveArraysCB_sig SetPrimitiveArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetPrimitiveArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStringArraysCB_sig GetStringArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStringArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStringArraysCB_sig SetStringArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStringArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetSimpleStructArraysCB_sig GetSimpleStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetSimpleStructArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetSimpleStructArraysCB_sig SetSimpleStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetSimpleStructArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetComplexStructArraysCB_sig GetComplexStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetComplexStructArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetComplexStructArraysCB_sig SetComplexStructArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetComplexStructArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetObjectArraysCB_sig GetObjectArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetObjectArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetObjectArraysCB_sig SetObjectArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetObjectArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetNamedDelegateArraysCB_sig GetNamedDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetNamedDelegateArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetNamedDelegateArraysCB_sig SetNamedDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetNamedDelegateArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetGenericDelegateArraysCB_sig GetGenericDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetGenericDelegateArraysCB_sig(IntPtr __i_, out IntPtr ___ret, out IntPtr ___ret_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetGenericDelegateArraysCB_sig SetGenericDelegateArraysCB;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetGenericDelegateArraysCB_sig(IntPtr __i_, IntPtr value, IntPtr value_context);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetStructMembers_sig GetStructMembers;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetStructMembers_sig(IntPtr __i_, out StructMemberTest ___ret);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetStructMembers_sig SetStructMembers;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int SetStructMembers_sig(IntPtr __i_, StructMemberTest value);
    }

    internal static partial class Factory
    {
        [DllImport(Native.DllPath)]
        public static extern int Create_GluonTest_ConversionUnitTest_1(out IntPtr newInstance);
    }
}
