/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;

namespace GluonTest
{
    [Guid("68a756e3-dac4-3983-dd16-07353f3812e6")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.DummyClass))]
    public partial class DummyClass : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static DummyClass()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public DummyClass() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public string Nugget
        {
            get {  Check(); string x; Native.Throw(_vt.GetNugget(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetNugget(IPtr, value)); }  
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal DummyClass(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.DummyClass>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_DummyClass_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.DummyClass _vt;
        static Guid _ID = new Guid("4f2fe4fd-d08b-3cbb-e6c5-d92d1fe29537");

        #endregion
    }
}
