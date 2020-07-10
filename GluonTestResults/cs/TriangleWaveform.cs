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
    [Guid("7a8352e3-bfb2-56e5-af7b-17323b3405c2")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.TriangleWaveform))]
    public partial class TriangleWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();

        static TriangleWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public TriangleWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal TriangleWaveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.TriangleWaveform>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_TriangleWaveform_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.TriangleWaveform _vt;
        static Guid _ID = new Guid("5d0be0fd-b5fd-53dd-94a8-c92a1bee8213");

        #endregion
    }
}
