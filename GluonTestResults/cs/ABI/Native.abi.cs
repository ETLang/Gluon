/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using Gluon;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;
using ABI.Gluon;

namespace ABI.GluonTest
{
    public static class Native
    {
        static Native()
        {
            GluonObject.RegisterType<global::GluonTest.DummyClass>(new Guid("68a756e3-dac4-3983-dd16-07353f3812e6"), native => new global::GluonTest.DummyClass(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.ConversionUnitTest>(new Guid("75bb5efc-b491-4dea-8973-735b3c230ed7"), native => new global::GluonTest.ConversionUnitTest(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.ITestClass>(new Guid("68a756e3-dac4-3983-dd16-0a1437261fe6"), native => new global::GluonTest.ITestClass(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SignalBuffer>(new Guid("7db242cd-a8a1-3983-dd16-1029353b0ac9"), native => new global::GluonTest.SignalBuffer(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.Waveform>(new Guid("1bd45afd-dac4-3983-dd16-142124300dca"), native => new global::GluonTest.Waveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SinusoidalWaveform>(new Guid("77b553e6-bb93-5cf5-bb79-62443c2018ca"), native => new global::GluonTest.SinusoidalWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SquareWaveform>(new Guid("7ea256d8-b5a2-54f1-dd16-1031273419c0"), native => new global::GluonTest.SquareWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.TriangleWaveform>(new Guid("7a8352e3-bfb2-56e5-af7b-17323b3405c2"), native => new global::GluonTest.TriangleWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SawtoothRightWaveform>(new Guid("72865ffb-b2a3-6ef7-bc60-75474a5369ca"), native => new global::GluonTest.SawtoothRightWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.SawtoothLeftWaveform>(new Guid("7e985ffb-aea2-58d4-ab73-764e574c04ca"), native => new global::GluonTest.SawtoothLeftWaveform(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.GTone>(new Guid("1bd4378f-dac4-3983-dd16-04143d3b0ea5"), native => new global::GluonTest.GTone(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.GWhiteNoise>(new Guid("68bd58c1-daa1-3983-dd16-04173a3c1fc0"), native => new global::GluonTest.GWhiteNoise(new AbiPtr(native)));
            GluonObject.RegisterType<global::GluonTest.NoiseEngine>(new Guid("75bd50e1-daa1-3983-dd16-0d2f3b260ee0"), native => new global::GluonTest.NoiseEngine(new AbiPtr(native)));
        }

        public const string DllPath = "GluonTestResultsCpp.dll";

        [DllImport(DllPath, EntryPoint = "$_GetGluonExceptionDetails")]
        private static extern int GetGluonExceptionDetails(out int outHR, out ExceptionType outType, out IntPtr outText);

        internal static void RegisterTypes() { }

        public static void Throw(int hr)
        {
            if (hr == (int)HResult.S_OK) return;

            int checkhr;
            ExceptionType type;
            IntPtr msgPtr;
            string msg;
            var chk = GetGluonExceptionDetails(out checkhr, out type, out msgPtr);
            if (chk != 0 || hr != checkhr) throw new GluonExceptionAssertionFail();
            msg = Marshal.PtrToStringAnsi(msgPtr);
            throw Translate.Exception(type, msg);
        }
    }
}
