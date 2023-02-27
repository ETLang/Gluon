#pragma once
#include "GluonTest.Common.h"
#include "Waveform.h"

namespace GluonTest { 
    class comid("7a8352e3-bfb2-56e5-af7b-17323b3405c2") TriangleWaveform : public ComObject<TriangleWaveform, Waveform, ::ABI::GluonTest::TriangleWaveform>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::TriangleWaveform ABIType;

        TriangleWaveform();

    private:
#ifndef __INTELLISENSE__
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::GluonTest::TriangleWaveform); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "GluonTest.TriangleWaveform"; return S_OK; }

#endif
    // clang-format on
    #pragma endregion






    };
} 
