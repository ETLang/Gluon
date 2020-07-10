#include "PCH.h"
#include "DummyClass.h"

using namespace GluonTest;


DummyClass::DummyClass()
{
    Not_Implemented_Warning
}

string DummyClass::GetNugget() const
{
    return _nugget;
}

void DummyClass::SetNugget(string value)
{
    _nugget = value;
}
