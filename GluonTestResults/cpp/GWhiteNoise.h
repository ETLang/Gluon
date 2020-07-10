#pragma once
#include "GluonTest.Common.h"
#include "Generator.h"


namespace GluonTest
{
    class comid("68bd58c1-daa1-3983-dd16-04173a3c1fc0")
    GWhiteNoise : public ComObject<GWhiteNoise, Generator, ::ABI::GluonTest::GWhiteNoise>
    {
    #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::GWhiteNoise ABIType;

        GWhiteNoise();

        void Eval(double t, double& inoutOutSample) override;

    private:
#ifndef __INTELLISENSE__

#endif
    // clang-format on
    #pragma endregion






    };
}

