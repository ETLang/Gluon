#include "PCH.h"
#include "GluonTest.Common.h"
#include "GTone.h"
#include "Generator.h"
#include "Waveform.h"

using namespace GluonTest;


GTone::GTone()
{
    Not_Implemented_Warning
}

double GTone::GetFrequency() const
{
    Not_Implemented_Warning
    return DEFAULT_(double);
}

void GTone::SetFrequency(double value)
{
    Not_Implemented_Warning
}

Waveform* GTone::GetWaveform() const
{
    Not_Implemented_Warning
    return DEFAULT_(Waveform_t);
}

void GTone::SetWaveform(Waveform_t* value)
{
    Not_Implemented_Warning
}

double GTone::GetAmplitude() const
{
    Not_Implemented_Warning
    return DEFAULT_(double);
}

void GTone::SetAmplitude(double value)
{
    Not_Implemented_Warning
}

void GTone::Eval(double t, double& inoutOutSample)
{
    Not_Implemented_Warning
}
