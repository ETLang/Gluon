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
        partial void PartialDispose(bool finalizing);

        static ConversionUnitTest()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public ConversionUnitTest() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public PrimitivesCB PrimitivesCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetPrimitivesCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_67C6D6E0.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_67C6D6E0.Unwrap(value); Native.Throw(_vt.SetPrimitivesCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StringsCB StringsCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetStringsCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_7A2B6D2C.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_7A2B6D2C.Unwrap(value); Native.Throw(_vt.SetStringsCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public SimpleStructsCB SimpleStructsCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetSimpleStructsCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_DF8B3B29.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_DF8B3B29.Unwrap(value); Native.Throw(_vt.SetSimpleStructsCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ComplexStructsCB ComplexStructsCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetComplexStructsCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_625CB5F.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_625CB5F.Unwrap(value); Native.Throw(_vt.SetComplexStructsCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ObjectsCB ObjectsCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetObjectsCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_87064FFB.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_87064FFB.Unwrap(value); Native.Throw(_vt.SetObjectsCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public NamedDelegatesCB NamedDelegatesCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetNamedDelegatesCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_7451AE97.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_7451AE97.Unwrap(value); Native.Throw(_vt.SetNamedDelegatesCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public GenericDelegatesCB GenericDelegatesCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetGenericDelegatesCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_61217488.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_61217488.Unwrap(value); Native.Throw(_vt.SetGenericDelegatesCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public PrimitiveArraysCB PrimitiveArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetPrimitiveArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_2C74C8B5.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_2C74C8B5.Unwrap(value); Native.Throw(_vt.SetPrimitiveArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StringArraysCB StringArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetStringArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_1061E85A.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_1061E85A.Unwrap(value); Native.Throw(_vt.SetStringArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public SimpleStructArraysCB SimpleStructArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetSimpleStructArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_1C12DC58.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_1C12DC58.Unwrap(value); Native.Throw(_vt.SetSimpleStructArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ComplexStructArraysCB ComplexStructArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetComplexStructArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_14F875F8.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_14F875F8.Unwrap(value); Native.Throw(_vt.SetComplexStructArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public ObjectArraysCB ObjectArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetObjectArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_A1A08E74.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_A1A08E74.Unwrap(value); Native.Throw(_vt.SetObjectArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public NamedDelegateArraysCB NamedDelegateArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetNamedDelegateArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_B2A7C512.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_B2A7C512.Unwrap(value); Native.Throw(_vt.SetNamedDelegateArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public GenericDelegateArraysCB GenericDelegateArraysCB
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetGenericDelegateArraysCB(IPtr, out x_abi_fn, out x_abi_ctx)); return D_DC21B22C.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_DC21B22C.Unwrap(value); Native.Throw(_vt.SetGenericDelegateArraysCB(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public StructMemberTest StructMembers
        {
            get {  Check(); ABI.GluonTest.StructMemberTest x_abi; Native.Throw(_vt.GetStructMembers(IPtr, out x_abi)); return ABI.GluonTest.StructMemberTest.FromABI(x_abi); }   
            set {  Check(); Native.Throw(_vt.SetStructMembers(IPtr, ABI.GluonTest.StructMemberTest.ToABI(value))); }  
        }

        public double Primitives(bool inTest, out char outTest, ref int refTest)
        {
            Check();
            double ___ret;
            Native.Throw(_vt.Primitives(IPtr, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public string Strings(string inTest, out string outTest, ref string refTest)
        {
            Check();
            string ___ret;
            Native.Throw(_vt.Strings(IPtr, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public BlittableStruct SimpleStructs(BlittableStruct inTest, out BlittableStruct outTest, ref BlittableStruct refTest)
        {
            Check();
            BlittableStruct ___ret;
            Native.Throw(_vt.SimpleStructs(IPtr, inTest, out outTest, ref refTest, out ___ret));
            return ___ret;
        }

        public ComplexStruct ComplexStructs(ComplexStruct inTest, out ComplexStruct outTest, ref ComplexStruct refTest)
        {
            Check();
            ABI.GluonTest.ComplexStruct outTest_abi;
            var refTest_abi = ABI.GluonTest.ComplexStruct.ToABI(refTest);
            ABI.GluonTest.ComplexStruct ___ret_abi;
            Native.Throw(_vt.ComplexStructs(IPtr, ABI.GluonTest.ComplexStruct.ToABI(inTest), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = ABI.GluonTest.ComplexStruct.FromABI(outTest_abi);
            refTest = ABI.GluonTest.ComplexStruct.FromABI(refTest_abi);
            return ABI.GluonTest.ComplexStruct.FromABI(___ret_abi);
        }

        public DummyClass Objects(DummyClass inTest, out DummyClass outTest, ref DummyClass refTest)
        {
            Check();
            IntPtr outTest_abi;
            var refTest_abi = MConv_.ToABI_Object(refTest == null ? IntPtr.Zero : ((DummyClass)refTest).IPtr);
            IntPtr ___ret_abi;
            Native.Throw(_vt.Objects(IPtr, (inTest == null ? IntPtr.Zero : ((DummyClass)inTest).IPtr), out outTest_abi, ref refTest_abi, out ___ret_abi));
            outTest = GluonObject.Of<DummyClass>(outTest_abi);
            refTest = MConv_.FromABI_Object<DummyClass>(refTest_abi);
            return GluonObject.Of<DummyClass>(___ret_abi);
        }

        public NamedDelegate NamedDelegates(NamedDelegate inTest, out NamedDelegate outTest, ref NamedDelegate refTest)
        {
            Check();
            var inTest_abi = D_BD6C0A4E.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_BD6C0A4E.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw(_vt.NamedDelegates(IPtr, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_BD6C0A4E.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_BD6C0A4E.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_BD6C0A4E.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        public Func<int,int> GenericDelegates(Action<string> inTest, out Action<Func<int,int>> outTest, ref Func<char[],string> refTest)
        {
            Check();
            var inTest_abi = D_5D02415D.Unwrap(inTest);
            IntPtr outTest_abi_fn; IntPtr outTest_abi_ctx;
            var refTest_abi = D_29454152.Unwrap(refTest);
            IntPtr ___ret_abi_fn; IntPtr ___ret_abi_ctx;
            Native.Throw(_vt.GenericDelegates(IPtr, inTest_abi.Fn, inTest_abi.Ctx, out outTest_abi_fn, out outTest_abi_ctx, ref refTest_abi.Fn, ref refTest_abi.Ctx, out ___ret_abi_fn, out ___ret_abi_ctx));
            outTest = D_5D02415E.Wrap(outTest_abi_fn, outTest_abi_ctx);
            refTest = D_29454152.Wrap(refTest_abi.Fn, refTest_abi.Ctx);
            return D_29454151.Wrap(___ret_abi_fn, ___ret_abi_ctx);
        }

        public double[] PrimitiveArrays(bool[] inTest, out char[] outTest, ref int[] refTest)
        {
            Check();
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_int(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.PrimitiveArrays(IPtr, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_char(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_int(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_double(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public string[] StringArrays(string[] inTest, out string[] outTest, ref string[] refTest)
        {
            Check();
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv_.ToABI_string(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.StringArrays(IPtr, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv_.FromABI_string(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv_.FromABI_string(refTest_abi.Ptr, refTest_abi.Count);
            return MConv_.FromABI_string(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public BlittableStruct[] SimpleStructArrays(BlittableStruct[] inTest, out BlittableStruct[] outTest, ref BlittableStruct[] refTest)
        {
            Check();
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_6FB3D833(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.SimpleStructArrays(IPtr, inTest, inTest.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_6FB3D833(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_6FB3D833(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_6FB3D833(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public ComplexStruct[] ComplexStructArrays(ComplexStruct[] inTest, out ComplexStruct[] outTest, ref ComplexStruct[] refTest)
        {
            Check();
            var inTest_abi = ABI.GluonTest.ComplexStruct.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            var refTest_abi = MConv.ToABI_7301BA3C(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ComplexStructArrays(IPtr, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_7301BA3C(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_7301BA3C(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_7301BA3C(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public DummyClass[] ObjectArrays(DummyClass[] inTest, out DummyClass[] outTest, ref DummyClass[] refTest)
        {
            Check();
            var inTest_abi = GluonObject.ArrayUnwrap(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_CAD799A2(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ObjectArrays(IPtr, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_CAD799A2(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_CAD799A2(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_CAD799A2(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public NamedDelegate[] NamedDelegateArrays(NamedDelegate[] inTest, out NamedDelegate[] outTest, ref NamedDelegate[] refTest)
        {
            Check();
            var inTest_abi = D_BD6C0A4E.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_BD6C0A4E(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.NamedDelegateArrays(IPtr, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_BD6C0A4E(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_BD6C0A4E(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_BD6C0A4E(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public Func<int,int>[] GenericDelegateArrays(Action<string>[] inTest, out Action<Func<int,int>>[] outTest, ref Func<char[],string>[] refTest)
        {
            Check();
            var inTest_abi = D_5D02415D.ToABI_Array(inTest);
            ArrayBlob outTest_abi;
            ArrayBlob refTest_abi = MConv.ToABI_29454152(refTest);
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.GenericDelegateArrays(IPtr, inTest_abi, inTest_abi.Length, out outTest_abi.Ptr, out outTest_abi.Count, ref refTest_abi.Ptr, ref refTest_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            outTest = MConv.FromABI_5D02415E(outTest_abi.Ptr, outTest_abi.Count);
            refTest = MConv.FromABI_29454152(refTest_abi.Ptr, refTest_abi.Count);
            return MConv.FromABI_29454151(___ret_abi.Ptr, ___ret_abi.Count);
        }

        public void ExCheckNullReference()
        {
            Check();
            Native.Throw(_vt.ExCheckNullReference(IPtr));
        }

        public void ExCheckArgumentNull()
        {
            Check();
            Native.Throw(_vt.ExCheckArgumentNull(IPtr));
        }

        public void ExCheckArgument()
        {
            Check();
            Native.Throw(_vt.ExCheckArgument(IPtr));
        }

        public void ExCheckInvalidOperation()
        {
            Check();
            Native.Throw(_vt.ExCheckInvalidOperation(IPtr));
        }

        public void ExCheckAccessDenied()
        {
            Check();
            Native.Throw(_vt.ExCheckAccessDenied(IPtr));
        }

        public void ExCheckGeneric()
        {
            Check();
            Native.Throw(_vt.ExCheckGeneric(IPtr));
        }

        public void ExCheckGenericStd()
        {
            Check();
            Native.Throw(_vt.ExCheckGenericStd(IPtr));
        }

        public void ExCheckNotImplemented()
        {
            Check();
            Native.Throw(_vt.ExCheckNotImplemented(IPtr));
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal ConversionUnitTest(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ConversionUnitTest>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_ConversionUnitTest_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.ConversionUnitTest _vt;
        static Guid _ID = new Guid("5233ece2-bede-48d2-b2a0-ad431cf98906");

        #endregion
    }
}
