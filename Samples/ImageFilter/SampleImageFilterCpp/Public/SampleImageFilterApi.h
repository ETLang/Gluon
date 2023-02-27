/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#pragma once
#include "SampleImageFilterApi.public.abi.h"

namespace SampleImageFilterApi
{
    using namespace GluonInternal;

    struct Thing;
    struct Thing2;
}

namespace SampleImageFilter
{
    using namespace GluonInternal;

    class _P_BlackAndWhiteFilter;
    typedef comid("2a72ca9e-829a-63fc-9de8-af767297fd57") ::ABI::PimplPtr<_P_BlackAndWhiteFilter> BlackAndWhiteFilter;

    class _P_SampleImage;
    typedef comid("4217a6f7-91e4-47fb-bae1-99797ee39811") ::ABI::PimplPtr<_P_SampleImage> SampleImage;
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

namespace SampleImageFilter
{
    class _P_BlackAndWhiteFilter : public ABI::Wrapper
    {
        template<typename> friend BlackAndWhiteFilter CreateBlackAndWhiteFilter();
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_BlackAndWhiteFilter, ::ABI::SampleImageFilter::BlackAndWhiteFilter)
    public:
        VirtualEvent<void(const SampleImage&), _P_BlackAndWhiteFilter> FilteringComplete
            { this, &_P_BlackAndWhiteFilter::AddFilteringCompleteHandler, &_P_BlackAndWhiteFilter::RemoveFilteringCompleteHandler };

        PROPERTY_READONLY(bool, IsFiltering);
        bool GetIsFiltering() const
        {
            return __P_GetIsFiltering();
        }

        void BeginFiltering(const SampleImage& image) const
        {
            __P_BeginFiltering(image);
        }

    private:
        void AddFilteringCompleteHandler(const Delegate<void(const SampleImage&)>& handler) const
        {
            __P_AddFilteringCompleteHandler(handler);
        }

        void RemoveFilteringCompleteHandler(const Delegate<void(const SampleImage&)>& handler) const
        {
            __P_RemoveFilteringCompleteHandler(handler);
        }

        template<typename = void>
        static BlackAndWhiteFilter __P_Create();

        template<typename = void>
        void __P_BeginFiltering(const SampleImage& image) const;

        template<typename = void>
        bool __P_GetIsFiltering() const;

        template<typename = void>
        void __P_AddFilteringCompleteHandler(const Delegate<void(const SampleImage&)>& handler) const;

        template<typename = void>
        void __P_RemoveFilteringCompleteHandler(const Delegate<void(const SampleImage&)>& handler) const;

    };

    template<typename = void>
    BlackAndWhiteFilter CreateBlackAndWhiteFilter()
    {
        return _P_BlackAndWhiteFilter::__P_Create();
    }
}

IS_VALUETYPE(SampleImageFilter::BlackAndWhiteFilter, "2a72ca9e-829a-63fc-9de8-af767297fd57")

namespace SampleImageFilter
{
    class _P_SampleImage : public ABI::Wrapper
    {
        template<typename> friend SampleImage CreateSampleImage(Array<byte> data, int width, int height);
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_SampleImage, ::ABI::SampleImageFilter::SampleImage)
    public:
        PROPERTY_READONLY(int, Width);
        int GetWidth() const
        {
            return __P_GetWidth();
        }

        PROPERTY_READONLY(int, Height);
        int GetHeight() const
        {
            return __P_GetHeight();
        }

        void CopyDataTo(Array<byte>& outData) const
        {
            __P_CopyDataTo(outData);
        }

        void Save(string path) const
        {
            __P_Save(path);
        }

        SampleImageFilterApi::Thing GetThing() const
        {
            return __P_GetThing();
        }

        SampleImageFilterApi::Thing2 AnotherThing() const
        {
            return __P_AnotherThing();
        }

    private:
        template<typename = void>
        static SampleImage __P_Create(Array<byte> data, int width, int height);

        template<typename = void>
        void __P_CopyDataTo(Array<byte>& outData) const;

        template<typename = void>
        void __P_Save(string path) const;

        template<typename = void>
        SampleImageFilterApi::Thing __P_GetThing() const;

        template<typename = void>
        SampleImageFilterApi::Thing2 __P_AnotherThing() const;

        template<typename = void>
        int __P_GetWidth() const;

        template<typename = void>
        int __P_GetHeight() const;

    };

    template<typename = void>
    SampleImage CreateSampleImage(Array<byte> data, int width, int height)
    {
        return _P_SampleImage::__P_Create(data, width, height);
    }
}

IS_VALUETYPE(SampleImageFilter::SampleImage, "4217a6f7-91e4-47fb-bae1-99797ee39811")

namespace SampleImageFilterApi::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5C0C3D4C : public ComObject<DW_5C0C3D4C, Object>, public ABI::DelegateWrapperBase<DW_5C0C3D4C,
        void(const SampleImageFilter::SampleImage&)>
    {
    public:
        DW_5C0C3D4C(const Delegate<void(const SampleImageFilter::SampleImage&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::SampleImageFilter::SampleImage* obj){
            return __P_AbiFunc(__i_, obj);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ::ABI::SampleImageFilter::SampleImage* obj);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<void(const SampleImageFilter::SampleImage&)>> : public ABIUtilForDelegates<void(const SampleImageFilter::SampleImage&)>
    {
        typedef SampleImageFilterApi::Details::DW_5C0C3D4C DW_5C0C3D4C;

        static Delegate<void(const SampleImageFilter::SampleImage&)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_5C0C3D4C::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_5C0C3D4C>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)>)fptr, cp = com_ptr<IObject>(ctx)](const SampleImageFilter::SampleImage& obj)
            {
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    ABIUtil<SampleImageFilter::SampleImage>::ToABI(obj)));
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<void(const SampleImageFilter::SampleImage&)>& x)
        {
            ABIOf<Delegate<void(const SampleImageFilter::SampleImage&)>> x_abi;
            x_abi.Fn = &DW_5C0C3D4C::AbiFunc;
            x_abi.Ctx = DW_5C0C3D4C::GetWrapper(x);
            return x_abi;
        }

        static Delegate<void(const SampleImageFilter::SampleImage&)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<SampleImageFilterApi::Thing> : public StructABI<SampleImageFilterApi::Thing, ::ABI::SampleImageFilterApi::Thing>
    {
        static SampleImageFilterApi::Thing FromABI(const ::ABI::SampleImageFilterApi::Thing& x)
        {
            return SampleImageFilterApi::Thing(
                ABIUtil<string>::FromABI(x.A),
                x.cc,
                x.boo);
        }

        static ::ABI::SampleImageFilterApi::Thing ToABI(const SampleImageFilterApi::Thing& x)
        {
            return ::ABI::SampleImageFilterApi::Thing(
                ABIUtil<string>::ToABI(x.A),
                x.cc,
                x.boo);
        }
    };
}

namespace SampleImageFilterApi::Details
{
    template<typename>
    HRESULT DW_5C0C3D4C::__P_AbiFunc(IObject* __i_, ::ABI::SampleImageFilter::SampleImage* obj)
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
    static Delegate<void(const SampleImageFilter::SampleImage&)> GluonInternal::ABIUtil<Delegate<void(const SampleImageFilter::SampleImage&)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_5C0C3D4C::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_5C0C3D4C>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)>)fptr, cp = com_ptr<IObject>(ctx)](const SampleImageFilter::SampleImage& obj)
        {
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                ABIUtil<SampleImageFilter::SampleImage>::ToABI(obj)));
        };
    }

    static ABIOf<Delegate<void(const SampleImageFilter::SampleImage&)>> GluonInternal::ABIUtil<Delegate<void(const SampleImageFilter::SampleImage&)>>::ToABI(const Delegate<void(const SampleImageFilter::SampleImage&)>& x)
    {
        ABIOf<Delegate<void(const SampleImageFilter::SampleImage&)>> x_abi;
        x_abi.Fn = &DW_5C0C3D4C::AbiFunc;
        x_abi.Ctx = DW_5C0C3D4C::GetWrapper(x);
        return x_abi;
    }
}

namespace SampleImageFilter
{
    template<typename>
    BlackAndWhiteFilter _P_BlackAndWhiteFilter::__P_Create()
    {
        ::ABI::SampleImageFilter::BlackAndWhiteFilter* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_SampleImageFilter_BlackAndWhiteFilter_1(
            &instance));
        return ::ABI::Wrapper::Of<BlackAndWhiteFilter>(instance);
    }

    template<typename>
    void _P_BlackAndWhiteFilter::__P_AddFilteringCompleteHandler(const Delegate<void(const SampleImage&)>& handler) const
    {
        auto handler_abi = ABIUtil<Delegate<void(const SampleImage&)>>::ToABI(handler);
        TRANSLATE_TO_EXCEPTIONS(_abi->_AddFilteringCompleteHandler(
            (fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)>)handler_abi.Fn, handler_abi.Ctx));
    }

    template<typename>
    void _P_BlackAndWhiteFilter::__P_RemoveFilteringCompleteHandler(const Delegate<void(const SampleImage&)>& handler) const
    {
        auto handler_abi = ABIUtil<Delegate<void(const SampleImage&)>>::ToABI(handler);
        TRANSLATE_TO_EXCEPTIONS(_abi->_RemoveFilteringCompleteHandler(
            (fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)>)handler_abi.Fn, handler_abi.Ctx));
    }

    template<typename>
    bool _P_BlackAndWhiteFilter::__P_GetIsFiltering() const
    {
        bool ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetIsFiltering(
            ABICallbackRef<bool>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_BlackAndWhiteFilter::__P_BeginFiltering(const SampleImage& image) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_BeginFiltering(
            ABIUtil<SampleImage>::ToABI(image)));
    }
}

namespace SampleImageFilter
{
    template<typename>
    SampleImage _P_SampleImage::__P_Create(Array<byte> data, int width, int height)
    {
        ::ABI::SampleImageFilter::SampleImage* instance;
        auto data_abi = ABIUtil<Array<byte>>::ToABI(data);
        TRANSLATE_TO_EXCEPTIONS(Create_SampleImageFilter_SampleImage_1(
            data_abi.begin(), data_abi.size(),
            width,
            height,
            &instance));
        return ::ABI::Wrapper::Of<SampleImage>(instance);
    }

    template<typename>
    int _P_SampleImage::__P_GetWidth() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetWidth(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    int _P_SampleImage::__P_GetHeight() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetHeight(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_SampleImage::__P_CopyDataTo(Array<byte>& outData) const
    {
        ABICallbackRef<Array<byte>> outData_abi(outData);
        TRANSLATE_TO_EXCEPTIONS(_abi->_CopyDataTo(
            &outData_abi.Data, &outData_abi.Count));
    }

    template<typename>
    void _P_SampleImage::__P_Save(string path) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Save(
            ABIUtil<string>::ToABI(path)));
    }

    template<typename>
    SampleImageFilterApi::Thing _P_SampleImage::__P_GetThing() const
    {
        SampleImageFilterApi::Thing ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetThing(
            ABICallbackRef<SampleImageFilterApi::Thing>(___ret)));
        return ___ret;
    }

    template<typename>
    SampleImageFilterApi::Thing2 _P_SampleImage::__P_AnotherThing() const
    {
        SampleImageFilterApi::Thing2 ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_AnotherThing(
            ABICallbackRef<SampleImageFilterApi::Thing2>(___ret)));
        return ___ret;
    }
}
