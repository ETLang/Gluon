#pragma once
#include "GluonTest.Common.h"
#include "Generator.h"


namespace GluonTest
{
    class comid("1bd4378f-dac4-3983-dd16-04143d3b0ea5")
    GTone : public ComObject<GTone, Generator, ::ABI::GluonTest::GTone>
    {
    #pragma region Gluon Maintained
    // clang-format off
        using Waveform_t = Waveform;

    public:
        typedef ::ABI::GluonTest::GTone ABIType;

        GTone();

        PROPERTY(double, Frequency);
        double GetFrequency() const;
        void SetFrequency(double value);

        PROPERTY(Waveform_t*, Waveform);
        Waveform_t* GetWaveform() const;
        void SetWaveform(Waveform_t* value);

        PROPERTY(double, Amplitude);
        double GetAmplitude() const;
        void SetAmplitude(double value);

        void Eval(double t, double& inoutOutSample) override;

    private:
#ifndef __INTELLISENSE__

        METHOD _GetFrequency(double* ___ret);
        METHOD _SetFrequency(double value);
        METHOD _GetWaveform(::ABI::GluonTest::Waveform** ___ret);
        METHOD _SetWaveform(::ABI::GluonTest::Waveform* value);
        METHOD _GetAmplitude(double* ___ret);
        METHOD _SetAmplitude(double value);

#endif
    // clang-format on
    #pragma endregion






    };
}

