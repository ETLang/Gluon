/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#pragma once
#define GLUON_BUILDING
#include "Public/GluonTest.public.abi.h"

namespace GluonTest
{
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

    class comid("5505f1f3-9de5-6ad8-85e0-c9137289ee7a") DW_827F05B1 : public ComObject<DW_827F05B1, Object>, public ABI::DelegateWrapperBase<DW_827F05B1,
        int(int, int)>
    {
    public:
        DW_827F05B1(const Delegate<int(int, int)>& d) : DBase(d) { }
        static Delegate<int(int, int)> Lookup(fn_ptr<HRESULT(IObject*,int,int,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, int arg1, int arg2, int* ___ret);
    };

    using namespace CS;

    class comid("5b39e9f4-a4ea-3cde-e6c5-d3391fea8830") DW_BD6C0A4D : public ComObject<DW_BD6C0A4D, Object>, public ABI::DelegateWrapperBase<DW_BD6C0A4D,
        int(string, string)>
    {
    public:
        DW_BD6C0A4D(const Delegate<int(string, string)>& d) : DBase(d) { }
        static Delegate<int(string, string)> Lookup(fn_ptr<HRESULT(IObject*,char*,char*,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* a, char* b, int* ___ret);
    };

    using namespace CS;

    class comid("4f39f3f8-92c8-3cbb-e6c5-cd2a1be28500") DW_67C6D6DF : public ComObject<DW_67C6D6DF, Object>, public ABI::DelegateWrapperBase<DW_67C6D6DF,
        double(bool, char&, int&)>
    {
    public:
        DW_67C6D6DF(const Delegate<double(bool, char&, int&)>& d) : DBase(d) { }
        static Delegate<double(bool, char&, int&)> Lookup(fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, bool inTest, char* outTest, int* refTest, double* ___ret);
    };

    using namespace CS;

    class comid("3c1ec6e2-d08b-3cbb-e6c5-ce2c00e68213") DW_7A2B6D2B : public ComObject<DW_7A2B6D2B, Object>, public ABI::DelegateWrapperBase<DW_7A2B6D2B,
        string(string, string&, string&)>
    {
    public:
        DW_7A2B6D2B(const Delegate<string(string, string&, string&)>& d) : DBase(d) { }
        static Delegate<string(string, string&, string&)> Lookup(fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* inTest, char** outTest, char** refTest, char** ___ret);
    };

    using namespace CS;

    class comid("492ef1c2-a4e8-7fc8-a4c5-ce311fff8011") DW_DF8B3B28 : public ComObject<DW_DF8B3B28, Object>, public ABI::DelegateWrapperBase<DW_DF8B3B28,
        GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>
    {
    public:
        DW_DF8B3B28(const Delegate<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>& d) : DBase(d) { }
        static Delegate<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)> Lookup(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct inTest, ::ABI::GluonTest::BlittableStruct* outTest, ::ABI::GluonTest::BlittableStruct* refTest, ::ABI::GluonTest::BlittableStruct* ___ret);
    };

    using namespace CS;

    class comid("4e28d6e9-b3fe-4fcf-a587-de371fff8011") DW_625CB5E : public ComObject<DW_625CB5E, Object>, public ABI::DelegateWrapperBase<DW_625CB5E,
        GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>
    {
    public:
        DW_625CB5E(const Delegate<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>& d) : DBase(d) { }
        static Delegate<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)> Lookup(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct inTest, ::ABI::GluonTest::ComplexStruct* outTest, ::ABI::GluonTest::ComplexStruct* refTest, ::ABI::GluonTest::ComplexStruct* ___ret);
    };

    using namespace CS;

    class comid("3c1ec6e2-d08b-3cbb-e6c5-d23a18ea8f00") DW_87064FFA : public ComObject<DW_87064FFA, Object>, public ABI::DelegateWrapperBase<DW_87064FFA,
        com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>
    {
    public:
        DW_87064FFA(const Delegate<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)>& d) : DBase(d) { }
        static Delegate<com_ptr<GluonTest::DummyClass>(GluonTest::DummyClass*, com_ptr<GluonTest::DummyClass>&, com_ptr<GluonTest::DummyClass>&)> Lookup(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass* inTest, ::ABI::GluonTest::DummyClass** outTest, ::ABI::GluonTest::DummyClass** refTest, ::ABI::GluonTest::DummyClass** ___ret);
    };

    using namespace CS;

    class comid("5b39e9f4-a4ea-4fde-a587-d3391fea8830") DW_7451AE96 : public ComObject<DW_7451AE96, Object>, public ABI::DelegateWrapperBase<DW_7451AE96,
        GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>
    {
    public:
        DW_7451AE96(const Delegate<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>& d) : DBase(d) { }
        static Delegate<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)> Lookup(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context);
    };

    using namespace CS;

    class comid("5039c1f2-b7ee-48da-83b6-997f1cea9e1d") DW_61217487 : public ComObject<DW_61217487, Object>, public ABI::DelegateWrapperBase<DW_61217487,
        Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>
    {
    public:
        DW_61217487(const Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>& d) : DBase(d) { }
        static Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)> Lookup(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context);
    };

    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_2945414A : public ComObject<DW_2945414A, Object>, public ABI::DelegateWrapperBase<DW_2945414A,
        int(int)>
    {
    public:
        DW_2945414A(const Delegate<int(int)>& d) : DBase(d) { }
        static Delegate<int(int)> Lookup(fn_ptr<HRESULT(IObject*,int,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, int arg, int* ___ret);
    };

    using namespace CS;

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5D02415A : public ComObject<DW_5D02415A, Object>, public ABI::DelegateWrapperBase<DW_5D02415A,
        void(string)>
    {
    public:
        DW_5D02415A(const Delegate<void(string)>& d) : DBase(d) { }
        static Delegate<void(string)> Lookup(fn_ptr<HRESULT(IObject*,char*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* obj);
    };

    using namespace CS;

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5D02415B : public ComObject<DW_5D02415B, Object>, public ABI::DelegateWrapperBase<DW_5D02415B,
        void(const Delegate<int(int)>&)>
    {
    public:
        DW_5D02415B(const Delegate<void(const Delegate<int(int)>&)>& d) : DBase(d) { }
        static Delegate<void(const Delegate<int(int)>&)> Lookup(fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,int,int*)> obj, IObject* obj_context);
    };

    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_2945414B : public ComObject<DW_2945414B, Object>, public ABI::DelegateWrapperBase<DW_2945414B,
        Array<string>(Array<char>)>
    {
    public:
        DW_2945414B(const Delegate<Array<string>(Array<char>)>& d) : DBase(d) { }
        static Delegate<Array<string>(Array<char>)> Lookup(fn_ptr<HRESULT(IObject*,char*,int,char***,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, int arg_count, char*** ___ret, int* ___ret_count);
    };

    using namespace CS;

    class comid("7d39f3f8-a2f9-45da-9586-8f2a1be28500") DW_2C74C8B4 : public ComObject<DW_2C74C8B4, Object>, public ABI::DelegateWrapperBase<DW_2C74C8B4,
        Array<double>(Array<bool>, Array<char>&, Array<int>&)>
    {
    public:
        DW_2C74C8B4(const Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)>& d) : DBase(d) { }
        static Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)> Lookup(fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, bool* inTest, int inTest_count, char** outTest, int* outTest_count, int** refTest, int* refTest_count, double** ___ret, int* ___ret_count);
    };

    using namespace CS;

    class comid("5d2ef7d0-a3f2-7ef8-e6c5-ce2c00e68213") DW_1061E859 : public ComObject<DW_1061E859, Object>, public ABI::DelegateWrapperBase<DW_1061E859,
        Array<string>(Array<string>, Array<string>&, Array<string>&)>
    {
    public:
        DW_1061E859(const Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)>& d) : DBase(d) { }
        static Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)> Lookup(fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, char** inTest, int inTest_count, char*** outTest, int* outTest_count, char*** refTest, int* refTest_count, char*** ___ret, int* ___ret_count);
    };

    using namespace CS;

    class comid("492ef1c2-a4e8-4efa-94a4-b7425cbd8011") DW_1C12DC57 : public ComObject<DW_1C12DC57, Object>, public ABI::DelegateWrapperBase<DW_1C12DC57,
        Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>
    {
    public:
        DW_1C12DC57(const Delegate<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>& d) : DBase(d) { }
        static Delegate<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)> Lookup(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct* inTest, int inTest_count, ::ABI::GluonTest::BlittableStruct** outTest, int* outTest_count, ::ABI::GluonTest::BlittableStruct** refTest, int* refTest_count, ::ABI::GluonTest::BlittableStruct** ___ret, int* ___ret_count);
    };

    using namespace CS;

    class comid("4e28d6e9-b3fe-7dcf-94b7-bf4e6cbcc211") DW_14F875F7 : public ComObject<DW_14F875F7, Object>, public ABI::DelegateWrapperBase<DW_14F875F7,
        Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>
    {
    public:
        DW_14F875F7(const Delegate<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>& d) : DBase(d) { }
        static Delegate<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)> Lookup(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct* inTest, int inTest_count, ::ABI::GluonTest::ComplexStruct** outTest, int* outTest_count, ::ABI::GluonTest::ComplexStruct** refTest, int* refTest_count, ::ABI::GluonTest::ComplexStruct** ___ret, int* ___ret_count);
    };

    using namespace CS;

    class comid("5d2ef7d0-a3f2-7ef8-e6c5-d23a18ea8f00") DW_A1A08E73 : public ComObject<DW_A1A08E73, Object>, public ABI::DelegateWrapperBase<DW_A1A08E73,
        Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>
    {
    public:
        DW_A1A08E73(const Delegate<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)>& d) : DBase(d) { }
        static Delegate<Array<com_ptr<GluonTest::DummyClass>>(Array<com_ptr<GluonTest::DummyClass>>, Array<com_ptr<GluonTest::DummyClass>>&, Array<com_ptr<GluonTest::DummyClass>>&)> Lookup(fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass** inTest, int inTest_count, ::ABI::GluonTest::DummyClass*** outTest, int* outTest_count, ::ABI::GluonTest::DummyClass*** refTest, int* refTest_count, ::ABI::GluonTest::DummyClass*** ___ret, int* ___ret_count);
    };

    using namespace CS;

    class comid("5b39e9f4-a4ea-7dde-94b7-b2406ca9ca30") DW_B2A7C511 : public ComObject<DW_B2A7C511, Object>, public ABI::DelegateWrapperBase<DW_B2A7C511,
        Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>
    {
    public:
        DW_B2A7C511(const Delegate<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>& d) : DBase(d) { }
        static Delegate<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)> Lookup(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
    };

    using namespace CS;

    class comid("5039c1b0-b7ee-48da-8384-a84f7d93ed5e") DW_DC21B22B : public ComObject<DW_DC21B22B, Object>, public ABI::DelegateWrapperBase<DW_DC21B22B,
        Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>
    {
    public:
        DW_DC21B22B(const Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>& d) : DBase(d) { }
        static Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)> Lookup(fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
    };

    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_2945414C : public ComObject<DW_2945414C, Object>, public ABI::DelegateWrapperBase<DW_2945414C,
        double(double)>
    {
    public:
        DW_2945414C(const Delegate<double(double)>& d) : DBase(d) { }
        static Delegate<double(double)> Lookup(fn_ptr<HRESULT(IObject*,double,double*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, double arg, double* ___ret);
    };

    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_2945414D : public ComObject<DW_2945414D, Object>, public ABI::DelegateWrapperBase<DW_2945414D,
        string(Array<char>)>
    {
    public:
        DW_2945414D(const Delegate<string(Array<char>)>& d) : DBase(d) { }
        static Delegate<string(Array<char>)> Lookup(fn_ptr<HRESULT(IObject*,char*,int,char**)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, int arg_count, char** ___ret);
    };

    using namespace CS;

    class comid("5534d6f4-d0ff-3cbb-e6c5-dc3c16dc8319") DW_668509AD : public ComObject<DW_668509AD, Object>, public ABI::DelegateWrapperBase<DW_668509AD,
        com_ptr<GluonTest::ITestClass>(int, int)>
    {
    public:
        DW_668509AD(const Delegate<com_ptr<GluonTest::ITestClass>(int, int)>& d) : DBase(d) { }
        static Delegate<com_ptr<GluonTest::ITestClass>(int, int)> Lookup(fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, int a, int b, ::ABI::GluonTest::ITestClass** ___ret);
    };

    using namespace CS;

    class comid("5505f1f3-9de5-6ad8-85e0-c9137289ee7a") DW_827F05B2 : public ComObject<DW_827F05B2, Object>, public ABI::DelegateWrapperBase<DW_827F05B2,
        string(char, int)>
    {
    public:
        DW_827F05B2(const Delegate<string(char, int)>& d) : DBase(d) { }
        static Delegate<string(char, int)> Lookup(fn_ptr<HRESULT(IObject*,char,int,char**)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, char arg1, int arg2, char** ___ret);
    };

    using namespace CS;

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_2945414E : public ComObject<DW_2945414E, Object>, public ABI::DelegateWrapperBase<DW_2945414E,
        char(string)>
    {
    public:
        DW_2945414E(const Delegate<char(string)>& d) : DBase(d) { }
        static Delegate<char(string)> Lookup(fn_ptr<HRESULT(IObject*,char*,char*)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, char* ___ret);
    };

    using namespace CS;

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5D02415C : public ComObject<DW_5D02415C, Object>, public ABI::DelegateWrapperBase<DW_5D02415C,
        void(int)>
    {
    public:
        DW_5D02415C(const Delegate<void(int)>& d) : DBase(d) { }
        static Delegate<void(int)> Lookup(fn_ptr<HRESULT(IObject*,int)> fptr, IObject* ctx);
        static HRESULT __stdcall AbiFunc(IObject* __i_, int obj);
    };
}
