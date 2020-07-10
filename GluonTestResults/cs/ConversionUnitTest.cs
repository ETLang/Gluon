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

namespace GluonTest
{
    [Guid("75bb5efc-b491-4dea-8973-735b3c230ed7")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.ConversionUnitTest))]
    public partial class ConversionUnitTest : GluonObject
    {
        static partial void StaticInit();
        partial void Init();

        static ConversionUnitTest()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public ConversionUnitTest() : this(new AbiPtr(Make())) {  Init(); }  

        public PrimitivesCB PrimitivesCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetPrimitivesCB(_i, out x_abi_fn, out x_abi_ctx)); return D_67C6D6DF.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_67C6D6DF.Unwrap(value); Native.Throw(_vt.SetPrimitivesCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StringsCB StringsCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetStringsCB(_i, out x_abi_fn, out x_abi_ctx)); return D_7A2B6D2B.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_7A2B6D2B.Unwrap(value); Native.Throw(_vt.SetStringsCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public SimpleStructsCB SimpleStructsCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetSimpleStructsCB(_i, out x_abi_fn, out x_abi_ctx)); return D_DF8B3B28.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_DF8B3B28.Unwrap(value); Native.Throw(_vt.SetSimpleStructsCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ComplexStructsCB ComplexStructsCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetComplexStructsCB(_i, out x_abi_fn, out x_abi_ctx)); return D_625CB5E.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_625CB5E.Unwrap(value); Native.Throw(_vt.SetComplexStructsCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ObjectsCB ObjectsCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetObjectsCB(_i, out x_abi_fn, out x_abi_ctx)); return D_87064FFA.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_87064FFA.Unwrap(value); Native.Throw(_vt.SetObjectsCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public NamedDelegatesCB NamedDelegatesCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetNamedDelegatesCB(_i, out x_abi_fn, out x_abi_ctx)); return D_7451AE96.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_7451AE96.Unwrap(value); Native.Throw(_vt.SetNamedDelegatesCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public GenericDelegatesCB GenericDelegatesCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetGenericDelegatesCB(_i, out x_abi_fn, out x_abi_ctx)); return D_61217487.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_61217487.Unwrap(value); Native.Throw(_vt.SetGenericDelegatesCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public PrimitiveArraysCB PrimitiveArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetPrimitiveArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_2C74C8B4.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_2C74C8B4.Unwrap(value); Native.Throw(_vt.SetPrimitiveArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StringArraysCB StringArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetStringArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_1061E859.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_1061E859.Unwrap(value); Native.Throw(_vt.SetStringArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public SimpleStructArraysCB SimpleStructArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetSimpleStructArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_1C12DC57.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_1C12DC57.Unwrap(value); Native.Throw(_vt.SetSimpleStructArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ComplexStructArraysCB ComplexStructArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetComplexStructArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_14F875F7.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_14F875F7.Unwrap(value); Native.Throw(_vt.SetComplexStructArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ObjectArraysCB ObjectArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetObjectArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_A1A08E73.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_A1A08E73.Unwrap(value); Native.Throw(_vt.SetObjectArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public NamedDelegateArraysCB NamedDelegateArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetNamedDelegateArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_B2A7C511.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_B2A7C511.Unwrap(value); Native.Throw(_vt.SetNamedDelegateArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public GenericDelegateArraysCB GenericDelegateArraysCB
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetGenericDelegateArraysCB(_i, out x_abi_fn, out x_abi_ctx)); return D_DC21B22B.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_DC21B22B.Unwrap(value); Native.Throw(_vt.SetGenericDelegateArraysCB(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StructMemberTest StructMembers
        {
            get {  ABI.GluonTest.StructMemberTest x_abi; Native.Throw(_vt.GetStructMembers(_i, out x_abi)); return ABI.GluonTest.StructMemberTest.FromABI(x_abi); }   
            set {  Native.Throw(_vt.SetStructMembers(_i, ABI.GluonTest.StructMemberTest.ToABI(value))); }  
        }

        public double Primitives(bool inTest, out char outTest, ref int refTest)
        {
            double ___ret;
            Native.Throw(_vt.Primitives1(_i, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public string Strings(string inTest, out string outTest, ref string refTest)
        {
            string ___ret;
            Native.Throw(_vt.Strings2(_i, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public BlittableStruct SimpleStructs(BlittableStruct inTest, out BlittableStruct outTest, ref BlittableStruct refTest)
        {
            BlittableStruct ___ret;
            Native.Throw(_vt.SimpleStructs3(_i, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public ComplexStruct ComplexStructs(ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest)
        {
            ABI.GluonTest.ComplexStruct outTest_abi;
            var refTest_abi = ABI.GluonTest.ComplexStruct.ToABI(refTest);
            ABI.GluonTest.ComplexStruct ___ret_abi;
            Native.Throw(_vt.ComplexStructs4(_i, ABI.GluonTest.ComplexStruct.ToABI(inTest), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = ABI.GluonTest.ComplexStruct.FromABI(outTest_abi);
            refTest = ABI.GluonTest.ComplexStruct.FromABI(refTest_abi);
            return ABI.GluonTest.ComplexStruct.FromABI(___ret_abi);
        }

        public DummyClass Objects(DummyClass inTest, out DummyClass outTest, ref DummyClass refTest)
        {
            IntPtr outTest_abi;
            var refTest_abi = MConv_.ToABI_Object(refTest);
            IntPtr ___ret_abi;
            Native.Throw(_vt.Objects5(_i, (inTest == null ? IntPtr.Zero : inTest.NativePtr), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = GluonObject.Of<DummyClass>(outTest_abi);
            refTest = MConv_.FromABI_Object<DummyClass>(refTest_abi);
            return GluonObject.Of<DummyClass>(___ret_abi);
        }

        public NamedDelegate NamedDelegates(NamedDelegate inTest, out NamedDelegate outTest, ref NamedDelegate refTest)
        {
            var inTest_abi = D_BD6C0A4D.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_BD6C0A4D.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw(_vt.NamedDelegates6(_i, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_BD6C0A4D.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_BD6C0A4D.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_BD6C0A4D.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        public Func<int,int> GenericDelegates(Action<string> inTest, out Action<Func<int,int>> outTest, ref Func<char[],string> refTest)
        {
            var inTest_abi = D_5D02415A.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_2945414D.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw(_vt.GenericDelegates7(_i, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_5D02415B.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_2945414D.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_2945414C.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        public double[] PrimitiveArrays(bool[] inTest, out char[] outTest, ref int[] refTest)
        {
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_int(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.PrimitiveArrays8(_i, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_char(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_int(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_double(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public string[] StringArrays(string[] inTest, out string[] outTest, ref string[] refTest)
        {
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_string(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.StringArrays9(_i, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_string(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_string(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_string(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public BlittableStruct[] SimpleStructArrays(BlittableStruct[] inTest, out BlittableStruct[] outTest, ref BlittableStruct[] refTest)
        {
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_6FB3D833(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.SimpleStructArrays10(_i, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_6FB3D833(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_6FB3D833(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_6FB3D833(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public ComplexStruct[] ComplexStructArrays(ComplexStruct[] inTest, out ComplexStruct[] outTest, ref ComplexStruct[] refTest)
        {
            var inTest_abi = ABI.GluonTest.ComplexStruct.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_7301BA3C(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ComplexStructArrays11(_i, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7301BA3C(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7301BA3C(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7301BA3C(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public DummyClass[] ObjectArrays(DummyClass[] inTest, out DummyClass[] outTest, ref DummyClass[] refTest)
        {
            var inTest_abi = GluonObject.ArrayUnwrap(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_Object(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ObjectArrays12(_i, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_Object<DummyClass>(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_Object<DummyClass>(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_Object<DummyClass>(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public NamedDelegate[] NamedDelegateArrays(NamedDelegate[] inTest, out NamedDelegate[] outTest, ref NamedDelegate[] refTest)
        {
            var inTest_abi = D_BD6C0A4D.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_BD6C0A4D(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.NamedDelegateArrays13(_i, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_BD6C0A4D(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_BD6C0A4D(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_BD6C0A4D(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public Func<int,int>[] GenericDelegateArrays(Action<string>[] inTest, out Action<Func<int,int>>[] outTest, ref Func<char[],string>[] refTest)
        {
            var inTest_abi = D_5D02415A.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_2945414D(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.GenericDelegateArrays14(_i, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_5D02415B(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_2945414D(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_2945414C(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public void ExCheckNullReference()
        {
            Native.Throw(_vt.ExCheckNullReference15(_i));
        }

        public void ExCheckArgumentNull()
        {
            Native.Throw(_vt.ExCheckArgumentNull16(_i));
        }

        public void ExCheckArgument()
        {
            Native.Throw(_vt.ExCheckArgument17(_i));
        }

        public void ExCheckInvalidOperation()
        {
            Native.Throw(_vt.ExCheckInvalidOperation18(_i));
        }

        public void ExCheckAccessDenied()
        {
            Native.Throw(_vt.ExCheckAccessDenied19(_i));
        }

        public void ExCheckGeneric()
        {
            Native.Throw(_vt.ExCheckGeneric20(_i));
        }

        public void ExCheckGenericStd()
        {
            Native.Throw(_vt.ExCheckGenericStd21(_i));
        }

        public void ExCheckNotImplemented()
        {
            Native.Throw(_vt.ExCheckNotImplemented22(_i));
        }

        #region Internal

        internal ConversionUnitTest(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ConversionUnitTest>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_ConversionUnitTest_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.ConversionUnitTest _vt;
        static Guid _ID = new Guid("5233ece2-bede-48d2-b2a0-ad431cf98906");

        #endregion
    }
}
