/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#include "GluonTest.Common.h"
#include "DummyClass.h"
#include "ConversionUnitTest.h"
#include "ITestClass.h"
#include "Generator.h"
#include "SignalBuffer.h"
#include "Waveform.h"
#include "SinusoidalWaveform.h"
#include "SquareWaveform.h"
#include "TriangleWaveform.h"
#include "SawtoothRightWaveform.h"
#include "SawtoothLeftWaveform.h"
#include "GTone.h"
#include "GWhiteNoise.h"
#include "NoiseEngine.h"


using namespace GluonInternal;
/*
extern __declspec(selectany)  CriticalSection g_ExceptionCSec;
extern __declspec(selectany)  HRESULT g_ExceptionHR = S_OK;
extern __declspec(selectany)  ABI::ExceptionType g_ExceptionType = ABI::ExceptionType::NoException;
extern __declspec(selectany)  std::string g_ExceptionMsg;

extern __declspec(selectany) HRESULT(*ABI::SetException)(HRESULT, ABI::ExceptionType, const char*) =
[](HRESULT hr, ABI::ExceptionType type, const char* msg)
{
    AutoLock lock(g_ExceptionCSec);
    g_ExceptionHR = hr;
    g_ExceptionType = type;
    g_ExceptionMsg = msg;

    return hr;
};

extern "C" __declspec(dllexport) HRESULT __stdcall $_GetGluonExceptionDetails(HRESULT* outHR, ABI::ExceptionType* outType, const char** outText)
{
    if(!outHR || !outText) return E_POINTER;

    AutoLock lock(g_ExceptionCSec);
    *outHR = g_ExceptionHR;
    *outType = g_ExceptionType;
    *outText = g_ExceptionMsg.c_str();

    return S_OK;
}
*/
void GluonTest_Initialize()
{
    ABI::GluonTest::Create_GluonTest_DummyClass_1(nullptr);
    ABI::GluonTest::Create_GluonTest_ConversionUnitTest_1(nullptr);
    ABI::GluonTest::Create_GluonTest_ITestClass_1(nullptr);
    ABI::GluonTest::Create_GluonTest_SignalBuffer_1(Def<int>(), Def<int>(), Def<int>(), nullptr);
    ABI::GluonTest::Create_GluonTest_SignalBuffer_2(Def<int>(), nullptr);
    ABI::GluonTest::Create_GluonTest_Waveform_1(Def<double*>(), Def<int>(), nullptr);
    ABI::GluonTest::Create_GluonTest_SinusoidalWaveform_1(nullptr);
    ABI::GluonTest::Create_GluonTest_SquareWaveform_1(nullptr);
    ABI::GluonTest::Create_GluonTest_TriangleWaveform_1(nullptr);
    ABI::GluonTest::Create_GluonTest_SawtoothRightWaveform_1(nullptr);
    ABI::GluonTest::Create_GluonTest_SawtoothLeftWaveform_1(nullptr);
    ABI::GluonTest::Create_GluonTest_GTone_1(nullptr);
    ABI::GluonTest::Create_GluonTest_GWhiteNoise_1(nullptr);
    ABI::GluonTest::Create_GluonTest_NoiseEngine_1(nullptr);
}

namespace GluonInternal
{
    GluonTest::ComplexStruct ABIUtil<GluonTest::ComplexStruct>::FromABI(const ::ABI::GluonTest::ComplexStruct& x)
    {
        return GluonTest::ComplexStruct(
            ABIUtil<string>::FromABI(x.Name),
            x.Sub,
            ABIUtil<GluonTest::DummyClass>::FromABI(x.Obj),
            ABIUtil<Delegate<int(int, int)>>::FromABI(x.Del));
    }

    ::ABI::GluonTest::ComplexStruct ABIUtil<GluonTest::ComplexStruct>::ToABI(const GluonTest::ComplexStruct& x)
    {
        auto Del_ = ABIUtil<Delegate<int(int, int)>>::ToABI(x.Del);
        return ::ABI::GluonTest::ComplexStruct(
            ABIUtil<string>::ToABI(x.Name),
            x.Sub,
            ABIUtil<GluonTest::DummyClass>::ToABI(x.Obj),
            (fn_ptr<HRESULT(IObject*,int,int,int*)>)Del_.Fn, Del_.Ctx);
    }

    GluonTest::StructMemberTest ABIUtil<GluonTest::StructMemberTest>::FromABI(const ::ABI::GluonTest::StructMemberTest& x)
    {
        return GluonTest::StructMemberTest(
            x.Boolean,
            x.Primitive,
            x.PrimitivePtr,
            ABIUtil<string>::FromABI(x.String),
            x.BlittableSt,
            ABIUtil<GluonTest::ComplexStruct>::FromABI(x.ComplexSt),
            ABIUtil<GluonTest::DummyClass>::FromABI(x.Object),
            ABIUtil<GluonTest::NamedDelegate>::FromABI(x.NamedDelegate),
            ABIUtil<Delegate<double(double)>>::FromABI(x.GenericDelegate));
    }

    ::ABI::GluonTest::StructMemberTest ABIUtil<GluonTest::StructMemberTest>::ToABI(const GluonTest::StructMemberTest& x)
    {
        auto NamedDelegate_ = ABIUtil<GluonTest::NamedDelegate>::ToABI(x.NamedDelegate);
        auto GenericDelegate_ = ABIUtil<Delegate<double(double)>>::ToABI(x.GenericDelegate);
        return ::ABI::GluonTest::StructMemberTest(
            x.Boolean,
            x.Primitive,
            x.PrimitivePtr,
            ABIUtil<string>::ToABI(x.String),
            x.BlittableSt,
            ABIUtil<GluonTest::ComplexStruct>::ToABI(x.ComplexSt),
            ABIUtil<GluonTest::DummyClass>::ToABI(x.Object),
            (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)NamedDelegate_.Fn, NamedDelegate_.Ctx,
            (fn_ptr<HRESULT(IObject*,double,double*)>)GenericDelegate_.Fn, GenericDelegate_.Ctx);
    }

    GluonTest::TestStruct ABIUtil<GluonTest::TestStruct>::FromABI(const ::ABI::GluonTest::TestStruct& x)
    {
        return GluonTest::TestStruct(
            x.a,
            x.b,
            x.c,
            x.d,
            ABIUtil<string>::FromABI(x.e),
            ABIUtil<Array<int>>::FromABI(x.f));
    }

    ::ABI::GluonTest::TestStruct ABIUtil<GluonTest::TestStruct>::ToABI(const GluonTest::TestStruct& x)
    {
        auto f_ = ABIUtil<Array<int>>::ToABI(x.f);
        return ::ABI::GluonTest::TestStruct(
            x.a,
            x.b,
            x.c,
            x.d,
            ABIUtil<string>::ToABI(x.e),
            f_.begin(), (int)f_.size());
    }

    HRESULT __stdcall ABI_Wrapper_1(IObject* __i_, int arg1, int arg2, int* ___ret)
    {
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<int(int, int)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ___del->Get()(
                arg1,
                arg2);
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<int(int, int)> ABIUtil<Delegate<int(int, int)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_1)
        {
            auto d = runtime_cast<DelegateContext<int(int, int)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,int,int,int*)>)fn;
        return [=](int arg1, int arg2) -> int 
        {
            int ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                arg1,
                arg2,
                ABICallbackRef<int>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<Delegate<int(int, int)>> ABIUtil<Delegate<int(int, int)>>::ToABI(const Delegate<int(int, int)>& x)
    {
        ABIOf<Delegate<int(int, int)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_1;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<int(int, int)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_2(IObject* __i_, char* a, char* b, int* ___ret)
    {
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<int(string, string)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ___del->Get()(
                ABIUtil<string>::FromABI(a),
                ABIUtil<string>::FromABI(b));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<int(string, string)> ABIUtil<Delegate<int(string, string)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_2)
        {
            auto d = runtime_cast<DelegateContext<int(string, string)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)fn;
        return [=](string a, string b) -> int 
        {
            int ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                ABIUtil<string>::ToABI(a),
                ABIUtil<string>::ToABI(b),
                ABICallbackRef<int>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::NamedDelegate> ABIUtil<GluonTest::NamedDelegate>::ToABI(const GluonTest::NamedDelegate& x)
    {
        ABIOf<Delegate<int(string, string)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_2;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<int(string, string)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_3(IObject* __i_, bool inTest, char* outTest, int* refTest, double* ___ret)
    {
        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<double(bool, char&, int&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ___del->Get()(
                inTest,
                ABIUtil<char>::Ref(outTest),
                ABIUtil<int>::Ref(refTest));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<double(bool, char&, int&)> ABIUtil<Delegate<double(bool, char&, int&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_3)
        {
            auto d = runtime_cast<DelegateContext<double(bool, char&, int&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>)fn;
        return [=](bool inTest, char& outTest, int& refTest) -> double 
        {
            double ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest,
                ABICallbackRef<char>(outTest),
                ABICallbackRef<int>(refTest),
                ABICallbackRef<double>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::PrimitivesCB> ABIUtil<GluonTest::PrimitivesCB>::ToABI(const GluonTest::PrimitivesCB& x)
    {
        ABIOf<Delegate<double(bool, char&, int&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_3;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<double(bool, char&, int&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_4(IObject* __i_, char* inTest, char** outTest, char** refTest, char** ___ret)
    {
        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<string(string, string&, string&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ABIUtil<string>::ToABI(___del->Get()(
                ABIUtil<string>::FromABI(inTest),
                ABIUtil<string>::Ref(outTest),
                ABIUtil<string>::Ref(refTest)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<string(string, string&, string&)> ABIUtil<Delegate<string(string, string&, string&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_4)
        {
            auto d = runtime_cast<DelegateContext<string(string, string&, string&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>)fn;
        return [=](string inTest, string& outTest, string& refTest) -> string 
        {
            string ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                ABIUtil<string>::ToABI(inTest),
                ABICallbackRef<string>(outTest),
                ABICallbackRef<string>(refTest),
                ABICallbackRef<string>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::StringsCB> ABIUtil<GluonTest::StringsCB>::ToABI(const GluonTest::StringsCB& x)
    {
        ABIOf<Delegate<string(string, string&, string&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_4;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<string(string, string&, string&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_5(IObject* __i_, ::ABI::GluonTest::BlittableStruct inTest, ::ABI::GluonTest::BlittableStruct* outTest, ::ABI::GluonTest::BlittableStruct* refTest, ::ABI::GluonTest::BlittableStruct* ___ret)
    {
        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ___del->Get()(
                inTest,
                ABIUtil<GluonTest::BlittableStruct>::Ref(outTest),
                ABIUtil<GluonTest::BlittableStruct>::Ref(refTest));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)> ABIUtil<Delegate<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_5)
        {
            auto d = runtime_cast<DelegateContext<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)>)fn;
        return [=](const GluonTest::BlittableStruct& inTest, GluonTest::BlittableStruct& outTest, GluonTest::BlittableStruct& refTest) -> GluonTest::BlittableStruct 
        {
            GluonTest::BlittableStruct ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest,
                ABICallbackRef<GluonTest::BlittableStruct>(outTest),
                ABICallbackRef<GluonTest::BlittableStruct>(refTest),
                ABICallbackRef<GluonTest::BlittableStruct>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::SimpleStructsCB> ABIUtil<GluonTest::SimpleStructsCB>::ToABI(const GluonTest::SimpleStructsCB& x)
    {
        ABIOf<Delegate<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_5;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_6(IObject* __i_, ::ABI::GluonTest::ComplexStruct inTest, ::ABI::GluonTest::ComplexStruct* outTest, ::ABI::GluonTest::ComplexStruct* refTest, ::ABI::GluonTest::ComplexStruct* ___ret)
    {
        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ABIUtil<GluonTest::ComplexStruct>::ToABI(___del->Get()(
                ABIUtil<GluonTest::ComplexStruct>::FromABI(inTest),
                ABIUtil<GluonTest::ComplexStruct>::Ref(outTest),
                ABIUtil<GluonTest::ComplexStruct>::Ref(refTest)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)> ABIUtil<Delegate<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_6)
        {
            auto d = runtime_cast<DelegateContext<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)>)fn;
        return [=](const GluonTest::ComplexStruct& inTest, GluonTest::ComplexStruct& outTest, GluonTest::ComplexStruct& refTest) -> GluonTest::ComplexStruct 
        {
            GluonTest::ComplexStruct ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                ABIUtil<GluonTest::ComplexStruct>::ToABI(inTest),
                ABICallbackRef<GluonTest::ComplexStruct>(outTest),
                ABICallbackRef<GluonTest::ComplexStruct>(refTest),
                ABICallbackRef<GluonTest::ComplexStruct>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::ComplexStructsCB> ABIUtil<GluonTest::ComplexStructsCB>::ToABI(const GluonTest::ComplexStructsCB& x)
    {
        ABIOf<Delegate<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_6;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_7(IObject* __i_, ::ABI::GluonTest::DummyClass* inTest, ::ABI::GluonTest::DummyClass** outTest, ::ABI::GluonTest::DummyClass** refTest, ::ABI::GluonTest::DummyClass** ___ret)
    {
        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ABIUtil<GluonTest::DummyClass>::ToABI(___del->Get()(
                ABIUtil<GluonTest::DummyClass>::FromABI(inTest),
                ABIUtil<GluonTest::DummyClass>::Ref(outTest),
                ABIUtil<GluonTest::DummyClass>::Ref(refTest)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)> ABIUtil<Delegate<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_7)
        {
            auto d = runtime_cast<DelegateContext<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)>)fn;
        return [=](GluonTest::DummyClass* inTest, com_ptr<GluonTest::DummyClass>& outTest, com_ptr<GluonTest::DummyClass>& refTest) -> com_ptr<GluonTest::DummyClass> 
        {
            com_ptr<GluonTest::DummyClass> ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                ABIUtil<GluonTest::DummyClass>::ToABI(inTest),
                ABICallbackRef<GluonTest::DummyClass>(outTest),
                ABICallbackRef<GluonTest::DummyClass>(refTest),
                ABICallbackRef<GluonTest::DummyClass>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::ObjectsCB> ABIUtil<GluonTest::ObjectsCB>::ToABI(const GluonTest::ObjectsCB& x)
    {
        ABIOf<Delegate<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_7;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_8(IObject* __i_, fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_context) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_context) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_context) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::DelegateRef<fn_ptr<HRESULT(IObject*,char*,char*,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::NamedDelegate>::ToABI(___del->Get()(
                ABIUtil<GluonTest::NamedDelegate>::FromABI((void**)inTest, inTest_context),
                ABIUtil<GluonTest::NamedDelegate>::Ref((void**)outTest, outTest_context),
                ABIUtil<GluonTest::NamedDelegate>::Ref((void**)refTest, refTest_context)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)> ABIUtil<Delegate<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_8)
        {
            auto d = runtime_cast<DelegateContext<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>)fn;
        return [=](const GluonTest::NamedDelegate& inTest, GluonTest::NamedDelegate& outTest, GluonTest::NamedDelegate& refTest) -> GluonTest::NamedDelegate 
        {
            GluonTest::NamedDelegate ___ret;
            ABICallbackRef<GluonTest::NamedDelegate> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<GluonTest::NamedDelegate>::ToABI(inTest);
            ABICallbackRef<GluonTest::NamedDelegate> outTest_abi(outTest);
            ABICallbackRef<GluonTest::NamedDelegate> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)inTest_abi.Fn, inTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&outTest_abi.Fn, &outTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&refTest_abi.Fn, &refTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::NamedDelegatesCB> ABIUtil<GluonTest::NamedDelegatesCB>::ToABI(const GluonTest::NamedDelegatesCB& x)
    {
        ABIOf<Delegate<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_8;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_9(IObject* __i_, fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_context) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_context) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_context) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::DelegateRef<fn_ptr<HRESULT(IObject*,int,int*)>>(___ret, ___ret_context) = ABIUtil<Delegate<int(int)>>::ToABI(___del->Get()(
                ABIUtil<Delegate<void(string)>>::FromABI((void**)inTest, inTest_context),
                ABIUtil<Delegate<void(const Delegate<int(int)>&)>>::Ref((void**)outTest, outTest_context),
                ABIUtil<Delegate<Array<string>(Array<char>)>>::Ref((void**)refTest, refTest_context)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)> ABIUtil<Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_9)
        {
            auto d = runtime_cast<DelegateContext<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>)fn;
        return [=](const Delegate<void(string)>& inTest, Delegate<void(const Delegate<int(int)>&)>& outTest, Delegate<Array<string>(Array<char>)>& refTest) -> Delegate<int(int)> 
        {
            Delegate<int(int)> ___ret;
            ABICallbackRef<Delegate<int(int)>> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<Delegate<void(string)>>::ToABI(inTest);
            ABICallbackRef<Delegate<void(const Delegate<int(int)>&)>> outTest_abi(outTest);
            ABICallbackRef<Delegate<Array<string>(Array<char>)>> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                (fn_ptr<HRESULT(IObject*,char*)>)inTest_abi.Fn, inTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*)&outTest_abi.Fn, &outTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*)&refTest_abi.Fn, &refTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,int,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::GenericDelegatesCB> ABIUtil<GluonTest::GenericDelegatesCB>::ToABI(const GluonTest::GenericDelegatesCB& x)
    {
        ABIOf<Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_9;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_10(IObject* __i_, int arg, int* ___ret)
    {
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<int(int)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ___del->Get()(arg);
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<int(int)> ABIUtil<Delegate<int(int)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_10)
        {
            auto d = runtime_cast<DelegateContext<int(int)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,int,int*)>)fn;
        return [=](int arg) -> int 
        {
            int ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                arg,
                ABICallbackRef<int>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<Delegate<int(int)>> ABIUtil<Delegate<int(int)>>::ToABI(const Delegate<int(int)>& x)
    {
        ABIOf<Delegate<int(int)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_10;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<int(int)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_11(IObject* __i_, char* obj)
    {
        auto ___del = runtime_cast<DelegateContext<void(string)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ___del->Get()(ABIUtil<string>::FromABI(obj));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<void(string)> ABIUtil<Delegate<void(string)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_11)
        {
            auto d = runtime_cast<DelegateContext<void(string)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,char*)>)fn;
        return [=](string obj) 
        {
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                ABIUtil<string>::ToABI(obj)));
        };
    }

    template<>
    ABIOf<Delegate<void(string)>> ABIUtil<Delegate<void(string)>>::ToABI(const Delegate<void(string)>& x)
    {
        ABIOf<Delegate<void(string)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_11;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<void(string)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_12(IObject* __i_, fn_ptr<HRESULT(IObject*,int,int*)> obj, IObject* obj_context)
    {
        auto ___del = runtime_cast<DelegateContext<void(const Delegate<int(int)>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ___del->Get()(ABIUtil<Delegate<int(int)>>::FromABI((void**)obj, obj_context));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<void(const Delegate<int(int)>&)> ABIUtil<Delegate<void(const Delegate<int(int)>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_12)
        {
            auto d = runtime_cast<DelegateContext<void(const Delegate<int(int)>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>)fn;
        return [=](const Delegate<int(int)>& obj) 
        {
            auto obj_abi = ABIUtil<Delegate<int(int)>>::ToABI(obj);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                (fn_ptr<HRESULT(IObject*,int,int*)>)obj_abi.Fn, obj_abi.Ctx));
        };
    }

    template<>
    ABIOf<Delegate<void(const Delegate<int(int)>&)>> ABIUtil<Delegate<void(const Delegate<int(int)>&)>>::ToABI(const Delegate<void(const Delegate<int(int)>&)>& x)
    {
        ABIOf<Delegate<void(const Delegate<int(int)>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_12;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<void(const Delegate<int(int)>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_13(IObject* __i_, char* arg, int arg_count, char*** ___ret, int* ___ret_count)
    {
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Array<string>(Array<char>)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::ArrayRef<char*>(___ret, ___ret_count) = ABIUtil<Array<string>>::ToABI(___del->Get()(ABIUtil<Array<char>>::FromABI(arg, arg_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Array<string>(Array<char>)> ABIUtil<Delegate<Array<string>(Array<char>)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_13)
        {
            auto d = runtime_cast<DelegateContext<Array<string>(Array<char>)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>)fn;
        return [=](Array<char> arg) -> Array<string> 
        {
            Array<string> ___ret;
            ABICallbackRef<Array<string>> ___ret_abi(___ret);
            auto arg_abi = ABIUtil<Array<char>>::ToABI(arg);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                arg_abi.begin(), arg_abi.size(),
                &___ret_abi.Data, &___ret_abi.Count));
            return ___ret;
        };
    }

    template<>
    ABIOf<Delegate<Array<string>(Array<char>)>> ABIUtil<Delegate<Array<string>(Array<char>)>>::ToABI(const Delegate<Array<string>(Array<char>)>& x)
    {
        ABIOf<Delegate<Array<string>(Array<char>)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_13;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Array<string>(Array<char>)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_14(IObject* __i_, bool* inTest, int inTest_count, char** outTest, int* outTest_count, int** refTest, int* refTest_count, double** ___ret, int* ___ret_count)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Array<double>(Array<bool>, Array<char>&, Array<int>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::ArrayRef<double>(___ret, ___ret_count) = ABIUtil<Array<double>>::ToABI(___del->Get()(
                ABIUtil<Array<bool>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<char>>::Ref(outTest, outTest_count),
                ABIUtil<Array<int>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)> ABIUtil<Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_14)
        {
            auto d = runtime_cast<DelegateContext<Array<double>(Array<bool>, Array<char>&, Array<int>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>)fn;
        return [=](Array<bool> inTest, Array<char>& outTest, Array<int>& refTest) -> Array<double> 
        {
            Array<double> ___ret;
            ABICallbackRef<Array<double>> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<Array<bool>>::ToABI(inTest);
            ABICallbackRef<Array<char>> outTest_abi(outTest);
            ABICallbackRef<Array<int>> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest_abi.begin(), inTest_abi.size(),
                &outTest_abi.Data, &outTest_abi.Count,
                &refTest_abi.Data, &refTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::PrimitiveArraysCB> ABIUtil<GluonTest::PrimitiveArraysCB>::ToABI(const GluonTest::PrimitiveArraysCB& x)
    {
        ABIOf<Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_14;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Array<double>(Array<bool>, Array<char>&, Array<int>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_15(IObject* __i_, char** inTest, int inTest_count, char*** outTest, int* outTest_count, char*** refTest, int* refTest_count, char*** ___ret, int* ___ret_count)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Array<string>(Array<string>, Array<string>&, Array<string>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::ArrayRef<char*>(___ret, ___ret_count) = ABIUtil<Array<string>>::ToABI(___del->Get()(
                ABIUtil<Array<string>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<string>>::Ref(outTest, outTest_count),
                ABIUtil<Array<string>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)> ABIUtil<Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_15)
        {
            auto d = runtime_cast<DelegateContext<Array<string>(Array<string>, Array<string>&, Array<string>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>)fn;
        return [=](Array<string> inTest, Array<string>& outTest, Array<string>& refTest) -> Array<string> 
        {
            Array<string> ___ret;
            ABICallbackRef<Array<string>> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<Array<string>>::ToABI(inTest);
            ABICallbackRef<Array<string>> outTest_abi(outTest);
            ABICallbackRef<Array<string>> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest_abi.begin(), inTest_abi.size(),
                &outTest_abi.Data, &outTest_abi.Count,
                &refTest_abi.Data, &refTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::StringArraysCB> ABIUtil<GluonTest::StringArraysCB>::ToABI(const GluonTest::StringArraysCB& x)
    {
        ABIOf<Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_15;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Array<string>(Array<string>, Array<string>&, Array<string>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_16(IObject* __i_, ::ABI::GluonTest::BlittableStruct* inTest, int inTest_count, ::ABI::GluonTest::BlittableStruct** outTest, int* outTest_count, ::ABI::GluonTest::BlittableStruct** refTest, int* refTest_count, ::ABI::GluonTest::BlittableStruct** ___ret, int* ___ret_count)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::ArrayRef<::ABI::GluonTest::BlittableStruct>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::BlittableStruct>>::ToABI(___del->Get()(
                ABIUtil<Array<GluonTest::BlittableStruct>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<GluonTest::BlittableStruct>>::Ref(outTest, outTest_count),
                ABIUtil<Array<GluonTest::BlittableStruct>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)> ABIUtil<Delegate<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_16)
        {
            auto d = runtime_cast<DelegateContext<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)>)fn;
        return [=](Array<GluonTest::BlittableStruct> inTest, Array<GluonTest::BlittableStruct>& outTest, Array<GluonTest::BlittableStruct>& refTest) -> Array<GluonTest::BlittableStruct> 
        {
            Array<GluonTest::BlittableStruct> ___ret;
            ABICallbackRef<Array<GluonTest::BlittableStruct>> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<Array<GluonTest::BlittableStruct>>::ToABI(inTest);
            ABICallbackRef<Array<GluonTest::BlittableStruct>> outTest_abi(outTest);
            ABICallbackRef<Array<GluonTest::BlittableStruct>> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest_abi.begin(), inTest_abi.size(),
                &outTest_abi.Data, &outTest_abi.Count,
                &refTest_abi.Data, &refTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::SimpleStructArraysCB> ABIUtil<GluonTest::SimpleStructArraysCB>::ToABI(const GluonTest::SimpleStructArraysCB& x)
    {
        ABIOf<Delegate<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_16;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_17(IObject* __i_, ::ABI::GluonTest::ComplexStruct* inTest, int inTest_count, ::ABI::GluonTest::ComplexStruct** outTest, int* outTest_count, ::ABI::GluonTest::ComplexStruct** refTest, int* refTest_count, ::ABI::GluonTest::ComplexStruct** ___ret, int* ___ret_count)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::ArrayRef<::ABI::GluonTest::ComplexStruct>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::ComplexStruct>>::ToABI(___del->Get()(
                ABIUtil<Array<GluonTest::ComplexStruct>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<GluonTest::ComplexStruct>>::Ref(outTest, outTest_count),
                ABIUtil<Array<GluonTest::ComplexStruct>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)> ABIUtil<Delegate<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_17)
        {
            auto d = runtime_cast<DelegateContext<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)>)fn;
        return [=](Array<GluonTest::ComplexStruct> inTest, Array<GluonTest::ComplexStruct>& outTest, Array<GluonTest::ComplexStruct>& refTest) -> Array<GluonTest::ComplexStruct> 
        {
            Array<GluonTest::ComplexStruct> ___ret;
            ABICallbackRef<Array<GluonTest::ComplexStruct>> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<Array<GluonTest::ComplexStruct>>::ToABI(inTest);
            ABICallbackRef<Array<GluonTest::ComplexStruct>> outTest_abi(outTest);
            ABICallbackRef<Array<GluonTest::ComplexStruct>> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest_abi.begin(), inTest_abi.size(),
                &outTest_abi.Data, &outTest_abi.Count,
                &refTest_abi.Data, &refTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::ComplexStructArraysCB> ABIUtil<GluonTest::ComplexStructArraysCB>::ToABI(const GluonTest::ComplexStructArraysCB& x)
    {
        ABIOf<Delegate<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_17;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_18(IObject* __i_, ::ABI::GluonTest::DummyClass** inTest, int inTest_count, ::ABI::GluonTest::DummyClass*** outTest, int* outTest_count, ::ABI::GluonTest::DummyClass*** refTest, int* refTest_count, ::ABI::GluonTest::DummyClass*** ___ret, int* ___ret_count)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::ArrayRef<::ABI::GluonTest::DummyClass*>(___ret, ___ret_count) = ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::ToABI(___del->Get()(
                ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::Ref(outTest, outTest_count),
                ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)> ABIUtil<Delegate<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_18)
        {
            auto d = runtime_cast<DelegateContext<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)>)fn;
        return [=](Array<com_ptr<GluonTest::DummyClass>> inTest, Array<com_ptr<GluonTest::DummyClass>>& outTest, Array<com_ptr<GluonTest::DummyClass>>& refTest) -> Array<com_ptr<GluonTest::DummyClass>> 
        {
            Array<com_ptr<GluonTest::DummyClass>> ___ret;
            ABICallbackRef<Array<com_ptr<GluonTest::DummyClass>>> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::ToABI(inTest);
            ABICallbackRef<Array<com_ptr<GluonTest::DummyClass>>> outTest_abi(outTest);
            ABICallbackRef<Array<com_ptr<GluonTest::DummyClass>>> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest_abi.begin(), inTest_abi.size(),
                &outTest_abi.Data, &outTest_abi.Count,
                &refTest_abi.Data, &refTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::ObjectArraysCB> ABIUtil<GluonTest::ObjectArraysCB>::ToABI(const GluonTest::ObjectArraysCB& x)
    {
        ABIOf<Delegate<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_18;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_19(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::ArrayRef<ABI::DelegateBlob>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::NamedDelegate>>::ToABI(___del->Get()(
                ABIUtil<Array<GluonTest::NamedDelegate>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<GluonTest::NamedDelegate>>::Ref(outTest, outTest_count),
                ABIUtil<Array<GluonTest::NamedDelegate>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)> ABIUtil<Delegate<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_19)
        {
            auto d = runtime_cast<DelegateContext<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>)fn;
        return [=](Array<GluonTest::NamedDelegate> inTest, Array<GluonTest::NamedDelegate>& outTest, Array<GluonTest::NamedDelegate>& refTest) -> Array<GluonTest::NamedDelegate> 
        {
            Array<GluonTest::NamedDelegate> ___ret;
            ABICallbackRef<Array<GluonTest::NamedDelegate>> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<Array<GluonTest::NamedDelegate>>::ToABI(inTest);
            ABICallbackRef<Array<GluonTest::NamedDelegate>> outTest_abi(outTest);
            ABICallbackRef<Array<GluonTest::NamedDelegate>> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest_abi.begin(), inTest_abi.size(),
                &outTest_abi.Data, &outTest_abi.Count,
                &refTest_abi.Data, &refTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::NamedDelegateArraysCB> ABIUtil<GluonTest::NamedDelegateArraysCB>::ToABI(const GluonTest::NamedDelegateArraysCB& x)
    {
        ABIOf<Delegate<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_19;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_20(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count)
    {
        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ABI::ArrayRef<ABI::DelegateBlob>(___ret, ___ret_count) = ABIUtil<Array<Delegate<int(int)>>>::ToABI(___del->Get()(
                ABIUtil<Array<Delegate<void(string)>>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<Delegate<void(const Delegate<int(int)>&)>>>::Ref(outTest, outTest_count),
                ABIUtil<Array<Delegate<Array<string>(Array<char>)>>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)> ABIUtil<Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_20)
        {
            auto d = runtime_cast<DelegateContext<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>)fn;
        return [=](Array<Delegate<void(string)>> inTest, Array<Delegate<void(const Delegate<int(int)>&)>>& outTest, Array<Delegate<Array<string>(Array<char>)>>& refTest) -> Array<Delegate<int(int)>> 
        {
            Array<Delegate<int(int)>> ___ret;
            ABICallbackRef<Array<Delegate<int(int)>>> ___ret_abi(___ret);
            auto inTest_abi = ABIUtil<Array<Delegate<void(string)>>>::ToABI(inTest);
            ABICallbackRef<Array<Delegate<void(const Delegate<int(int)>&)>>> outTest_abi(outTest);
            ABICallbackRef<Array<Delegate<Array<string>(Array<char>)>>> refTest_abi(refTest);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                inTest_abi.begin(), inTest_abi.size(),
                &outTest_abi.Data, &outTest_abi.Count,
                &refTest_abi.Data, &refTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::GenericDelegateArraysCB> ABIUtil<GluonTest::GenericDelegateArraysCB>::ToABI(const GluonTest::GenericDelegateArraysCB& x)
    {
        ABIOf<Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_20;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_21(IObject* __i_, double arg, double* ___ret)
    {
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<double(double)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ___del->Get()(arg);
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<double(double)> ABIUtil<Delegate<double(double)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_21)
        {
            auto d = runtime_cast<DelegateContext<double(double)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,double,double*)>)fn;
        return [=](double arg) -> double 
        {
            double ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                arg,
                ABICallbackRef<double>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<Delegate<double(double)>> ABIUtil<Delegate<double(double)>>::ToABI(const Delegate<double(double)>& x)
    {
        ABIOf<Delegate<double(double)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_21;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<double(double)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_22(IObject* __i_, char* arg, int arg_count, char** ___ret)
    {
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<string(Array<char>)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ABIUtil<string>::ToABI(___del->Get()(ABIUtil<Array<char>>::FromABI(arg, arg_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<string(Array<char>)> ABIUtil<Delegate<string(Array<char>)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_22)
        {
            auto d = runtime_cast<DelegateContext<string(Array<char>)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,char*,int,char**)>)fn;
        return [=](Array<char> arg) -> string 
        {
            string ___ret;
            auto arg_abi = ABIUtil<Array<char>>::ToABI(arg);
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                arg_abi.begin(), arg_abi.size(),
                ABICallbackRef<string>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<Delegate<string(Array<char>)>> ABIUtil<Delegate<string(Array<char>)>>::ToABI(const Delegate<string(Array<char>)>& x)
    {
        ABIOf<Delegate<string(Array<char>)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_22;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<string(Array<char>)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_23(IObject* __i_, int a, int b, ::ABI::GluonTest::ITestClass** ___ret)
    {
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<com_ptr<GluonTest::ITestClass>(int, int)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ABIUtil<GluonTest::ITestClass>::ToABI(___del->Get()(
                a,
                b));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<com_ptr<GluonTest::ITestClass>(int, int)> ABIUtil<Delegate<com_ptr<GluonTest::ITestClass>(int, int)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_23)
        {
            auto d = runtime_cast<DelegateContext<com_ptr<GluonTest::ITestClass>(int, int)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)>)fn;
        return [=](int a, int b) -> com_ptr<GluonTest::ITestClass> 
        {
            com_ptr<GluonTest::ITestClass> ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                a,
                b,
                ABICallbackRef<GluonTest::ITestClass>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<GluonTest::AddSomeShit> ABIUtil<GluonTest::AddSomeShit>::ToABI(const GluonTest::AddSomeShit& x)
    {
        ABIOf<Delegate<com_ptr<GluonTest::ITestClass>(int, int)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_23;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<com_ptr<GluonTest::ITestClass>(int, int)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_24(IObject* __i_, char arg1, int arg2, char** ___ret)
    {
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<string(char, int)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ABIUtil<string>::ToABI(___del->Get()(
                arg1,
                arg2));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<string(char, int)> ABIUtil<Delegate<string(char, int)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_24)
        {
            auto d = runtime_cast<DelegateContext<string(char, int)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,char,int,char**)>)fn;
        return [=](char arg1, int arg2) -> string 
        {
            string ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                arg1,
                arg2,
                ABICallbackRef<string>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<Delegate<string(char, int)>> ABIUtil<Delegate<string(char, int)>>::ToABI(const Delegate<string(char, int)>& x)
    {
        ABIOf<Delegate<string(char, int)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_24;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<string(char, int)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_25(IObject* __i_, char* arg, char* ___ret)
    {
        if(!___ret) return E_POINTER;

        auto ___del = runtime_cast<DelegateContext<char(string)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            *___ret = ___del->Get()(ABIUtil<string>::FromABI(arg));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<char(string)> ABIUtil<Delegate<char(string)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_25)
        {
            auto d = runtime_cast<DelegateContext<char(string)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,char*,char*)>)fn;
        return [=](string arg) -> char 
        {
            char ___ret;
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                ABIUtil<string>::ToABI(arg),
                ABICallbackRef<char>(___ret)));
            return ___ret;
        };
    }

    template<>
    ABIOf<Delegate<char(string)>> ABIUtil<Delegate<char(string)>>::ToABI(const Delegate<char(string)>& x)
    {
        ABIOf<Delegate<char(string)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_25;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<char(string)>(x));
        return x_abi;
    }

    HRESULT __stdcall ABI_Wrapper_26(IObject* __i_, int obj)
    {
        auto ___del = runtime_cast<DelegateContext<void(int)>>(__i_);
        if(!___del) return E_FAIL;

        try {
            ___del->Get()(obj);
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<>
    Delegate<void(int)> ABIUtil<Delegate<void(int)>>::FromABI(void* fn, IObject* ctx)
    {
        if(fn == (void*)&ABI_Wrapper_26)
        {
            auto d = runtime_cast<DelegateContext<void(int)>>(ctx);
            if(d) return d->Get();
        }

        auto fptr = (fn_ptr<HRESULT(IObject*,int)>)fn;
        return [=](int obj) 
        {
            TRANSLATE_TO_EXCEPTIONS(fptr(
                ctx,
                obj));
        };
    }

    template<>
    ABIOf<Delegate<void(int)>> ABIUtil<Delegate<void(int)>>::ToABI(const Delegate<void(int)>& x)
    {
        ABIOf<Delegate<void(int)>> x_abi;
        x_abi.Fn = &ABI_Wrapper_26;
        x_abi.Ctx = reinterpret_cast<IObject*>(new DelegateContext<void(int)>(x));
        return x_abi;
    }
}

#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_DummyClass_1(::ABI::GluonTest::DummyClass** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::DummyClass(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::DummyClass::_GetNugget(char** ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<string>::ToABI(GetNugget());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::DummyClass::_SetNugget(char* value)
{
    try {
        SetNugget(ABIUtil<string>::FromABI(value));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_ConversionUnitTest_1(::ABI::GluonTest::ConversionUnitTest** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::ConversionUnitTest(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_Primitives(bool inTest, char* outOutTest, int* inoutRefTest, double* ___ret)
{
    if(!outOutTest) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!___ret) return E_POINTER;

    try {
        *___ret = Primitives(
            inTest,
            ABIUtil<char>::Ref(outOutTest),
            ABIUtil<int>::Ref(inoutRefTest));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_Strings(char* inTest, char** outOutTest, char** inoutRefTest, char** ___ret)
{
    if(!outOutTest) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<string>::ToABI(Strings(
            ABIUtil<string>::FromABI(inTest),
            ABIUtil<string>::Ref(outOutTest),
            ABIUtil<string>::Ref(inoutRefTest)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SimpleStructs(::ABI::GluonTest::BlittableStruct inTest, ::ABI::GluonTest::BlittableStruct* outOutTest, ::ABI::GluonTest::BlittableStruct* inoutRefTest, ::ABI::GluonTest::BlittableStruct* ___ret)
{
    if(!outOutTest) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!___ret) return E_POINTER;

    try {
        *___ret = SimpleStructs(
            inTest,
            ABIUtil<GluonTest::BlittableStruct>::Ref(outOutTest),
            ABIUtil<GluonTest::BlittableStruct>::Ref(inoutRefTest));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ComplexStructs(::ABI::GluonTest::ComplexStruct inTest, ::ABI::GluonTest::ComplexStruct* outOutTest, ::ABI::GluonTest::ComplexStruct* inoutRefTest, ::ABI::GluonTest::ComplexStruct* ___ret)
{
    if(!outOutTest) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<GluonTest::ComplexStruct>::ToABI(ComplexStructs(
            ABIUtil<GluonTest::ComplexStruct>::FromABI(inTest),
            ABIUtil<GluonTest::ComplexStruct>::Ref(outOutTest),
            ABIUtil<GluonTest::ComplexStruct>::Ref(inoutRefTest)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_Objects(::ABI::GluonTest::DummyClass* inTest, ::ABI::GluonTest::DummyClass** outOutTest, ::ABI::GluonTest::DummyClass** inoutRefTest, ::ABI::GluonTest::DummyClass** ___ret)
{
    if(!outOutTest) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<GluonTest::DummyClass>::ToABI(Objects(
            ABIUtil<GluonTest::DummyClass>::FromABI(inTest),
            ABIUtil<GluonTest::DummyClass>::Ref(outOutTest),
            ABIUtil<GluonTest::DummyClass>::Ref(inoutRefTest)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_NamedDelegates(fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outOutTest, IObject** outOutTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* inoutRefTest, IObject** inoutRefTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_context) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_context) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,char*,char*,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::NamedDelegate>::ToABI(NamedDelegates(
            ABIUtil<GluonTest::NamedDelegate>::FromABI((void**)inTest, inTest_context),
            ABIUtil<GluonTest::NamedDelegate>::Ref((void**)outOutTest, outOutTest_context),
            ABIUtil<GluonTest::NamedDelegate>::Ref((void**)inoutRefTest, inoutRefTest_context)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GenericDelegates(fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outOutTest, IObject** outOutTest_context, fn_ptr<HRESULT(IObject*,char*,int,char**)>* inoutRefTest, IObject** inoutRefTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_context) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_context) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,int,int*)>>(___ret, ___ret_context) = ABIUtil<Delegate<int(int)>>::ToABI(GenericDelegates(
            ABIUtil<Delegate<void(string)>>::FromABI((void**)inTest, inTest_context),
            ABIUtil<Delegate<void(const Delegate<int(int)>&)>>::Ref((void**)outOutTest, outOutTest_context),
            ABIUtil<Delegate<string(Array<char>)>>::Ref((void**)inoutRefTest, inoutRefTest_context)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_PrimitiveArrays(bool* inTest, int inTest_count, char** outOutTest, int* outOutTest_count, int** inoutRefTest, int* inoutRefTest_count, double** ___ret, int* ___ret_count)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_count) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_count) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<double>(___ret, ___ret_count) = ABIUtil<Array<double>>::ToABI(PrimitiveArrays(
            ABIUtil<Array<bool>>::FromABI(inTest, inTest_count),
            ABIUtil<Array<char>>::Ref(outOutTest, outOutTest_count),
            ABIUtil<Array<int>>::Ref(inoutRefTest, inoutRefTest_count)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_StringArrays(char** inTest, int inTest_count, char*** outOutTest, int* outOutTest_count, char*** inoutRefTest, int* inoutRefTest_count, char*** ___ret, int* ___ret_count)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_count) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_count) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<char*>(___ret, ___ret_count) = ABIUtil<Array<string>>::ToABI(StringArrays(
            ABIUtil<Array<string>>::FromABI(inTest, inTest_count),
            ABIUtil<Array<string>>::Ref(outOutTest, outOutTest_count),
            ABIUtil<Array<string>>::Ref(inoutRefTest, inoutRefTest_count)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SimpleStructArrays(::ABI::GluonTest::BlittableStruct* inTest, int inTest_count, ::ABI::GluonTest::BlittableStruct** outOutTest, int* outOutTest_count, ::ABI::GluonTest::BlittableStruct** inoutRefTest, int* inoutRefTest_count, ::ABI::GluonTest::BlittableStruct** ___ret, int* ___ret_count)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_count) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_count) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<::ABI::GluonTest::BlittableStruct>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::BlittableStruct>>::ToABI(SimpleStructArrays(
            ABIUtil<Array<GluonTest::BlittableStruct>>::FromABI(inTest, inTest_count),
            ABIUtil<Array<GluonTest::BlittableStruct>>::Ref(outOutTest, outOutTest_count),
            ABIUtil<Array<GluonTest::BlittableStruct>>::Ref(inoutRefTest, inoutRefTest_count)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ComplexStructArrays(::ABI::GluonTest::ComplexStruct* inTest, int inTest_count, ::ABI::GluonTest::ComplexStruct** outOutTest, int* outOutTest_count, ::ABI::GluonTest::ComplexStruct** inoutRefTest, int* inoutRefTest_count, ::ABI::GluonTest::ComplexStruct** ___ret, int* ___ret_count)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_count) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_count) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<::ABI::GluonTest::ComplexStruct>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::ComplexStruct>>::ToABI(ComplexStructArrays(
            ABIUtil<Array<GluonTest::ComplexStruct>>::FromABI(inTest, inTest_count),
            ABIUtil<Array<GluonTest::ComplexStruct>>::Ref(outOutTest, outOutTest_count),
            ABIUtil<Array<GluonTest::ComplexStruct>>::Ref(inoutRefTest, inoutRefTest_count)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ObjectArrays(::ABI::GluonTest::DummyClass** inTest, int inTest_count, ::ABI::GluonTest::DummyClass*** outOutTest, int* outOutTest_count, ::ABI::GluonTest::DummyClass*** inoutRefTest, int* inoutRefTest_count, ::ABI::GluonTest::DummyClass*** ___ret, int* ___ret_count)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_count) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_count) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<::ABI::GluonTest::DummyClass*>(___ret, ___ret_count) = ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::ToABI(ObjectArrays(
            ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::FromABI(inTest, inTest_count),
            ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::Ref(outOutTest, outOutTest_count),
            ABIUtil<Array<com_ptr<GluonTest::DummyClass>>>::Ref(inoutRefTest, inoutRefTest_count)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_NamedDelegateArrays(ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outOutTest, int* outOutTest_count, ABI::DelegateBlob** inoutRefTest, int* inoutRefTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_count) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_count) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<ABI::DelegateBlob>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::NamedDelegate>>::ToABI(NamedDelegateArrays(
            ABIUtil<Array<GluonTest::NamedDelegate>>::FromABI(inTest, inTest_count),
            ABIUtil<Array<GluonTest::NamedDelegate>>::Ref(outOutTest, outOutTest_count),
            ABIUtil<Array<GluonTest::NamedDelegate>>::Ref(inoutRefTest, inoutRefTest_count)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GenericDelegateArrays(ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outOutTest, int* outOutTest_count, ABI::DelegateBlob** inoutRefTest, int* inoutRefTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count)
{
    if(!outOutTest) return E_POINTER;
    if(!outOutTest_count) return E_POINTER;
    if(!inoutRefTest) return E_POINTER;
    if(!inoutRefTest_count) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<ABI::DelegateBlob>(___ret, ___ret_count) = ABIUtil<Array<Delegate<int(int)>>>::ToABI(GenericDelegateArrays(
            ABIUtil<Array<Delegate<void(string)>>>::FromABI(inTest, inTest_count),
            ABIUtil<Array<Delegate<void(const Delegate<int(int)>&)>>>::Ref(outOutTest, outOutTest_count),
            ABIUtil<Array<Delegate<string(Array<char>)>>>::Ref(inoutRefTest, inoutRefTest_count)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ExCheckNullReference()
{
    try {
        ExCheckNullReference();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ExCheckArgumentNull()
{
    try {
        ExCheckArgumentNull();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ExCheckArgument()
{
    try {
        ExCheckArgument();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ExCheckInvalidOperation()
{
    try {
        ExCheckInvalidOperation();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ExCheckAccessDenied()
{
    try {
        ExCheckAccessDenied();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ExCheckGeneric()
{
    try {
        ExCheckGeneric();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ExCheckGenericStd()
{
    try {
        ExCheckGenericStd();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_ExCheckNotImplemented()
{
    try {
        ExCheckNotImplemented();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetPrimitivesCB(fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::PrimitivesCB>::ToABI(GetPrimitivesCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetPrimitivesCB(fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)> value, IObject* value_context)
{
    try {
        SetPrimitivesCB(ABIUtil<GluonTest::PrimitivesCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetStringsCB(fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>>(___ret, ___ret_context) = ABIUtil<GluonTest::StringsCB>::ToABI(GetStringsCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetStringsCB(fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)> value, IObject* value_context)
{
    try {
        SetStringsCB(ABIUtil<GluonTest::StringsCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetSimpleStructsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::SimpleStructsCB>::ToABI(GetSimpleStructsCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetSimpleStructsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)> value, IObject* value_context)
{
    try {
        SetSimpleStructsCB(ABIUtil<GluonTest::SimpleStructsCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetComplexStructsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::ComplexStructsCB>::ToABI(GetComplexStructsCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetComplexStructsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)> value, IObject* value_context)
{
    try {
        SetComplexStructsCB(ABIUtil<GluonTest::ComplexStructsCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetObjectsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)>>(___ret, ___ret_context) = ABIUtil<GluonTest::ObjectsCB>::ToABI(GetObjectsCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetObjectsCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)> value, IObject* value_context)
{
    try {
        SetObjectsCB(ABIUtil<GluonTest::ObjectsCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetNamedDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>>(___ret, ___ret_context) = ABIUtil<GluonTest::NamedDelegatesCB>::ToABI(GetNamedDelegatesCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetNamedDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)> value, IObject* value_context)
{
    try {
        SetNamedDelegatesCB(ABIUtil<GluonTest::NamedDelegatesCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetGenericDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>>(___ret, ___ret_context) = ABIUtil<GluonTest::GenericDelegatesCB>::ToABI(GetGenericDelegatesCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetGenericDelegatesCB(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)> value, IObject* value_context)
{
    try {
        SetGenericDelegatesCB(ABIUtil<GluonTest::GenericDelegatesCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetPrimitiveArraysCB(fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::PrimitiveArraysCB>::ToABI(GetPrimitiveArraysCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetPrimitiveArraysCB(fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)> value, IObject* value_context)
{
    try {
        SetPrimitiveArraysCB(ABIUtil<GluonTest::PrimitiveArraysCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetStringArraysCB(fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::StringArraysCB>::ToABI(GetStringArraysCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetStringArraysCB(fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)> value, IObject* value_context)
{
    try {
        SetStringArraysCB(ABIUtil<GluonTest::StringArraysCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetSimpleStructArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::SimpleStructArraysCB>::ToABI(GetSimpleStructArraysCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetSimpleStructArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)> value, IObject* value_context)
{
    try {
        SetSimpleStructArraysCB(ABIUtil<GluonTest::SimpleStructArraysCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetComplexStructArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::ComplexStructArraysCB>::ToABI(GetComplexStructArraysCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetComplexStructArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)> value, IObject* value_context)
{
    try {
        SetComplexStructArraysCB(ABIUtil<GluonTest::ComplexStructArraysCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetObjectArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::ObjectArraysCB>::ToABI(GetObjectArraysCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetObjectArraysCB(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)> value, IObject* value_context)
{
    try {
        SetObjectArraysCB(ABIUtil<GluonTest::ObjectArraysCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetNamedDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::NamedDelegateArraysCB>::ToABI(GetNamedDelegateArraysCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetNamedDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)> value, IObject* value_context)
{
    try {
        SetNamedDelegateArraysCB(ABIUtil<GluonTest::NamedDelegateArraysCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetGenericDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::GenericDelegateArraysCB>::ToABI(GetGenericDelegateArraysCB());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetGenericDelegateArraysCB(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)> value, IObject* value_context)
{
    try {
        SetGenericDelegateArraysCB(ABIUtil<GluonTest::GenericDelegateArraysCB>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_GetStructMembers(::ABI::GluonTest::StructMemberTest* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<GluonTest::StructMemberTest>::ToABI(GetStructMembers());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ConversionUnitTest::_SetStructMembers(::ABI::GluonTest::StructMemberTest value)
{
    try {
        SetStructMembers(ABIUtil<GluonTest::StructMemberTest>::FromABI(value));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_ITestClass_1(::ABI::GluonTest::ITestClass** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::ITestClass(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_Methody()
{
    try {
        Methody();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_RetMethod(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = RetMethod();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_OutMethod(int* outX)
{
    if(!outX) return E_POINTER;

    try {
        OutMethod(ABIUtil<int>::Ref(outX));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_RefMethod(char** inoutThing)
{
    if(!inoutThing) return E_POINTER;

    try {
        RefMethod(ABIUtil<string>::Ref(inoutThing));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_Ref2(::ABI::GluonTest::ITestClass** inoutThing)
{
    if(!inoutThing) return E_POINTER;

    try {
        Ref2(ABIUtil<GluonTest::ITestClass>::Ref(inoutThing));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_Ref3(::ABI::GluonTest::TestStruct thing)
{
    try {
        Ref3(ABIUtil<GluonTest::TestStruct>::FromABI(thing));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_ComplexMethod(char** inoutA, IUnknown* _dumb, void* p, char** outFart, int* outFart_count, int** ___ret, int* ___ret_count)
{
    if(!inoutA) return E_POINTER;
    if(!outFart) return E_POINTER;
    if(!outFart_count) return E_POINTER;
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<int>(___ret, ___ret_count) = ABIUtil<Array<int>>::ToABI(ComplexMethod(
            ABIUtil<string>::Ref(inoutA),
            ABIUtil<IUnknown>::FromABI(_dumb),
            p,
            ABIUtil<Array<char>>::Ref(outFart, outFart_count)));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_GetAdder(fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)>>(___ret, ___ret_context) = ABIUtil<GluonTest::AddSomeShit>::ToABI(GetAdder());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_SetAdder(fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)> value, IObject* value_context)
{
    try {
        SetAdder(ABIUtil<GluonTest::AddSomeShit>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_GetProperty(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetProperty();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_SetProperty(int value)
{
    try {
        SetProperty(value);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_GetReadOnlyProperty(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetReadOnlyProperty();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_GetHardProperty(::ABI::GluonTest::TestStruct** ___ret, int* ___ret_count)
{
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<::ABI::GluonTest::TestStruct>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::TestStruct>>::ToABI(GetHardProperty());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_SetHardProperty(::ABI::GluonTest::TestStruct* value, int value_count)
{
    try {
        SetHardProperty(ABIUtil<Array<GluonTest::TestStruct>>::FromABI(value, value_count));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_GetHarderProperty(ABI::DelegateBlob** ___ret, int* ___ret_count)
{
    if(!___ret) return E_POINTER;
    if(!___ret_count) return E_POINTER;

    try {
        ABI::ArrayRef<ABI::DelegateBlob>(___ret, ___ret_count) = ABIUtil<Array<Delegate<string(char, int)>>>::ToABI(GetHarderProperty());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_SetHarderProperty(ABI::DelegateBlob* value, int value_count)
{
    try {
        SetHarderProperty(ABIUtil<Array<Delegate<string(char, int)>>>::FromABI(value, value_count));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_GetDumbDelegate(fn_ptr<HRESULT(IObject*,char*,char*)>* ___ret, IObject** ___ret_context)
{
    if(!___ret) return E_POINTER;
    if(!___ret_context) return E_POINTER;

    try {
        ABI::DelegateRef<fn_ptr<HRESULT(IObject*,char*,char*)>>(___ret, ___ret_context) = ABIUtil<Delegate<char(string)>>::ToABI(GetDumbDelegate());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_SetDumbDelegate(fn_ptr<HRESULT(IObject*,char*,char*)> value, IObject* value_context)
{
    try {
        SetDumbDelegate(ABIUtil<Delegate<char(string)>>::FromABI((void**)value, value_context));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_AddBigEventHandler(fn_ptr<HRESULT(IObject*,int)> handler, IObject* context)
{
    try {
        BigEvent += ABIUtil<Delegate<void(int)>>::FromABI(handler, context);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::ITestClass::_RemoveBigEventHandler(fn_ptr<HRESULT(IObject*,int)> handler, IObject* context)
{
    try {
        BigEvent -= ABIUtil<Delegate<void(int)>>::FromABI(handler, context);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

HRESULT GluonTest::Generator::_Initialize(int channels, int sampleRate)
{
    try {
        Initialize(
            channels,
            sampleRate);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::Generator::_Eval(double t, double* inoutOutSample)
{
    if(!inoutOutSample) return E_POINTER;

    try {
        Eval(
            t,
            ABIUtil<double>::Ref(inoutOutSample));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::Generator::_EvalBuffer(double t, ::ABI::GluonTest::SignalBuffer* inoutBuffer)
{
    try {
        EvalBuffer(
            t,
            ABIUtil<GluonTest::SignalBuffer>::FromABI(inoutBuffer));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::Generator::_GetChannelCount(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetChannelCount();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::Generator::_GetSampleRate(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetSampleRate();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_SignalBuffer_1(int samples, int channels, int alignment, ::ABI::GluonTest::SignalBuffer** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::SignalBuffer(
            ABIUtil<int>::FromABI(samples),
            ABIUtil<int>::FromABI(channels),
            ABIUtil<int>::FromABI(alignment));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

ABI_CONSTRUCTOR Create_GluonTest_SignalBuffer_2(int samples, ::ABI::GluonTest::SignalBuffer** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::SignalBuffer(
            ABIUtil<int>::FromABI(samples));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::SignalBuffer::_CopyTo(double* arr, int arr_count, int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = CopyTo(ABIUtil<Array<double>>::FromABI(arr, arr_count));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::SignalBuffer::_CopyTo(float* arr, int arr_count, int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = CopyTo(ABIUtil<Array<float>>::FromABI(arr, arr_count));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::SignalBuffer::_CopyTo(short* arr, int arr_count, int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = CopyTo(ABIUtil<Array<short>>::FromABI(arr, arr_count));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::SignalBuffer::_GetChannelCount(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetChannelCount();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::SignalBuffer::_GetSampleCount(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetSampleCount();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_Waveform_1(double* samples, int samples_count, ::ABI::GluonTest::Waveform** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::Waveform(
            ABIUtil<Array<double>>::FromABI(samples, samples_count));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::Waveform::_Phase(double t, double* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = Phase(t);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_SinusoidalWaveform_1(::ABI::GluonTest::SinusoidalWaveform** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::SinusoidalWaveform(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_SquareWaveform_1(::ABI::GluonTest::SquareWaveform** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::SquareWaveform(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_TriangleWaveform_1(::ABI::GluonTest::TriangleWaveform** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::TriangleWaveform(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_SawtoothRightWaveform_1(::ABI::GluonTest::SawtoothRightWaveform** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::SawtoothRightWaveform(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_SawtoothLeftWaveform_1(::ABI::GluonTest::SawtoothLeftWaveform** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::SawtoothLeftWaveform(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_GTone_1(::ABI::GluonTest::GTone** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::GTone(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::GTone::_GetFrequency(double* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetFrequency();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::GTone::_SetFrequency(double value)
{
    try {
        SetFrequency(value);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::GTone::_GetWaveform(::ABI::GluonTest::Waveform** ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<GluonTest::Waveform>::ToABI(GetWaveform());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::GTone::_SetWaveform(::ABI::GluonTest::Waveform* value)
{
    try {
        SetWaveform(ABIUtil<GluonTest::Waveform>::FromABI(value));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::GTone::_GetAmplitude(double* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetAmplitude();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::GTone::_SetAmplitude(double value)
{
    try {
        SetAmplitude(value);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_GWhiteNoise_1(::ABI::GluonTest::GWhiteNoise** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::GWhiteNoise(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
#ifndef __INTELLISENSE__

ABI_CONSTRUCTOR Create_GluonTest_NoiseEngine_1(::ABI::GluonTest::NoiseEngine** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new GluonTest::NoiseEngine(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_Play()
{
    try {
        Play();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_Pause()
{
    try {
        Pause();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_GetPlot(double durationSeconds, GluonTest::PlotType type, ::ABI::GluonTest::SignalBuffer** ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<GluonTest::SignalBuffer>::ToABI(GetPlot(
            durationSeconds,
            type));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_GetError(char** ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<string>::ToABI(GetError());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_GetState(GluonTest::NoiseEngineState* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetState();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_GetSampleRate(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetSampleRate();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_SetSampleRate(int value)
{
    try {
        SetSampleRate(value);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_GetChannels(GluonTest::NoiseChannels* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetChannels();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_SetChannels(GluonTest::NoiseChannels value)
{
    try {
        SetChannels(value);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_GetBlockDuration(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetBlockDuration();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_SetBlockDuration(int value)
{
    try {
        SetBlockDuration(value);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_GetDistribution(GluonTest::NoiseDistribution* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetDistribution();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_SetDistribution(GluonTest::NoiseDistribution value)
{
    try {
        SetDistribution(value);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_GetIsFilterEnabled(bool* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetIsFilterEnabled();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT GluonTest::NoiseEngine::_SetIsFilterEnabled(bool value)
{
    try {
        SetIsFilterEnabled(value);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

#endif
