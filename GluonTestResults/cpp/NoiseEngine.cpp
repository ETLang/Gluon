#include "PCH.h"
#include "NoiseEngine.h"
#include "SignalBuffer.h"

using namespace GluonTest;


NoiseEngine::NoiseEngine()
{
}

string NoiseEngine::GetError() const
{
    return DEFAULT_(string);
}

NoiseEngineState NoiseEngine::GetState() const
{
    return DEFAULT_(NoiseEngineState);
}

int NoiseEngine::GetSampleRate() const
{
    return DEFAULT_(int);
}

void NoiseEngine::SetSampleRate(int value)
{
}

NoiseChannels NoiseEngine::GetChannels() const
{
    return DEFAULT_(NoiseChannels);
}

void NoiseEngine::SetChannels(NoiseChannels value)
{
}

int NoiseEngine::GetBlockDuration() const
{
    return DEFAULT_(int);
}

void NoiseEngine::SetBlockDuration(int value)
{
}

NoiseDistribution NoiseEngine::GetDistribution() const
{
    return DEFAULT_(NoiseDistribution);
}

void NoiseEngine::SetDistribution(NoiseDistribution value)
{
}

void NoiseEngine::Play()
{
}

com_ptr<SignalBuffer> NoiseEngine::GetPlot(double durationSeconds, PlotType type)
{
	int myimp = 0;

	return nullptr;
}

void NoiseEngine::Pause()
{
}

bool NoiseEngine::GetIsFilterEnabled() const
{
    return DEFAULT_(bool);
}


void NoiseEngine::SetIsFilterEnabled(bool value)
{
}
