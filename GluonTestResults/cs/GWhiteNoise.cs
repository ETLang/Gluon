/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;
using GluonTest;

namespace GluonTest
{
    [Guid("68bd58c1-daa1-3983-dd16-04173a3c1fc0")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.GWhiteNoise))]
    public partial class GWhiteNoise : Generator
    {
        static partial void StaticInit();
        partial void Init();

        static GWhiteNoise()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public GWhiteNoise() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal GWhiteNoise(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.GWhiteNoise>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_GWhiteNoise_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.GWhiteNoise _vt;
        static Guid _ID = new Guid("4f35eadf-d0ee-3cbb-e6c5-da0f1ae69811");

        #endregion
    }
}
