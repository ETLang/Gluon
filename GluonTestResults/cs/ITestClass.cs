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
        partial void PartialDispose(bool finalizing);

        static ITestClass()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public ITestClass() : this(new AbiPtr(Make())) { _BigEvent_abi = D_5D02415F.Unwrap(_Call_BigEvent);  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);
            if(_BigEvent != null) _vt.RemoveBigEventHandler(IPtr, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        #region BigEvent

        public event Action<int> BigEvent
        {
            add
            {
                Check();
                if(_BigEvent == null)
                    _vt.AddBigEventHandler(IPtr, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);

                _BigEvent += value;
            }
            remove
            {
                Check();
                _BigEvent -= value;
                if(_BigEvent == null)
                    _vt.RemoveBigEventHandler(IPtr, _BigEvent_abi.Fn, _BigEvent_abi.Ctx);
            }
        }

        private void _Call_BigEvent(int obj)
        {
            try
            {
                _BigEvent(obj);
            }
            catch(Exception ___ex)
            {
                CallbackEventExceptionHandler?.Invoke(___ex);
            }
        }

        private Action<int> _BigEvent;
        private DelegateBlob _BigEvent_abi;

        #endregion

        public AddSomeShit Adder
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetAdder(IPtr, out x_abi_fn, out x_abi_ctx)); return D_668509AE.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_668509AE.Unwrap(value); Native.Throw(_vt.SetAdder(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public int Property
        {
            get {  Check(); int x; Native.Throw(_vt.GetProperty(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetProperty(IPtr, value)); }  
        }

        public int ReadOnlyProperty {  get {  Check(); int x; Native.Throw(_vt.GetReadOnlyProperty(IPtr, out x)); return x; }  }  

        public TestStruct[] HardProperty
        {
            get {  Check(); ArrayBlob x_abi; Native.Throw(_vt.GetHardProperty(IPtr, out x_abi.Ptr, out x_abi.Count)); return MConv.FromABI_463C8217(x_abi.Ptr, x_abi.Count); }   
            set {  Check(); var value_abi = ABI.GluonTest.TestStruct.ToABI_Array(value); Native.Throw(_vt.SetHardProperty(IPtr, value_abi, value_abi.Length)); }  
        }

        public Func<char,int,string>[] HarderProperty
        {
            get {  Check(); ArrayBlob x_abi; Native.Throw(_vt.GetHarderProperty(IPtr, out x_abi.Ptr, out x_abi.Count)); return MConv.FromABI_827F05B4(x_abi.Ptr, x_abi.Count); }   
            set {  Check(); var value_abi = D_827F05B4.ToABI_Array(value); Native.Throw(_vt.SetHarderProperty(IPtr, value_abi, value_abi.Length)); }  
        }

        public Func<string,char> DumbDelegate
        {
            get {  Check(); IntPtr x_abi_fn; IntPtr x_abi_ctx; Native.Throw(_vt.GetDumbDelegate(IPtr, out x_abi_fn, out x_abi_ctx)); return D_29454153.Wrap(x_abi_fn, x_abi_ctx); }   
            set {  Check(); var value_abi = D_29454153.Unwrap(value); Native.Throw(_vt.SetDumbDelegate(IPtr, value_abi.Fn, value_abi.Ctx)); }  
        }

        public void Methody()
        {
            Check();
            Native.Throw(_vt.Methody(IPtr));
        }

        public int RetMethod()
        {
            Check();
            int ___ret;
            Native.Throw(_vt.RetMethod(IPtr, out ___ret));
            return ___ret;
        }

        public void OutMethod(out int x)
        {
            Check();
            Native.Throw(_vt.OutMethod(IPtr, out x));
        }

        public void RefMethod(ref string thing)
        {
            Check();
            Native.Throw(_vt.RefMethod(IPtr, ref thing));
        }

        public void Ref2(ref ITestClass thing)
        {
            Check();
            var thing_abi = MConv_.ToABI_Object(thing == null ? IntPtr.Zero : ((ITestClass)thing).IPtr);
            Native.Throw(_vt.Ref2(IPtr, ref thing_abi));
            thing = MConv_.FromABI_Object<ITestClass>(thing_abi);
        }

        public void Ref3(TestStruct thing)
        {
            Check();
            Native.Throw(_vt.Ref3(IPtr, ABI.GluonTest.TestStruct.ToABI(thing)));
        }

        public int[] ComplexMethod(ref string a, IntPtr _dumb, IntPtr p, out char[] fart)
        {
            Check();
            ArrayBlob fart_abi;
            ArrayBlob ___ret_abi;
            Native.Throw(_vt.ComplexMethod(IPtr, ref a, _dumb, p, out fart_abi.Ptr, out fart_abi.Count, out ___ret_abi.Ptr, out ___ret_abi.Count));
            fart = MConv_.FromABI_char(fart_abi.Ptr, fart_abi.Count);
            return MConv_.FromABI_int(___ret_abi.Ptr, ___ret_abi.Count);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal ITestClass(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.ITestClass>(IPtr);
            _BigEvent_abi = D_5D02415F.Unwrap(_Call_BigEvent);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_ITestClass_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.ITestClass _vt;
        static Guid _ID = new Guid("4f2fe4fd-d08b-3cbb-e6c5-d40c17fc9837");

        #endregion
    }
}
