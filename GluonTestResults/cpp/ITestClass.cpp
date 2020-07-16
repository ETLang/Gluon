#include "PCH.h"
#include "ITestClass.h"

using namespace GluonTest;

ITestClass::ITestClass()
{
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
    return DEFAULT_(int);
}

void ITestClass::Ref3(const TestStruct& thing)
{
}

Delegate<char(string)> ITestClass::GetDumbDelegate() const
{
    return DEFAULT_(Delegate<char(string)>);
}

void ITestClass::SetDumbDelegate(const Delegate<char(string)>& value)
{
}


AddSomeShit ITestClass::GetAdder() const
{
    return DEFAULT_(AddSomeShit);
}


void ITestClass::SetAdder(const AddSomeShit& value)
{
}


void ITestClass::Methody()
{
}


void ITestClass::OutMethod(int& outX)
{
}


void ITestClass::RefMethod(string& inoutThing)
{
}


Array<int> ITestClass::ComplexMethod(string& inoutA, IUnknown* _dumb, void* p, Array<char>& outFart)
{
    return DEFAULT_(Array<int>);
}


void ITestClass::Ref2(com_ptr<ITestClass>& inoutThing)
{
}


Array<TestStruct> ITestClass::GetHardProperty() const
{
    return DEFAULT_(Array<TestStruct>);
}


void ITestClass::SetHardProperty(Array<TestStruct> value)
{
}


Array<Delegate<string(char, int)>> ITestClass::GetHarderProperty() const
{
    return DEFAULT_(Array<Delegate<string(char, int)>>);
}


void ITestClass::SetHarderProperty(Array<Delegate<string(char, int)>> value)
{
}
