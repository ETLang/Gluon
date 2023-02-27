#pragma once
#include "GluonTest.Common.h"

namespace GluonTest { 
    class comid("1ba658fb-dac4-3983-dd16-04253c3019c4") Generator : public ComObject<Generator, Object, ::ABI::GluonTest::Generator>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::Generator ABIType;

        PROPERTY_READONLY(int, ChannelCount);
        int GetChannelCount() const;

        PROPERTY_READONLY(int, SampleRate);
        int GetSampleRate() const;

        void Initialize(int channels, int sampleRate);
        virtual void Eval(double t, double& inoutOutSample) = 0;
        void EvalBuffer(double t, SignalBuffer* inoutBuffer);

    private:
#ifndef __INTELLISENSE__
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::GluonTest::Generator); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "GluonTest.Generator"; return S_OK; }
        METHOD _Initialize(int channels, int sampleRate);
        METHOD _Eval(double t, double* inoutOutSample);
        METHOD _EvalBuffer(double t, ::ABI::GluonTest::SignalBuffer* inoutBuffer);

        METHOD _GetChannelCount(int* ___ret);
        METHOD _GetSampleRate(int* ___ret);

#endif
    // clang-format on
    #pragma endregion






    };
} 
