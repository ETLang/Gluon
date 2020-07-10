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
    [Guid("68a756e3-dac4-3983-dd16-0a1437261fe6")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.ITestClass))]
    public partial class ITestClass : GluonObject
    {
        static partial void StaticInit();
        partial void Init();

        static ITestClass()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public ITestClass() : this(new AbiPtr(Make())) {  _BigEvent_abi = D_5D02415C.Unwrap(_Call_BigEvent); Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            if(_BigEvent != null) _vt.RemoveBigEventHandler(_i, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);

            base.OnDispose(finalizing);
        }

        #region BigEvent

        public event Action<int> BigEvent
        {
            add
            {
                if(_BigEvent == null)
                    _vt.AddBigEventHandler(_i, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);

                _BigEvent += value;
            }

            remove
            {
                _BigEvent -= value;
                if(_BigEvent == null)
                    _vt.RemoveBigEventHandler(_i, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);
            }
        }

        private void _Call_BigEvent(int obj)
        {
            _BigEvent(obj);
        }

        private Action<int> _BigEvent;
        private DelegateBlob _BigEvent_abi;

        #endregion

        public AddSomeShit Adder
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetAdder(_i, out x_abi_fn, out x_abi_ctx)); return D_668509AD.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_668509AD.Unwrap(value); Native.Throw(_vt.SetAdder(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public int Property
        {
            get {  int x; Native.Throw(_vt.GetProperty(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetProperty(_i, value)); }  
        }

        public int ReadOnlyProperty {  get {  int x; Native.Throw(_vt.GetReadOnlyProperty(_i, out x)); return x; }  }  

        public TestStruct[] HardProperty
        {
            get {  ArrayBlob x_abi; Native.Throw(_vt.GetHardProperty(_i, out x_abi.Ptr, out x_abi.Count)); return MConv.FromABI_463C8217(x_abi.Ptr, x_abi.Count); }   
            set {  var value_abi = ABI.GluonTest.TestStruct.ToABI_Array(value); Native.Throw(_vt.SetHardProperty(_i, value_abi, value_abi.Length)); }  
        }

        public Func<char,int,string>[] HarderProperty
        {
            get {  ArrayBlob x_abi; Native.Throw(_vt.GetHarderProperty(_i, out x_abi.Ptr, out x_abi.Count)); return MConv.FromABI_827F05B2(x_abi.Ptr, x_abi.Count); }   
            set {  var value_abi = D_827F05B2.ToABI_Array(value); Native.Throw(_vt.SetHarderProperty(_i, value_abi, value_abi.Length)); }  
        }

        public Func<string,char> DumbDelegate
        {
            get {  IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetDumbDelegate(_i, out x_abi_fn, out x_abi_ctx)); return D_2945414E.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  var value_abi = D_2945414E.Unwrap(value); Native.Throw(_vt.SetDumbDelegate(_i, value_abi.Fn, value_abi.Ctx)); }  
        }

        public void Methody()
        {
            Native.Throw(_vt.Methody1(_i));
        }

        public int RetMethod()
        {
            int ___ret;
            Native.Throw(_vt.RetMethod2(_i, out ___ret));
            return ___ret;
        }

        public void OutMethod(out int x)
        {
            Native.Throw(_vt.OutMethod3(_i, out x));
        }

        public void RefMethod(ref string thing)
        {
            Native.Throw(_vt.RefMethod4(_i, ref thing));
        }

        public void Ref2(ref ITestClass thing)
        {
            var thing_abi = MConv_.ToABI_Object(thing);
            Native.Throw(_vt.Ref25(_i, ref thing_abi));
            thing = MConv_.FromABI_Object<ITestClass>(thing_abi);
        }

        public void Ref3(TestStruct thing)
        {
            Native.Throw(_vt.Ref36(_i, ABI.GluonTest.TestStruct.ToABI(thing)));
        }

        public int[] ComplexMethod(ref string a, IntPtr _dumb, IntPtr p, out char[] fart)
        {
            ArrayBlob fart_abi;
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ComplexMethod7(_i, ref a, _dumb, p, out fart_abi.Ptr, out fart_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            fart = MConv_.FromABI_char(fart_abi.Ptr, fart_abi.Count);
            return MConv_.FromABI_int(___ret_abi.Ptr, ___ret_abi.Count);
        }

        #region Internal

        internal ITestClass(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ITestClass>(_i);
            _BigEvent_abi = D_5D02415C.Unwrap(_Call_BigEvent);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_ITestClass_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.ITestClass _vt;
        static Guid _ID = new Guid("4f2fe4fd-d08b-3cbb-e6c5-d40c17fc9837");

        #endregion
    }
}
