#include "PCH.h"
#include "NoiseEngine.h"
#include "SignalBuffer.h"

using namespace GluonTest;


NoiseEngine::NoiseEngine()
{
    Not_Implemented_Warning
}

string NoiseEngine::GetError() const
{
    Not_Implemented_Warning

    return DEFAULT_(string);
}

NoiseEngineState NoiseEngine::GetState() const
{
    Not_Implemented_Warning

    return DEFAULT_(NoiseEngineState);
}

int NoiseEngine::GetSampleRate() const
{
    Not_Implemented_Warning

    return DEFAULT_(int);
}

void NoiseEngine::SetSampleRate(int value)
{
    Not_Implemented_Warning
}

NoiseChannels NoiseEngine::GetChannels() const
{
    Not_Implemented_Warning

    return DEFAULT_(NoiseChannels);
}

void NoiseEngine::SetChannels(NoiseChannels value)
{
    Not_Implemented_Warning
}

int NoiseEngine::GetBlockDuration() const
{
    Not_Implemented_Warning

    return DEFAULT_(int);
}

void NoiseEngine::SetBlockDuration(int value)
{
    Not_Implemented_Warning
}

NoiseDistribution NoiseEngine::GetDistribution() const
{
    Not_Implemented_Warning

    return DEFAULT_(NoiseDistribution);
}

void NoiseEngine::SetDistribution(NoiseDistribution value)
{
    Not_Implemented_Warning
}

void NoiseEngine::Play()
{
    Not_Implemented_Warning
}

com_ptr<SignalBuffer> NoiseEngine::GetPlot(double durationSeconds, PlotType type)
{
	int myimp = 0;

	return nullptr;
}

void NoiseEngine::Pause()
{
    Not_Implemented_Warning
}

bool NoiseEngine::GetIsFilterEnabled() const
{
    Not_Implemented_Warning
    return DEFAULT_(bool);
}


void NoiseEngine::SetIsFilterEnabled(bool value)
{
    Not_Implemented_Warning
}
