#pragma once
#include "GluonTest.Common.h"
#include "Waveform.h"

namespace GluonTest { 
    class comid("7ea256d8-b5a2-54f1-dd16-1031273419c0") SquareWaveform : public ComObject<SquareWaveform, Waveform, ::ABI::GluonTest::SquareWaveform>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::SquareWaveform ABIType;

        SquareWaveform();

    private:
#ifndef __INTELLISENSE__
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::GluonTest::SquareWaveform); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "GluonTest.SquareWaveform"; return S_OK; }

#endif
    // clang-format on
    #pragma endregion






    };
} 
