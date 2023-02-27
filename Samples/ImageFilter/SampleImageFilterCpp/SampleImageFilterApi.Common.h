/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#pragma once
#define GLUON_BUILDING
#include "Public/SampleImageFilterApi.public.abi.h"

namespace SampleImageFilterApi
{
    using namespace GluonInternal;

    struct Thing;
    struct Thing2;
}

namespace SampleImageFilter
{
    using namespace GluonInternal;

    class BlackAndWhiteFilter;
    class SampleImage;
}

namespace System
{
    using namespace GluonInternal;
}

namespace SampleImageFilterApi
{
    struct comid("6dbc7be9-bfe8-4ec7-a638-26063b391fc0") Thing
    {
        typedef ::ABI::SampleImageFilterApi::Thing ABIType;

        string A;
        int cc;
        double boo;

        Thing() { }
        Thing(string _A, int _cc, double _boo) : 
            A(_A), cc(_cc), boo(_boo)
        { }
    };
}

IS_VALUETYPE(::SampleImageFilterApi::Thing, "6dbc7be9-bfe8-4ec7-a638-26063b391fc0");

MapStructABI(SampleImageFilterApi::Thing, ::ABI::SampleImageFilterApi::Thing)

namespace SampleImageFilterApi::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5C0C3D4C : public ComObject<DW_5C0C3D4C, Object>, public ABI::DelegateWrapperBase<DW_5C0C3D4C,
        void(SampleImageFilter::SampleImage*)>
    {
    public:
        DW_5C0C3D4C(const Delegate<void(SampleImageFilter::SampleImage*)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::SampleImageFilter::SampleImage* obj);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<void(SampleImageFilter::SampleImage*)>> : public ABIUtilForDelegates<void(SampleImageFilter::SampleImage*)>
    {
        typedef SampleImageFilterApi::Details::DW_5C0C3D4C DW_5C0C3D4C;

        static Delegate<void(SampleImageFilter::SampleImage*)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<void(SampleImageFilter::SampleImage*)>& x);
        static Delegate<void(SampleImageFilter::SampleImage*)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}
