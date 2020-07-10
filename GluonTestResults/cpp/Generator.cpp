#include "PCH.h"
#include "Generator.h"
#include "SignalBuffer.h"
#include <ppltasks.h>

using namespace GluonTest;


int Generator::GetChannelCount() const
{
    Not_Implemented_Warning

    return DEFAULT_(int);
}

int Generator::GetSampleRate() const
{
    Not_Implemented_Warning

    return DEFAULT_(int);
}

void Generator::Initialize(int channels, int sampleRate)
{
    Not_Implemented_Warning
}

void Generator::EvalBuffer(double t, SignalBuffer* inoutBuffer)
{
    Not_Implemented_Warning
}
