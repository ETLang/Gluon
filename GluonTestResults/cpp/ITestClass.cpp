#include "PCH.h"
#include "ITestClass.h"

using namespace GluonTest;

ITestClass::ITestClass()
{
    Not_Implemented_Warning
}

ITestClass::~ITestClass()
{
	_prop = 77;
}

int ITestClass::GetProperty() const
{
	return _prop;
}

void ITestClass::SetProperty(int value)
{
	_prop = value;
}

int ITestClass::GetReadOnlyProperty() const
{
	return 42;
}

int ITestClass::RetMethod()
{
    Not_Implemented_Warning

    return DEFAULT_(int);
}

void ITestClass::Ref3(const TestStruct& thing)
{
    Not_Implemented_Warning
}

Delegate<char(string)> ITestClass::GetDumbDelegate() const
{
    Not_Implemented_Warning

    return DEFAULT_(Delegate<char(string)>);
}

void ITestClass::SetDumbDelegate(const Delegate<char(string)>& value)
{
    Not_Implemented_Warning
}


AddSomeShit ITestClass::GetAdder() const
{
    Not_Implemented_Warning
    return DEFAULT_(AddSomeShit);
}


void ITestClass::SetAdder(const AddSomeShit& value)
{
    Not_Implemented_Warning
}


void ITestClass::Methody()
{
    Not_Implemented_Warning
}


void ITestClass::OutMethod(int& outX)
{
    Not_Implemented_Warning
}


void ITestClass::RefMethod(string& inoutThing)
{
    Not_Implemented_Warning
}


Array<int> ITestClass::ComplexMethod(string& inoutA, IUnknown* _dumb, void* p, Array<char>& outFart)
{
    Not_Implemented_Warning

    return DEFAULT_(Array<int>);
}


void ITestClass::Ref2(com_ptr<ITestClass>& inoutThing)
{
    Not_Implemented_Warning
}


Array<TestStruct> ITestClass::GetHardProperty() const
{
    Not_Implemented_Warning
    return DEFAULT_(Array<TestStruct>);
}


void ITestClass::SetHardProperty(Array<TestStruct> value)
{
    Not_Implemented_Warning
}


Array<Delegate<string(char, int)>> ITestClass::GetHarderProperty() const
{
    Not_Implemented_Warning
    return DEFAULT_(Array<Delegate<string(char, int)>>);
}


void ITestClass::SetHarderProperty(Array<Delegate<string(char, int)>> value)
{
    Not_Implemented_Warning
}
