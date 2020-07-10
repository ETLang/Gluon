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
    [Guid("77b553e6-bb93-5cf5-bb79-62443c2018ca")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SinusoidalWaveform))]
    public partial class SinusoidalWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();

        static SinusoidalWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SinusoidalWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal SinusoidalWaveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SinusoidalWaveform>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SinusoidalWaveform_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.SinusoidalWaveform _vt;
        static Guid _ID = new Guid("503de1f8-b1dc-59cd-80aa-bc5c1cfa9f1b");

        #endregion
    }
}
