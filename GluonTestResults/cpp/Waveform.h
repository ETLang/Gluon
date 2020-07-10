#pragma once
#include "GluonTest.Common.h"

namespace GluonTest { 
    class comid("1bd45afd-dac4-3983-dd16-142124300dca") Waveform : public ComObject<Waveform, Object, ::ABI::GluonTest::Waveform>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::Waveform ABIType;

        Waveform(Array<double> samples);

        double Phase(double t);

    private:
#ifndef __INTELLISENSE__
        METHOD _Phase(double t, double* ___ret);

#endif
    // clang-format on
    #pragma endregion






    };
} 
