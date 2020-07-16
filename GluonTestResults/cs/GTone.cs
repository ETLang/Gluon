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
        partial void PartialDispose(bool finalizing);

        static GTone()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public GTone() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public double Frequency
        {
            get {  Check(); double x; Native.Throw(_vt.GetFrequency(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetFrequency(IPtr, value)); }  
        }

        public Waveform Waveform
        {
            get {  Check(); IntPtr x_abi; Native.Throw(_vt.GetWaveform(IPtr, out x_abi)); return GluonObject.Of<Waveform>(x_abi); }   
            set {  Check(); Native.Throw(_vt.SetWaveform(IPtr, (value == null ? IntPtr.Zero : ((Waveform)value).IPtr))); }  
        }

        public double Amplitude
        {
            get {  Check(); double x; Native.Throw(_vt.GetAmplitude(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetAmplitude(IPtr, value)); }  
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal GTone(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.GTone>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_GTone_1(out instance_abi));
            return instance_abi;
        }

        public new IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.GTone _vt;
        static Guid _ID = new Guid("3c5c8591-d08b-3cbb-e6c5-da0c1de18974");

        #endregion
    }
}
