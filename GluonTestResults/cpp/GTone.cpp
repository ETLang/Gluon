#include "PCH.h"
#include "GluonTest.Common.h"
#include "GTone.h"
#include "Generator.h"
#include "Waveform.h"

using namespace GluonTest;


GTone::GTone()
{
}

double GTone::GetFrequency() const
{
    return DEFAULT_(double);
}

void GTone::SetFrequency(double value)
{
}

Waveform* GTone::GetWaveform() const
{
    return DEFAULT_(Waveform_t*);
}

void GTone::SetWaveform(Waveform_t* value)
{
}

double GTone::GetAmplitude() const
{
    return DEFAULT_(double);
}

void GTone::SetAmplitude(double value)
{
}

void GTone::Eval(double t, double& inoutOutSample)
{
}
