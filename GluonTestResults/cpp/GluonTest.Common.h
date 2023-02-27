/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#pragma once
#define GLUON_BUILDING
#include "Public/GluonTest.public.abi.h"

namespace GluonTest
{
    using namespace GluonInternal;

    struct BlittableStruct;
    struct ComplexStruct;
    struct StructMemberTest;
    struct TestStruct;
    class DummyClass;
    class ConversionUnitTest;
    class ITestClass;
    class Generator;
    class SignalBuffer;
    class Waveform;
    class SinusoidalWaveform;
    class SquareWaveform;
    class TriangleWaveform;
    class SawtoothRightWaveform;
    class SawtoothLeftWaveform;
    class GTone;
    class GWhiteNoise;
    class NoiseEngine;
}

namespace System
{
    using namespace GluonInternal;
}

namespace GluonTest
{
}

namespace System
{
}

namespace GluonTest
{
}

namespace System
{
}

namespace GluonTest
{
}

namespace System
{
}

namespace GluonTest
{
    struct comid("69a064f7-b9b1-39f7-dd16-002f3f2507c0") ComplexStruct
    {
        typedef ::ABI::GluonTest::ComplexStruct ABIType;

        string Name;
        BlittableStruct Sub;
        com_ptr<DummyClass> Obj;
        Delegate<int(int, int)> Del;

        ComplexStruct() { }
        ComplexStruct(string _Name, const BlittableStruct& _Sub, DummyClass* _Obj, const Delegate<int(int, int)>& _Del) : 
            Name(_Name), Sub(_Sub), Obj(_Obj), Del(_Del)
        { }
    };
}

IS_VALUETYPE(::GluonTest::ComplexStruct, "69a064f7-b9b1-39f7-dd16-002f3f2507c0");

namespace GluonTest
{
    typedef Delegate<int(string, string)> NamedDelegate;

    struct comid("79b952c2-a8a1-5cd7-ae62-1034202008d1") StructMemberTest
    {
        typedef ::ABI::GluonTest::StructMemberTest ABIType;

        using NamedDelegate_t = NamedDelegate;

        bool Boolean;
        double Primitive;
        void* PrimitivePtr;
        string String;
        BlittableStruct BlittableSt;
        ComplexStruct ComplexSt;
        com_ptr<DummyClass> Object;
        NamedDelegate_t NamedDelegate;
        Delegate<double(double)> GenericDelegate;

        StructMemberTest() { }
        StructMemberTest(bool _Boolean, double _Primitive, void* _PrimitivePtr, string _String, const BlittableStruct& _BlittableSt, const ComplexStruct& _ComplexSt, DummyClass* _Object, const NamedDelegate_t& _NamedDelegate, const Delegate<double(double)>& _GenericDelegate) : 
            Boolean(_Boolean), Primitive(_Primitive), PrimitivePtr(_PrimitivePtr), String(_String), BlittableSt(_BlittableSt), ComplexSt(_ComplexSt), Object(_Object), NamedDelegate(_NamedDelegate), GenericDelegate(_GenericDelegate)
        { }
    };
}

IS_VALUETYPE(::GluonTest::StructMemberTest, "79b952c2-a8a1-5cd7-ae62-1034202008d1");

namespace GluonTest
{
    struct comid("6fb742fd-dac4-3983-dd16-1725212138d1") TestStruct
    {
        typedef ::ABI::GluonTest::TestStruct ABIType;

        char a;
        int b;
        int64_t c;
        int d;
        string e;
        Array<int> f;

        TestStruct() { }
        TestStruct(char _a, int _b, int64_t _c, int _d, string _e, Array<int> _f) : 
            a(_a), b(_b), c(_c), d(_d), e(_e), f(_f)
        { }
    };
}

IS_VALUETYPE(::GluonTest::TestStruct, "6fb742fd-dac4-3983-dd16-1725212138d1");

namespace GluonTest
{
    typedef Delegate<double(bool, char&, int&)> PrimitivesCB;
    typedef Delegate<string(string, string&, string&)> StringsCB;
    typedef Delegate<BlittableStruct(const BlittableStruct&, BlittableStruct&, BlittableStruct&)> SimpleStructsCB;
    typedef Delegate<ComplexStruct(const ComplexStruct&, ComplexStruct&, ComplexStruct&)> ComplexStructsCB;
    typedef Delegate<com_ptr<DummyClass>(DummyClass*, com_ptr<DummyClass>&, com_ptr<DummyClass>&)> ObjectsCB;
    typedef Delegate<NamedDelegate(const NamedDelegate&, NamedDelegate&, NamedDelegate&)> NamedDelegatesCB;
    typedef Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)> GenericDelegatesCB;
    typedef Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)> PrimitiveArraysCB;
    typedef Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)> StringArraysCB;
    typedef Delegate<Array<BlittableStruct>(Array<BlittableStruct>, Array<BlittableStruct>&, Array<BlittableStruct>&)> SimpleStructArraysCB;
    typedef Delegate<Array<ComplexStruct>(Array<ComplexStruct>, Array<ComplexStruct>&, Array<ComplexStruct>&)> ComplexStructArraysCB;
    typedef Delegate<Array<com_ptr<DummyClass>>(Array<com_ptr<DummyClass>>, Array<com_ptr<DummyClass>>&, Array<com_ptr<DummyClass>>&)> ObjectArraysCB;
    typedef Delegate<Array<NamedDelegate>(Array<NamedDelegate>, Array<NamedDelegate>&, Array<NamedDelegate>&)> NamedDelegateArraysCB;
    typedef Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)> GenericDelegateArraysCB;
    typedef Delegate<com_ptr<ITestClass>(int, int)> AddSomeShit;
}

MapStructABI(GluonTest::ComplexStruct, ::ABI::GluonTest::ComplexStruct)
MapStructABI(GluonTest::StructMemberTest, ::ABI::GluonTest::StructMemberTest)
MapStructABI(GluonTest::TestStruct, ::ABI::GluonTest::TestStruct)

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505f1f3-9de5-6ad8-85e0-c9137289ee7a") DW_6FD213D6 : public ComObject<DW_6FD213D6, Object>, public ABI::DelegateWrapperBase<DW_6FD213D6,
        int(int, int)>
    {
    public:
        DW_6FD213D6(const Delegate<int(int, int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, int arg1, int arg2, int* ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<int(int, int)>> : public ABIUtilForDelegates<int(int, int)>
    {
        typedef GluonTest::Details::DW_6FD213D6 DW_6FD213D6;

        static Delegate<int(int, int)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<int(int, int)>& x);
        static Delegate<int(int, int)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5b39e9f4-a4ea-3cde-e6c5-d3391fea8830") DW_F8ED26DB : public ComObject<DW_F8ED26DB, Object>, public ABI::DelegateWrapperBase<DW_F8ED26DB,
        int(string, string)>
    {
    public:
        DW_F8ED26DB(const Delegate<int(string, string)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* a, char* b, int* ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::NamedDelegate> : public ABIUtilForDelegates<int(string, string)>
    {
        typedef GluonTest::Details::DW_F8ED26DB DW_F8ED26DB;

        static GluonTest::NamedDelegate FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::NamedDelegate& x);
        static GluonTest::NamedDelegate FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("4f39f3f8-92c8-3cbb-e6c5-cd2a1be28500") DW_1B83CCC6 : public ComObject<DW_1B83CCC6, Object>, public ABI::DelegateWrapperBase<DW_1B83CCC6,
        double(bool, char&, int&)>
    {
    public:
        DW_1B83CCC6(const Delegate<double(bool, char&, int&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, bool inTest, char* outTest, int* refTest, double* ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::PrimitivesCB> : public ABIUtilForDelegates<double(bool, char&, int&)>
    {
        typedef GluonTest::Details::DW_1B83CCC6 DW_1B83CCC6;

        static GluonTest::PrimitivesCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::PrimitivesCB& x);
        static GluonTest::PrimitivesCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("3c1ec6e2-d08b-3cbb-e6c5-ce2c00e68213") DW_E24BCA44 : public ComObject<DW_E24BCA44, Object>, public ABI::DelegateWrapperBase<DW_E24BCA44,
        string(string, string&, string&)>
    {
    public:
        DW_E24BCA44(const Delegate<string(string, string&, string&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* inTest, char** outTest, char** refTest, char** ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::StringsCB> : public ABIUtilForDelegates<string(string, string&, string&)>
    {
        typedef GluonTest::Details::DW_E24BCA44 DW_E24BCA44;

        static GluonTest::StringsCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::StringsCB& x);
        static GluonTest::StringsCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("492ef1c2-a4e8-7fc8-a4c5-ce311fff8011") DW_CA433402 : public ComObject<DW_CA433402, Object>, public ABI::DelegateWrapperBase<DW_CA433402,
        GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>
    {
    public:
        DW_CA433402(const Delegate<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct inTest, ::ABI::GluonTest::BlittableStruct* outTest, ::ABI::GluonTest::BlittableStruct* refTest, ::ABI::GluonTest::BlittableStruct* ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::SimpleStructsCB> : public ABIUtilForDelegates<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>
    {
        typedef GluonTest::Details::DW_CA433402 DW_CA433402;

        static GluonTest::SimpleStructsCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::SimpleStructsCB& x);
        static GluonTest::SimpleStructsCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("4e28d6e9-b3fe-4fcf-a587-de371fff8011") DW_10105E22 : public ComObject<DW_10105E22, Object>, public ABI::DelegateWrapperBase<DW_10105E22,
        GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>
    {
    public:
        DW_10105E22(const Delegate<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct inTest, ::ABI::GluonTest::ComplexStruct* outTest, ::ABI::GluonTest::ComplexStruct* refTest, ::ABI::GluonTest::ComplexStruct* ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::ComplexStructsCB> : public ABIUtilForDelegates<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>
    {
        typedef GluonTest::Details::DW_10105E22 DW_10105E22;

        static GluonTest::ComplexStructsCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::ComplexStructsCB& x);
        static GluonTest::ComplexStructsCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("3c1ec6e2-d08b-3cbb-e6c5-d23a18ea8f00") DW_95E0837A : public ComObject<DW_95E0837A, Object>, public ABI::DelegateWrapperBase<DW_95E0837A,
        com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>
    {
    public:
        DW_95E0837A(const Delegate<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass* inTest, ::ABI::GluonTest::DummyClass** outTest, ::ABI::GluonTest::DummyClass** refTest, ::ABI::GluonTest::DummyClass** ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::ObjectsCB> : public ABIUtilForDelegates<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>
    {
        typedef GluonTest::Details::DW_95E0837A DW_95E0837A;

        static GluonTest::ObjectsCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::ObjectsCB& x);
        static GluonTest::ObjectsCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5b39e9f4-a4ea-4fde-a587-d3391fea8830") DW_F2E7AE0D : public ComObject<DW_F2E7AE0D, Object>, public ABI::DelegateWrapperBase<DW_F2E7AE0D,
        GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>
    {
    public:
        DW_F2E7AE0D(const Delegate<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::NamedDelegatesCB> : public ABIUtilForDelegates<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>
    {
        typedef GluonTest::Details::DW_F2E7AE0D DW_F2E7AE0D;

        static GluonTest::NamedDelegatesCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::NamedDelegatesCB& x);
        static GluonTest::NamedDelegatesCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5039c1f2-b7ee-48da-83b6-997f1cea9e1d") DW_D744D573 : public ComObject<DW_D744D573, Object>, public ABI::DelegateWrapperBase<DW_D744D573,
        Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>
    {
    public:
        DW_D744D573(const Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::GenericDelegatesCB> : public ABIUtilForDelegates<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>
    {
        typedef GluonTest::Details::DW_D744D573 DW_D744D573;

        static GluonTest::GenericDelegatesCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::GenericDelegatesCB& x);
        static GluonTest::GenericDelegatesCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1EB : public ComObject<DW_F757A1EB, Object>, public ABI::DelegateWrapperBase<DW_F757A1EB,
        int(int)>
    {
    public:
        DW_F757A1EB(const Delegate<int(int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, int arg, int* ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<int(int)>> : public ABIUtilForDelegates<int(int)>
    {
        typedef GluonTest::Details::DW_F757A1EB DW_F757A1EB;

        static Delegate<int(int)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<int(int)>& x);
        static Delegate<int(int)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5C0C3D4C : public ComObject<DW_5C0C3D4C, Object>, public ABI::DelegateWrapperBase<DW_5C0C3D4C,
        void(string)>
    {
    public:
        DW_5C0C3D4C(const Delegate<void(string)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* obj);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<void(string)>> : public ABIUtilForDelegates<void(string)>
    {
        typedef GluonTest::Details::DW_5C0C3D4C DW_5C0C3D4C;

        static Delegate<void(string)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<void(string)>& x);
        static Delegate<void(string)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5C0C3D4D : public ComObject<DW_5C0C3D4D, Object>, public ABI::DelegateWrapperBase<DW_5C0C3D4D,
        void(const Delegate<int(int)>&)>
    {
    public:
        DW_5C0C3D4D(const Delegate<void(const Delegate<int(int)>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,int,int*)> obj, IObject* obj_context);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<void(const Delegate<int(int)>&)>> : public ABIUtilForDelegates<void(const Delegate<int(int)>&)>
    {
        typedef GluonTest::Details::DW_5C0C3D4D DW_5C0C3D4D;

        static Delegate<void(const Delegate<int(int)>&)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<void(const Delegate<int(int)>&)>& x);
        static Delegate<void(const Delegate<int(int)>&)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1EC : public ComObject<DW_F757A1EC, Object>, public ABI::DelegateWrapperBase<DW_F757A1EC,
        Array<string>(Array<char>)>
    {
    public:
        DW_F757A1EC(const Delegate<Array<string>(Array<char>)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, int arg_count, char*** ___ret, int* ___ret_count);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<Array<string>(Array<char>)>> : public ABIUtilForDelegates<Array<string>(Array<char>)>
    {
        typedef GluonTest::Details::DW_F757A1EC DW_F757A1EC;

        static Delegate<Array<string>(Array<char>)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<Array<string>(Array<char>)>& x);
        static Delegate<Array<string>(Array<char>)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("7d39f3f8-a2f9-45da-9586-8f2a1be28500") DW_C30682FD : public ComObject<DW_C30682FD, Object>, public ABI::DelegateWrapperBase<DW_C30682FD,
        Array<double>(Array<bool>, Array<char>&, Array<int>&)>
    {
    public:
        DW_C30682FD(const Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, bool* inTest, int inTest_count, char** outTest, int* outTest_count, int** refTest, int* refTest_count, double** ___ret, int* ___ret_count);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::PrimitiveArraysCB> : public ABIUtilForDelegates<Array<double>(Array<bool>, Array<char>&, Array<int>&)>
    {
        typedef GluonTest::Details::DW_C30682FD DW_C30682FD;

        static GluonTest::PrimitiveArraysCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::PrimitiveArraysCB& x);
        static GluonTest::PrimitiveArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5d2ef7d0-a3f2-7ef8-e6c5-ce2c00e68213") DW_B2F37841 : public ComObject<DW_B2F37841, Object>, public ABI::DelegateWrapperBase<DW_B2F37841,
        Array<string>(Array<string>, Array<string>&, Array<string>&)>
    {
    public:
        DW_B2F37841(const Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char** inTest, int inTest_count, char*** outTest, int* outTest_count, char*** refTest, int* refTest_count, char*** ___ret, int* ___ret_count);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::StringArraysCB> : public ABIUtilForDelegates<Array<string>(Array<string>, Array<string>&, Array<string>&)>
    {
        typedef GluonTest::Details::DW_B2F37841 DW_B2F37841;

        static GluonTest::StringArraysCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::StringArraysCB& x);
        static GluonTest::StringArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("492ef1c2-a4e8-4efa-94a4-b7425cbd8011") DW_B28180A5 : public ComObject<DW_B28180A5, Object>, public ABI::DelegateWrapperBase<DW_B28180A5,
        Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>
    {
    public:
        DW_B28180A5(const Delegate<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct* inTest, int inTest_count, ::ABI::GluonTest::BlittableStruct** outTest, int* outTest_count, ::ABI::GluonTest::BlittableStruct** refTest, int* refTest_count, ::ABI::GluonTest::BlittableStruct** ___ret, int* ___ret_count);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::SimpleStructArraysCB> : public ABIUtilForDelegates<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>
    {
        typedef GluonTest::Details::DW_B28180A5 DW_B28180A5;

        static GluonTest::SimpleStructArraysCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::SimpleStructArraysCB& x);
        static GluonTest::SimpleStructArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("4e28d6e9-b3fe-7dcf-94b7-bf4e6cbcc211") DW_EE6D3DFB : public ComObject<DW_EE6D3DFB, Object>, public ABI::DelegateWrapperBase<DW_EE6D3DFB,
        Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>
    {
    public:
        DW_EE6D3DFB(const Delegate<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct* inTest, int inTest_count, ::ABI::GluonTest::ComplexStruct** outTest, int* outTest_count, ::ABI::GluonTest::ComplexStruct** refTest, int* refTest_count, ::ABI::GluonTest::ComplexStruct** ___ret, int* ___ret_count);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::ComplexStructArraysCB> : public ABIUtilForDelegates<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>
    {
        typedef GluonTest::Details::DW_EE6D3DFB DW_EE6D3DFB;

        static GluonTest::ComplexStructArraysCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::ComplexStructArraysCB& x);
        static GluonTest::ComplexStructArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5d2ef7d0-a3f2-7ef8-e6c5-d23a18ea8f00") DW_4388047D : public ComObject<DW_4388047D, Object>, public ABI::DelegateWrapperBase<DW_4388047D,
        Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>
    {
    public:
        DW_4388047D(const Delegate<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass** inTest, int inTest_count, ::ABI::GluonTest::DummyClass*** outTest, int* outTest_count, ::ABI::GluonTest::DummyClass*** refTest, int* refTest_count, ::ABI::GluonTest::DummyClass*** ___ret, int* ___ret_count);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::ObjectArraysCB> : public ABIUtilForDelegates<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>
    {
        typedef GluonTest::Details::DW_4388047D DW_4388047D;

        static GluonTest::ObjectArraysCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::ObjectArraysCB& x);
        static GluonTest::ObjectArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5b39e9f4-a4ea-7dde-94b7-b2406ca9ca30") DW_CCD79226 : public ComObject<DW_CCD79226, Object>, public ABI::DelegateWrapperBase<DW_CCD79226,
        Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>
    {
    public:
        DW_CCD79226(const Delegate<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::NamedDelegateArraysCB> : public ABIUtilForDelegates<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>
    {
        typedef GluonTest::Details::DW_CCD79226 DW_CCD79226;

        static GluonTest::NamedDelegateArraysCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::NamedDelegateArraysCB& x);
        static GluonTest::NamedDelegateArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5039c1b0-b7ee-48da-8384-a84f7d93ed5e") DW_F5BD3F9A : public ComObject<DW_F5BD3F9A, Object>, public ABI::DelegateWrapperBase<DW_F5BD3F9A,
        Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>
    {
    public:
        DW_F5BD3F9A(const Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::GenericDelegateArraysCB> : public ABIUtilForDelegates<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>
    {
        typedef GluonTest::Details::DW_F5BD3F9A DW_F5BD3F9A;

        static GluonTest::GenericDelegateArraysCB FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::GenericDelegateArraysCB& x);
        static GluonTest::GenericDelegateArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1ED : public ComObject<DW_F757A1ED, Object>, public ABI::DelegateWrapperBase<DW_F757A1ED,
        double(double)>
    {
    public:
        DW_F757A1ED(const Delegate<double(double)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, double arg, double* ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<double(double)>> : public ABIUtilForDelegates<double(double)>
    {
        typedef GluonTest::Details::DW_F757A1ED DW_F757A1ED;

        static Delegate<double(double)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<double(double)>& x);
        static Delegate<double(double)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1EE : public ComObject<DW_F757A1EE, Object>, public ABI::DelegateWrapperBase<DW_F757A1EE,
        string(Array<char>)>
    {
    public:
        DW_F757A1EE(const Delegate<string(Array<char>)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, int arg_count, char** ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<string(Array<char>)>> : public ABIUtilForDelegates<string(Array<char>)>
    {
        typedef GluonTest::Details::DW_F757A1EE DW_F757A1EE;

        static Delegate<string(Array<char>)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<string(Array<char>)>& x);
        static Delegate<string(Array<char>)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5534d6f4-d0ff-3cbb-e6c5-dc3c16dc8319") DW_FBC9C526 : public ComObject<DW_FBC9C526, Object>, public ABI::DelegateWrapperBase<DW_FBC9C526,
        com_ptr<GluonTest::ITestClass>(int, int)>
    {
    public:
        DW_FBC9C526(const Delegate<com_ptr<GluonTest::ITestClass>(int, int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, int a, int b, ::ABI::GluonTest::ITestClass** ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::AddSomeShit> : public ABIUtilForDelegates<com_ptr<GluonTest::ITestClass>(int, int)>
    {
        typedef GluonTest::Details::DW_FBC9C526 DW_FBC9C526;

        static GluonTest::AddSomeShit FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const GluonTest::AddSomeShit& x);
        static GluonTest::AddSomeShit FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505f1f3-9de5-6ad8-85e0-c9137289ee7a") DW_6FD213D7 : public ComObject<DW_6FD213D7, Object>, public ABI::DelegateWrapperBase<DW_6FD213D7,
        string(char, int)>
    {
    public:
        DW_6FD213D7(const Delegate<string(char, int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char arg1, int arg2, char** ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<string(char, int)>> : public ABIUtilForDelegates<string(char, int)>
    {
        typedef GluonTest::Details::DW_6FD213D7 DW_6FD213D7;

        static Delegate<string(char, int)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<string(char, int)>& x);
        static Delegate<string(char, int)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1EF : public ComObject<DW_F757A1EF, Object>, public ABI::DelegateWrapperBase<DW_F757A1EF,
        char(string)>
    {
    public:
        DW_F757A1EF(const Delegate<char(string)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, char* ___ret);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<char(string)>> : public ABIUtilForDelegates<char(string)>
    {
        typedef GluonTest::Details::DW_F757A1EF DW_F757A1EF;

        static Delegate<char(string)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<char(string)>& x);
        static Delegate<char(string)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5C0C3D4E : public ComObject<DW_5C0C3D4E, Object>, public ABI::DelegateWrapperBase<DW_5C0C3D4E,
        void(int)>
    {
    public:
        DW_5C0C3D4E(const Delegate<void(int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, int obj);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<void(int)>> : public ABIUtilForDelegates<void(int)>
    {
        typedef GluonTest::Details::DW_5C0C3D4E DW_5C0C3D4E;

        static Delegate<void(int)> FromABI(void* fptr, IObject* ctx);
        static ABI::DelegateBlob ToABI(const Delegate<void(int)>& x);
        static Delegate<void(int)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}
