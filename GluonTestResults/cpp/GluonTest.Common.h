/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#pragma once
#define GLUON_BUILDING
#include "Public/GluonTest.h"

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
