#include "SampleImageFilterApi.Common.h"
#include "SampleImage.h"

using namespace SampleImageFilterApi;
using namespace SampleImageFilter;


SampleImage::SampleImage(Array<byte> data, int width, int height)
{
    Not_Implemented_Warning
}

int SampleImage::GetWidth() const
{
    Not_Implemented_Warning

    return DEFAULT_(int);
}

int SampleImage::GetHeight() const
{
    Not_Implemented_Warning

    return DEFAULT_(int);
}

void SampleImage::CopyDataTo(Array<byte>& outData)
{
    Not_Implemented_Warning
}

void SampleImage::Save(string path)
{
    Not_Implemented_Warning
}

Thing SampleImage::GetThing()
{
    Not_Implemented_Warning

    return DEFAULT_(Thing);
}

Thing2 SampleImage::AnotherThing()
{
    Not_Implemented_Warning

    return DEFAULT_(Thing2);
}

SampleImageFilterApi::Thing SampleImage::GetThing()
{
    Not_Implemented_Warning

    return DEFAULT_(SampleImageFilterApi::Thing);
}

SampleImageFilterApi::Thing2 SampleImage::AnotherThing()
{
    Not_Implemented_Warning

    return DEFAULT_(SampleImageFilterApi::Thing2);
}
