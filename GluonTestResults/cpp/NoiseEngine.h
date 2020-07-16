#pragma once
#include "GluonTest.Common.h"

namespace GluonTest { 
    class comid("75bd50e1-daa1-3983-dd16-0d2f3b260ee0") NoiseEngine : public ComObject<NoiseEngine, Object, ::ABI::GluonTest::NoiseEngine>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::NoiseEngine ABIType;

        NoiseEngine();

        PROPERTY_READONLY(string, Error);
        string GetError() const;

        PROPERTY_READONLY(NoiseEngineState, State);
        NoiseEngineState GetState() const;

        PROPERTY(int, SampleRate);
        int GetSampleRate() const;
        void SetSampleRate(int value);

        PROPERTY(NoiseChannels, Channels);
        NoiseChannels GetChannels() const;
        void SetChannels(NoiseChannels value);

        PROPERTY(int, BlockDuration);
        int GetBlockDuration() const;
        void SetBlockDuration(int value);

        PROPERTY(NoiseDistribution, Distribution);
        NoiseDistribution GetDistribution() const;
        void SetDistribution(NoiseDistribution value);

        PROPERTY(bool, IsFilterEnabled);
        bool GetIsFilterEnabled() const;
        void SetIsFilterEnabled(bool value);

        void Play();
        void Pause();
        com_ptr<SignalBuffer> GetPlot(double durationSeconds, PlotType type);

    private:
#ifndef __INTELLISENSE__
        METHOD _Play();
        METHOD _Pause();
        METHOD _GetPlot(double durationSeconds, PlotType type, ::ABI::GluonTest::SignalBuffer** ___ret);

        METHOD _GetError(char** ___ret);
        METHOD _GetState(NoiseEngineState* ___ret);
        METHOD _GetSampleRate(int* ___ret);
        METHOD _SetSampleRate(int value);
        METHOD _GetChannels(NoiseChannels* ___ret);
        METHOD _SetChannels(NoiseChannels value);
        METHOD _GetBlockDuration(int* ___ret);
        METHOD _SetBlockDuration(int value);
        METHOD _GetDistribution(NoiseDistribution* ___ret);
        METHOD _SetDistribution(NoiseDistribution value);
        METHOD _GetIsFilterEnabled(bool* ___ret);
        METHOD _SetIsFilterEnabled(bool value);
#endif
    // clang-format on
    #pragma endregion






    };
} 
