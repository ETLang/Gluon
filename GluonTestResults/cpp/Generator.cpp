#include "PCH.h"
#include "Generator.h"
#include "SignalBuffer.h"
#include <ppltasks.h>

using namespace GluonTest;


int Generator::GetChannelCount() const
{
    return DEFAULT_(int);
}

int Generator::GetSampleRate() const
{
    return DEFAULT_(int);
}

void Generator::Initialize(int channels, int sampleRate)
{
}

void Generator::EvalBuffer(double t, SignalBuffer* inoutBuffer)
{
}
