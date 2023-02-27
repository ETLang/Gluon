#pragma once
#include "SampleImageFilterApi.Common.h"


namespace SampleImageFilter
{
    class comid("0dfa7880-88d5-66c4-a63b-716e524d7a86")
    BlackAndWhiteFilter : public ComObject<BlackAndWhiteFilter, Object, ::ABI::IGluonObject, ::ABI::SampleImageFilter::BlackAndWhiteFilter>
    {
    #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::SampleImageFilter::BlackAndWhiteFilter ABIType;

        BlackAndWhiteFilter();

        Event<void(SampleImage*)> FilteringComplete {_FilteringComplete};

        PROPERTY_READONLY(bool, IsFiltering);
        bool GetIsFiltering() const;

        void BeginFiltering(SampleImage* image);

    private:
        EventTrigger<void(SampleImage*)> _FilteringComplete;

        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::SampleImageFilter::BlackAndWhiteFilter); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "SampleImageFilter.BlackAndWhiteFilter"; return S_OK; }
        METHOD _BeginFiltering(::ABI::SampleImageFilter::SampleImage* image);

        METHOD _GetIsFiltering(bool* ___ret);

        METHOD _AddFilteringCompleteHandler(fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)> handler, IObject* handler_context);
        METHOD _RemoveFilteringCompleteHandler(fn_ptr<HRESULT(IObject*,::ABI::SampleImageFilter::SampleImage*)> handler, IObject* handler_context);
    // clang-format on
    #pragma endregion
    };
}

