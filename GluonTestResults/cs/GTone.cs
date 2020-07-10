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
    [Guid("1bd4378f-dac4-3983-dd16-04143d3b0ea5")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.GTone))]
    public partial class GTone : Generator
    {
        static partial void StaticInit();
        partial void Init();

        static GTone()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public GTone() : this(new AbiPtr(Make())) {  Init(); }  

        public double Frequency
        {
            get {  double x; Native.Throw(_vt.GetFrequency(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetFrequency(_i, value)); }  
        }

        public Waveform Waveform
        {
            get {  IntPtr x_abi; Native.Throw(_vt.GetWaveform(_i, out x_abi)); return GluonObject.Of<Waveform>(x_abi); }   
            set {  Native.Throw(_vt.SetWaveform(_i, (value == null ? IntPtr.Zero : value.NativePtr))); }  
        }

        public double Amplitude
        {
            get {  double x; Native.Throw(_vt.GetAmplitude(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetAmplitude(_i, value)); }  
        }

        #region Internal

        internal GTone(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.GTone>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_GTone_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.GTone _vt;
        static Guid _ID = new Guid("3c5c8591-d08b-3cbb-e6c5-da0c1de18974");

        #endregion
    }
}
