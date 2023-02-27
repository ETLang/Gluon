/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#pragma once
#include <Sharpish.h>

using namespace CS;

#include "GluonNative.h"

void GluonTest_Initialize();

namespace GluonTest
{
    using namespace GluonInternal;

    struct BlittableStruct;
}

namespace ABI
{
    namespace GluonTest
    {
        using ::GluonTest::BlittableStruct;
        struct ComplexStruct;
        struct StructMemberTest;
        struct TestStruct;
        cominterface DummyClass;
        cominterface ConversionUnitTest;
        cominterface ITestClass;
        cominterface Generator;
        cominterface SignalBuffer;
        cominterface Waveform;
        cominterface SinusoidalWaveform;
        cominterface SquareWaveform;
        cominterface TriangleWaveform;
        cominterface SawtoothRightWaveform;
        cominterface SawtoothLeftWaveform;
        cominterface GTone;
        cominterface GWhiteNoise;
        cominterface NoiseEngine;
    }
}

namespace ABI
{
    namespace System
    {
        using namespace GluonInternal;
    }
}

namespace ABI
{
    namespace GluonTest
    {
    }
}

namespace ABI
{
    namespace System
    {
    }
}

namespace ABI
{
    namespace GluonTest
    {
    }
}

namespace ABI
{
    namespace System
    {
    }
}

namespace ABI
{
    namespace GluonTest
    {
    }
}

namespace ABI
{
    namespace System
    {
    }
}

namespace GluonTest
{
    enum class Foo : int
    {
        Doo,
        Boo,
        Noo  = 0x00000003,
        Blu  = 0x00000005
    };

    enum class NoiseEngineState : int
    {
        Idle,
        Running,
        Failed
    };

    enum class NoiseChannels : int
    {
        Mono,
        Stereo
    };

    enum class NoiseDistribution : int
    {
        Uniform,
        Gaussian
    };

    enum class PlotType : int
    {
        Signal,
        FFT
    };

    struct comid("6f39e9f3-a2ff-5fce-92c5-df341bfb9815") BlittableStruct
    {
        int x;
        int y;
        double u;
        double v;

        BlittableStruct() { }
        BlittableStruct(int _x, int _y, double _u, double _v) : 
            x(_x), y(_y), u(_u), v(_v)
        { }
    };
}

IS_VALUETYPE(::GluonTest::BlittableStruct, "6f39e9f3-a2ff-5fce-92c5-df341bfb9815");


namespace ABI
{
    namespace GluonTest
    {
        using ::GluonTest::Foo;
        using ::GluonTest::NoiseEngineState;
        using ::GluonTest::NoiseChannels;
        using ::GluonTest::NoiseDistribution;
        using ::GluonTest::PlotType;
        using ::GluonTest::BlittableStruct;

        struct comid("4e28d6e9-b3fe-3ccf-e6c5-de371fff8011") ComplexStruct
        {
            char* Name;
            BlittableStruct Sub;
            DummyClass* Obj;
            ABI::DelegateBlob Del;

            ComplexStruct() { }
            ComplexStruct(char* _Name, BlittableStruct _Sub, DummyClass* _Obj, fn_ptr<HRESULT(IObject*,int,int,int*)> _Del, IObject* _Del_context) : 
                Name(_Name), Sub(_Sub), Obj(_Obj), Del(_Del, _Del_context)
            { }
        };
    }
}

IS_VALUETYPE(::ABI::GluonTest::ComplexStruct, "4e28d6e9-b3fe-3ccf-e6c5-de371fff8011");

namespace ABI
{
    namespace GluonTest
    {
        typedef HRESULT (__stdcall* NamedDelegate)(char* a, char* b, int* ___ret);

        struct comid("5e31e0dc-a2ee-59ef-95b1-ce2c00fa8f00") StructMemberTest
        {
            bool Boolean;
            double Primitive;
            void* PrimitivePtr;
            char* String;
            BlittableStruct BlittableSt;
            ComplexStruct ComplexSt;
            DummyClass* Object;
            ABI::DelegateBlob NamedDelegate;
            ABI::DelegateBlob GenericDelegate;

            StructMemberTest() { }
            StructMemberTest(bool _Boolean, double _Primitive, void* _PrimitivePtr, char* _String, BlittableStruct _BlittableSt, ComplexStruct _ComplexSt, DummyClass* _Object, fn_ptr<HRESULT(IObject*,char*,char*,int*)> _NamedDelegate, IObject* _NamedDelegate_context, fn_ptr<HRESULT(IObject*,double,double*)> _GenericDelegate, IObject* _GenericDelegate_context) : 
                Boolean(_Boolean), Primitive(_Primitive), PrimitivePtr(_PrimitivePtr), String(_String), BlittableSt(_BlittableSt), ComplexSt(_ComplexSt), Object(_Object), NamedDelegate(_NamedDelegate, _NamedDelegate_context), GenericDelegate(_GenericDelegate, _GenericDelegate_context)
            { }
        };
    }
}

IS_VALUETYPE(::ABI::GluonTest::StructMemberTest, "5e31e0dc-a2ee-59ef-95b1-ce2c00fa8f00");

namespace ABI
{
    namespace GluonTest
    {
        struct comid("483ff0e3-d08b-3cbb-e6c5-c93d01fbbf00") TestStruct
        {
            char a;
            int b;
            int64_t c;
            int d;
            char* e;
            ABI::Array<int> f;

            TestStruct() { }
            TestStruct(char _a, int _b, int64_t _c, int _d, char* _e, int* _f, int _f_count) : 
                a(_a), b(_b), c(_c), d(_d), e(_e), f(_f, _f_count)
            { }
        };
    }
}

IS_VALUETYPE(::ABI::GluonTest::TestStruct, "483ff0e3-d08b-3cbb-e6c5-c93d01fbbf00");

namespace ABI
{
    namespace GluonTest
    {
        typedef HRESULT (__stdcall* PrimitivesCB)(bool inTest, char* outTest, int* refTest, double* ___ret);
        typedef HRESULT (__stdcall* StringsCB)(char* inTest, char** outTest, char** refTest, char** ___ret);
        typedef HRESULT (__stdcall* SimpleStructsCB)(BlittableStruct inTest, BlittableStruct* outTest, BlittableStruct* refTest, BlittableStruct* ___ret);
        typedef HRESULT (__stdcall* ComplexStructsCB)(ComplexStruct inTest, ComplexStruct* outTest, ComplexStruct* refTest, ComplexStruct* ___ret);
        typedef HRESULT (__stdcall* ObjectsCB)(DummyClass* inTest, DummyClass** outTest, DummyClass** refTest, DummyClass** ___ret);
        typedef HRESULT (__stdcall* NamedDelegatesCB)(fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context);
        typedef HRESULT (__stdcall* GenericDelegatesCB)(fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context);
        typedef HRESULT (__stdcall* PrimitiveArraysCB)(bool* inTest, int inTest_count, char** outTest, int* outTest_count, int** refTest, int* refTest_count, double** ___ret, int* ___ret_count);
        typedef HRESULT (__stdcall* StringArraysCB)(char** inTest, int inTest_count, char*** outTest, int* outTest_count, char*** refTest, int* refTest_count, char*** ___ret, int* ___ret_count);
        typedef HRESULT (__stdcall* SimpleStructArraysCB)(BlittableStruct* inTest, int inTest_count, BlittableStruct** outTest, int* outTest_count, BlittableStruct** refTest, int* refTest_count, BlittableStruct** ___ret, int* ___ret_count);
        typedef HRESULT (__stdcall* ComplexStructArraysCB)(ComplexStruct* inTest, int inTest_count, ComplexStruct** outTest, int* outTest_count, ComplexStruct** refTest, int* refTest_count, ComplexStruct** ___ret, int* ___ret_count);
        typedef HRESULT (__stdcall* ObjectArraysCB)(DummyClass** inTest, int inTest_count, DummyClass*** outTest, int* outTest_count, DummyClass*** refTest, int* refTest_count, DummyClass*** ___ret, int* ___ret_count);
        typedef HRESULT (__stdcall* NamedDelegateArraysCB)(ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
        typedef HRESULT (__stdcall* GenericDelegateArraysCB)(ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
        typedef HRESULT (__stdcall* AddSomeShit)(int a, int b, ITestClass** ___ret);
    }
}

IS_PRIMITIVE(::GluonTest::Foo, "3c5c8591-d08b-3cbb-e6c5-db371d8fec74");
IS_PRIMITIVE(::GluonTest::NoiseEngineState, "5235e2ff-83ee-5dcf-92a0-d3371bfc8931");
IS_PRIMITIVE(::GluonTest::NoiseChannels, "5232e4f9-bcee-3cc8-e6c5-d3371bfc8937");
IS_PRIMITIVE(::GluonTest::NoiseDistribution, "4e28f6f8-b2e2-48ce-8faa-bd371bfc8930");
IS_PRIMITIVE(::GluonTest::PlotType, "3c5ce0e1-d08b-3cbb-e6c5-cd341dfbb80d");

ABI_CONSTRUCTOR Create_GluonTest_DummyClass_1(::ABI::GluonTest::DummyClass** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_ConversionUnitTest_1(::ABI::GluonTest::ConversionUnitTest** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_ITestClass_1(::ABI::GluonTest::ITestClass** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_SignalBuffer_1(int samples, int channels, int alignment, ::ABI::GluonTest::SignalBuffer** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_SignalBuffer_2(int samples, ::ABI::GluonTest::SignalBuffer** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_Waveform_1(double* samples, int samples_count, ::ABI::GluonTest::Waveform** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_SinusoidalWaveform_1(::ABI::GluonTest::SinusoidalWaveform** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_SquareWaveform_1(::ABI::GluonTest::SquareWaveform** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_TriangleWaveform_1(::ABI::GluonTest::TriangleWaveform** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_SawtoothRightWaveform_1(::ABI::GluonTest::SawtoothRightWaveform** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_SawtoothLeftWaveform_1(::ABI::GluonTest::SawtoothLeftWaveform** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_GTone_1(::ABI::GluonTest::GTone** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_GWhiteNoise_1(::ABI::GluonTest::GWhiteNoise** outInstance);
ABI_CONSTRUCTOR Create_GluonTest_NoiseEngine_1(::ABI::GluonTest::NoiseEngine** outInstance);

namespace ABI
{
    namespace GluonTest
    {
        cominterface comid("4f2fe4fd-d08b-3cbb-e6c5-d92d1fe29537") DummyClass : public IUnknown
        {
#ifndef __INTELLISENSE__
            METHOD _GetNugget(char** ___ret) = 0;
            METHOD _SetNugget(char* value) = 0;
#endif
        };

        cominterface comid("5233ece2-bede-48d2-b2a0-ad431cf98906") ConversionUnitTest : public IUnknown
        {
#ifndef __INTELLISENSE__
            METHOD _Primitives(bool inTest, char* outOutTest, int* inoutRefTest, double* ___ret) = 0;
            METHOD _Strings(char* inTest, char** outOutTest, char** inoutRefTest, char** ___ret) = 0;
            METHOD _SimpleStructs(BlittableStruct inTest, BlittableStruct* outOutTest, BlittableStruct* inoutRefTest, BlittableStruct* ___ret) = 0;
            METHOD _ComplexStructs(ComplexStruct inTest, ComplexStruct* outOutTest, ComplexStruct* inoutRefTest, ComplexStruct* ___ret) = 0;
            METHOD _Objects(DummyClass* inTest, DummyClass** outOutTest, DummyClass** inoutRefTest, DummyClass** ___ret) = 0;
            METHOD _NamedDelegates(fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outOutTest, IObject** outOutTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* inoutRefTest, IObject** inoutRefTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _GenericDelegates(fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outOutTest, IObject** outOutTest_context, fn_ptr<HRESULT(IObject*,char*,int,char**)>* inoutRefTest, IObject** inoutRefTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _PrimitiveArrays(bool* inTest, int inTest_count, char** outOutTest, int* outOutTest_count, int** inoutRefTest, int* inoutRefTest_count, double** ___ret, int* ___ret_count) = 0;
            METHOD _StringArrays(char** inTest, int inTest_count, char*** outOutTest, int* outOutTest_count, char*** inoutRefTest, int* inoutRefTest_count, char*** ___ret, int* ___ret_count) = 0;
            METHOD _SimpleStructArrays(BlittableStruct* inTest, int inTest_count, BlittableStruct** outOutTest, int* outOutTest_count, BlittableStruct** inoutRefTest, int* inoutRefTest_count, BlittableStruct** ___ret, int* ___ret_count) = 0;
            METHOD _ComplexStructArrays(ComplexStruct* inTest, int inTest_count, ComplexStruct** outOutTest, int* outOutTest_count, ComplexStruct** inoutRefTest, int* inoutRefTest_count, ComplexStruct** ___ret, int* ___ret_count) = 0;
            METHOD _ObjectArrays(DummyClass** inTest, int inTest_count, DummyClass*** outOutTest, int* outOutTest_count, DummyClass*** inoutRefTest, int* inoutRefTest_count, DummyClass*** ___ret, int* ___ret_count) = 0;
            METHOD _NamedDelegateArrays(ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outOutTest, int* outOutTest_count, ABI::DelegateBlob** inoutRefTest, int* inoutRefTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count) = 0;
            METHOD _GenericDelegateArrays(ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outOutTest, int* outOutTest_count, ABI::DelegateBlob** inoutRefTest, int* inoutRefTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count) = 0;
            METHOD _ExCheckNullReference() = 0;
            METHOD _ExCheckArgumentNull() = 0;
            METHOD _ExCheckArgument() = 0;
            METHOD _ExCheckInvalidOperation() = 0;
            METHOD _ExCheckAccessDenied() = 0;
            METHOD _ExCheckGeneric() = 0;
            METHOD _ExCheckGenericStd() = 0;
            METHOD _ExCheckNotImplemented() = 0;

            METHOD _GetPrimitivesCB(fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetPrimitivesCB(fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)> value, IObject* value_context) = 0;
            METHOD _GetStringsCB(fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetStringsCB(fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)> value, IObject* value_context) = 0;
            METHOD _GetSimpleStructsCB(fn_ptr<HRESULT(IObject*,BlittableStruct,BlittableStruct*,BlittableStruct*,BlittableStruct*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetSimpleStructsCB(fn_ptr<HRESULT(IObject*,BlittableStruct,BlittableStruct*,BlittableStruct*,BlittableStruct*)> value, IObject* value_context) = 0;
            METHOD _GetComplexStructsCB(fn_ptr<HRESULT(IObject*,ComplexStruct,ComplexStruct*,ComplexStruct*,ComplexStruct*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetComplexStructsCB(fn_ptr<HRESULT(IObject*,ComplexStruct,ComplexStruct*,ComplexStruct*,ComplexStruct*)> value, IObject* value_context) = 0;
            METHOD _GetObjectsCB(fn_ptr<HRESULT(IObject*,DummyClass*,DummyClass**,DummyClass**,DummyClass**)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetObjectsCB(fn_ptr<HRESULT(IObject*,DummyClass*,DummyClass**,DummyClass**,DummyClass**)> value, IObject* value_context) = 0;
            METHOD _GetNamedDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetNamedDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)> value, IObject* value_context) = 0;
            METHOD _GetGenericDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetGenericDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)> value, IObject* value_context) = 0;
            METHOD _GetPrimitiveArraysCB(fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetPrimitiveArraysCB(fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)> value, IObject* value_context) = 0;
            METHOD _GetStringArraysCB(fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetStringArraysCB(fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)> value, IObject* value_context) = 0;
            METHOD _GetSimpleStructArraysCB(fn_ptr<HRESULT(IObject*,BlittableStruct*,int,BlittableStruct**,int*,BlittableStruct**,int*,BlittableStruct**,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetSimpleStructArraysCB(fn_ptr<HRESULT(IObject*,BlittableStruct*,int,BlittableStruct**,int*,BlittableStruct**,int*,BlittableStruct**,int*)> value, IObject* value_context) = 0;
            METHOD _GetComplexStructArraysCB(fn_ptr<HRESULT(IObject*,ComplexStruct*,int,ComplexStruct**,int*,ComplexStruct**,int*,ComplexStruct**,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetComplexStructArraysCB(fn_ptr<HRESULT(IObject*,ComplexStruct*,int,ComplexStruct**,int*,ComplexStruct**,int*,ComplexStruct**,int*)> value, IObject* value_context) = 0;
            METHOD _GetObjectArraysCB(fn_ptr<HRESULT(IObject*,DummyClass**,int,DummyClass***,int*,DummyClass***,int*,DummyClass***,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetObjectArraysCB(fn_ptr<HRESULT(IObject*,DummyClass**,int,DummyClass***,int*,DummyClass***,int*,DummyClass***,int*)> value, IObject* value_context) = 0;
            METHOD _GetNamedDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetNamedDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)> value, IObject* value_context) = 0;
            METHOD _GetGenericDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetGenericDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)> value, IObject* value_context) = 0;
            METHOD _GetStructMembers(StructMemberTest* ___ret) = 0;
            METHOD _SetStructMembers(StructMemberTest value) = 0;
#endif
        };

        cominterface comid("4f2fe4fd-d08b-3cbb-e6c5-d40c17fc9837") ITestClass : public IUnknown
        {
#ifndef __INTELLISENSE__
            METHOD _Methody() = 0;
            METHOD _RetMethod(int* ___ret) = 0;
            METHOD _OutMethod(int* outX) = 0;
            METHOD _RefMethod(char** inoutThing) = 0;
            METHOD _Ref2(ITestClass** inoutThing) = 0;
            METHOD _Ref3(TestStruct thing) = 0;
            METHOD _ComplexMethod(char** inoutA, IUnknown* _dumb, void* p, char** outFart, int* outFart_count, int** ___ret, int* ___ret_count) = 0;

            METHOD _GetAdder(fn_ptr<HRESULT(IObject*,int,int,ITestClass**)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetAdder(fn_ptr<HRESULT(IObject*,int,int,ITestClass**)> value, IObject* value_context) = 0;
            METHOD _GetProperty(int* ___ret) = 0;
            METHOD _SetProperty(int value) = 0;
            METHOD _GetReadOnlyProperty(int* ___ret) = 0;
            METHOD _GetHardProperty(TestStruct** ___ret, int* ___ret_count) = 0;
            METHOD _SetHardProperty(TestStruct* value, int value_count) = 0;
            METHOD _GetHarderProperty(ABI::DelegateBlob** ___ret, int* ___ret_count) = 0;
            METHOD _SetHarderProperty(ABI::DelegateBlob* value, int value_count) = 0;
            METHOD _GetDumbDelegate(fn_ptr<HRESULT(IObject*,char*,char*)>* ___ret, IObject** ___ret_context) = 0;
            METHOD _SetDumbDelegate(fn_ptr<HRESULT(IObject*,char*,char*)> value, IObject* value_context) = 0;

            METHOD _AddBigEventHandler(fn_ptr<HRESULT(IObject*,int)> handler, IObject* handler_context) = 0;
            METHOD _RemoveBigEventHandler(fn_ptr<HRESULT(IObject*,int)> handler, IObject* handler_context) = 0;
#endif
        };

        cominterface comid("3c2eeae5-d08b-3cbb-e6c5-da3d1cea9e15") Generator : public IUnknown
        {
#ifndef __INTELLISENSE__
            METHOD _Initialize(int channels, int sampleRate) = 0;
            METHOD _Eval(double t, double* inoutOutSample) = 0;
            METHOD _EvalBuffer(double t, SignalBuffer* inoutBuffer) = 0;

            METHOD _GetChannelCount(int* ___ret) = 0;
            METHOD _GetSampleRate(int* ___ret) = 0;
#endif
        };

        cominterface comid("5a3af0d3-a2ee-3cbb-e6c5-ce3115e18d18") SignalBuffer : public IUnknown
        {
#ifndef __INTELLISENSE__
            METHOD _CopyTo(double* arr, int arr_count, int* ___ret) = 0;
            METHOD _CopyTo_1(float* arr, int arr_count, int* ___ret) = 0;
            METHOD _CopyTo_2(short* arr, int arr_count, int* ___ret) = 0;

            METHOD _GetChannelCount(int* ___ret) = 0;
            METHOD _GetSampleCount(int* ___ret) = 0;
#endif
        };

        cominterface comid("3c5ce8e3-d08b-3cbb-e6c5-ca3904ea8a1b") Waveform : public IUnknown
        {
#ifndef __INTELLISENSE__
            METHOD _Phase(double t, double* ___ret) = 0;
#endif
        };

        cominterface comid("503de1f8-b1dc-59cd-80aa-bc5c1cfa9f1b") SinusoidalWaveform : public IUnknown
        {
#ifndef __INTELLISENSE__
#endif
        };

        cominterface comid("592ae4c6-bfed-51c9-e6c5-ce2907ee9e11") SquareWaveform : public IUnknown
        {
#ifndef __INTELLISENSE__
#endif
        };

        cominterface comid("5d0be0fd-b5fd-53dd-94a8-c92a1bee8213") TriangleWaveform : public IUnknown
        {
#ifndef __INTELLISENSE__
#endif
        };

        cominterface comid("550eede5-b8ec-6bcf-87b3-ab5f6a89ee1b") SawtoothRightWaveform : public IUnknown
        {
#ifndef __INTELLISENSE__
#endif
        };

        cominterface comid("5910ede5-a4ed-5dec-90a0-a8567796831b") SawtoothLeftWaveform : public IUnknown
        {
#ifndef __INTELLISENSE__
#endif
        };

        cominterface comid("3c5c8591-d08b-3cbb-e6c5-da0c1de18974") GTone : public IUnknown
        {
#ifndef __INTELLISENSE__
            METHOD _GetFrequency(double* ___ret) = 0;
            METHOD _SetFrequency(double value) = 0;
            METHOD _GetWaveform(Waveform** ___ret) = 0;
            METHOD _SetWaveform(Waveform* value) = 0;
            METHOD _GetAmplitude(double* ___ret) = 0;
            METHOD _SetAmplitude(double value) = 0;
#endif
        };

        cominterface comid("4f35eadf-d0ee-3cbb-e6c5-da0f1ae69811") GWhiteNoise : public IUnknown
        {
#ifndef __INTELLISENSE__
#endif
        };

        cominterface comid("5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931") NoiseEngine : public IUnknown
        {
#ifndef __INTELLISENSE__
            METHOD _Play() = 0;
            METHOD _Pause() = 0;
            METHOD _GetPlot(double durationSeconds, GluonTest::PlotType type, SignalBuffer** ___ret) = 0;

            METHOD _GetError(char** ___ret) = 0;
            METHOD _GetState(GluonTest::NoiseEngineState* ___ret) = 0;
            METHOD _GetSampleRate(int* ___ret) = 0;
            METHOD _SetSampleRate(int value) = 0;
            METHOD _GetChannels(GluonTest::NoiseChannels* ___ret) = 0;
            METHOD _SetChannels(GluonTest::NoiseChannels value) = 0;
            METHOD _GetBlockDuration(int* ___ret) = 0;
            METHOD _SetBlockDuration(int value) = 0;
            METHOD _GetDistribution(GluonTest::NoiseDistribution* ___ret) = 0;
            METHOD _SetDistribution(GluonTest::NoiseDistribution value) = 0;
            METHOD _GetIsFilterEnabled(bool* ___ret) = 0;
            METHOD _SetIsFilterEnabled(bool value) = 0;
#endif
        };
    }
}
