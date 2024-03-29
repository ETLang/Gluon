#pragma once
#include "GluonTest.Common.h"
#include "Waveform.h"

namespace GluonTest { 
    class comid("77b553e6-bb93-5cf5-bb79-62443c2018ca") SinusoidalWaveform : public ComObject<SinusoidalWaveform, Waveform, ::ABI::GluonTest::SinusoidalWaveform>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::SinusoidalWaveform ABIType;

        SinusoidalWaveform();

    private:
#ifndef __INTELLISENSE__
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::GluonTest::SinusoidalWaveform); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "GluonTest.SinusoidalWaveform"; return S_OK; }

#endif
    // clang-format on
    #pragma endregion






    };
} 
