#pragma once
#include "GluonTest.Common.h"

namespace GluonTest { 
    class comid("75bb5efc-b491-4dea-8973-735b3c230ed7")
    ConversionUnitTest : public ComObject<ConversionUnitTest, Object, ::ABI::GluonTest::ConversionUnitTest>
    {
    #pragma region Gluon Maintained
    // clang-format off
        using PrimitivesCB_t = PrimitivesCB;
        using StringsCB_t = StringsCB;
        using SimpleStructsCB_t = SimpleStructsCB;
        using ComplexStructsCB_t = ComplexStructsCB;
        using ObjectsCB_t = ObjectsCB;
        using NamedDelegatesCB_t = NamedDelegatesCB;
        using GenericDelegatesCB_t = GenericDelegatesCB;
        using PrimitiveArraysCB_t = PrimitiveArraysCB;
        using StringArraysCB_t = StringArraysCB;
        using SimpleStructArraysCB_t = SimpleStructArraysCB;
        using ComplexStructArraysCB_t = ComplexStructArraysCB;
        using ObjectArraysCB_t = ObjectArraysCB;
        using NamedDelegateArraysCB_t = NamedDelegateArraysCB;
        using GenericDelegateArraysCB_t = GenericDelegateArraysCB;

    public:
        typedef ::ABI::GluonTest::ConversionUnitTest ABIType;

        ConversionUnitTest();

        PROPERTY(PrimitivesCB_t, PrimitivesCB);
        PrimitivesCB_t GetPrimitivesCB() const;
        void SetPrimitivesCB(const PrimitivesCB_t& value);

        PROPERTY(StringsCB_t, StringsCB);
        StringsCB_t GetStringsCB() const;
        void SetStringsCB(const StringsCB_t& value);

        PROPERTY(SimpleStructsCB_t, SimpleStructsCB);
        SimpleStructsCB_t GetSimpleStructsCB() const;
        void SetSimpleStructsCB(const SimpleStructsCB_t& value);

        PROPERTY(ComplexStructsCB_t, ComplexStructsCB);
        ComplexStructsCB_t GetComplexStructsCB() const;
        void SetComplexStructsCB(const ComplexStructsCB_t& value);

        PROPERTY(ObjectsCB_t, ObjectsCB);
        ObjectsCB_t GetObjectsCB() const;
        void SetObjectsCB(const ObjectsCB_t& value);

        PROPERTY(NamedDelegatesCB_t, NamedDelegatesCB);
        NamedDelegatesCB_t GetNamedDelegatesCB() const;
        void SetNamedDelegatesCB(const NamedDelegatesCB_t& value);

        PROPERTY(GenericDelegatesCB_t, GenericDelegatesCB);
        GenericDelegatesCB_t GetGenericDelegatesCB() const;
        void SetGenericDelegatesCB(const GenericDelegatesCB_t& value);

        PROPERTY(PrimitiveArraysCB_t, PrimitiveArraysCB);
        PrimitiveArraysCB_t GetPrimitiveArraysCB() const;
        void SetPrimitiveArraysCB(const PrimitiveArraysCB_t& value);

        PROPERTY(StringArraysCB_t, StringArraysCB);
        StringArraysCB_t GetStringArraysCB() const;
        void SetStringArraysCB(const StringArraysCB_t& value);

        PROPERTY(SimpleStructArraysCB_t, SimpleStructArraysCB);
        SimpleStructArraysCB_t GetSimpleStructArraysCB() const;
        void SetSimpleStructArraysCB(const SimpleStructArraysCB_t& value);

        PROPERTY(ComplexStructArraysCB_t, ComplexStructArraysCB);
        ComplexStructArraysCB_t GetComplexStructArraysCB() const;
        void SetComplexStructArraysCB(const ComplexStructArraysCB_t& value);

        PROPERTY(ObjectArraysCB_t, ObjectArraysCB);
        ObjectArraysCB_t GetObjectArraysCB() const;
        void SetObjectArraysCB(const ObjectArraysCB_t& value);

        PROPERTY(NamedDelegateArraysCB_t, NamedDelegateArraysCB);
        NamedDelegateArraysCB_t GetNamedDelegateArraysCB() const;
        void SetNamedDelegateArraysCB(const NamedDelegateArraysCB_t& value);

        PROPERTY(GenericDelegateArraysCB_t, GenericDelegateArraysCB);
        GenericDelegateArraysCB_t GetGenericDelegateArraysCB() const;
        void SetGenericDelegateArraysCB(const GenericDelegateArraysCB_t& value);

        PROPERTY(StructMemberTest, StructMembers);
        StructMemberTest GetStructMembers() const;
        void SetStructMembers(const StructMemberTest& value);

        double Primitives(bool inTest, char& outOutTest, int& inoutRefTest);
        string Strings(string inTest, string& outOutTest, string& inoutRefTest);
        BlittableStruct SimpleStructs(const BlittableStruct& inTest, BlittableStruct& outOutTest, BlittableStruct& inoutRefTest);
        ComplexStruct ComplexStructs(const ComplexStruct& inTest, ComplexStruct& outOutTest, ComplexStruct& inoutRefTest);
        com_ptr<DummyClass> Objects(DummyClass* inTest, com_ptr<DummyClass>& outOutTest, com_ptr<DummyClass>& inoutRefTest);
        NamedDelegate NamedDelegates(const NamedDelegate& inTest, NamedDelegate& outOutTest, NamedDelegate& inoutRefTest);
        Delegate<int(int)> GenericDelegates(const Delegate<void(string)>& inTest, Delegate<void(const Delegate<int(int)>&)>& outOutTest, Delegate<string(Array<char>)>& inoutRefTest);
        Array<double> PrimitiveArrays(Array<bool> inTest, Array<char>& outOutTest, Array<int>& inoutRefTest);
        Array<string> StringArrays(Array<string> inTest, Array<string>& outOutTest, Array<string>& inoutRefTest);
        Array<BlittableStruct> SimpleStructArrays(Array<BlittableStruct> inTest, Array<BlittableStruct>& outOutTest, Array<BlittableStruct>& inoutRefTest);
        Array<ComplexStruct> ComplexStructArrays(Array<ComplexStruct> inTest, Array<ComplexStruct>& outOutTest, Array<ComplexStruct>& inoutRefTest);
        Array<com_ptr<DummyClass>> ObjectArrays(Array<com_ptr<DummyClass>> inTest, Array<com_ptr<DummyClass>>& outOutTest, Array<com_ptr<DummyClass>>& inoutRefTest);
        Array<NamedDelegate> NamedDelegateArrays(Array<NamedDelegate> inTest, Array<NamedDelegate>& outOutTest, Array<NamedDelegate>& inoutRefTest);
        Array<Delegate<int(int)>> GenericDelegateArrays(Array<Delegate<void(string)>> inTest, Array<Delegate<void(const Delegate<int(int)>&)>>& outOutTest, Array<Delegate<string(Array<char>)>>& inoutRefTest);
        void ExCheckNullReference();
        void ExCheckArgumentNull();
        void ExCheckArgument();
        void ExCheckInvalidOperation();
        void ExCheckAccessDenied();
        void ExCheckGeneric();
        void ExCheckGenericStd();
        void ExCheckNotImplemented();

    private:
#ifndef __INTELLISENSE__
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::GluonTest::ConversionUnitTest); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "GluonTest.ConversionUnitTest"; return S_OK; }
        METHOD _Primitives(bool inTest, char* outOutTest, int* inoutRefTest, double* ___ret);
        METHOD _Strings(char* inTest, char** outOutTest, char** inoutRefTest, char** ___ret);
        METHOD _SimpleStructs(::ABI::GluonTest::BlittableStruct inTest, ::ABI::GluonTest::BlittableStruct* outOutTest, ::ABI::GluonTest::BlittableStruct* inoutRefTest, ::ABI::GluonTest::BlittableStruct* ___ret);
        METHOD _ComplexStructs(::ABI::GluonTest::ComplexStruct inTest, ::ABI::GluonTest::ComplexStruct* outOutTest, ::ABI::GluonTest::ComplexStruct* inoutRefTest, ::ABI::GluonTest::ComplexStruct* ___ret);
        METHOD _Objects(::ABI::GluonTest::DummyClass* inTest, ::ABI::GluonTest::DummyClass** outOutTest, ::ABI::GluonTest::DummyClass** inoutRefTest, ::ABI::GluonTest::DummyClass** ___ret);
        METHOD _NamedDelegates(fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outOutTest, IObject** outOutTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* inoutRefTest, IObject** inoutRefTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context);
        METHOD _GenericDelegates(fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outOutTest, IObject** outOutTest_context, fn_ptr<HRESULT(IObject*,char*,int,char**)>* inoutRefTest, IObject** inoutRefTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context);
        METHOD _PrimitiveArrays(bool* inTest, int inTest_count, char** outOutTest, int* outOutTest_count, int** inoutRefTest, int* inoutRefTest_count, double** ___ret, int* ___ret_count);
        METHOD _StringArrays(char** inTest, int inTest_count, char*** outOutTest, int* outOutTest_count, char*** inoutRefTest, int* inoutRefTest_count, char*** ___ret, int* ___ret_count);
        METHOD _SimpleStructArrays(::ABI::GluonTest::BlittableStruct* inTest, int inTest_count, ::ABI::GluonTest::BlittableStruct** outOutTest, int* outOutTest_count, ::ABI::GluonTest::BlittableStruct** inoutRefTest, int* inoutRefTest_count, ::ABI::GluonTest::BlittableStruct** ___ret, int* ___ret_count);
        METHOD _ComplexStructArrays(::ABI::GluonTest::ComplexStruct* inTest, int inTest_count, ::ABI::GluonTest::ComplexStruct** outOutTest, int* outOutTest_count, ::ABI::GluonTest::ComplexStruct** inoutRefTest, int* inoutRefTest_count, ::ABI::GluonTest::ComplexStruct** ___ret, int* ___ret_count);
        METHOD _ObjectArrays(::ABI::GluonTest::DummyClass** inTest, int inTest_count, ::ABI::GluonTest::DummyClass*** outOutTest, int* outOutTest_count, ::ABI::GluonTest::DummyClass*** inoutRefTest, int* inoutRefTest_count, ::ABI::GluonTest::DummyClass*** ___ret, int* ___ret_count);
        METHOD _NamedDelegateArrays(ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outOutTest, int* outOutTest_count, ABI::DelegateBlob** inoutRefTest, int* inoutRefTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
        METHOD _GenericDelegateArrays(ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outOutTest, int* outOutTest_count, ABI::DelegateBlob** inoutRefTest, int* inoutRefTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
        METHOD _ExCheckNullReference();
        METHOD _ExCheckArgumentNull();
        METHOD _ExCheckArgument();
        METHOD _ExCheckInvalidOperation();
        METHOD _ExCheckAccessDenied();
        METHOD _ExCheckGeneric();
        METHOD _ExCheckGenericStd();
        METHOD _ExCheckNotImplemented();

        METHOD _GetPrimitivesCB(fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>* ___ret, IObject** ___ret_context);
        METHOD _SetPrimitivesCB(fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)> value, IObject* value_context);
        METHOD _GetStringsCB(fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>* ___ret, IObject** ___ret_context);
        METHOD _SetStringsCB(fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)> value, IObject* value_context);
        METHOD _GetSimpleStructsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)>* ___ret, IObject** ___ret_context);
        METHOD _SetSimpleStructsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)> value, IObject* value_context);
        METHOD _GetComplexStructsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)>* ___ret, IObject** ___ret_context);
        METHOD _SetComplexStructsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)> value, IObject* value_context);
        METHOD _GetObjectsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)>* ___ret, IObject** ___ret_context);
        METHOD _SetObjectsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)> value, IObject* value_context);
        METHOD _GetNamedDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>* ___ret, IObject** ___ret_context);
        METHOD _SetNamedDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)> value, IObject* value_context);
        METHOD _GetGenericDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>* ___ret, IObject** ___ret_context);
        METHOD _SetGenericDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)> value, IObject* value_context);
        METHOD _GetPrimitiveArraysCB(fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>* ___ret, IObject** ___ret_context);
        METHOD _SetPrimitiveArraysCB(fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)> value, IObject* value_context);
        METHOD _GetStringArraysCB(fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>* ___ret, IObject** ___ret_context);
        METHOD _SetStringArraysCB(fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)> value, IObject* value_context);
        METHOD _GetSimpleStructArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)>* ___ret, IObject** ___ret_context);
        METHOD _SetSimpleStructArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)> value, IObject* value_context);
        METHOD _GetComplexStructArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)>* ___ret, IObject** ___ret_context);
        METHOD _SetComplexStructArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)> value, IObject* value_context);
        METHOD _GetObjectArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)>* ___ret, IObject** ___ret_context);
        METHOD _SetObjectArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)> value, IObject* value_context);
        METHOD _GetNamedDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>* ___ret, IObject** ___ret_context);
        METHOD _SetNamedDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)> value, IObject* value_context);
        METHOD _GetGenericDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>* ___ret, IObject** ___ret_context);
        METHOD _SetGenericDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)> value, IObject* value_context);
        METHOD _GetStructMembers(::ABI::GluonTest::StructMemberTest* ___ret);
        METHOD _SetStructMembers(::ABI::GluonTest::StructMemberTest value);

#endif
    // clang-format on
    #pragma endregion



        virtual ULONG STDMETHODCALLTYPE AddRef()
        {
            return Base::AddRef();
        }

        virtual ULONG STDMETHODCALLTYPE Release()
        {
            return Base::Release();
        }



    private:
        PrimitivesCB_t _primitivesCB;
        StringsCB_t _stringsCB;
        SimpleStructsCB_t _simpleStructsCB;
        ComplexStructsCB_t _complexStructsCB;
        ObjectsCB_t _objectsCB;
        NamedDelegatesCB_t _namedDelegatesCB;
        GenericDelegatesCB_t _genericDelegatesCB;
        PrimitiveArraysCB_t _primitiveArraysCB;
        StringArraysCB_t _stringArraysCB;
        SimpleStructArraysCB_t _simpleStructArraysCB;
        ComplexStructArraysCB_t _complexStructArraysCB;
        ObjectArraysCB_t _objectArraysCB;
        NamedDelegateArraysCB_t _namedDelegateArraysCB;
        GenericDelegateArraysCB_t _genericDelegateArraysCB;
    };
}
