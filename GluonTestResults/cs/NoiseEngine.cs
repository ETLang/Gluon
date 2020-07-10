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

        static NoiseEngine()
        {
            ABI.GluonTest.Native.RegisterTypes();
            StaticInit();
        }

        public NoiseEngine() : this(new AbiPtr(Make())) {  Init(); }  

        public string Error {  get {  string x; Native.Throw(_vt.GetError(_i, out x)); return x; }  }  

        public NoiseEngineState State {  get {  NoiseEngineState x; Native.Throw(_vt.GetState(_i, out x)); return x; }  }  

        public int SampleRate
        {
            get {  int x; Native.Throw(_vt.GetSampleRate(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetSampleRate(_i, value)); }  
        }

        public NoiseChannels Channels
        {
            get {  NoiseChannels x; Native.Throw(_vt.GetChannels(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetChannels(_i, value)); }  
        }

        public int BlockDuration
        {
            get {  int x; Native.Throw(_vt.GetBlockDuration(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetBlockDuration(_i, value)); }  
        }

        public NoiseDistribution Distribution
        {
            get {  NoiseDistribution x; Native.Throw(_vt.GetDistribution(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetDistribution(_i, value)); }  
        }

        public bool IsFilterEnabled
        {
            get {  bool x; Native.Throw(_vt.GetIsFilterEnabled(_i, out x)); return x; }   
            set {  Native.Throw(_vt.SetIsFilterEnabled(_i, value)); }  
        }

        public void Play()
        {
            Native.Throw(_vt.Play1(_i));
        }

        public void Pause()
        {
            Native.Throw(_vt.Pause2(_i));
        }

        public SignalBuffer GetPlot(double durationSeconds, PlotType type)
        {
            IntPtr ___ret_abi;
            Native.Throw(_vt.GetPlot3(_i, durationSeconds, type, out ___ret_abi));
            return GluonObject.Of<SignalBuffer>(___ret_abi);
        }

        #region Internal

        internal NoiseEngine(AbiPtr i) : base(i)
        {
            Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out _i));
            Marshal.Release(_i);
            _vt = VTUnknown.GetVTable<ABI.GluonTest.NoiseEngine>(_i);
            Init();
        }

        private static IntPtr Make()
        {
            IntPtr instance_abi;
            Native.Throw(ABI.GluonTest.Factory.Create_GluonTest_NoiseEngine_1(out instance_abi));
            return instance_abi;
        }

        IntPtr _i;
        ABI.GluonTest.NoiseEngine _vt;
        static Guid _ID = new Guid("5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931");

        #endregion
    }
}
