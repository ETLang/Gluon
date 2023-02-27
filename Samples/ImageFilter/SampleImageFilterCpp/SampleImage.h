#pragma once
#include "SampleImageFilterApi.Common.h"


namespace SampleImageFilter
{
    class comid("659f14e9-9bab-42c3-8132-47615e391fc0")
    SampleImage : public ComObject<SampleImage, Object, ::ABI::IGluonObject, ::ABI::SampleImageFilter::SampleImage>
    {
    #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::SampleImageFilter::SampleImage ABIType;

        SampleImage(Array<byte> data, int width, int height);

        PROPERTY_READONLY(int, Width);
        int GetWidth() const;

        PROPERTY_READONLY(int, Height);
        int GetHeight() const;

        void CopyDataTo(Array<byte>& outData);
        void Save(string path);
        SampleImageFilterApi::Thing GetThing();
        SampleImageFilterApi::Thing2 AnotherThing();

    private:
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::SampleImageFilter::SampleImage); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "SampleImageFilter.SampleImage"; return S_OK; }
        METHOD _CopyDataTo(byte** outData, int* outData_count);
        METHOD _Save(char* path);
        METHOD _GetThing(::ABI::SampleImageFilterApi::Thing* ___ret);
        METHOD _AnotherThing(::ABI::SampleImageFilterApi::Thing2* ___ret);

        METHOD _GetWidth(int* ___ret);
        METHOD _GetHeight(int* ___ret);
    // clang-format on
    #pragma endregion
    };
}

