#pragma once
#include "GluonTest.Common.h"

namespace GluonTest { 
    class comid("68a756e3-dac4-3983-dd16-0a1437261fe6") ITestClass : public ComObject<ITestClass, Object, ::ABI::GluonTest::ITestClass>
    {
    #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::ITestClass ABIType;

        ITestClass();

        Event<void(int)> BigEvent {_BigEvent};

        PROPERTY(AddSomeShit, Adder);
        AddSomeShit GetAdder() const;
        void SetAdder(const AddSomeShit& value);

        PROPERTY(int, Property);
        int GetProperty() const;
        void SetProperty(int value);

        PROPERTY_READONLY(int, ReadOnlyProperty);
        int GetReadOnlyProperty() const;

        PROPERTY(Array<TestStruct>, HardProperty);
        Array<TestStruct> GetHardProperty() const;
        void SetHardProperty(Array<TestStruct> value);

        PROPERTY(Array<Delegate<string(char, int)>>, HarderProperty);
        Array<Delegate<string(char, int)>> GetHarderProperty() const;
        void SetHarderProperty(Array<Delegate<string(char, int)>> value);

        PROPERTY(Delegate<char(string)>, DumbDelegate);
        Delegate<char(string)> GetDumbDelegate() const;
        void SetDumbDelegate(const Delegate<char(string)>& value);

        void Methody();
        int RetMethod();
        void OutMethod(int& outX);
        void RefMethod(string& inoutThing);
        void Ref2(com_ptr<ITestClass>& inoutThing);
        void Ref3(const TestStruct& thing);
        Array<int> ComplexMethod(string& inoutA, IUnknown* _dumb, void* p, Array<char>& outFart);

    private:
        EventTrigger<void(int)> _BigEvent;

#ifndef __INTELLISENSE__
        METHOD _Methody();
        METHOD _RetMethod(int* ___ret);
        METHOD _OutMethod(int* outX);
        METHOD _RefMethod(char** inoutThing);
        METHOD _Ref2(::ABI::GluonTest::ITestClass** inoutThing);
        METHOD _Ref3(::ABI::GluonTest::TestStruct thing);
        METHOD _ComplexMethod(char** inoutA, IUnknown* _dumb, void* p, char** outFart, int* outFart_count, int** ___ret, int* ___ret_count);

        METHOD _GetAdder(fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)>* ___ret, IObject** ___ret_context);
        METHOD _SetAdder(fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)> value, IObject* value_context);
        METHOD _GetProperty(int* ___ret);
        METHOD _SetProperty(int value);
        METHOD _GetReadOnlyProperty(int* ___ret);
        METHOD _GetHardProperty(::ABI::GluonTest::TestStruct** ___ret, int* ___ret_count);
        METHOD _SetHardProperty(::ABI::GluonTest::TestStruct* value, int value_count);
        METHOD _GetHarderProperty(ABI::DelegateBlob** ___ret, int* ___ret_count);
        METHOD _SetHarderProperty(ABI::DelegateBlob* value, int value_count);
        METHOD _GetDumbDelegate(fn_ptr<HRESULT(IObject*,char*,char*)>* ___ret, IObject** ___ret_context);
        METHOD _SetDumbDelegate(fn_ptr<HRESULT(IObject*,char*,char*)> value, IObject* value_context);

        METHOD _AddBigEventHandler(fn_ptr<HRESULT(IObject*,int)> handler, IObject* handler_context);
        METHOD _RemoveBigEventHandler(fn_ptr<HRESULT(IObject*,int)> handler, IObject* handler_context);
#endif
    // clang-format on
    #pragma endregion







	public:
		~ITestClass();
		int _prop = 5;
    };
} 
