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
    [Guid("7ea256d8-b5a2-54f1-dd16-1031273419c0")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.SquareWaveform))]
    public partial class SquareWaveform : Waveform
    {
        static partial void StaticInit();
        partial void Init();

        static SquareWaveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public SquareWaveform() : this(new AbiPtr(Make())) {  Init(); }  

        #region Internal

        internal SquareWaveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.SquareWaveform>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_SquareWaveform_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.SquareWaveform _vt;
        static Guid _ID = new Guid("592ae4c6-bfed-51c9-e6c5-ce2907ee9e11");

        #endregion
    }
}
