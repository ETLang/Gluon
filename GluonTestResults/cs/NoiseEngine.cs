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
    [Guid("75bd50e1-daa1-3983-dd16-0d2f3b260ee0")]
    [GluonGenerated(abi: typeof(global::ABI.GluonTest.NoiseEngine))]
    public partial class NoiseEngine : GluonObject
    {
        static partial void StaticInit();
        partial void Init();
        partial void PartialDispose(bool finalizing);

        static NoiseEngine()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public NoiseEngine() : this(new AbiPtr(Make())) {  Init(); }  

        protected override void OnDispose(bool finalizing)
        {
            PartialDispose(finalizing);

            IPtr = IntPtr.Zero;
            base.OnDispose(finalizing);
        }

        public string Error {  get {  Check(); string x; Native.Throw(_vt.GetError(IPtr, out x)); return x; }  }  

        public NoiseEngineState State {  get {  Check(); NoiseEngineState x; Native.Throw(_vt.GetState(IPtr, out x)); return x; }  }  

        public int SampleRate
        {
            get {  Check(); int x; Native.Throw(_vt.GetSampleRate(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetSampleRate(IPtr, value)); }  
        }

        public NoiseChannels Channels
        {
            get {  Check(); NoiseChannels x; Native.Throw(_vt.GetChannels(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetChannels(IPtr, value)); }  
        }

        public int BlockDuration
        {
            get {  Check(); int x; Native.Throw(_vt.GetBlockDuration(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetBlockDuration(IPtr, value)); }  
        }

        public NoiseDistribution Distribution
        {
            get {  Check(); NoiseDistribution x; Native.Throw(_vt.GetDistribution(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetDistribution(IPtr, value)); }  
        }

        public bool IsFilterEnabled
        {
            get {  Check(); bool x; Native.Throw(_vt.GetIsFilterEnabled(IPtr, out x)); return x; }   
            set {  Check(); Native.Throw(_vt.SetIsFilterEnabled(IPtr, value)); }  
        }

        public void Play()
        {
            Check();
            Native.Throw(_vt.Play(IPtr));
        }

        public void Pause()
        {
            Check();
            Native.Throw(_vt.Pause(IPtr));
        }

        public SignalBuffer GetPlot(double durationSeconds, PlotType type)
        {
            Check();
            IntPtr ___ret_abi;
            Native.Throw(_vt.GetPlot(IPtr, durationSeconds, type, out ___ret_abi));
            return GluonObject.Of<SignalBuffer>(___ret_abi);
        }

        #region Internal

        [System.Diagnostics.Conditional("DEBUG")]
        private void Check()
        {
            if (IPtr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name + " has been disposed");
        }

        internal NoiseEngine(AbiPtr i) : base(i)
        {
            IntPtr iptr;
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
            Marshal.Release(iptr);
            IPtr = iptr;
            _vt = VTUnknown.GetVTable<ABI.GluonTest.NoiseEngine>(IPtr);

            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_NoiseEngine_1(out instance_abi));
            return instance_abi;
        }

        public IntPtr IPtr { get; private set; } //IntPtr _i;
        ABI.GluonTest.NoiseEngine _vt;
        static Guid _ID = new Guid("5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931");

        #endregion
    }
}
