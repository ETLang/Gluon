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
    [Guid("1bd45afd-dac4-3983-dd16-142124300dca")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.Waveform))]
    public partial class Waveform : GluonObject
    {
        static partial void StaticInit();
        partial void Init();

        static Waveform()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public Waveform(double[] samples)
            : this(new AbiPtr(Make(samples)))
        {
            Init();
        }

        public double Phase(double t)
        {
            double ___ret;
            Native.Throw(_vt.Phase1(_i, t, out ___ret));
            return ___ret;
        }

        #region Internal

        internal Waveform(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.Waveform>(_i);
            Init();
        }

        private static IntPtr Make(double[] samples)
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_Waveform_1(samples, samples.Length, out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.Waveform _vt;
        static Guid _ID = new Guid("3c5ce8e3-d08b-3cbb-e6c5-ca3904ea8a1b");

        #endregion
    }
}
