#pragma once
#include "GluonTest.Common.h"
#include "Waveform.h"

namespace GluonTest { 
    class comid("72865ffb-b2a3-6ef7-bc60-75474a5369ca") SawtoothRightWaveform : public ComObject<SawtoothRightWaveform, Waveform, ::ABI::GluonTest::SawtoothRightWaveform>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::SawtoothRightWaveform ABIType;

        SawtoothRightWaveform();

    private:
#ifndef __INTELLISENSE__
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::GluonTest::SawtoothRightWaveform); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "GluonTest.SawtoothRightWaveform"; return S_OK; }

#endif
    // clang-format on
    #pragma endregion






    };
} 
