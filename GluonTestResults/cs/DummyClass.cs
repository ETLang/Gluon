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

        static DummyClass()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public DummyClass() : this(new AbiPtr(Make())) {  Init(); }  

        public string Nugget
        {
            get {  string x; Native.Throw(_vt.GetNugget(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetNugget(_i, value)); }  
        }

        #region Internal

        internal DummyClass(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.DummyClass>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_DummyClass_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.DummyClass _vt;
        static Guid _ID = new Guid("4f2fe4fd-d08b-3cbb-e6c5-d92d1fe29537");

        #endregion
    }
}
