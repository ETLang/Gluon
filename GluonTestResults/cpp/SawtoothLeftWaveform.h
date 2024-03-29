#pragma once
#include "GluonTest.Common.h"
#include "Waveform.h"

namespace GluonTest { 
    class comid("7e985ffb-aea2-58d4-ab73-764e574c04ca") SawtoothLeftWaveform : public ComObject<SawtoothLeftWaveform, Waveform, ::ABI::GluonTest::SawtoothLeftWaveform>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::SawtoothLeftWaveform ABIType;

        SawtoothLeftWaveform();

    private:
#ifndef __INTELLISENSE__
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::GluonTest::SawtoothLeftWaveform); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "GluonTest.SawtoothLeftWaveform"; return S_OK; }

#endif
    // clang-format on
    #pragma endregion






    };
} 
