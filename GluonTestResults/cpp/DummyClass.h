#pragma once
#include "GluonTest.Common.h"

namespace GluonTest { 
    class comid("68a756e3-dac4-3983-dd16-07353f3812e6")
    DummyClass : public ComObject<DummyClass, Object, ::ABI::GluonTest::DummyClass>
    {
                #pragma region Gluon Maintained
    // clang-format off
    public:
        typedef ::ABI::GluonTest::DummyClass ABIType;

        DummyClass();

        PROPERTY(string, Nugget);
        string GetNugget() const;
        void SetNugget(string value);

    private:
#ifndef __INTELLISENSE__
        METHOD GetObjectTypeId(UUID* outID) { if(!outID) return E_POINTER; *outID = _uuidof(::ABI::GluonTest::DummyClass); return S_OK; }
        METHOD GetObjectTypeName(const char** outStr) { if(!outStr) return E_POINTER; *outStr = "GluonTest.DummyClass"; return S_OK; }
        METHOD _GetNugget(char** ___ret);
        METHOD _SetNugget(char* value);

#endif
    // clang-format on
    #pragma endregion

        string _nugget;
    };
}
