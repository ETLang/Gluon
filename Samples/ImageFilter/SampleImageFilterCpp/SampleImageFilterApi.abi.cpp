/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#include "SampleImageFilterApi.Common.h"
#include "BlackAndWhiteFilter.h"
#include "SampleImage.h"


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
void SampleImageFilterApi_Initialize()
{
    Create_SampleImageFilter_BlackAndWhiteFilter_1(nullptr);
    Create_SampleImageFilter_SampleImage_1(Def<byte*>(), Def<int>(), Def<int>(), Def<int>(), nullptr);
}

namespace GluonInternal
{
    SampleImageFilterApi::Thing ABIUtil<SampleImageFilterApi::Thing>::FromABI(const ::ABI::SampleImageFilterApi::Thing& x)
    {
        return SampleImageFilterApi::Thing(
            ABIUtil<string>::FromABI(x.A),
            x.cc,
            x.boo);
    }

    ::ABI::SampleImageFilterApi::Thing ABIUtil<SampleImageFilterApi::Thing>::ToABI(const SampleImageFilterApi::Thing& x)
    {
        return ::ABI::SampleImageFilterApi::Thing(
            ABIUtil<string>::ToABI(x.A),
            x.cc,
            x.boo);
    }
}

#include "Public/SampleImageFilterApi.public.abi.h"
using namespace SampleImageFilterApi::Details;
using namespace GluonInternal;

namespace SampleImageFilterApi::Details
{
    HRESULT DW_5C0C3D4C::AbiFunc(IObject* __i_, ::ABI::SampleImageFilter::SampleImage* obj)
    {
        auto ___del = runtime_cast<DW_5C0C3D4C>(__i_);
        if (!___del) return E_FAIL;

        try {
            ___del->Func(ABIUtil<SampleImageFilter::SampleImage>::FromABI(obj));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }
}

namespace GluonInternal
{
    Delegate<void(SampleImageFilter::SampleImage*)> GluonInternal::ABIUtil<Delegate<void(SampleImageFilter::SampleImage*)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_5C0C3D4C::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_5C0C3D4C>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)>)fptr, cp = com_ptr<IObject>(ctx)](SampleImageFilter::SampleImage* obj)
        {
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                ABIUtil<SampleImageFilter::SampleImage>::ToABI(obj)));
        };
    }

    ABIOf<Delegate<void(SampleImageFilter::SampleImage*)>> GluonInternal::ABIUtil<Delegate<void(SampleImageFilter::SampleImage*)>>::ToABI(const Delegate<void(SampleImageFilter::SampleImage*)>& x)
    {
        ABIOf<Delegate<void(SampleImageFilter::SampleImage*)>> x_abi;
        x_abi.Fn = &DW_5C0C3D4C::AbiFunc;
        x_abi.Ctx = DW_5C0C3D4C::GetWrapper(x);
        return x_abi;
    }
}

ABI_CONSTRUCTOR Create_SampleImageFilter_BlackAndWhiteFilter_1(::ABI::SampleImageFilter::BlackAndWhiteFilter** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new SampleImageFilter::BlackAndWhiteFilter(
        );
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::BlackAndWhiteFilter::_BeginFiltering(::ABI::SampleImageFilter::SampleImage* image)
{
    try {
        BeginFiltering(ABIUtil<SampleImageFilter::SampleImage>::FromABI(image));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::BlackAndWhiteFilter::_GetIsFiltering(bool* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetIsFiltering();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::BlackAndWhiteFilter::_AddFilteringCompleteHandler(fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)> handler, IObject* context)
{
    try {
        FilteringComplete += ABIUtil<Delegate<void(SampleImageFilter::SampleImage*)>>::FromABI(handler, context);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::BlackAndWhiteFilter::_RemoveFilteringCompleteHandler(fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)> handler, IObject* context)
{
    try {
        FilteringComplete -= ABIUtil<Delegate<void(SampleImageFilter::SampleImage*)>>::FromABI(handler, context);
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

ABI_CONSTRUCTOR Create_SampleImageFilter_SampleImage_1(byte* data, int data_count, int width, int height, ::ABI::SampleImageFilter::SampleImage** outInstance)
{
    try {
        if(!outInstance) return E_POINTER;
        *outInstance = new SampleImageFilter::SampleImage(
            ABIUtil<Array<byte>>::FromABI(data, data_count),
            ABIUtil<int>::FromABI(width),
            ABIUtil<int>::FromABI(height));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::SampleImage::_CopyDataTo(byte** outData, int* outData_count)
{
    if(!outData) return E_POINTER;
    if(!outData_count) return E_POINTER;

    try {
        CopyDataTo(ABIUtil<Array<byte>>::Ref(outData, outData_count));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::SampleImage::_Save(char* path)
{
    try {
        Save(ABIUtil<string>::FromABI(path));
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::SampleImage::_GetThing(::ABI::SampleImageFilterApi::Thing* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = ABIUtil<SampleImageFilterApi::Thing>::ToABI(GetThing());
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::SampleImage::_AnotherThing(::ABI::SampleImageFilterApi::Thing2* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = AnotherThing();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::SampleImage::_GetWidth(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetWidth();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}

HRESULT SampleImageFilter::SampleImage::_GetHeight(int* ___ret)
{
    if(!___ret) return E_POINTER;

    try {
        *___ret = GetHeight();
        return S_OK;
    } TRANSLATE_EXCEPTIONS
}
