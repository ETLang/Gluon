/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#pragma once
#include <Sharpish.h>

using namespace CS;

#include "GluonNative.h"

void SampleImageFilterApi_Initialize();

namespace SampleImageFilterApi
{
    using namespace GluonInternal;

    struct Thing2;
}

namespace ABI
{
    namespace SampleImageFilterApi
    {
        struct Thing;
        using ::SampleImageFilterApi::Thing2;
    }
}

namespace ABI
{
    namespace SampleImageFilter
    {
        using namespace GluonInternal;

        cominterface BlackAndWhiteFilter;
        cominterface SampleImage;
    }
}

namespace ABI
{
    namespace System
    {
        using namespace GluonInternal;
    }
}

namespace SampleImageFilterApi
{
    struct comid("4a34c9f7-b5a7-4bff-9deb-ca1e1be39811") Thing2
    {
        int a;
        int b;

        Thing2() { }
        Thing2(int _a, int _b) : 
            a(_a), b(_b)
        { }
    };
}

IS_VALUETYPE(::SampleImageFilterApi::Thing2, "4a34c9f7-b5a7-4bff-9deb-ca1e1be39811");


namespace ABI
{
    namespace SampleImageFilterApi
    {
        using ::SampleImageFilterApi::Thing2;

        struct comid("4a34c9f7-b5a7-4bff-9deb-f81e1be39811") Thing
        {
            char* A;
            int cc;
            double boo;

            Thing() { }
            Thing(char* _A, int _cc, double _boo) : 
                A(_A), cc(_cc), boo(_boo)
            { }
        };
    }
}

IS_VALUETYPE(::ABI::SampleImageFilterApi::Thing, "4a34c9f7-b5a7-4bff-9deb-f81e1be39811");

ABI_CONSTRUCTOR Create_SampleImageFilter_BlackAndWhiteFilter_1(::ABI::SampleImageFilter::BlackAndWhiteFilter** outInstance);
ABI_CONSTRUCTOR Create_SampleImageFilter_SampleImage_1(byte* data, int data_count, int width, int height, ::ABI::SampleImageFilter::SampleImage** outInstance);

namespace ABI
{
    namespace SampleImageFilter
    {
        cominterface comid("2a72ca9e-829a-63fc-9de8-af767297fd57") BlackAndWhiteFilter : public IUnknown
        {
            METHOD _BeginFiltering(SampleImage* image) = 0;

            METHOD _GetIsFiltering(bool* ___ret) = 0;

            METHOD _AddFilteringCompleteHandler(fn_ptr<HRESULT(IObject*,SampleImage*)> handler, IObject* handler_context) = 0;
            METHOD _RemoveFilteringCompleteHandler(fn_ptr<HRESULT(IObject*,SampleImage*)> handler, IObject* handler_context) = 0;
        };

        cominterface comid("4217a6f7-91e4-47fb-bae1-99797ee39811") SampleImage : public IUnknown
        {
            METHOD _CopyDataTo(byte** outData, int* outData_count) = 0;
            METHOD _Save(char* path) = 0;
            METHOD _GetThing(SampleImageFilterApi::Thing* ___ret) = 0;
            METHOD _AnotherThing(SampleImageFilterApi::Thing2* ___ret) = 0;

            METHOD _GetWidth(int* ___ret) = 0;
            METHOD _GetHeight(int* ___ret) = 0;
        };
    }
}
