/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

// clang-format off

#pragma once
#include "GluonTest.public.abi.h"

namespace GluonTest
{
    using namespace GluonInternal;

    struct BlittableStruct;
    struct ComplexStruct;
    struct StructMemberTest;
    struct TestStruct;
    class _P_DummyClass;
    typedef comid("4f2fe4fd-d08b-3cbb-e6c5-d92d1fe29537") ::ABI::PimplPtr<_P_DummyClass> DummyClass;

    class _P_ConversionUnitTest;
    typedef comid("5233ece2-bede-48d2-b2a0-ad431cf98906") ::ABI::PimplPtr<_P_ConversionUnitTest> ConversionUnitTest;

    class _P_ITestClass;
    typedef comid("4f2fe4fd-d08b-3cbb-e6c5-d40c17fc9837") ::ABI::PimplPtr<_P_ITestClass> ITestClass;

    class _P_Generator;
    typedef comid("3c2eeae5-d08b-3cbb-e6c5-da3d1cea9e15") ::ABI::PimplPtr<_P_Generator> Generator;

    class _P_SignalBuffer;
    typedef comid("5a3af0d3-a2ee-3cbb-e6c5-ce3115e18d18") ::ABI::PimplPtr<_P_SignalBuffer> SignalBuffer;

    class _P_Waveform;
    typedef comid("3c5ce8e3-d08b-3cbb-e6c5-ca3904ea8a1b") ::ABI::PimplPtr<_P_Waveform> Waveform;

    class _P_SinusoidalWaveform;
    typedef comid("503de1f8-b1dc-59cd-80aa-bc5c1cfa9f1b") ::ABI::PimplPtr<_P_SinusoidalWaveform> SinusoidalWaveform;

    class _P_SquareWaveform;
    typedef comid("592ae4c6-bfed-51c9-e6c5-ce2907ee9e11") ::ABI::PimplPtr<_P_SquareWaveform> SquareWaveform;

    class _P_TriangleWaveform;
    typedef comid("5d0be0fd-b5fd-53dd-94a8-c92a1bee8213") ::ABI::PimplPtr<_P_TriangleWaveform> TriangleWaveform;

    class _P_SawtoothRightWaveform;
    typedef comid("550eede5-b8ec-6bcf-87b3-ab5f6a89ee1b") ::ABI::PimplPtr<_P_SawtoothRightWaveform> SawtoothRightWaveform;

    class _P_SawtoothLeftWaveform;
    typedef comid("5910ede5-a4ed-5dec-90a0-a8567796831b") ::ABI::PimplPtr<_P_SawtoothLeftWaveform> SawtoothLeftWaveform;

    class _P_GTone;
    typedef comid("3c5c8591-d08b-3cbb-e6c5-da0c1de18974") ::ABI::PimplPtr<_P_GTone> GTone;

    class _P_GWhiteNoise;
    typedef comid("4f35eadf-d0ee-3cbb-e6c5-da0f1ae69811") ::ABI::PimplPtr<_P_GWhiteNoise> GWhiteNoise;

    class _P_NoiseEngine;
    typedef comid("5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931") ::ABI::PimplPtr<_P_NoiseEngine> NoiseEngine;
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
        DummyClass Obj;
        Delegate<int(int, int)> Del;

        ComplexStruct() { }
        ComplexStruct(string _Name, const BlittableStruct& _Sub, const DummyClass& _Obj, const Delegate<int(int, int)>& _Del) : 
            Name(_Name), Sub(_Sub), Obj(_Obj), Del(_Del)
        { }
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::ComplexStruct>;
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
        DummyClass Object;
        NamedDelegate_t NamedDelegate;
        Delegate<double(double)> GenericDelegate;

        StructMemberTest() { }
        StructMemberTest(bool _Boolean, double _Primitive, void* _PrimitivePtr, string _String, const BlittableStruct& _BlittableSt, const ComplexStruct& _ComplexSt, const DummyClass& _Object, const NamedDelegate_t& _NamedDelegate, const Delegate<double(double)>& _GenericDelegate) : 
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
    typedef Delegate<DummyClass(const DummyClass&, DummyClass&, DummyClass&)> ObjectsCB;
    typedef Delegate<NamedDelegate(const NamedDelegate&, NamedDelegate&, NamedDelegate&)> NamedDelegatesCB;
    typedef Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)> GenericDelegatesCB;
    typedef Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)> PrimitiveArraysCB;
    typedef Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)> StringArraysCB;
    typedef Delegate<Array<BlittableStruct>(Array<BlittableStruct>, Array<BlittableStruct>&, Array<BlittableStruct>&)> SimpleStructArraysCB;
    typedef Delegate<Array<ComplexStruct>(Array<ComplexStruct>, Array<ComplexStruct>&, Array<ComplexStruct>&)> ComplexStructArraysCB;
    typedef Delegate<Array<DummyClass>(Array<DummyClass>, Array<DummyClass>&, Array<DummyClass>&)> ObjectArraysCB;
    typedef Delegate<Array<NamedDelegate>(Array<NamedDelegate>, Array<NamedDelegate>&, Array<NamedDelegate>&)> NamedDelegateArraysCB;
    typedef Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)> GenericDelegateArraysCB;
    typedef Delegate<ITestClass(int, int)> AddSomeShit;
}

namespace GluonTest
{
    class _P_DummyClass : public ABI::Wrapper
    {
        template<typename> friend DummyClass CreateDummyClass();
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_DummyClass, ::ABI::GluonTest::DummyClass)
    public:
        PROPERTY(string, Nugget);
        string GetNugget() const
        {
            return __P_GetNugget();
        }

        void SetNugget(string value) const
        {
            __P_SetNugget(value);
        }

    private:
#ifndef __INTELLISENSE__
        template<typename = void>
        static DummyClass __P_Create();

        template<typename = void>
        string __P_GetNugget() const;

        template<typename = void>
        void __P_SetNugget(string value) const;

#endif

    };

    template<typename = void>
    DummyClass CreateDummyClass()
    {
        return _P_DummyClass::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::DummyClass, "4f2fe4fd-d08b-3cbb-e6c5-d92d1fe29537")

namespace GluonTest
{
    class _P_ConversionUnitTest : public ABI::Wrapper
    {
        template<typename> friend ConversionUnitTest CreateConversionUnitTest();
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_ConversionUnitTest, ::ABI::GluonTest::ConversionUnitTest)
        using PrimitivesCB_t = PrimitivesCB;
        using StringsCB_t = StringsCB;
        using SimpleStructsCB_t = SimpleStructsCB;
        using ComplexStructsCB_t = ComplexStructsCB;
        using ObjectsCB_t = ObjectsCB;
        using NamedDelegatesCB_t = NamedDelegatesCB;
        using GenericDelegatesCB_t = GenericDelegatesCB;
        using PrimitiveArraysCB_t = PrimitiveArraysCB;
        using StringArraysCB_t = StringArraysCB;
        using SimpleStructArraysCB_t = SimpleStructArraysCB;
        using ComplexStructArraysCB_t = ComplexStructArraysCB;
        using ObjectArraysCB_t = ObjectArraysCB;
        using NamedDelegateArraysCB_t = NamedDelegateArraysCB;
        using GenericDelegateArraysCB_t = GenericDelegateArraysCB;

    public:
        PROPERTY(PrimitivesCB_t, PrimitivesCB);
        PrimitivesCB_t GetPrimitivesCB() const
        {
            return __P_GetPrimitivesCB();
        }

        void SetPrimitivesCB(const PrimitivesCB_t& value) const
        {
            __P_SetPrimitivesCB(value);
        }

        PROPERTY(StringsCB_t, StringsCB);
        StringsCB_t GetStringsCB() const
        {
            return __P_GetStringsCB();
        }

        void SetStringsCB(const StringsCB_t& value) const
        {
            __P_SetStringsCB(value);
        }

        PROPERTY(SimpleStructsCB_t, SimpleStructsCB);
        SimpleStructsCB_t GetSimpleStructsCB() const
        {
            return __P_GetSimpleStructsCB();
        }

        void SetSimpleStructsCB(const SimpleStructsCB_t& value) const
        {
            __P_SetSimpleStructsCB(value);
        }

        PROPERTY(ComplexStructsCB_t, ComplexStructsCB);
        ComplexStructsCB_t GetComplexStructsCB() const
        {
            return __P_GetComplexStructsCB();
        }

        void SetComplexStructsCB(const ComplexStructsCB_t& value) const
        {
            __P_SetComplexStructsCB(value);
        }

        PROPERTY(ObjectsCB_t, ObjectsCB);
        ObjectsCB_t GetObjectsCB() const
        {
            return __P_GetObjectsCB();
        }

        void SetObjectsCB(const ObjectsCB_t& value) const
        {
            __P_SetObjectsCB(value);
        }

        PROPERTY(NamedDelegatesCB_t, NamedDelegatesCB);
        NamedDelegatesCB_t GetNamedDelegatesCB() const
        {
            return __P_GetNamedDelegatesCB();
        }

        void SetNamedDelegatesCB(const NamedDelegatesCB_t& value) const
        {
            __P_SetNamedDelegatesCB(value);
        }

        PROPERTY(GenericDelegatesCB_t, GenericDelegatesCB);
        GenericDelegatesCB_t GetGenericDelegatesCB() const
        {
            return __P_GetGenericDelegatesCB();
        }

        void SetGenericDelegatesCB(const GenericDelegatesCB_t& value) const
        {
            __P_SetGenericDelegatesCB(value);
        }

        PROPERTY(PrimitiveArraysCB_t, PrimitiveArraysCB);
        PrimitiveArraysCB_t GetPrimitiveArraysCB() const
        {
            return __P_GetPrimitiveArraysCB();
        }

        void SetPrimitiveArraysCB(const PrimitiveArraysCB_t& value) const
        {
            __P_SetPrimitiveArraysCB(value);
        }

        PROPERTY(StringArraysCB_t, StringArraysCB);
        StringArraysCB_t GetStringArraysCB() const
        {
            return __P_GetStringArraysCB();
        }

        void SetStringArraysCB(const StringArraysCB_t& value) const
        {
            __P_SetStringArraysCB(value);
        }

        PROPERTY(SimpleStructArraysCB_t, SimpleStructArraysCB);
        SimpleStructArraysCB_t GetSimpleStructArraysCB() const
        {
            return __P_GetSimpleStructArraysCB();
        }

        void SetSimpleStructArraysCB(const SimpleStructArraysCB_t& value) const
        {
            __P_SetSimpleStructArraysCB(value);
        }

        PROPERTY(ComplexStructArraysCB_t, ComplexStructArraysCB);
        ComplexStructArraysCB_t GetComplexStructArraysCB() const
        {
            return __P_GetComplexStructArraysCB();
        }

        void SetComplexStructArraysCB(const ComplexStructArraysCB_t& value) const
        {
            __P_SetComplexStructArraysCB(value);
        }

        PROPERTY(ObjectArraysCB_t, ObjectArraysCB);
        ObjectArraysCB_t GetObjectArraysCB() const
        {
            return __P_GetObjectArraysCB();
        }

        void SetObjectArraysCB(const ObjectArraysCB_t& value) const
        {
            __P_SetObjectArraysCB(value);
        }

        PROPERTY(NamedDelegateArraysCB_t, NamedDelegateArraysCB);
        NamedDelegateArraysCB_t GetNamedDelegateArraysCB() const
        {
            return __P_GetNamedDelegateArraysCB();
        }

        void SetNamedDelegateArraysCB(const NamedDelegateArraysCB_t& value) const
        {
            __P_SetNamedDelegateArraysCB(value);
        }

        PROPERTY(GenericDelegateArraysCB_t, GenericDelegateArraysCB);
        GenericDelegateArraysCB_t GetGenericDelegateArraysCB() const
        {
            return __P_GetGenericDelegateArraysCB();
        }

        void SetGenericDelegateArraysCB(const GenericDelegateArraysCB_t& value) const
        {
            __P_SetGenericDelegateArraysCB(value);
        }

        PROPERTY(StructMemberTest, StructMembers);
        StructMemberTest GetStructMembers() const
        {
            return __P_GetStructMembers();
        }

        void SetStructMembers(const StructMemberTest& value) const
        {
            __P_SetStructMembers(value);
        }

        double Primitives(bool inTest, char& outOutTest, int& inoutRefTest) const
        {
            return __P_Primitives(inTest, outOutTest, inoutRefTest);
        }

        string Strings(string inTest, string& outOutTest, string& inoutRefTest) const
        {
            return __P_Strings(inTest, outOutTest, inoutRefTest);
        }

        BlittableStruct SimpleStructs(const BlittableStruct& inTest, BlittableStruct& outOutTest, BlittableStruct& inoutRefTest) const
        {
            return __P_SimpleStructs(inTest, outOutTest, inoutRefTest);
        }

        ComplexStruct ComplexStructs(const ComplexStruct& inTest, ComplexStruct& outOutTest, ComplexStruct& inoutRefTest) const
        {
            return __P_ComplexStructs(inTest, outOutTest, inoutRefTest);
        }

        DummyClass Objects(const DummyClass& inTest, DummyClass& outOutTest, DummyClass& inoutRefTest) const
        {
            return __P_Objects(inTest, outOutTest, inoutRefTest);
        }

        NamedDelegate NamedDelegates(const NamedDelegate& inTest, NamedDelegate& outOutTest, NamedDelegate& inoutRefTest) const
        {
            return __P_NamedDelegates(inTest, outOutTest, inoutRefTest);
        }

        Delegate<int(int)> GenericDelegates(const Delegate<void(string)>& inTest, Delegate<void(const Delegate<int(int)>&)>& outOutTest, Delegate<string(Array<char>)>& inoutRefTest) const
        {
            return __P_GenericDelegates(inTest, outOutTest, inoutRefTest);
        }

        Array<double> PrimitiveArrays(Array<bool> inTest, Array<char>& outOutTest, Array<int>& inoutRefTest) const
        {
            return __P_PrimitiveArrays(inTest, outOutTest, inoutRefTest);
        }

        Array<string> StringArrays(Array<string> inTest, Array<string>& outOutTest, Array<string>& inoutRefTest) const
        {
            return __P_StringArrays(inTest, outOutTest, inoutRefTest);
        }

        Array<BlittableStruct> SimpleStructArrays(Array<BlittableStruct> inTest, Array<BlittableStruct>& outOutTest, Array<BlittableStruct>& inoutRefTest) const
        {
            return __P_SimpleStructArrays(inTest, outOutTest, inoutRefTest);
        }

        Array<ComplexStruct> ComplexStructArrays(Array<ComplexStruct> inTest, Array<ComplexStruct>& outOutTest, Array<ComplexStruct>& inoutRefTest) const
        {
            return __P_ComplexStructArrays(inTest, outOutTest, inoutRefTest);
        }

        Array<DummyClass> ObjectArrays(Array<DummyClass> inTest, Array<DummyClass>& outOutTest, Array<DummyClass>& inoutRefTest) const
        {
            return __P_ObjectArrays(inTest, outOutTest, inoutRefTest);
        }

        Array<NamedDelegate> NamedDelegateArrays(Array<NamedDelegate> inTest, Array<NamedDelegate>& outOutTest, Array<NamedDelegate>& inoutRefTest) const
        {
            return __P_NamedDelegateArrays(inTest, outOutTest, inoutRefTest);
        }

        Array<Delegate<int(int)>> GenericDelegateArrays(Array<Delegate<void(string)>> inTest, Array<Delegate<void(const Delegate<int(int)>&)>>& outOutTest, Array<Delegate<string(Array<char>)>>& inoutRefTest) const
        {
            return __P_GenericDelegateArrays(inTest, outOutTest, inoutRefTest);
        }

        void ExCheckNullReference() const
        {
            __P_ExCheckNullReference();
        }

        void ExCheckArgumentNull() const
        {
            __P_ExCheckArgumentNull();
        }

        void ExCheckArgument() const
        {
            __P_ExCheckArgument();
        }

        void ExCheckInvalidOperation() const
        {
            __P_ExCheckInvalidOperation();
        }

        void ExCheckAccessDenied() const
        {
            __P_ExCheckAccessDenied();
        }

        void ExCheckGeneric() const
        {
            __P_ExCheckGeneric();
        }

        void ExCheckGenericStd() const
        {
            __P_ExCheckGenericStd();
        }

        void ExCheckNotImplemented() const
        {
            __P_ExCheckNotImplemented();
        }

    private:
#ifndef __INTELLISENSE__
        template<typename = void>
        static ConversionUnitTest __P_Create();

        template<typename = void>
        double __P_Primitives(bool inTest, char& outOutTest, int& inoutRefTest) const;

        template<typename = void>
        string __P_Strings(string inTest, string& outOutTest, string& inoutRefTest) const;

        template<typename = void>
        BlittableStruct __P_SimpleStructs(const BlittableStruct& inTest, BlittableStruct& outOutTest, BlittableStruct& inoutRefTest) const;

        template<typename = void>
        ComplexStruct __P_ComplexStructs(const ComplexStruct& inTest, ComplexStruct& outOutTest, ComplexStruct& inoutRefTest) const;

        template<typename = void>
        DummyClass __P_Objects(const DummyClass& inTest, DummyClass& outOutTest, DummyClass& inoutRefTest) const;

        template<typename = void>
        NamedDelegate __P_NamedDelegates(const NamedDelegate& inTest, NamedDelegate& outOutTest, NamedDelegate& inoutRefTest) const;

        template<typename = void>
        Delegate<int(int)> __P_GenericDelegates(const Delegate<void(string)>& inTest, Delegate<void(const Delegate<int(int)>&)>& outOutTest, Delegate<string(Array<char>)>& inoutRefTest) const;

        template<typename = void>
        Array<double> __P_PrimitiveArrays(Array<bool> inTest, Array<char>& outOutTest, Array<int>& inoutRefTest) const;

        template<typename = void>
        Array<string> __P_StringArrays(Array<string> inTest, Array<string>& outOutTest, Array<string>& inoutRefTest) const;

        template<typename = void>
        Array<BlittableStruct> __P_SimpleStructArrays(Array<BlittableStruct> inTest, Array<BlittableStruct>& outOutTest, Array<BlittableStruct>& inoutRefTest) const;

        template<typename = void>
        Array<ComplexStruct> __P_ComplexStructArrays(Array<ComplexStruct> inTest, Array<ComplexStruct>& outOutTest, Array<ComplexStruct>& inoutRefTest) const;

        template<typename = void>
        Array<DummyClass> __P_ObjectArrays(Array<DummyClass> inTest, Array<DummyClass>& outOutTest, Array<DummyClass>& inoutRefTest) const;

        template<typename = void>
        Array<NamedDelegate> __P_NamedDelegateArrays(Array<NamedDelegate> inTest, Array<NamedDelegate>& outOutTest, Array<NamedDelegate>& inoutRefTest) const;

        template<typename = void>
        Array<Delegate<int(int)>> __P_GenericDelegateArrays(Array<Delegate<void(string)>> inTest, Array<Delegate<void(const Delegate<int(int)>&)>>& outOutTest, Array<Delegate<string(Array<char>)>>& inoutRefTest) const;

        template<typename = void>
        void __P_ExCheckNullReference() const;

        template<typename = void>
        void __P_ExCheckArgumentNull() const;

        template<typename = void>
        void __P_ExCheckArgument() const;

        template<typename = void>
        void __P_ExCheckInvalidOperation() const;

        template<typename = void>
        void __P_ExCheckAccessDenied() const;

        template<typename = void>
        void __P_ExCheckGeneric() const;

        template<typename = void>
        void __P_ExCheckGenericStd() const;

        template<typename = void>
        void __P_ExCheckNotImplemented() const;

        template<typename = void>
        PrimitivesCB_t __P_GetPrimitivesCB() const;

        template<typename = void>
        StringsCB_t __P_GetStringsCB() const;

        template<typename = void>
        SimpleStructsCB_t __P_GetSimpleStructsCB() const;

        template<typename = void>
        ComplexStructsCB_t __P_GetComplexStructsCB() const;

        template<typename = void>
        ObjectsCB_t __P_GetObjectsCB() const;

        template<typename = void>
        NamedDelegatesCB_t __P_GetNamedDelegatesCB() const;

        template<typename = void>
        GenericDelegatesCB_t __P_GetGenericDelegatesCB() const;

        template<typename = void>
        PrimitiveArraysCB_t __P_GetPrimitiveArraysCB() const;

        template<typename = void>
        StringArraysCB_t __P_GetStringArraysCB() const;

        template<typename = void>
        SimpleStructArraysCB_t __P_GetSimpleStructArraysCB() const;

        template<typename = void>
        ComplexStructArraysCB_t __P_GetComplexStructArraysCB() const;

        template<typename = void>
        ObjectArraysCB_t __P_GetObjectArraysCB() const;

        template<typename = void>
        NamedDelegateArraysCB_t __P_GetNamedDelegateArraysCB() const;

        template<typename = void>
        GenericDelegateArraysCB_t __P_GetGenericDelegateArraysCB() const;

        template<typename = void>
        StructMemberTest __P_GetStructMembers() const;

        template<typename = void>
        void __P_SetPrimitivesCB(const PrimitivesCB_t& value) const;

        template<typename = void>
        void __P_SetStringsCB(const StringsCB_t& value) const;

        template<typename = void>
        void __P_SetSimpleStructsCB(const SimpleStructsCB_t& value) const;

        template<typename = void>
        void __P_SetComplexStructsCB(const ComplexStructsCB_t& value) const;

        template<typename = void>
        void __P_SetObjectsCB(const ObjectsCB_t& value) const;

        template<typename = void>
        void __P_SetNamedDelegatesCB(const NamedDelegatesCB_t& value) const;

        template<typename = void>
        void __P_SetGenericDelegatesCB(const GenericDelegatesCB_t& value) const;

        template<typename = void>
        void __P_SetPrimitiveArraysCB(const PrimitiveArraysCB_t& value) const;

        template<typename = void>
        void __P_SetStringArraysCB(const StringArraysCB_t& value) const;

        template<typename = void>
        void __P_SetSimpleStructArraysCB(const SimpleStructArraysCB_t& value) const;

        template<typename = void>
        void __P_SetComplexStructArraysCB(const ComplexStructArraysCB_t& value) const;

        template<typename = void>
        void __P_SetObjectArraysCB(const ObjectArraysCB_t& value) const;

        template<typename = void>
        void __P_SetNamedDelegateArraysCB(const NamedDelegateArraysCB_t& value) const;

        template<typename = void>
        void __P_SetGenericDelegateArraysCB(const GenericDelegateArraysCB_t& value) const;

        template<typename = void>
        void __P_SetStructMembers(const StructMemberTest& value) const;

#endif

    };

    template<typename = void>
    ConversionUnitTest CreateConversionUnitTest()
    {
        return _P_ConversionUnitTest::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::ConversionUnitTest, "5233ece2-bede-48d2-b2a0-ad431cf98906")

namespace GluonTest
{
    class _P_ITestClass : public ABI::Wrapper
    {
        template<typename> friend ITestClass CreateITestClass();
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_ITestClass, ::ABI::GluonTest::ITestClass)
    public:
        VirtualEvent<void(int), _P_ITestClass> BigEvent
            { this, &_P_ITestClass::AddBigEventHandler, &_P_ITestClass::RemoveBigEventHandler };

        PROPERTY(AddSomeShit, Adder);
        AddSomeShit GetAdder() const
        {
            return __P_GetAdder();
        }

        void SetAdder(const AddSomeShit& value) const
        {
            __P_SetAdder(value);
        }

        PROPERTY(int, Property);
        int GetProperty() const
        {
            return __P_GetProperty();
        }

        void SetProperty(int value) const
        {
            __P_SetProperty(value);
        }

        PROPERTY_READONLY(int, ReadOnlyProperty);
        int GetReadOnlyProperty() const
        {
            return __P_GetReadOnlyProperty();
        }

        PROPERTY(Array<TestStruct>, HardProperty);
        Array<TestStruct> GetHardProperty() const
        {
            return __P_GetHardProperty();
        }

        void SetHardProperty(Array<TestStruct> value) const
        {
            __P_SetHardProperty(value);
        }

        PROPERTY(Array<Delegate<string(char, int)>>, HarderProperty);
        Array<Delegate<string(char, int)>> GetHarderProperty() const
        {
            return __P_GetHarderProperty();
        }

        void SetHarderProperty(Array<Delegate<string(char, int)>> value) const
        {
            __P_SetHarderProperty(value);
        }

        PROPERTY(Delegate<char(string)>, DumbDelegate);
        Delegate<char(string)> GetDumbDelegate() const
        {
            return __P_GetDumbDelegate();
        }

        void SetDumbDelegate(const Delegate<char(string)>& value) const
        {
            __P_SetDumbDelegate(value);
        }

        void Methody() const
        {
            __P_Methody();
        }

        int RetMethod() const
        {
            return __P_RetMethod();
        }

        void OutMethod(int& outX) const
        {
            __P_OutMethod(outX);
        }

        void RefMethod(string& inoutThing) const
        {
            __P_RefMethod(inoutThing);
        }

        void Ref2(ITestClass& inoutThing) const
        {
            __P_Ref2(inoutThing);
        }

        void Ref3(const TestStruct& thing) const
        {
            __P_Ref3(thing);
        }

        Array<int> ComplexMethod(string& inoutA, IUnknown* _dumb, void* p, Array<char>& outFart) const
        {
            return __P_ComplexMethod(inoutA, _dumb, p, outFart);
        }

    private:
        void AddBigEventHandler(const Delegate<void(int)>& handler) const
        {
            __P_AddBigEventHandler(handler);
        }

        void RemoveBigEventHandler(const Delegate<void(int)>& handler) const
        {
            __P_RemoveBigEventHandler(handler);
        }

#ifndef __INTELLISENSE__
        template<typename = void>
        static ITestClass __P_Create();

        template<typename = void>
        void __P_Methody() const;

        template<typename = void>
        int __P_RetMethod() const;

        template<typename = void>
        void __P_OutMethod(int& outX) const;

        template<typename = void>
        void __P_RefMethod(string& inoutThing) const;

        template<typename = void>
        void __P_Ref2(ITestClass& inoutThing) const;

        template<typename = void>
        void __P_Ref3(const TestStruct& thing) const;

        template<typename = void>
        Array<int> __P_ComplexMethod(string& inoutA, IUnknown* _dumb, void* p, Array<char>& outFart) const;

        template<typename = void>
        AddSomeShit __P_GetAdder() const;

        template<typename = void>
        int __P_GetProperty() const;

        template<typename = void>
        int __P_GetReadOnlyProperty() const;

        template<typename = void>
        Array<TestStruct> __P_GetHardProperty() const;

        template<typename = void>
        Array<Delegate<string(char, int)>> __P_GetHarderProperty() const;

        template<typename = void>
        Delegate<char(string)> __P_GetDumbDelegate() const;

        template<typename = void>
        void __P_SetAdder(const AddSomeShit& value) const;

        template<typename = void>
        void __P_SetProperty(int value) const;

        template<typename = void>
        void __P_SetHardProperty(Array<TestStruct> value) const;

        template<typename = void>
        void __P_SetHarderProperty(Array<Delegate<string(char, int)>> value) const;

        template<typename = void>
        void __P_SetDumbDelegate(const Delegate<char(string)>& value) const;

        template<typename = void>
        void __P_AddBigEventHandler(const Delegate<void(int)>& handler) const;

        template<typename = void>
        void __P_RemoveBigEventHandler(const Delegate<void(int)>& handler) const;

#endif

    };

    template<typename = void>
    ITestClass CreateITestClass()
    {
        return _P_ITestClass::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::ITestClass, "4f2fe4fd-d08b-3cbb-e6c5-d40c17fc9837")

namespace GluonTest
{
    class _P_Generator : public ABI::Wrapper
    {
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_Generator, ::ABI::GluonTest::Generator)
    public:
        PROPERTY_READONLY(int, ChannelCount);
        int GetChannelCount() const
        {
            return __P_GetChannelCount();
        }

        PROPERTY_READONLY(int, SampleRate);
        int GetSampleRate() const
        {
            return __P_GetSampleRate();
        }

        void Initialize(int channels, int sampleRate) const
        {
            __P_Initialize(channels, sampleRate);
        }

        virtual void Eval(double t, double& inoutOutSample) const = 0
        {
            __P_Eval(t, inoutOutSample);
        }

        void EvalBuffer(double t, const SignalBuffer& inoutBuffer) const
        {
            __P_EvalBuffer(t, inoutBuffer);
        }

    private:
#ifndef __INTELLISENSE__
        template<typename = void>
        void __P_Initialize(int channels, int sampleRate) const;

        template<typename = void>
        void __P_Eval(double t, double& inoutOutSample) const;

        template<typename = void>
        void __P_EvalBuffer(double t, const SignalBuffer& inoutBuffer) const;

        template<typename = void>
        int __P_GetChannelCount() const;

        template<typename = void>
        int __P_GetSampleRate() const;

#endif

    };
}

IS_VALUETYPE(GluonTest::Generator, "3c2eeae5-d08b-3cbb-e6c5-da3d1cea9e15")

namespace GluonTest
{
    class _P_SignalBuffer : public ABI::Wrapper
    {
        template<typename> friend SignalBuffer CreateSignalBuffer(int samples, int channels, int alignment);
        template<typename> friend SignalBuffer CreateSignalBuffer(int samples);
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_SignalBuffer, ::ABI::GluonTest::SignalBuffer)
    public:
        PROPERTY_READONLY(int, ChannelCount);
        int GetChannelCount() const
        {
            return __P_GetChannelCount();
        }

        PROPERTY_READONLY(int, SampleCount);
        int GetSampleCount() const
        {
            return __P_GetSampleCount();
        }

        int CopyTo(Array<double> arr) const
        {
            return __P_CopyTo(arr);
        }

        int CopyTo(Array<float> arr) const
        {
            return __P_CopyTo(arr);
        }

        int CopyTo(Array<short> arr) const
        {
            return __P_CopyTo(arr);
        }

    private:
#ifndef __INTELLISENSE__
        template<typename = void>
        static SignalBuffer __P_Create(int samples, int channels, int alignment);

        template<typename = void>
        static SignalBuffer __P_Create(int samples);

        template<typename = void>
        int __P_CopyTo(Array<double> arr) const;

        template<typename = void>
        int __P_CopyTo(Array<float> arr) const;

        template<typename = void>
        int __P_CopyTo(Array<short> arr) const;

        template<typename = void>
        int __P_GetChannelCount() const;

        template<typename = void>
        int __P_GetSampleCount() const;

#endif

    };

    template<typename = void>
    SignalBuffer CreateSignalBuffer(int samples, int channels, int alignment)
    {
        return _P_SignalBuffer::__P_Create(samples, channels, alignment);
    }

    template<typename = void>
    SignalBuffer CreateSignalBuffer(int samples)
    {
        return _P_SignalBuffer::__P_Create(samples);
    }
}

IS_VALUETYPE(GluonTest::SignalBuffer, "5a3af0d3-a2ee-3cbb-e6c5-ce3115e18d18")

namespace GluonTest
{
    class _P_Waveform : public ABI::Wrapper
    {
        template<typename> friend Waveform CreateWaveform(Array<double> samples);
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_Waveform, ::ABI::GluonTest::Waveform)
    public:
        double Phase(double t) const
        {
            return __P_Phase(t);
        }

    private:
#ifndef __INTELLISENSE__
        template<typename = void>
        static Waveform __P_Create(Array<double> samples);

        template<typename = void>
        double __P_Phase(double t) const;

#endif

    };

    template<typename = void>
    Waveform CreateWaveform(Array<double> samples)
    {
        return _P_Waveform::__P_Create(samples);
    }
}

IS_VALUETYPE(GluonTest::Waveform, "3c5ce8e3-d08b-3cbb-e6c5-ca3904ea8a1b")

namespace GluonTest
{
    class _P_SinusoidalWaveform : public _P_Waveform
    {
        template<typename> friend SinusoidalWaveform CreateSinusoidalWaveform();
        typedef _P_Waveform Base;
        WRAPPER_CORE(_P_SinusoidalWaveform, ::ABI::GluonTest::SinusoidalWaveform)
#ifndef __INTELLISENSE__
        template<typename = void>
        static SinusoidalWaveform __P_Create();

#endif

    };

    template<typename = void>
    SinusoidalWaveform CreateSinusoidalWaveform()
    {
        return _P_SinusoidalWaveform::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::SinusoidalWaveform, "503de1f8-b1dc-59cd-80aa-bc5c1cfa9f1b")

namespace GluonTest
{
    class _P_SquareWaveform : public _P_Waveform
    {
        template<typename> friend SquareWaveform CreateSquareWaveform();
        typedef _P_Waveform Base;
        WRAPPER_CORE(_P_SquareWaveform, ::ABI::GluonTest::SquareWaveform)
#ifndef __INTELLISENSE__
        template<typename = void>
        static SquareWaveform __P_Create();

#endif

    };

    template<typename = void>
    SquareWaveform CreateSquareWaveform()
    {
        return _P_SquareWaveform::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::SquareWaveform, "592ae4c6-bfed-51c9-e6c5-ce2907ee9e11")

namespace GluonTest
{
    class _P_TriangleWaveform : public _P_Waveform
    {
        template<typename> friend TriangleWaveform CreateTriangleWaveform();
        typedef _P_Waveform Base;
        WRAPPER_CORE(_P_TriangleWaveform, ::ABI::GluonTest::TriangleWaveform)
#ifndef __INTELLISENSE__
        template<typename = void>
        static TriangleWaveform __P_Create();

#endif

    };

    template<typename = void>
    TriangleWaveform CreateTriangleWaveform()
    {
        return _P_TriangleWaveform::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::TriangleWaveform, "5d0be0fd-b5fd-53dd-94a8-c92a1bee8213")

namespace GluonTest
{
    class _P_SawtoothRightWaveform : public _P_Waveform
    {
        template<typename> friend SawtoothRightWaveform CreateSawtoothRightWaveform();
        typedef _P_Waveform Base;
        WRAPPER_CORE(_P_SawtoothRightWaveform, ::ABI::GluonTest::SawtoothRightWaveform)
#ifndef __INTELLISENSE__
        template<typename = void>
        static SawtoothRightWaveform __P_Create();

#endif

    };

    template<typename = void>
    SawtoothRightWaveform CreateSawtoothRightWaveform()
    {
        return _P_SawtoothRightWaveform::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::SawtoothRightWaveform, "550eede5-b8ec-6bcf-87b3-ab5f6a89ee1b")

namespace GluonTest
{
    class _P_SawtoothLeftWaveform : public _P_Waveform
    {
        template<typename> friend SawtoothLeftWaveform CreateSawtoothLeftWaveform();
        typedef _P_Waveform Base;
        WRAPPER_CORE(_P_SawtoothLeftWaveform, ::ABI::GluonTest::SawtoothLeftWaveform)
#ifndef __INTELLISENSE__
        template<typename = void>
        static SawtoothLeftWaveform __P_Create();

#endif

    };

    template<typename = void>
    SawtoothLeftWaveform CreateSawtoothLeftWaveform()
    {
        return _P_SawtoothLeftWaveform::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::SawtoothLeftWaveform, "5910ede5-a4ed-5dec-90a0-a8567796831b")

namespace GluonTest
{
    class _P_GTone : public _P_Generator
    {
        template<typename> friend GTone CreateGTone();
        typedef _P_Generator Base;
        WRAPPER_CORE(_P_GTone, ::ABI::GluonTest::GTone)
        using Waveform_t = Waveform;

    public:
        PROPERTY(double, Frequency);
        double GetFrequency() const
        {
            return __P_GetFrequency();
        }

        void SetFrequency(double value) const
        {
            __P_SetFrequency(value);
        }

        PROPERTY(const Waveform_t&, Waveform);
        const Waveform_t& GetWaveform() const
        {
            return __P_GetWaveform();
        }

        void SetWaveform(const Waveform_t& value) const
        {
            __P_SetWaveform(value);
        }

        PROPERTY(double, Amplitude);
        double GetAmplitude() const
        {
            return __P_GetAmplitude();
        }

        void SetAmplitude(double value) const
        {
            __P_SetAmplitude(value);
        }

        void Eval(double t, double& inoutOutSample) const override
        {
            __P_Eval(t, inoutOutSample);
        }

    private:
#ifndef __INTELLISENSE__
        template<typename = void>
        static GTone __P_Create();

        template<typename = void>
        void __P_Eval(double t, double& inoutOutSample) const;

        template<typename = void>
        double __P_GetFrequency() const;

        template<typename = void>
        Waveform_t __P_GetWaveform() const;

        template<typename = void>
        double __P_GetAmplitude() const;

        template<typename = void>
        void __P_SetFrequency(double value) const;

        template<typename = void>
        void __P_SetWaveform(const Waveform_t& value) const;

        template<typename = void>
        void __P_SetAmplitude(double value) const;

#endif

    };

    template<typename = void>
    GTone CreateGTone()
    {
        return _P_GTone::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::GTone, "3c5c8591-d08b-3cbb-e6c5-da0c1de18974")

namespace GluonTest
{
    class _P_GWhiteNoise : public _P_Generator
    {
        template<typename> friend GWhiteNoise CreateGWhiteNoise();
        typedef _P_Generator Base;
        WRAPPER_CORE(_P_GWhiteNoise, ::ABI::GluonTest::GWhiteNoise)
    public:
        void Eval(double t, double& inoutOutSample) const override
        {
            __P_Eval(t, inoutOutSample);
        }

    private:
#ifndef __INTELLISENSE__
        template<typename = void>
        static GWhiteNoise __P_Create();

        template<typename = void>
        void __P_Eval(double t, double& inoutOutSample) const;

#endif

    };

    template<typename = void>
    GWhiteNoise CreateGWhiteNoise()
    {
        return _P_GWhiteNoise::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::GWhiteNoise, "4f35eadf-d0ee-3cbb-e6c5-da0f1ae69811")

namespace GluonTest
{
    class _P_NoiseEngine : public ABI::Wrapper
    {
        template<typename> friend NoiseEngine CreateNoiseEngine();
        typedef ABI::Wrapper Base;
        WRAPPER_CORE(_P_NoiseEngine, ::ABI::GluonTest::NoiseEngine)
    public:
        PROPERTY_READONLY(string, Error);
        string GetError() const
        {
            return __P_GetError();
        }

        PROPERTY_READONLY(NoiseEngineState, State);
        NoiseEngineState GetState() const
        {
            return __P_GetState();
        }

        PROPERTY(int, SampleRate);
        int GetSampleRate() const
        {
            return __P_GetSampleRate();
        }

        void SetSampleRate(int value) const
        {
            __P_SetSampleRate(value);
        }

        PROPERTY(NoiseChannels, Channels);
        NoiseChannels GetChannels() const
        {
            return __P_GetChannels();
        }

        void SetChannels(NoiseChannels value) const
        {
            __P_SetChannels(value);
        }

        PROPERTY(int, BlockDuration);
        int GetBlockDuration() const
        {
            return __P_GetBlockDuration();
        }

        void SetBlockDuration(int value) const
        {
            __P_SetBlockDuration(value);
        }

        PROPERTY(NoiseDistribution, Distribution);
        NoiseDistribution GetDistribution() const
        {
            return __P_GetDistribution();
        }

        void SetDistribution(NoiseDistribution value) const
        {
            __P_SetDistribution(value);
        }

        PROPERTY(bool, IsFilterEnabled);
        bool GetIsFilterEnabled() const
        {
            return __P_GetIsFilterEnabled();
        }

        void SetIsFilterEnabled(bool value) const
        {
            __P_SetIsFilterEnabled(value);
        }

        void Play() const
        {
            __P_Play();
        }

        void Pause() const
        {
            __P_Pause();
        }

        SignalBuffer GetPlot(double durationSeconds, PlotType type) const
        {
            return __P_GetPlot(durationSeconds, type);
        }

    private:
#ifndef __INTELLISENSE__
        template<typename = void>
        static NoiseEngine __P_Create();

        template<typename = void>
        void __P_Play() const;

        template<typename = void>
        void __P_Pause() const;

        template<typename = void>
        SignalBuffer __P_GetPlot(double durationSeconds, PlotType type) const;

        template<typename = void>
        string __P_GetError() const;

        template<typename = void>
        NoiseEngineState __P_GetState() const;

        template<typename = void>
        int __P_GetSampleRate() const;

        template<typename = void>
        NoiseChannels __P_GetChannels() const;

        template<typename = void>
        int __P_GetBlockDuration() const;

        template<typename = void>
        NoiseDistribution __P_GetDistribution() const;

        template<typename = void>
        bool __P_GetIsFilterEnabled() const;

        template<typename = void>
        void __P_SetSampleRate(int value) const;

        template<typename = void>
        void __P_SetChannels(NoiseChannels value) const;

        template<typename = void>
        void __P_SetBlockDuration(int value) const;

        template<typename = void>
        void __P_SetDistribution(NoiseDistribution value) const;

        template<typename = void>
        void __P_SetIsFilterEnabled(bool value) const;

#endif

    };

    template<typename = void>
    NoiseEngine CreateNoiseEngine()
    {
        return _P_NoiseEngine::__P_Create();
    }
}

IS_VALUETYPE(GluonTest::NoiseEngine, "5235e2ff-d0ee-3cbb-e6c5-d3371bfc8931")

namespace GluonTest::Details
{
    using namespace CS;

    class comid("5505f1f3-9de5-6ad8-85e0-c9137289ee7a") DW_6FD213D6 : public ComObject<DW_6FD213D6, Object>, public ABI::DelegateWrapperBase<DW_6FD213D6,
        int(int, int)>
    {
    public:
        DW_6FD213D6(const Delegate<int(int, int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, int arg1, int arg2, int* ___ret){
            return __P_AbiFunc(__i_, arg1, arg2, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, int arg1, int arg2, int* ___ret);
    };

    class comid("5b39e9f4-a4ea-3cde-e6c5-d3391fea8830") DW_F8ED26DB : public ComObject<DW_F8ED26DB, Object>, public ABI::DelegateWrapperBase<DW_F8ED26DB,
        int(string, string)>
    {
    public:
        DW_F8ED26DB(const Delegate<int(string, string)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* a, char* b, int* ___ret){
            return __P_AbiFunc(__i_, a, b, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, char* a, char* b, int* ___ret);
    };

    class comid("4f39f3f8-92c8-3cbb-e6c5-cd2a1be28500") DW_1B83CCC6 : public ComObject<DW_1B83CCC6, Object>, public ABI::DelegateWrapperBase<DW_1B83CCC6,
        double(bool, char&, int&)>
    {
    public:
        DW_1B83CCC6(const Delegate<double(bool, char&, int&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, bool inTest, char* outTest, int* refTest, double* ___ret){
            return __P_AbiFunc(__i_, inTest, outTest, refTest, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, bool inTest, char* outTest, int* refTest, double* ___ret);
    };

    class comid("3c1ec6e2-d08b-3cbb-e6c5-ce2c00e68213") DW_E24BCA44 : public ComObject<DW_E24BCA44, Object>, public ABI::DelegateWrapperBase<DW_E24BCA44,
        string(string, string&, string&)>
    {
    public:
        DW_E24BCA44(const Delegate<string(string, string&, string&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* inTest, char** outTest, char** refTest, char** ___ret){
            return __P_AbiFunc(__i_, inTest, outTest, refTest, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, char* inTest, char** outTest, char** refTest, char** ___ret);
    };

    class comid("492ef1c2-a4e8-7fc8-a4c5-ce311fff8011") DW_CA433402 : public ComObject<DW_CA433402, Object>, public ABI::DelegateWrapperBase<DW_CA433402,
        GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>
    {
    public:
        DW_CA433402(const Delegate<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct inTest, ::ABI::GluonTest::BlittableStruct* outTest, ::ABI::GluonTest::BlittableStruct* refTest, ::ABI::GluonTest::BlittableStruct* ___ret){
            return __P_AbiFunc(__i_, inTest, outTest, refTest, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct inTest, ::ABI::GluonTest::BlittableStruct* outTest, ::ABI::GluonTest::BlittableStruct* refTest, ::ABI::GluonTest::BlittableStruct* ___ret);
    };

    class comid("4e28d6e9-b3fe-4fcf-a587-de371fff8011") DW_10105E22 : public ComObject<DW_10105E22, Object>, public ABI::DelegateWrapperBase<DW_10105E22,
        GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>
    {
    public:
        DW_10105E22(const Delegate<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct inTest, ::ABI::GluonTest::ComplexStruct* outTest, ::ABI::GluonTest::ComplexStruct* refTest, ::ABI::GluonTest::ComplexStruct* ___ret){
            return __P_AbiFunc(__i_, inTest, outTest, refTest, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct inTest, ::ABI::GluonTest::ComplexStruct* outTest, ::ABI::GluonTest::ComplexStruct* refTest, ::ABI::GluonTest::ComplexStruct* ___ret);
    };

    class comid("3c1ec6e2-d08b-3cbb-e6c5-d23a18ea8f00") DW_95E0837A : public ComObject<DW_95E0837A, Object>, public ABI::DelegateWrapperBase<DW_95E0837A,
        GluonTest::DummyClass(const GluonTest::DummyClass&, GluonTest::DummyClass&, GluonTest::DummyClass&)>
    {
    public:
        DW_95E0837A(const Delegate<GluonTest::DummyClass(const GluonTest::DummyClass&, GluonTest::DummyClass&, GluonTest::DummyClass&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass* inTest, ::ABI::GluonTest::DummyClass** outTest, ::ABI::GluonTest::DummyClass** refTest, ::ABI::GluonTest::DummyClass** ___ret){
            return __P_AbiFunc(__i_, inTest, outTest, refTest, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass* inTest, ::ABI::GluonTest::DummyClass** outTest, ::ABI::GluonTest::DummyClass** refTest, ::ABI::GluonTest::DummyClass** ___ret);
    };

    class comid("5b39e9f4-a4ea-4fde-a587-d3391fea8830") DW_F2E7AE0D : public ComObject<DW_F2E7AE0D, Object>, public ABI::DelegateWrapperBase<DW_F2E7AE0D,
        GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>
    {
    public:
        DW_F2E7AE0D(const Delegate<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context){
            return __P_AbiFunc(__i_, inTest, inTest_context, outTest, outTest_context, refTest, refTest_context, ___ret, ___ret_context);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context);
    };

    class comid("5039c1f2-b7ee-48da-83b6-997f1cea9e1d") DW_D744D573 : public ComObject<DW_D744D573, Object>, public ABI::DelegateWrapperBase<DW_D744D573,
        Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>
    {
    public:
        DW_D744D573(const Delegate<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context){
            return __P_AbiFunc(__i_, inTest, inTest_context, outTest, outTest_context, refTest, refTest_context, ___ret, ___ret_context);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context);
    };

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1EB : public ComObject<DW_F757A1EB, Object>, public ABI::DelegateWrapperBase<DW_F757A1EB,
        int(int)>
    {
    public:
        DW_F757A1EB(const Delegate<int(int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, int arg, int* ___ret){
            return __P_AbiFunc(__i_, arg, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, int arg, int* ___ret);
    };

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5C0C3D4C : public ComObject<DW_5C0C3D4C, Object>, public ABI::DelegateWrapperBase<DW_5C0C3D4C,
        void(string)>
    {
    public:
        DW_5C0C3D4C(const Delegate<void(string)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* obj){
            return __P_AbiFunc(__i_, obj);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, char* obj);
    };

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5C0C3D4D : public ComObject<DW_5C0C3D4D, Object>, public ABI::DelegateWrapperBase<DW_5C0C3D4D,
        void(const Delegate<int(int)>&)>
    {
    public:
        DW_5C0C3D4D(const Delegate<void(const Delegate<int(int)>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,int,int*)> obj, IObject* obj_context){
            return __P_AbiFunc(__i_, obj, obj_context);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,int,int*)> obj, IObject* obj_context);
    };

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1EC : public ComObject<DW_F757A1EC, Object>, public ABI::DelegateWrapperBase<DW_F757A1EC,
        Array<string>(Array<char>)>
    {
    public:
        DW_F757A1EC(const Delegate<Array<string>(Array<char>)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, int arg_count, char*** ___ret, int* ___ret_count){
            return __P_AbiFunc(__i_, arg, arg_count, ___ret, ___ret_count);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, char* arg, int arg_count, char*** ___ret, int* ___ret_count);
    };

    class comid("7d39f3f8-a2f9-45da-9586-8f2a1be28500") DW_C30682FD : public ComObject<DW_C30682FD, Object>, public ABI::DelegateWrapperBase<DW_C30682FD,
        Array<double>(Array<bool>, Array<char>&, Array<int>&)>
    {
    public:
        DW_C30682FD(const Delegate<Array<double>(Array<bool>, Array<char>&, Array<int>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, bool* inTest, int inTest_count, char** outTest, int* outTest_count, int** refTest, int* refTest_count, double** ___ret, int* ___ret_count){
            return __P_AbiFunc(__i_, inTest, inTest_count, outTest, outTest_count, refTest, refTest_count, ___ret, ___ret_count);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, bool* inTest, int inTest_count, char** outTest, int* outTest_count, int** refTest, int* refTest_count, double** ___ret, int* ___ret_count);
    };

    class comid("5d2ef7d0-a3f2-7ef8-e6c5-ce2c00e68213") DW_B2F37841 : public ComObject<DW_B2F37841, Object>, public ABI::DelegateWrapperBase<DW_B2F37841,
        Array<string>(Array<string>, Array<string>&, Array<string>&)>
    {
    public:
        DW_B2F37841(const Delegate<Array<string>(Array<string>, Array<string>&, Array<string>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char** inTest, int inTest_count, char*** outTest, int* outTest_count, char*** refTest, int* refTest_count, char*** ___ret, int* ___ret_count){
            return __P_AbiFunc(__i_, inTest, inTest_count, outTest, outTest_count, refTest, refTest_count, ___ret, ___ret_count);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, char** inTest, int inTest_count, char*** outTest, int* outTest_count, char*** refTest, int* refTest_count, char*** ___ret, int* ___ret_count);
    };

    class comid("492ef1c2-a4e8-4efa-94a4-b7425cbd8011") DW_B28180A5 : public ComObject<DW_B28180A5, Object>, public ABI::DelegateWrapperBase<DW_B28180A5,
        Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>
    {
    public:
        DW_B28180A5(const Delegate<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct* inTest, int inTest_count, ::ABI::GluonTest::BlittableStruct** outTest, int* outTest_count, ::ABI::GluonTest::BlittableStruct** refTest, int* refTest_count, ::ABI::GluonTest::BlittableStruct** ___ret, int* ___ret_count){
            return __P_AbiFunc(__i_, inTest, inTest_count, outTest, outTest_count, refTest, refTest_count, ___ret, ___ret_count);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct* inTest, int inTest_count, ::ABI::GluonTest::BlittableStruct** outTest, int* outTest_count, ::ABI::GluonTest::BlittableStruct** refTest, int* refTest_count, ::ABI::GluonTest::BlittableStruct** ___ret, int* ___ret_count);
    };

    class comid("4e28d6e9-b3fe-7dcf-94b7-bf4e6cbcc211") DW_EE6D3DFB : public ComObject<DW_EE6D3DFB, Object>, public ABI::DelegateWrapperBase<DW_EE6D3DFB,
        Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>
    {
    public:
        DW_EE6D3DFB(const Delegate<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct* inTest, int inTest_count, ::ABI::GluonTest::ComplexStruct** outTest, int* outTest_count, ::ABI::GluonTest::ComplexStruct** refTest, int* refTest_count, ::ABI::GluonTest::ComplexStruct** ___ret, int* ___ret_count){
            return __P_AbiFunc(__i_, inTest, inTest_count, outTest, outTest_count, refTest, refTest_count, ___ret, ___ret_count);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct* inTest, int inTest_count, ::ABI::GluonTest::ComplexStruct** outTest, int* outTest_count, ::ABI::GluonTest::ComplexStruct** refTest, int* refTest_count, ::ABI::GluonTest::ComplexStruct** ___ret, int* ___ret_count);
    };

    class comid("5d2ef7d0-a3f2-7ef8-e6c5-d23a18ea8f00") DW_4388047D : public ComObject<DW_4388047D, Object>, public ABI::DelegateWrapperBase<DW_4388047D,
        Array<GluonTest::DummyClass>(Array<GluonTest::DummyClass>, Array<GluonTest::DummyClass>&, Array<GluonTest::DummyClass>&)>
    {
    public:
        DW_4388047D(const Delegate<Array<GluonTest::DummyClass>(Array<GluonTest::DummyClass>, Array<GluonTest::DummyClass>&, Array<GluonTest::DummyClass>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass** inTest, int inTest_count, ::ABI::GluonTest::DummyClass*** outTest, int* outTest_count, ::ABI::GluonTest::DummyClass*** refTest, int* refTest_count, ::ABI::GluonTest::DummyClass*** ___ret, int* ___ret_count){
            return __P_AbiFunc(__i_, inTest, inTest_count, outTest, outTest_count, refTest, refTest_count, ___ret, ___ret_count);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass** inTest, int inTest_count, ::ABI::GluonTest::DummyClass*** outTest, int* outTest_count, ::ABI::GluonTest::DummyClass*** refTest, int* refTest_count, ::ABI::GluonTest::DummyClass*** ___ret, int* ___ret_count);
    };

    class comid("5b39e9f4-a4ea-7dde-94b7-b2406ca9ca30") DW_CCD79226 : public ComObject<DW_CCD79226, Object>, public ABI::DelegateWrapperBase<DW_CCD79226,
        Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>
    {
    public:
        DW_CCD79226(const Delegate<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count){
            return __P_AbiFunc(__i_, inTest, inTest_count, outTest, outTest_count, refTest, refTest_count, ___ret, ___ret_count);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
    };

    class comid("5039c1b0-b7ee-48da-8384-a84f7d93ed5e") DW_F5BD3F9A : public ComObject<DW_F5BD3F9A, Object>, public ABI::DelegateWrapperBase<DW_F5BD3F9A,
        Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>
    {
    public:
        DW_F5BD3F9A(const Delegate<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count){
            return __P_AbiFunc(__i_, inTest, inTest_count, outTest, outTest_count, refTest, refTest_count, ___ret, ___ret_count);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count);
    };

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1ED : public ComObject<DW_F757A1ED, Object>, public ABI::DelegateWrapperBase<DW_F757A1ED,
        double(double)>
    {
    public:
        DW_F757A1ED(const Delegate<double(double)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, double arg, double* ___ret){
            return __P_AbiFunc(__i_, arg, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, double arg, double* ___ret);
    };

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1EE : public ComObject<DW_F757A1EE, Object>, public ABI::DelegateWrapperBase<DW_F757A1EE,
        string(Array<char>)>
    {
    public:
        DW_F757A1EE(const Delegate<string(Array<char>)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, int arg_count, char** ___ret){
            return __P_AbiFunc(__i_, arg, arg_count, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, char* arg, int arg_count, char** ___ret);
    };

    class comid("5534d6f4-d0ff-3cbb-e6c5-dc3c16dc8319") DW_FBC9C526 : public ComObject<DW_FBC9C526, Object>, public ABI::DelegateWrapperBase<DW_FBC9C526,
        GluonTest::ITestClass(int, int)>
    {
    public:
        DW_FBC9C526(const Delegate<GluonTest::ITestClass(int, int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, int a, int b, ::ABI::GluonTest::ITestClass** ___ret){
            return __P_AbiFunc(__i_, a, b, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, int a, int b, ::ABI::GluonTest::ITestClass** ___ret);
    };

    class comid("5505f1f3-9de5-6ad8-85e0-c9137289ee7a") DW_6FD213D7 : public ComObject<DW_6FD213D7, Object>, public ABI::DelegateWrapperBase<DW_6FD213D7,
        string(char, int)>
    {
    public:
        DW_6FD213D7(const Delegate<string(char, int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char arg1, int arg2, char** ___ret){
            return __P_AbiFunc(__i_, arg1, arg2, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, char arg1, int arg2, char** ___ret);
    };

    class comid("5505cfda-9de5-6ad8-85e0-d10113fb8948") DW_F757A1EF : public ComObject<DW_F757A1EF, Object>, public ABI::DelegateWrapperBase<DW_F757A1EF,
        char(string)>
    {
    public:
        DW_F757A1EF(const Delegate<char(string)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, char* arg, char* ___ret){
            return __P_AbiFunc(__i_, arg, ___ret);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, char* arg, char* ___ret);
    };

    class comid("5505cfda-9de5-64d8-95ed-d10113fb8948") DW_5C0C3D4E : public ComObject<DW_5C0C3D4E, Object>, public ABI::DelegateWrapperBase<DW_5C0C3D4E,
        void(int)>
    {
    public:
        DW_5C0C3D4E(const Delegate<void(int)>& d) : DBase(d) { }
        static HRESULT __stdcall AbiFunc(IObject* __i_, int obj){
            return __P_AbiFunc(__i_, obj);
        }

    private:
        template<typename = void>
        static HRESULT __P_AbiFunc(IObject* __i_, int obj);
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<Delegate<int(int, int)>> : public ABIUtilForDelegates<int(int, int)>
    {
        typedef GluonTest::Details::DW_6FD213D6 DW_6FD213D6;

        static Delegate<int(int, int)> FromABI(void* fptr, IObject* ctx) { return __P_FromABI(fptr, ctx); }
        static ABI::DelegateBlob ToABI(const Delegate<int(int, int)>& x) { return __P_ToABI(x); }
        static Delegate<int(int, int)> FromABI(const ABI::DelegateBlob& abi) { return FromABI(abi.Fn, abi.Ctx); }
        template<typename = void> static Delegate<int(int, int)> __P_FromABI(void* fptr, IObject* ctx);
        template<typename = void> static ABI::DelegateBlob __P_ToABI(const Delegate<int(int, int)>& x);
    };

    template<typename>
    Delegate<int(int, int)> ABIUtil<Delegate<int(int, int)>>::__P_FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_6FD213D6::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_6FD213D6>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return[fn = (fn_ptr<HRESULT(IObject*, int, int, int*)>)fptr, cp = com_ptr<IObject>(ctx)](int arg1, int arg2)
            -> int {
            int ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                arg1,
                arg2,
                ABICallbackRef<int>(___ret)));
            return ___ret;
        };
    }

    template<typename>
    ABI::DelegateBlob ABIUtil<Delegate<int(int, int)>>::__P_ToABI(const Delegate<int(int, int)>& x)
    {
        ABIOf<Delegate<int(int, int)>> x_abi;
        x_abi.Fn = &DW_6FD213D6::AbiFunc;
        x_abi.Ctx = DW_6FD213D6::GetWrapper(x);
        return x_abi;
    }

    //template<> struct ABIUtil<Delegate<int(int, int)>> : public ABIUtilForDelegates<int(int, int)>
    //{
    //    typedef GluonTest::Details::DW_6FD213D6 DW_6FD213D6;

    //    static Delegate<int(int, int)> FromABI(void* fptr, IObject* ctx)
    //    {
    //        if (fptr == &DW_6FD213D6::AbiFunc)
    //        {
    //            auto wrapper = runtime_cast<DW_6FD213D6>(ctx);
    //            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
    //            return wrapper->Func;
    //        }

    //        return [fn = (fn_ptr<HRESULT(IObject*,int,int,int*)>)fptr, cp = com_ptr<IObject>(ctx)](int arg1, int arg2)
    //            -> int {
    //            int ___ret;
    //            TRANSLATE_TO_EXCEPTIONS(fn(
    //                cp.Get(),
    //                arg1,
    //                arg2,
    //                ABICallbackRef<int>(___ret)));
    //            return ___ret;
    //        };
    //    }

    //    static ABI::DelegateBlob ToABI(const Delegate<int(int, int)>& x)
    //    {
    //        ABIOf<Delegate<int(int, int)>> x_abi;
    //        x_abi.Fn = &DW_6FD213D6::AbiFunc;
    //        x_abi.Ctx = DW_6FD213D6::GetWrapper(x);
    //        return x_abi;
    //    }

    //    static Delegate<int(int, int)> FromABI(const ABI::DelegateBlob& abi)
    //    {
    //        return FromABI(abi.Fn, abi.Ctx);
    //    }
    //};

    template<> struct ABIUtil<GluonTest::NamedDelegate> : public ABIUtilForDelegates<int(string, string)>
    {
        typedef GluonTest::Details::DW_F8ED26DB DW_F8ED26DB;

        static GluonTest::NamedDelegate FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_F8ED26DB::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_F8ED26DB>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)fptr, cp = com_ptr<IObject>(ctx)](string a, string b)
                -> int {
                int ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    ABIUtil<string>::ToABI(a),
                    ABIUtil<string>::ToABI(b),
                    ABICallbackRef<int>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::NamedDelegate& x)
        {
            ABIOf<GluonTest::NamedDelegate> x_abi;
            x_abi.Fn = &DW_F8ED26DB::AbiFunc;
            x_abi.Ctx = DW_F8ED26DB::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::NamedDelegate FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::PrimitivesCB> : public ABIUtilForDelegates<double(bool, char&, int&)>
    {
        typedef GluonTest::Details::DW_1B83CCC6 DW_1B83CCC6;

        static GluonTest::PrimitivesCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_1B83CCC6::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_1B83CCC6>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>)fptr, cp = com_ptr<IObject>(ctx)](bool inTest, char& outTest, int& refTest)
                -> double {
                double ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest,
                    ABICallbackRef<char>(outTest),
                    ABICallbackRef<int>(refTest),
                    ABICallbackRef<double>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::PrimitivesCB& x)
        {
            ABIOf<GluonTest::PrimitivesCB> x_abi;
            x_abi.Fn = &DW_1B83CCC6::AbiFunc;
            x_abi.Ctx = DW_1B83CCC6::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::PrimitivesCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::StringsCB> : public ABIUtilForDelegates<string(string, string&, string&)>
    {
        typedef GluonTest::Details::DW_E24BCA44 DW_E24BCA44;

        static GluonTest::StringsCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_E24BCA44::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_E24BCA44>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>)fptr, cp = com_ptr<IObject>(ctx)](string inTest, string& outTest, string& refTest)
                -> string {
                string ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    ABIUtil<string>::ToABI(inTest),
                    ABICallbackRef<string>(outTest),
                    ABICallbackRef<string>(refTest),
                    ABICallbackRef<string>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::StringsCB& x)
        {
            ABIOf<GluonTest::StringsCB> x_abi;
            x_abi.Fn = &DW_E24BCA44::AbiFunc;
            x_abi.Ctx = DW_E24BCA44::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::StringsCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::SimpleStructsCB> : public ABIUtilForDelegates<GluonTest::BlittableStruct(const GluonTest::BlittableStruct&, GluonTest::BlittableStruct&, GluonTest::BlittableStruct&)>
    {
        typedef GluonTest::Details::DW_CA433402 DW_CA433402;

        static GluonTest::SimpleStructsCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_CA433402::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_CA433402>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)>)fptr, cp = com_ptr<IObject>(ctx)](const GluonTest::BlittableStruct& inTest, GluonTest::BlittableStruct& outTest, GluonTest::BlittableStruct& refTest)
                -> GluonTest::BlittableStruct {
                GluonTest::BlittableStruct ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest,
                    ABICallbackRef<GluonTest::BlittableStruct>(outTest),
                    ABICallbackRef<GluonTest::BlittableStruct>(refTest),
                    ABICallbackRef<GluonTest::BlittableStruct>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::SimpleStructsCB& x)
        {
            ABIOf<GluonTest::SimpleStructsCB> x_abi;
            x_abi.Fn = &DW_CA433402::AbiFunc;
            x_abi.Ctx = DW_CA433402::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::SimpleStructsCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::ComplexStructsCB> : public ABIUtilForDelegates<GluonTest::ComplexStruct(const GluonTest::ComplexStruct&, GluonTest::ComplexStruct&, GluonTest::ComplexStruct&)>
    {
        typedef GluonTest::Details::DW_10105E22 DW_10105E22;

        static GluonTest::ComplexStructsCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_10105E22::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_10105E22>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)>)fptr, cp = com_ptr<IObject>(ctx)](const GluonTest::ComplexStruct& inTest, GluonTest::ComplexStruct& outTest, GluonTest::ComplexStruct& refTest)
                -> GluonTest::ComplexStruct {
                GluonTest::ComplexStruct ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    ABIUtil<GluonTest::ComplexStruct>::ToABI(inTest),
                    ABICallbackRef<GluonTest::ComplexStruct>(outTest),
                    ABICallbackRef<GluonTest::ComplexStruct>(refTest),
                    ABICallbackRef<GluonTest::ComplexStruct>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::ComplexStructsCB& x)
        {
            ABIOf<GluonTest::ComplexStructsCB> x_abi;
            x_abi.Fn = &DW_10105E22::AbiFunc;
            x_abi.Ctx = DW_10105E22::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::ComplexStructsCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::ObjectsCB> : public ABIUtilForDelegates<GluonTest::DummyClass(const GluonTest::DummyClass&, GluonTest::DummyClass&, GluonTest::DummyClass&)>
    {
        typedef GluonTest::Details::DW_95E0837A DW_95E0837A;

        static GluonTest::ObjectsCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_95E0837A::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_95E0837A>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)>)fptr, cp = com_ptr<IObject>(ctx)](const GluonTest::DummyClass& inTest, GluonTest::DummyClass& outTest, GluonTest::DummyClass& refTest)
                -> GluonTest::DummyClass {
                GluonTest::DummyClass ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    ABIUtil<GluonTest::DummyClass>::ToABI(inTest),
                    ABICallbackRef<GluonTest::DummyClass>(outTest),
                    ABICallbackRef<GluonTest::DummyClass>(refTest),
                    ABICallbackRef<GluonTest::DummyClass>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::ObjectsCB& x)
        {
            ABIOf<GluonTest::ObjectsCB> x_abi;
            x_abi.Fn = &DW_95E0837A::AbiFunc;
            x_abi.Ctx = DW_95E0837A::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::ObjectsCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::NamedDelegatesCB> : public ABIUtilForDelegates<GluonTest::NamedDelegate(const GluonTest::NamedDelegate&, GluonTest::NamedDelegate&, GluonTest::NamedDelegate&)>
    {
        typedef GluonTest::Details::DW_F2E7AE0D DW_F2E7AE0D;

        static GluonTest::NamedDelegatesCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_F2E7AE0D::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_F2E7AE0D>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>)fptr, cp = com_ptr<IObject>(ctx)](const GluonTest::NamedDelegate& inTest, GluonTest::NamedDelegate& outTest, GluonTest::NamedDelegate& refTest)
                -> GluonTest::NamedDelegate {
                auto inTest_abi = ABIUtil<GluonTest::NamedDelegate>::ToABI(inTest);
                ABICallbackRef<GluonTest::NamedDelegate> outTest_abi(outTest);
                ABICallbackRef<GluonTest::NamedDelegate> refTest_abi(refTest);
                GluonTest::NamedDelegate ___ret;
                {
                    ABICallbackRef<GluonTest::NamedDelegate> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)inTest_abi.Fn, inTest_abi.Ctx,
                        (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&outTest_abi.Fn, &outTest_abi.Ctx,
                        (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&refTest_abi.Fn, &refTest_abi.Ctx,
                        (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::NamedDelegatesCB& x)
        {
            ABIOf<GluonTest::NamedDelegatesCB> x_abi;
            x_abi.Fn = &DW_F2E7AE0D::AbiFunc;
            x_abi.Ctx = DW_F2E7AE0D::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::NamedDelegatesCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::GenericDelegatesCB> : public ABIUtilForDelegates<Delegate<int(int)>(const Delegate<void(string)>&, Delegate<void(const Delegate<int(int)>&)>&, Delegate<Array<string>(Array<char>)>&)>
    {
        typedef GluonTest::Details::DW_D744D573 DW_D744D573;

        static GluonTest::GenericDelegatesCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_D744D573::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_D744D573>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>)fptr, cp = com_ptr<IObject>(ctx)](const Delegate<void(string)>& inTest, Delegate<void(const Delegate<int(int)>&)>& outTest, Delegate<Array<string>(Array<char>)>& refTest)
                -> Delegate<int(int)> {
                auto inTest_abi = ABIUtil<Delegate<void(string)>>::ToABI(inTest);
                ABICallbackRef<Delegate<void(const Delegate<int(int)>&)>> outTest_abi(outTest);
                ABICallbackRef<Delegate<Array<string>(Array<char>)>> refTest_abi(refTest);
                Delegate<int(int)> ___ret;
                {
                    ABICallbackRef<Delegate<int(int)>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        (fn_ptr<HRESULT(IObject*,char*)>)inTest_abi.Fn, inTest_abi.Ctx,
                        (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*)&outTest_abi.Fn, &outTest_abi.Ctx,
                        (fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*)&refTest_abi.Fn, &refTest_abi.Ctx,
                        (fn_ptr<HRESULT(IObject*,int,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::GenericDelegatesCB& x)
        {
            ABIOf<GluonTest::GenericDelegatesCB> x_abi;
            x_abi.Fn = &DW_D744D573::AbiFunc;
            x_abi.Ctx = DW_D744D573::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::GenericDelegatesCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<int(int)>> : public ABIUtilForDelegates<int(int)>
    {
        typedef GluonTest::Details::DW_F757A1EB DW_F757A1EB;

        static Delegate<int(int)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_F757A1EB::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_F757A1EB>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,int,int*)>)fptr, cp = com_ptr<IObject>(ctx)](int arg)
                -> int {
                int ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    arg,
                    ABICallbackRef<int>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<int(int)>& x)
        {
            ABIOf<Delegate<int(int)>> x_abi;
            x_abi.Fn = &DW_F757A1EB::AbiFunc;
            x_abi.Ctx = DW_F757A1EB::GetWrapper(x);
            return x_abi;
        }

        static Delegate<int(int)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<void(string)>> : public ABIUtilForDelegates<void(string)>
    {
        typedef GluonTest::Details::DW_5C0C3D4C DW_5C0C3D4C;

        static Delegate<void(string)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_5C0C3D4C::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_5C0C3D4C>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,char*)>)fptr, cp = com_ptr<IObject>(ctx)](string obj)
            {
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    ABIUtil<string>::ToABI(obj)));
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<void(string)>& x)
        {
            ABIOf<Delegate<void(string)>> x_abi;
            x_abi.Fn = &DW_5C0C3D4C::AbiFunc;
            x_abi.Ctx = DW_5C0C3D4C::GetWrapper(x);
            return x_abi;
        }

        static Delegate<void(string)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<void(const Delegate<int(int)>&)>> : public ABIUtilForDelegates<void(const Delegate<int(int)>&)>
    {
        typedef GluonTest::Details::DW_5C0C3D4D DW_5C0C3D4D;

        static Delegate<void(const Delegate<int(int)>&)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_5C0C3D4D::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_5C0C3D4D>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>)fptr, cp = com_ptr<IObject>(ctx)](const Delegate<int(int)>& obj)
            {
                auto obj_abi = ABIUtil<Delegate<int(int)>>::ToABI(obj);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    (fn_ptr<HRESULT(IObject*,int,int*)>)obj_abi.Fn, obj_abi.Ctx));
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<void(const Delegate<int(int)>&)>& x)
        {
            ABIOf<Delegate<void(const Delegate<int(int)>&)>> x_abi;
            x_abi.Fn = &DW_5C0C3D4D::AbiFunc;
            x_abi.Ctx = DW_5C0C3D4D::GetWrapper(x);
            return x_abi;
        }

        static Delegate<void(const Delegate<int(int)>&)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<Array<string>(Array<char>)>> : public ABIUtilForDelegates<Array<string>(Array<char>)>
    {
        typedef GluonTest::Details::DW_F757A1EC DW_F757A1EC;

        static Delegate<Array<string>(Array<char>)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_F757A1EC::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_F757A1EC>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<char> arg)
                -> Array<string> {
                auto arg_abi = ABIUtil<Array<char>>::ToABI(arg);
                Array<string> ___ret;
                {
                    ABICallbackRef<Array<string>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        arg_abi.begin(), arg_abi.size(),
                        &___ret_abi.Data, &___ret_abi.Count));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<Array<string>(Array<char>)>& x)
        {
            ABIOf<Delegate<Array<string>(Array<char>)>> x_abi;
            x_abi.Fn = &DW_F757A1EC::AbiFunc;
            x_abi.Ctx = DW_F757A1EC::GetWrapper(x);
            return x_abi;
        }

        static Delegate<Array<string>(Array<char>)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::PrimitiveArraysCB> : public ABIUtilForDelegates<Array<double>(Array<bool>, Array<char>&, Array<int>&)>
    {
        typedef GluonTest::Details::DW_C30682FD DW_C30682FD;

        static GluonTest::PrimitiveArraysCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_C30682FD::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_C30682FD>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<bool> inTest, Array<char>& outTest, Array<int>& refTest)
                -> Array<double> {
                auto inTest_abi = ABIUtil<Array<bool>>::ToABI(inTest);
                ABICallbackRef<Array<char>> outTest_abi(outTest);
                ABICallbackRef<Array<int>> refTest_abi(refTest);
                Array<double> ___ret;
                {
                    ABICallbackRef<Array<double>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        inTest_abi.begin(), inTest_abi.size(),
                        &outTest_abi.Data, &outTest_abi.Count,
                        &refTest_abi.Data, &refTest_abi.Count,
                        &___ret_abi.Data, &___ret_abi.Count));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::PrimitiveArraysCB& x)
        {
            ABIOf<GluonTest::PrimitiveArraysCB> x_abi;
            x_abi.Fn = &DW_C30682FD::AbiFunc;
            x_abi.Ctx = DW_C30682FD::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::PrimitiveArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::StringArraysCB> : public ABIUtilForDelegates<Array<string>(Array<string>, Array<string>&, Array<string>&)>
    {
        typedef GluonTest::Details::DW_B2F37841 DW_B2F37841;

        static GluonTest::StringArraysCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_B2F37841::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_B2F37841>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<string> inTest, Array<string>& outTest, Array<string>& refTest)
                -> Array<string> {
                auto inTest_abi = ABIUtil<Array<string>>::ToABI(inTest);
                ABICallbackRef<Array<string>> outTest_abi(outTest);
                ABICallbackRef<Array<string>> refTest_abi(refTest);
                Array<string> ___ret;
                {
                    ABICallbackRef<Array<string>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        inTest_abi.begin(), inTest_abi.size(),
                        &outTest_abi.Data, &outTest_abi.Count,
                        &refTest_abi.Data, &refTest_abi.Count,
                        &___ret_abi.Data, &___ret_abi.Count));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::StringArraysCB& x)
        {
            ABIOf<GluonTest::StringArraysCB> x_abi;
            x_abi.Fn = &DW_B2F37841::AbiFunc;
            x_abi.Ctx = DW_B2F37841::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::StringArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::SimpleStructArraysCB> : public ABIUtilForDelegates<Array<GluonTest::BlittableStruct>(Array<GluonTest::BlittableStruct>, Array<GluonTest::BlittableStruct>&, Array<GluonTest::BlittableStruct>&)>
    {
        typedef GluonTest::Details::DW_B28180A5 DW_B28180A5;

        static GluonTest::SimpleStructArraysCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_B28180A5::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_B28180A5>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<GluonTest::BlittableStruct> inTest, Array<GluonTest::BlittableStruct>& outTest, Array<GluonTest::BlittableStruct>& refTest)
                -> Array<GluonTest::BlittableStruct> {
                auto inTest_abi = ABIUtil<Array<GluonTest::BlittableStruct>>::ToABI(inTest);
                ABICallbackRef<Array<GluonTest::BlittableStruct>> outTest_abi(outTest);
                ABICallbackRef<Array<GluonTest::BlittableStruct>> refTest_abi(refTest);
                Array<GluonTest::BlittableStruct> ___ret;
                {
                    ABICallbackRef<Array<GluonTest::BlittableStruct>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        inTest_abi.begin(), inTest_abi.size(),
                        &outTest_abi.Data, &outTest_abi.Count,
                        &refTest_abi.Data, &refTest_abi.Count,
                        &___ret_abi.Data, &___ret_abi.Count));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::SimpleStructArraysCB& x)
        {
            ABIOf<GluonTest::SimpleStructArraysCB> x_abi;
            x_abi.Fn = &DW_B28180A5::AbiFunc;
            x_abi.Ctx = DW_B28180A5::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::SimpleStructArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::ComplexStructArraysCB> : public ABIUtilForDelegates<Array<GluonTest::ComplexStruct>(Array<GluonTest::ComplexStruct>, Array<GluonTest::ComplexStruct>&, Array<GluonTest::ComplexStruct>&)>
    {
        typedef GluonTest::Details::DW_EE6D3DFB DW_EE6D3DFB;

        static GluonTest::ComplexStructArraysCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_EE6D3DFB::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_EE6D3DFB>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<GluonTest::ComplexStruct> inTest, Array<GluonTest::ComplexStruct>& outTest, Array<GluonTest::ComplexStruct>& refTest)
                -> Array<GluonTest::ComplexStruct> {
                auto inTest_abi = ABIUtil<Array<GluonTest::ComplexStruct>>::ToABI(inTest);
                ABICallbackRef<Array<GluonTest::ComplexStruct>> outTest_abi(outTest);
                ABICallbackRef<Array<GluonTest::ComplexStruct>> refTest_abi(refTest);
                Array<GluonTest::ComplexStruct> ___ret;
                {
                    ABICallbackRef<Array<GluonTest::ComplexStruct>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        inTest_abi.begin(), inTest_abi.size(),
                        &outTest_abi.Data, &outTest_abi.Count,
                        &refTest_abi.Data, &refTest_abi.Count,
                        &___ret_abi.Data, &___ret_abi.Count));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::ComplexStructArraysCB& x)
        {
            ABIOf<GluonTest::ComplexStructArraysCB> x_abi;
            x_abi.Fn = &DW_EE6D3DFB::AbiFunc;
            x_abi.Ctx = DW_EE6D3DFB::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::ComplexStructArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::ObjectArraysCB> : public ABIUtilForDelegates<Array<GluonTest::DummyClass>(Array<GluonTest::DummyClass>, Array<GluonTest::DummyClass>&, Array<GluonTest::DummyClass>&)>
    {
        typedef GluonTest::Details::DW_4388047D DW_4388047D;

        static GluonTest::ObjectArraysCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_4388047D::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_4388047D>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<GluonTest::DummyClass> inTest, Array<GluonTest::DummyClass>& outTest, Array<GluonTest::DummyClass>& refTest)
                -> Array<GluonTest::DummyClass> {
                auto inTest_abi = ABIUtil<Array<GluonTest::DummyClass>>::ToABI(inTest);
                ABICallbackRef<Array<GluonTest::DummyClass>> outTest_abi(outTest);
                ABICallbackRef<Array<GluonTest::DummyClass>> refTest_abi(refTest);
                Array<GluonTest::DummyClass> ___ret;
                {
                    ABICallbackRef<Array<GluonTest::DummyClass>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        inTest_abi.begin(), inTest_abi.size(),
                        &outTest_abi.Data, &outTest_abi.Count,
                        &refTest_abi.Data, &refTest_abi.Count,
                        &___ret_abi.Data, &___ret_abi.Count));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::ObjectArraysCB& x)
        {
            ABIOf<GluonTest::ObjectArraysCB> x_abi;
            x_abi.Fn = &DW_4388047D::AbiFunc;
            x_abi.Ctx = DW_4388047D::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::ObjectArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::NamedDelegateArraysCB> : public ABIUtilForDelegates<Array<GluonTest::NamedDelegate>(Array<GluonTest::NamedDelegate>, Array<GluonTest::NamedDelegate>&, Array<GluonTest::NamedDelegate>&)>
    {
        typedef GluonTest::Details::DW_CCD79226 DW_CCD79226;

        static GluonTest::NamedDelegateArraysCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_CCD79226::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_CCD79226>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<GluonTest::NamedDelegate> inTest, Array<GluonTest::NamedDelegate>& outTest, Array<GluonTest::NamedDelegate>& refTest)
                -> Array<GluonTest::NamedDelegate> {
                auto inTest_abi = ABIUtil<Array<GluonTest::NamedDelegate>>::ToABI(inTest);
                ABICallbackRef<Array<GluonTest::NamedDelegate>> outTest_abi(outTest);
                ABICallbackRef<Array<GluonTest::NamedDelegate>> refTest_abi(refTest);
                Array<GluonTest::NamedDelegate> ___ret;
                {
                    ABICallbackRef<Array<GluonTest::NamedDelegate>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        inTest_abi.begin(), inTest_abi.size(),
                        &outTest_abi.Data, &outTest_abi.Count,
                        &refTest_abi.Data, &refTest_abi.Count,
                        &___ret_abi.Data, &___ret_abi.Count));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::NamedDelegateArraysCB& x)
        {
            ABIOf<GluonTest::NamedDelegateArraysCB> x_abi;
            x_abi.Fn = &DW_CCD79226::AbiFunc;
            x_abi.Ctx = DW_CCD79226::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::NamedDelegateArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::GenericDelegateArraysCB> : public ABIUtilForDelegates<Array<Delegate<int(int)>>(Array<Delegate<void(string)>>, Array<Delegate<void(const Delegate<int(int)>&)>>&, Array<Delegate<Array<string>(Array<char>)>>&)>
    {
        typedef GluonTest::Details::DW_F5BD3F9A DW_F5BD3F9A;

        static GluonTest::GenericDelegateArraysCB FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_F5BD3F9A::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_F5BD3F9A>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<Delegate<void(string)>> inTest, Array<Delegate<void(const Delegate<int(int)>&)>>& outTest, Array<Delegate<Array<string>(Array<char>)>>& refTest)
                -> Array<Delegate<int(int)>> {
                auto inTest_abi = ABIUtil<Array<Delegate<void(string)>>>::ToABI(inTest);
                ABICallbackRef<Array<Delegate<void(const Delegate<int(int)>&)>>> outTest_abi(outTest);
                ABICallbackRef<Array<Delegate<Array<string>(Array<char>)>>> refTest_abi(refTest);
                Array<Delegate<int(int)>> ___ret;
                {
                    ABICallbackRef<Array<Delegate<int(int)>>> ___ret_abi(___ret);
                    TRANSLATE_TO_EXCEPTIONS(fn(
                        cp.Get(),
                        inTest_abi.begin(), inTest_abi.size(),
                        &outTest_abi.Data, &outTest_abi.Count,
                        &refTest_abi.Data, &refTest_abi.Count,
                        &___ret_abi.Data, &___ret_abi.Count));
                }
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::GenericDelegateArraysCB& x)
        {
            ABIOf<GluonTest::GenericDelegateArraysCB> x_abi;
            x_abi.Fn = &DW_F5BD3F9A::AbiFunc;
            x_abi.Ctx = DW_F5BD3F9A::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::GenericDelegateArraysCB FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<double(double)>> : public ABIUtilForDelegates<double(double)>
    {
        typedef GluonTest::Details::DW_F757A1ED DW_F757A1ED;

        static Delegate<double(double)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_F757A1ED::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_F757A1ED>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,double,double*)>)fptr, cp = com_ptr<IObject>(ctx)](double arg)
                -> double {
                double ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    arg,
                    ABICallbackRef<double>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<double(double)>& x)
        {
            ABIOf<Delegate<double(double)>> x_abi;
            x_abi.Fn = &DW_F757A1ED::AbiFunc;
            x_abi.Ctx = DW_F757A1ED::GetWrapper(x);
            return x_abi;
        }

        static Delegate<double(double)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<string(Array<char>)>> : public ABIUtilForDelegates<string(Array<char>)>
    {
        typedef GluonTest::Details::DW_F757A1EE DW_F757A1EE;

        static Delegate<string(Array<char>)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_F757A1EE::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_F757A1EE>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,char*,int,char**)>)fptr, cp = com_ptr<IObject>(ctx)](Array<char> arg)
                -> string {
                auto arg_abi = ABIUtil<Array<char>>::ToABI(arg);
                string ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    arg_abi.begin(), arg_abi.size(),
                    ABICallbackRef<string>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<string(Array<char>)>& x)
        {
            ABIOf<Delegate<string(Array<char>)>> x_abi;
            x_abi.Fn = &DW_F757A1EE::AbiFunc;
            x_abi.Ctx = DW_F757A1EE::GetWrapper(x);
            return x_abi;
        }

        static Delegate<string(Array<char>)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::AddSomeShit> : public ABIUtilForDelegates<GluonTest::ITestClass(int, int)>
    {
        typedef GluonTest::Details::DW_FBC9C526 DW_FBC9C526;

        static GluonTest::AddSomeShit FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_FBC9C526::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_FBC9C526>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)>)fptr, cp = com_ptr<IObject>(ctx)](int a, int b)
                -> GluonTest::ITestClass {
                GluonTest::ITestClass ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    a,
                    b,
                    ABICallbackRef<GluonTest::ITestClass>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const GluonTest::AddSomeShit& x)
        {
            ABIOf<GluonTest::AddSomeShit> x_abi;
            x_abi.Fn = &DW_FBC9C526::AbiFunc;
            x_abi.Ctx = DW_FBC9C526::GetWrapper(x);
            return x_abi;
        }

        static GluonTest::AddSomeShit FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<string(char, int)>> : public ABIUtilForDelegates<string(char, int)>
    {
        typedef GluonTest::Details::DW_6FD213D7 DW_6FD213D7;

        static Delegate<string(char, int)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_6FD213D7::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_6FD213D7>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,char,int,char**)>)fptr, cp = com_ptr<IObject>(ctx)](char arg1, int arg2)
                -> string {
                string ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    arg1,
                    arg2,
                    ABICallbackRef<string>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<string(char, int)>& x)
        {
            ABIOf<Delegate<string(char, int)>> x_abi;
            x_abi.Fn = &DW_6FD213D7::AbiFunc;
            x_abi.Ctx = DW_6FD213D7::GetWrapper(x);
            return x_abi;
        }

        static Delegate<string(char, int)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<char(string)>> : public ABIUtilForDelegates<char(string)>
    {
        typedef GluonTest::Details::DW_F757A1EF DW_F757A1EF;

        static Delegate<char(string)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_F757A1EF::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_F757A1EF>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,char*,char*)>)fptr, cp = com_ptr<IObject>(ctx)](string arg)
                -> char {
                char ___ret;
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    ABIUtil<string>::ToABI(arg),
                    ABICallbackRef<char>(___ret)));
                return ___ret;
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<char(string)>& x)
        {
            ABIOf<Delegate<char(string)>> x_abi;
            x_abi.Fn = &DW_F757A1EF::AbiFunc;
            x_abi.Ctx = DW_F757A1EF::GetWrapper(x);
            return x_abi;
        }

        static Delegate<char(string)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };

    template<> struct ABIUtil<Delegate<void(int)>> : public ABIUtilForDelegates<void(int)>
    {
        typedef GluonTest::Details::DW_5C0C3D4E DW_5C0C3D4E;

        static Delegate<void(int)> FromABI(void* fptr, IObject* ctx)
        {
            if (fptr == &DW_5C0C3D4E::AbiFunc)
            {
                auto wrapper = runtime_cast<DW_5C0C3D4E>(ctx);
                if (!wrapper) throw Exception("Unexpected context type for delegate translation");
                return wrapper->Func;
            }

            return [fn = (fn_ptr<HRESULT(IObject*,int)>)fptr, cp = com_ptr<IObject>(ctx)](int obj)
            {
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    obj));
            };
        }

        static ABI::DelegateBlob ToABI(const Delegate<void(int)>& x)
        {
            ABIOf<Delegate<void(int)>> x_abi;
            x_abi.Fn = &DW_5C0C3D4E::AbiFunc;
            x_abi.Ctx = DW_5C0C3D4E::GetWrapper(x);
            return x_abi;
        }

        static Delegate<void(int)> FromABI(const ABI::DelegateBlob& abi)
        {
            return FromABI(abi.Fn, abi.Ctx);
        }
    };
}

namespace GluonInternal
{
    template<> struct ABIUtil<GluonTest::ComplexStruct> : public StructABI<GluonTest::ComplexStruct, ::ABI::GluonTest::ComplexStruct>
    {
        static GluonTest::ComplexStruct FromABI(const ::ABI::GluonTest::ComplexStruct& x)
        {
            return GluonTest::ComplexStruct(
                ABIUtil<string>::FromABI(x.Name),
                x.Sub,
                ABIUtil<GluonTest::DummyClass>::FromABI(x.Obj),
                ABIUtil<Delegate<int(int, int)>>::FromABI(x.Del));
        }

        static ::ABI::GluonTest::ComplexStruct ToABI(const GluonTest::ComplexStruct& x)
        {
            auto Del_ = ABIUtil<Delegate<int(int, int)>>::ToABI(x.Del);
            return ::ABI::GluonTest::ComplexStruct(
                ABIUtil<string>::ToABI(x.Name),
                x.Sub,
                ABIUtil<GluonTest::DummyClass>::ToABI(x.Obj),
                (fn_ptr<HRESULT(IObject*,int,int,int*)>)Del_.Fn, Del_.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::StructMemberTest> : public StructABI<GluonTest::StructMemberTest, ::ABI::GluonTest::StructMemberTest>
    {
        static GluonTest::StructMemberTest FromABI(const ::ABI::GluonTest::StructMemberTest& x)
        {
            return GluonTest::StructMemberTest(
                x.Boolean,
                x.Primitive,
                x.PrimitivePtr,
                ABIUtil<string>::FromABI(x.String),
                x.BlittableSt,
                ABIUtil<GluonTest::ComplexStruct>::FromABI(x.ComplexSt),
                ABIUtil<GluonTest::DummyClass>::FromABI(x.Object),
                ABIUtil<GluonTest::NamedDelegate>::FromABI(x.NamedDelegate),
                ABIUtil<Delegate<double(double)>>::FromABI(x.GenericDelegate));
        }

        static ::ABI::GluonTest::StructMemberTest ToABI(const GluonTest::StructMemberTest& x)
        {
            auto NamedDelegate_ = ABIUtil<GluonTest::NamedDelegate>::ToABI(x.NamedDelegate);
            auto GenericDelegate_ = ABIUtil<Delegate<double(double)>>::ToABI(x.GenericDelegate);
            return ::ABI::GluonTest::StructMemberTest(
                x.Boolean,
                x.Primitive,
                x.PrimitivePtr,
                ABIUtil<string>::ToABI(x.String),
                x.BlittableSt,
                ABIUtil<GluonTest::ComplexStruct>::ToABI(x.ComplexSt),
                ABIUtil<GluonTest::DummyClass>::ToABI(x.Object),
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)NamedDelegate_.Fn, NamedDelegate_.Ctx,
                (fn_ptr<HRESULT(IObject*,double,double*)>)GenericDelegate_.Fn, GenericDelegate_.Ctx);
        }
    };

    template<> struct ABIUtil<GluonTest::TestStruct> : public StructABI<GluonTest::TestStruct, ::ABI::GluonTest::TestStruct>
    {
        static GluonTest::TestStruct FromABI(const ::ABI::GluonTest::TestStruct& x)
        {
            return GluonTest::TestStruct(
                x.a,
                x.b,
                x.c,
                x.d,
                ABIUtil<string>::FromABI(x.e),
                ABIUtil<Array<int>>::FromABI(x.f));
        }

        static ::ABI::GluonTest::TestStruct ToABI(const GluonTest::TestStruct& x)
        {
            auto f_ = ABIUtil<Array<int>>::ToABI(x.f);
            return ::ABI::GluonTest::TestStruct(
                x.a,
                x.b,
                x.c,
                x.d,
                ABIUtil<string>::ToABI(x.e),
                f_.begin(), (int)f_.size());
        }
    };
}

namespace GluonTest::Details
{
    template<typename>
    HRESULT DW_6FD213D6::__P_AbiFunc(IObject* __i_, int arg1, int arg2, int* ___ret)
    {
        auto ___del = runtime_cast<DW_6FD213D6>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;

        try {
            *___ret = ___del->Func(
                arg1,
                arg2);
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_F8ED26DB::__P_AbiFunc(IObject* __i_, char* a, char* b, int* ___ret)
    {
        auto ___del = runtime_cast<DW_F8ED26DB>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;

        try {
            *___ret = ___del->Func(
                ABIUtil<string>::FromABI(a),
                ABIUtil<string>::FromABI(b));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_1B83CCC6::__P_AbiFunc(IObject* __i_, bool inTest, char* outTest, int* refTest, double* ___ret)
    {
        auto ___del = runtime_cast<DW_1B83CCC6>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        try {
            *___ret = ___del->Func(
                inTest,
                ABIUtil<char>::Ref(outTest),
                ABIUtil<int>::Ref(refTest));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_E24BCA44::__P_AbiFunc(IObject* __i_, char* inTest, char** outTest, char** refTest, char** ___ret)
    {
        auto ___del = runtime_cast<DW_E24BCA44>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        try {
            *___ret = ABIUtil<string>::ToABI(___del->Func(
                ABIUtil<string>::FromABI(inTest),
                ABIUtil<string>::Ref(outTest),
                ABIUtil<string>::Ref(refTest)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_CA433402::__P_AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct inTest, ::ABI::GluonTest::BlittableStruct* outTest, ::ABI::GluonTest::BlittableStruct* refTest, ::ABI::GluonTest::BlittableStruct* ___ret)
    {
        auto ___del = runtime_cast<DW_CA433402>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        try {
            *___ret = ___del->Func(
                inTest,
                ABIUtil<GluonTest::BlittableStruct>::Ref(outTest),
                ABIUtil<GluonTest::BlittableStruct>::Ref(refTest));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_10105E22::__P_AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct inTest, ::ABI::GluonTest::ComplexStruct* outTest, ::ABI::GluonTest::ComplexStruct* refTest, ::ABI::GluonTest::ComplexStruct* ___ret)
    {
        auto ___del = runtime_cast<DW_10105E22>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        try {
            *___ret = ABIUtil<GluonTest::ComplexStruct>::ToABI(___del->Func(
                ABIUtil<GluonTest::ComplexStruct>::FromABI(inTest),
                ABIUtil<GluonTest::ComplexStruct>::Ref(outTest),
                ABIUtil<GluonTest::ComplexStruct>::Ref(refTest)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_95E0837A::__P_AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass* inTest, ::ABI::GluonTest::DummyClass** outTest, ::ABI::GluonTest::DummyClass** refTest, ::ABI::GluonTest::DummyClass** ___ret)
    {
        auto ___del = runtime_cast<DW_95E0837A>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!___ret) return E_POINTER;

        try {
            *___ret = ABIUtil<GluonTest::DummyClass>::ToABI(___del->Func(
                ABIUtil<GluonTest::DummyClass>::FromABI(inTest),
                ABIUtil<GluonTest::DummyClass>::Ref(outTest),
                ABIUtil<GluonTest::DummyClass>::Ref(refTest)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_F2E7AE0D::__P_AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*,char*,int*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,char*,char*,int*)>* ___ret, IObject** ___ret_context)
    {
        auto ___del = runtime_cast<DW_F2E7AE0D>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_context) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_context) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_context) return E_POINTER;

        try {
            ABI::DelegateRef<fn_ptr<HRESULT(IObject*,char*,char*,int*)>>(___ret, ___ret_context) = ABIUtil<GluonTest::NamedDelegate>::ToABI(___del->Func(
                ABIUtil<GluonTest::NamedDelegate>::FromABI((void**)inTest, inTest_context),
                ABIUtil<GluonTest::NamedDelegate>::Ref((void**)outTest, outTest_context),
                ABIUtil<GluonTest::NamedDelegate>::Ref((void**)refTest, refTest_context)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_D744D573::__P_AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,char*)> inTest, IObject* inTest_context, fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>* outTest, IObject** outTest_context, fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>* refTest, IObject** refTest_context, fn_ptr<HRESULT(IObject*,int,int*)>* ___ret, IObject** ___ret_context)
    {
        auto ___del = runtime_cast<DW_D744D573>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_context) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_context) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_context) return E_POINTER;

        try {
            ABI::DelegateRef<fn_ptr<HRESULT(IObject*,int,int*)>>(___ret, ___ret_context) = ABIUtil<Delegate<int(int)>>::ToABI(___del->Func(
                ABIUtil<Delegate<void(string)>>::FromABI((void**)inTest, inTest_context),
                ABIUtil<Delegate<void(const Delegate<int(int)>&)>>::Ref((void**)outTest, outTest_context),
                ABIUtil<Delegate<Array<string>(Array<char>)>>::Ref((void**)refTest, refTest_context)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_F757A1EB::__P_AbiFunc(IObject* __i_, int arg, int* ___ret)
    {
        auto ___del = runtime_cast<DW_F757A1EB>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;

        try {
            *___ret = ___del->Func(arg);
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_5C0C3D4C::__P_AbiFunc(IObject* __i_, char* obj)
    {
        auto ___del = runtime_cast<DW_5C0C3D4C>(__i_);
        if (!___del) return E_FAIL;

        try {
            ___del->Func(ABIUtil<string>::FromABI(obj));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_5C0C3D4D::__P_AbiFunc(IObject* __i_, fn_ptr<HRESULT(IObject*,int,int*)> obj, IObject* obj_context)
    {
        auto ___del = runtime_cast<DW_5C0C3D4D>(__i_);
        if (!___del) return E_FAIL;

        try {
            ___del->Func(ABIUtil<Delegate<int(int)>>::FromABI((void**)obj, obj_context));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_F757A1EC::__P_AbiFunc(IObject* __i_, char* arg, int arg_count, char*** ___ret, int* ___ret_count)
    {
        auto ___del = runtime_cast<DW_F757A1EC>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        try {
            ABI::ArrayRef<char*>(___ret, ___ret_count) = ABIUtil<Array<string>>::ToABI(___del->Func(ABIUtil<Array<char>>::FromABI(arg, arg_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_C30682FD::__P_AbiFunc(IObject* __i_, bool* inTest, int inTest_count, char** outTest, int* outTest_count, int** refTest, int* refTest_count, double** ___ret, int* ___ret_count)
    {
        auto ___del = runtime_cast<DW_C30682FD>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        try {
            ABI::ArrayRef<double>(___ret, ___ret_count) = ABIUtil<Array<double>>::ToABI(___del->Func(
                ABIUtil<Array<bool>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<char>>::Ref(outTest, outTest_count),
                ABIUtil<Array<int>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_B2F37841::__P_AbiFunc(IObject* __i_, char** inTest, int inTest_count, char*** outTest, int* outTest_count, char*** refTest, int* refTest_count, char*** ___ret, int* ___ret_count)
    {
        auto ___del = runtime_cast<DW_B2F37841>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        try {
            ABI::ArrayRef<char*>(___ret, ___ret_count) = ABIUtil<Array<string>>::ToABI(___del->Func(
                ABIUtil<Array<string>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<string>>::Ref(outTest, outTest_count),
                ABIUtil<Array<string>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_B28180A5::__P_AbiFunc(IObject* __i_, ::ABI::GluonTest::BlittableStruct* inTest, int inTest_count, ::ABI::GluonTest::BlittableStruct** outTest, int* outTest_count, ::ABI::GluonTest::BlittableStruct** refTest, int* refTest_count, ::ABI::GluonTest::BlittableStruct** ___ret, int* ___ret_count)
    {
        auto ___del = runtime_cast<DW_B28180A5>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        try {
            ABI::ArrayRef<::ABI::GluonTest::BlittableStruct>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::BlittableStruct>>::ToABI(___del->Func(
                ABIUtil<Array<GluonTest::BlittableStruct>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<GluonTest::BlittableStruct>>::Ref(outTest, outTest_count),
                ABIUtil<Array<GluonTest::BlittableStruct>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_EE6D3DFB::__P_AbiFunc(IObject* __i_, ::ABI::GluonTest::ComplexStruct* inTest, int inTest_count, ::ABI::GluonTest::ComplexStruct** outTest, int* outTest_count, ::ABI::GluonTest::ComplexStruct** refTest, int* refTest_count, ::ABI::GluonTest::ComplexStruct** ___ret, int* ___ret_count)
    {
        auto ___del = runtime_cast<DW_EE6D3DFB>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        try {
            ABI::ArrayRef<::ABI::GluonTest::ComplexStruct>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::ComplexStruct>>::ToABI(___del->Func(
                ABIUtil<Array<GluonTest::ComplexStruct>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<GluonTest::ComplexStruct>>::Ref(outTest, outTest_count),
                ABIUtil<Array<GluonTest::ComplexStruct>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_4388047D::__P_AbiFunc(IObject* __i_, ::ABI::GluonTest::DummyClass** inTest, int inTest_count, ::ABI::GluonTest::DummyClass*** outTest, int* outTest_count, ::ABI::GluonTest::DummyClass*** refTest, int* refTest_count, ::ABI::GluonTest::DummyClass*** ___ret, int* ___ret_count)
    {
        auto ___del = runtime_cast<DW_4388047D>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        try {
            ABI::ArrayRef<::ABI::GluonTest::DummyClass*>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::DummyClass>>::ToABI(___del->Func(
                ABIUtil<Array<GluonTest::DummyClass>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<GluonTest::DummyClass>>::Ref(outTest, outTest_count),
                ABIUtil<Array<GluonTest::DummyClass>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_CCD79226::__P_AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count)
    {
        auto ___del = runtime_cast<DW_CCD79226>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        try {
            ABI::ArrayRef<ABI::DelegateBlob>(___ret, ___ret_count) = ABIUtil<Array<GluonTest::NamedDelegate>>::ToABI(___del->Func(
                ABIUtil<Array<GluonTest::NamedDelegate>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<GluonTest::NamedDelegate>>::Ref(outTest, outTest_count),
                ABIUtil<Array<GluonTest::NamedDelegate>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_F5BD3F9A::__P_AbiFunc(IObject* __i_, ABI::DelegateBlob* inTest, int inTest_count, ABI::DelegateBlob** outTest, int* outTest_count, ABI::DelegateBlob** refTest, int* refTest_count, ABI::DelegateBlob** ___ret, int* ___ret_count)
    {
        auto ___del = runtime_cast<DW_F5BD3F9A>(__i_);
        if (!___del) return E_FAIL;

        if(!outTest) return E_POINTER;
        if(!outTest_count) return E_POINTER;
        if(!refTest) return E_POINTER;
        if(!refTest_count) return E_POINTER;
        if(!___ret) return E_POINTER;
        if(!___ret_count) return E_POINTER;

        try {
            ABI::ArrayRef<ABI::DelegateBlob>(___ret, ___ret_count) = ABIUtil<Array<Delegate<int(int)>>>::ToABI(___del->Func(
                ABIUtil<Array<Delegate<void(string)>>>::FromABI(inTest, inTest_count),
                ABIUtil<Array<Delegate<void(const Delegate<int(int)>&)>>>::Ref(outTest, outTest_count),
                ABIUtil<Array<Delegate<Array<string>(Array<char>)>>>::Ref(refTest, refTest_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_F757A1ED::__P_AbiFunc(IObject* __i_, double arg, double* ___ret)
    {
        auto ___del = runtime_cast<DW_F757A1ED>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;

        try {
            *___ret = ___del->Func(arg);
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_F757A1EE::__P_AbiFunc(IObject* __i_, char* arg, int arg_count, char** ___ret)
    {
        auto ___del = runtime_cast<DW_F757A1EE>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;

        try {
            *___ret = ABIUtil<string>::ToABI(___del->Func(ABIUtil<Array<char>>::FromABI(arg, arg_count)));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_FBC9C526::__P_AbiFunc(IObject* __i_, int a, int b, ::ABI::GluonTest::ITestClass** ___ret)
    {
        auto ___del = runtime_cast<DW_FBC9C526>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;

        try {
            *___ret = ABIUtil<GluonTest::ITestClass>::ToABI(___del->Func(
                a,
                b));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_6FD213D7::__P_AbiFunc(IObject* __i_, char arg1, int arg2, char** ___ret)
    {
        auto ___del = runtime_cast<DW_6FD213D7>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;

        try {
            *___ret = ABIUtil<string>::ToABI(___del->Func(
                arg1,
                arg2));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_F757A1EF::__P_AbiFunc(IObject* __i_, char* arg, char* ___ret)
    {
        auto ___del = runtime_cast<DW_F757A1EF>(__i_);
        if (!___del) return E_FAIL;

        if(!___ret) return E_POINTER;

        try {
            *___ret = ___del->Func(ABIUtil<string>::FromABI(arg));
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }

    template<typename>
    HRESULT DW_5C0C3D4E::__P_AbiFunc(IObject* __i_, int obj)
    {
        auto ___del = runtime_cast<DW_5C0C3D4E>(__i_);
        if (!___del) return E_FAIL;

        try {
            ___del->Func(obj);
            return S_OK;
        } TRANSLATE_EXCEPTIONS
    }
}

namespace GluonInternal
{
    static Delegate<int(int, int)> GluonInternal::ABIUtil<Delegate<int(int, int)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_6FD213D6::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_6FD213D6>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,int,int,int*)>)fptr, cp = com_ptr<IObject>(ctx)](int arg1, int arg2)
            -> int {
            int ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                arg1,
                arg2,
                ABICallbackRef<int>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<Delegate<int(int, int)>> GluonInternal::ABIUtil<Delegate<int(int, int)>>::ToABI(const Delegate<int(int, int)>& x)
    {
        ABIOf<Delegate<int(int, int)>> x_abi;
        x_abi.Fn = &DW_6FD213D6::AbiFunc;
        x_abi.Ctx = DW_6FD213D6::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::NamedDelegate GluonInternal::ABIUtil<GluonTest::NamedDelegate>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_F8ED26DB::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_F8ED26DB>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)fptr, cp = com_ptr<IObject>(ctx)](string a, string b)
            -> int {
            int ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                ABIUtil<string>::ToABI(a),
                ABIUtil<string>::ToABI(b),
                ABICallbackRef<int>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<GluonTest::NamedDelegate> GluonInternal::ABIUtil<GluonTest::NamedDelegate>::ToABI(const GluonTest::NamedDelegate& x)
    {
        ABIOf<GluonTest::NamedDelegate> x_abi;
        x_abi.Fn = &DW_F8ED26DB::AbiFunc;
        x_abi.Ctx = DW_F8ED26DB::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::PrimitivesCB GluonInternal::ABIUtil<GluonTest::PrimitivesCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_1B83CCC6::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_1B83CCC6>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>)fptr, cp = com_ptr<IObject>(ctx)](bool inTest, char& outTest, int& refTest)
            -> double {
            double ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                inTest,
                ABICallbackRef<char>(outTest),
                ABICallbackRef<int>(refTest),
                ABICallbackRef<double>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<GluonTest::PrimitivesCB> GluonInternal::ABIUtil<GluonTest::PrimitivesCB>::ToABI(const GluonTest::PrimitivesCB& x)
    {
        ABIOf<GluonTest::PrimitivesCB> x_abi;
        x_abi.Fn = &DW_1B83CCC6::AbiFunc;
        x_abi.Ctx = DW_1B83CCC6::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::StringsCB GluonInternal::ABIUtil<GluonTest::StringsCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_E24BCA44::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_E24BCA44>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>)fptr, cp = com_ptr<IObject>(ctx)](string inTest, string& outTest, string& refTest)
            -> string {
            string ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                ABIUtil<string>::ToABI(inTest),
                ABICallbackRef<string>(outTest),
                ABICallbackRef<string>(refTest),
                ABICallbackRef<string>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<GluonTest::StringsCB> GluonInternal::ABIUtil<GluonTest::StringsCB>::ToABI(const GluonTest::StringsCB& x)
    {
        ABIOf<GluonTest::StringsCB> x_abi;
        x_abi.Fn = &DW_E24BCA44::AbiFunc;
        x_abi.Ctx = DW_E24BCA44::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::SimpleStructsCB GluonInternal::ABIUtil<GluonTest::SimpleStructsCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_CA433402::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_CA433402>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)>)fptr, cp = com_ptr<IObject>(ctx)](const GluonTest::BlittableStruct& inTest, GluonTest::BlittableStruct& outTest, GluonTest::BlittableStruct& refTest)
            -> GluonTest::BlittableStruct {
            GluonTest::BlittableStruct ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                inTest,
                ABICallbackRef<GluonTest::BlittableStruct>(outTest),
                ABICallbackRef<GluonTest::BlittableStruct>(refTest),
                ABICallbackRef<GluonTest::BlittableStruct>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<GluonTest::SimpleStructsCB> GluonInternal::ABIUtil<GluonTest::SimpleStructsCB>::ToABI(const GluonTest::SimpleStructsCB& x)
    {
        ABIOf<GluonTest::SimpleStructsCB> x_abi;
        x_abi.Fn = &DW_CA433402::AbiFunc;
        x_abi.Ctx = DW_CA433402::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::ComplexStructsCB GluonInternal::ABIUtil<GluonTest::ComplexStructsCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_10105E22::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_10105E22>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)>)fptr, cp = com_ptr<IObject>(ctx)](const GluonTest::ComplexStruct& inTest, GluonTest::ComplexStruct& outTest, GluonTest::ComplexStruct& refTest)
            -> GluonTest::ComplexStruct {
            GluonTest::ComplexStruct ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                ABIUtil<GluonTest::ComplexStruct>::ToABI(inTest),
                ABICallbackRef<GluonTest::ComplexStruct>(outTest),
                ABICallbackRef<GluonTest::ComplexStruct>(refTest),
                ABICallbackRef<GluonTest::ComplexStruct>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<GluonTest::ComplexStructsCB> GluonInternal::ABIUtil<GluonTest::ComplexStructsCB>::ToABI(const GluonTest::ComplexStructsCB& x)
    {
        ABIOf<GluonTest::ComplexStructsCB> x_abi;
        x_abi.Fn = &DW_10105E22::AbiFunc;
        x_abi.Ctx = DW_10105E22::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::ObjectsCB GluonInternal::ABIUtil<GluonTest::ObjectsCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_95E0837A::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_95E0837A>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)>)fptr, cp = com_ptr<IObject>(ctx)](const GluonTest::DummyClass& inTest, GluonTest::DummyClass& outTest, GluonTest::DummyClass& refTest)
            -> GluonTest::DummyClass {
            GluonTest::DummyClass ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                ABIUtil<GluonTest::DummyClass>::ToABI(inTest),
                ABICallbackRef<GluonTest::DummyClass>(outTest),
                ABICallbackRef<GluonTest::DummyClass>(refTest),
                ABICallbackRef<GluonTest::DummyClass>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<GluonTest::ObjectsCB> GluonInternal::ABIUtil<GluonTest::ObjectsCB>::ToABI(const GluonTest::ObjectsCB& x)
    {
        ABIOf<GluonTest::ObjectsCB> x_abi;
        x_abi.Fn = &DW_95E0837A::AbiFunc;
        x_abi.Ctx = DW_95E0837A::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::NamedDelegatesCB GluonInternal::ABIUtil<GluonTest::NamedDelegatesCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_F2E7AE0D::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_F2E7AE0D>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>)fptr, cp = com_ptr<IObject>(ctx)](const GluonTest::NamedDelegate& inTest, GluonTest::NamedDelegate& outTest, GluonTest::NamedDelegate& refTest)
            -> GluonTest::NamedDelegate {
            auto inTest_abi = ABIUtil<GluonTest::NamedDelegate>::ToABI(inTest);
            ABICallbackRef<GluonTest::NamedDelegate> outTest_abi(outTest);
            ABICallbackRef<GluonTest::NamedDelegate> refTest_abi(refTest);
            GluonTest::NamedDelegate ___ret;
            {
                ABICallbackRef<GluonTest::NamedDelegate> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)inTest_abi.Fn, inTest_abi.Ctx,
                    (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&outTest_abi.Fn, &outTest_abi.Ctx,
                    (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&refTest_abi.Fn, &refTest_abi.Ctx,
                    (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::NamedDelegatesCB> GluonInternal::ABIUtil<GluonTest::NamedDelegatesCB>::ToABI(const GluonTest::NamedDelegatesCB& x)
    {
        ABIOf<GluonTest::NamedDelegatesCB> x_abi;
        x_abi.Fn = &DW_F2E7AE0D::AbiFunc;
        x_abi.Ctx = DW_F2E7AE0D::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::GenericDelegatesCB GluonInternal::ABIUtil<GluonTest::GenericDelegatesCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_D744D573::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_D744D573>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>)fptr, cp = com_ptr<IObject>(ctx)](const Delegate<void(string)>& inTest, Delegate<void(const Delegate<int(int)>&)>& outTest, Delegate<Array<string>(Array<char>)>& refTest)
            -> Delegate<int(int)> {
            auto inTest_abi = ABIUtil<Delegate<void(string)>>::ToABI(inTest);
            ABICallbackRef<Delegate<void(const Delegate<int(int)>&)>> outTest_abi(outTest);
            ABICallbackRef<Delegate<Array<string>(Array<char>)>> refTest_abi(refTest);
            Delegate<int(int)> ___ret;
            {
                ABICallbackRef<Delegate<int(int)>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    (fn_ptr<HRESULT(IObject*,char*)>)inTest_abi.Fn, inTest_abi.Ctx,
                    (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*)&outTest_abi.Fn, &outTest_abi.Ctx,
                    (fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*)&refTest_abi.Fn, &refTest_abi.Ctx,
                    (fn_ptr<HRESULT(IObject*,int,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::GenericDelegatesCB> GluonInternal::ABIUtil<GluonTest::GenericDelegatesCB>::ToABI(const GluonTest::GenericDelegatesCB& x)
    {
        ABIOf<GluonTest::GenericDelegatesCB> x_abi;
        x_abi.Fn = &DW_D744D573::AbiFunc;
        x_abi.Ctx = DW_D744D573::GetWrapper(x);
        return x_abi;
    }

    static Delegate<int(int)> GluonInternal::ABIUtil<Delegate<int(int)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_F757A1EB::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_F757A1EB>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,int,int*)>)fptr, cp = com_ptr<IObject>(ctx)](int arg)
            -> int {
            int ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                arg,
                ABICallbackRef<int>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<Delegate<int(int)>> GluonInternal::ABIUtil<Delegate<int(int)>>::ToABI(const Delegate<int(int)>& x)
    {
        ABIOf<Delegate<int(int)>> x_abi;
        x_abi.Fn = &DW_F757A1EB::AbiFunc;
        x_abi.Ctx = DW_F757A1EB::GetWrapper(x);
        return x_abi;
    }

    static Delegate<void(string)> GluonInternal::ABIUtil<Delegate<void(string)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_5C0C3D4C::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_5C0C3D4C>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,char*)>)fptr, cp = com_ptr<IObject>(ctx)](string obj)
        {
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                ABIUtil<string>::ToABI(obj)));
        };
    }

    static ABIOf<Delegate<void(string)>> GluonInternal::ABIUtil<Delegate<void(string)>>::ToABI(const Delegate<void(string)>& x)
    {
        ABIOf<Delegate<void(string)>> x_abi;
        x_abi.Fn = &DW_5C0C3D4C::AbiFunc;
        x_abi.Ctx = DW_5C0C3D4C::GetWrapper(x);
        return x_abi;
    }

    static Delegate<void(const Delegate<int(int)>&)> GluonInternal::ABIUtil<Delegate<void(const Delegate<int(int)>&)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_5C0C3D4D::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_5C0C3D4D>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>)fptr, cp = com_ptr<IObject>(ctx)](const Delegate<int(int)>& obj)
        {
            auto obj_abi = ABIUtil<Delegate<int(int)>>::ToABI(obj);
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                (fn_ptr<HRESULT(IObject*,int,int*)>)obj_abi.Fn, obj_abi.Ctx));
        };
    }

    static ABIOf<Delegate<void(const Delegate<int(int)>&)>> GluonInternal::ABIUtil<Delegate<void(const Delegate<int(int)>&)>>::ToABI(const Delegate<void(const Delegate<int(int)>&)>& x)
    {
        ABIOf<Delegate<void(const Delegate<int(int)>&)>> x_abi;
        x_abi.Fn = &DW_5C0C3D4D::AbiFunc;
        x_abi.Ctx = DW_5C0C3D4D::GetWrapper(x);
        return x_abi;
    }

    static Delegate<Array<string>(Array<char>)> GluonInternal::ABIUtil<Delegate<Array<string>(Array<char>)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_F757A1EC::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_F757A1EC>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<char> arg)
            -> Array<string> {
            auto arg_abi = ABIUtil<Array<char>>::ToABI(arg);
            Array<string> ___ret;
            {
                ABICallbackRef<Array<string>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    arg_abi.begin(), arg_abi.size(),
                    &___ret_abi.Data, &___ret_abi.Count));
            }
            return ___ret;
        };
    }

    static ABIOf<Delegate<Array<string>(Array<char>)>> GluonInternal::ABIUtil<Delegate<Array<string>(Array<char>)>>::ToABI(const Delegate<Array<string>(Array<char>)>& x)
    {
        ABIOf<Delegate<Array<string>(Array<char>)>> x_abi;
        x_abi.Fn = &DW_F757A1EC::AbiFunc;
        x_abi.Ctx = DW_F757A1EC::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::PrimitiveArraysCB GluonInternal::ABIUtil<GluonTest::PrimitiveArraysCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_C30682FD::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_C30682FD>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<bool> inTest, Array<char>& outTest, Array<int>& refTest)
            -> Array<double> {
            auto inTest_abi = ABIUtil<Array<bool>>::ToABI(inTest);
            ABICallbackRef<Array<char>> outTest_abi(outTest);
            ABICallbackRef<Array<int>> refTest_abi(refTest);
            Array<double> ___ret;
            {
                ABICallbackRef<Array<double>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest_abi.begin(), inTest_abi.size(),
                    &outTest_abi.Data, &outTest_abi.Count,
                    &refTest_abi.Data, &refTest_abi.Count,
                    &___ret_abi.Data, &___ret_abi.Count));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::PrimitiveArraysCB> GluonInternal::ABIUtil<GluonTest::PrimitiveArraysCB>::ToABI(const GluonTest::PrimitiveArraysCB& x)
    {
        ABIOf<GluonTest::PrimitiveArraysCB> x_abi;
        x_abi.Fn = &DW_C30682FD::AbiFunc;
        x_abi.Ctx = DW_C30682FD::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::StringArraysCB GluonInternal::ABIUtil<GluonTest::StringArraysCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_B2F37841::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_B2F37841>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<string> inTest, Array<string>& outTest, Array<string>& refTest)
            -> Array<string> {
            auto inTest_abi = ABIUtil<Array<string>>::ToABI(inTest);
            ABICallbackRef<Array<string>> outTest_abi(outTest);
            ABICallbackRef<Array<string>> refTest_abi(refTest);
            Array<string> ___ret;
            {
                ABICallbackRef<Array<string>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest_abi.begin(), inTest_abi.size(),
                    &outTest_abi.Data, &outTest_abi.Count,
                    &refTest_abi.Data, &refTest_abi.Count,
                    &___ret_abi.Data, &___ret_abi.Count));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::StringArraysCB> GluonInternal::ABIUtil<GluonTest::StringArraysCB>::ToABI(const GluonTest::StringArraysCB& x)
    {
        ABIOf<GluonTest::StringArraysCB> x_abi;
        x_abi.Fn = &DW_B2F37841::AbiFunc;
        x_abi.Ctx = DW_B2F37841::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::SimpleStructArraysCB GluonInternal::ABIUtil<GluonTest::SimpleStructArraysCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_B28180A5::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_B28180A5>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<GluonTest::BlittableStruct> inTest, Array<GluonTest::BlittableStruct>& outTest, Array<GluonTest::BlittableStruct>& refTest)
            -> Array<GluonTest::BlittableStruct> {
            auto inTest_abi = ABIUtil<Array<GluonTest::BlittableStruct>>::ToABI(inTest);
            ABICallbackRef<Array<GluonTest::BlittableStruct>> outTest_abi(outTest);
            ABICallbackRef<Array<GluonTest::BlittableStruct>> refTest_abi(refTest);
            Array<GluonTest::BlittableStruct> ___ret;
            {
                ABICallbackRef<Array<GluonTest::BlittableStruct>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest_abi.begin(), inTest_abi.size(),
                    &outTest_abi.Data, &outTest_abi.Count,
                    &refTest_abi.Data, &refTest_abi.Count,
                    &___ret_abi.Data, &___ret_abi.Count));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::SimpleStructArraysCB> GluonInternal::ABIUtil<GluonTest::SimpleStructArraysCB>::ToABI(const GluonTest::SimpleStructArraysCB& x)
    {
        ABIOf<GluonTest::SimpleStructArraysCB> x_abi;
        x_abi.Fn = &DW_B28180A5::AbiFunc;
        x_abi.Ctx = DW_B28180A5::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::ComplexStructArraysCB GluonInternal::ABIUtil<GluonTest::ComplexStructArraysCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_EE6D3DFB::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_EE6D3DFB>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<GluonTest::ComplexStruct> inTest, Array<GluonTest::ComplexStruct>& outTest, Array<GluonTest::ComplexStruct>& refTest)
            -> Array<GluonTest::ComplexStruct> {
            auto inTest_abi = ABIUtil<Array<GluonTest::ComplexStruct>>::ToABI(inTest);
            ABICallbackRef<Array<GluonTest::ComplexStruct>> outTest_abi(outTest);
            ABICallbackRef<Array<GluonTest::ComplexStruct>> refTest_abi(refTest);
            Array<GluonTest::ComplexStruct> ___ret;
            {
                ABICallbackRef<Array<GluonTest::ComplexStruct>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest_abi.begin(), inTest_abi.size(),
                    &outTest_abi.Data, &outTest_abi.Count,
                    &refTest_abi.Data, &refTest_abi.Count,
                    &___ret_abi.Data, &___ret_abi.Count));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::ComplexStructArraysCB> GluonInternal::ABIUtil<GluonTest::ComplexStructArraysCB>::ToABI(const GluonTest::ComplexStructArraysCB& x)
    {
        ABIOf<GluonTest::ComplexStructArraysCB> x_abi;
        x_abi.Fn = &DW_EE6D3DFB::AbiFunc;
        x_abi.Ctx = DW_EE6D3DFB::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::ObjectArraysCB GluonInternal::ABIUtil<GluonTest::ObjectArraysCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_4388047D::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_4388047D>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<GluonTest::DummyClass> inTest, Array<GluonTest::DummyClass>& outTest, Array<GluonTest::DummyClass>& refTest)
            -> Array<GluonTest::DummyClass> {
            auto inTest_abi = ABIUtil<Array<GluonTest::DummyClass>>::ToABI(inTest);
            ABICallbackRef<Array<GluonTest::DummyClass>> outTest_abi(outTest);
            ABICallbackRef<Array<GluonTest::DummyClass>> refTest_abi(refTest);
            Array<GluonTest::DummyClass> ___ret;
            {
                ABICallbackRef<Array<GluonTest::DummyClass>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest_abi.begin(), inTest_abi.size(),
                    &outTest_abi.Data, &outTest_abi.Count,
                    &refTest_abi.Data, &refTest_abi.Count,
                    &___ret_abi.Data, &___ret_abi.Count));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::ObjectArraysCB> GluonInternal::ABIUtil<GluonTest::ObjectArraysCB>::ToABI(const GluonTest::ObjectArraysCB& x)
    {
        ABIOf<GluonTest::ObjectArraysCB> x_abi;
        x_abi.Fn = &DW_4388047D::AbiFunc;
        x_abi.Ctx = DW_4388047D::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::NamedDelegateArraysCB GluonInternal::ABIUtil<GluonTest::NamedDelegateArraysCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_CCD79226::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_CCD79226>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<GluonTest::NamedDelegate> inTest, Array<GluonTest::NamedDelegate>& outTest, Array<GluonTest::NamedDelegate>& refTest)
            -> Array<GluonTest::NamedDelegate> {
            auto inTest_abi = ABIUtil<Array<GluonTest::NamedDelegate>>::ToABI(inTest);
            ABICallbackRef<Array<GluonTest::NamedDelegate>> outTest_abi(outTest);
            ABICallbackRef<Array<GluonTest::NamedDelegate>> refTest_abi(refTest);
            Array<GluonTest::NamedDelegate> ___ret;
            {
                ABICallbackRef<Array<GluonTest::NamedDelegate>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest_abi.begin(), inTest_abi.size(),
                    &outTest_abi.Data, &outTest_abi.Count,
                    &refTest_abi.Data, &refTest_abi.Count,
                    &___ret_abi.Data, &___ret_abi.Count));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::NamedDelegateArraysCB> GluonInternal::ABIUtil<GluonTest::NamedDelegateArraysCB>::ToABI(const GluonTest::NamedDelegateArraysCB& x)
    {
        ABIOf<GluonTest::NamedDelegateArraysCB> x_abi;
        x_abi.Fn = &DW_CCD79226::AbiFunc;
        x_abi.Ctx = DW_CCD79226::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::GenericDelegateArraysCB GluonInternal::ABIUtil<GluonTest::GenericDelegateArraysCB>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_F5BD3F9A::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_F5BD3F9A>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>)fptr, cp = com_ptr<IObject>(ctx)](Array<Delegate<void(string)>> inTest, Array<Delegate<void(const Delegate<int(int)>&)>>& outTest, Array<Delegate<Array<string>(Array<char>)>>& refTest)
            -> Array<Delegate<int(int)>> {
            auto inTest_abi = ABIUtil<Array<Delegate<void(string)>>>::ToABI(inTest);
            ABICallbackRef<Array<Delegate<void(const Delegate<int(int)>&)>>> outTest_abi(outTest);
            ABICallbackRef<Array<Delegate<Array<string>(Array<char>)>>> refTest_abi(refTest);
            Array<Delegate<int(int)>> ___ret;
            {
                ABICallbackRef<Array<Delegate<int(int)>>> ___ret_abi(___ret);
                TRANSLATE_TO_EXCEPTIONS(fn(
                    cp.Get(),
                    inTest_abi.begin(), inTest_abi.size(),
                    &outTest_abi.Data, &outTest_abi.Count,
                    &refTest_abi.Data, &refTest_abi.Count,
                    &___ret_abi.Data, &___ret_abi.Count));
            }
            return ___ret;
        };
    }

    static ABIOf<GluonTest::GenericDelegateArraysCB> GluonInternal::ABIUtil<GluonTest::GenericDelegateArraysCB>::ToABI(const GluonTest::GenericDelegateArraysCB& x)
    {
        ABIOf<GluonTest::GenericDelegateArraysCB> x_abi;
        x_abi.Fn = &DW_F5BD3F9A::AbiFunc;
        x_abi.Ctx = DW_F5BD3F9A::GetWrapper(x);
        return x_abi;
    }

    static Delegate<double(double)> GluonInternal::ABIUtil<Delegate<double(double)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_F757A1ED::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_F757A1ED>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,double,double*)>)fptr, cp = com_ptr<IObject>(ctx)](double arg)
            -> double {
            double ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                arg,
                ABICallbackRef<double>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<Delegate<double(double)>> GluonInternal::ABIUtil<Delegate<double(double)>>::ToABI(const Delegate<double(double)>& x)
    {
        ABIOf<Delegate<double(double)>> x_abi;
        x_abi.Fn = &DW_F757A1ED::AbiFunc;
        x_abi.Ctx = DW_F757A1ED::GetWrapper(x);
        return x_abi;
    }

    static Delegate<string(Array<char>)> GluonInternal::ABIUtil<Delegate<string(Array<char>)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_F757A1EE::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_F757A1EE>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,char*,int,char**)>)fptr, cp = com_ptr<IObject>(ctx)](Array<char> arg)
            -> string {
            auto arg_abi = ABIUtil<Array<char>>::ToABI(arg);
            string ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                arg_abi.begin(), arg_abi.size(),
                ABICallbackRef<string>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<Delegate<string(Array<char>)>> GluonInternal::ABIUtil<Delegate<string(Array<char>)>>::ToABI(const Delegate<string(Array<char>)>& x)
    {
        ABIOf<Delegate<string(Array<char>)>> x_abi;
        x_abi.Fn = &DW_F757A1EE::AbiFunc;
        x_abi.Ctx = DW_F757A1EE::GetWrapper(x);
        return x_abi;
    }

    static GluonTest::AddSomeShit GluonInternal::ABIUtil<GluonTest::AddSomeShit>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_FBC9C526::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_FBC9C526>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)>)fptr, cp = com_ptr<IObject>(ctx)](int a, int b)
            -> GluonTest::ITestClass {
            GluonTest::ITestClass ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                a,
                b,
                ABICallbackRef<GluonTest::ITestClass>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<GluonTest::AddSomeShit> GluonInternal::ABIUtil<GluonTest::AddSomeShit>::ToABI(const GluonTest::AddSomeShit& x)
    {
        ABIOf<GluonTest::AddSomeShit> x_abi;
        x_abi.Fn = &DW_FBC9C526::AbiFunc;
        x_abi.Ctx = DW_FBC9C526::GetWrapper(x);
        return x_abi;
    }

    static Delegate<string(char, int)> GluonInternal::ABIUtil<Delegate<string(char, int)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_6FD213D7::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_6FD213D7>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,char,int,char**)>)fptr, cp = com_ptr<IObject>(ctx)](char arg1, int arg2)
            -> string {
            string ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                arg1,
                arg2,
                ABICallbackRef<string>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<Delegate<string(char, int)>> GluonInternal::ABIUtil<Delegate<string(char, int)>>::ToABI(const Delegate<string(char, int)>& x)
    {
        ABIOf<Delegate<string(char, int)>> x_abi;
        x_abi.Fn = &DW_6FD213D7::AbiFunc;
        x_abi.Ctx = DW_6FD213D7::GetWrapper(x);
        return x_abi;
    }

    static Delegate<char(string)> GluonInternal::ABIUtil<Delegate<char(string)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_F757A1EF::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_F757A1EF>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,char*,char*)>)fptr, cp = com_ptr<IObject>(ctx)](string arg)
            -> char {
            char ___ret;
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                ABIUtil<string>::ToABI(arg),
                ABICallbackRef<char>(___ret)));
            return ___ret;
        };
    }

    static ABIOf<Delegate<char(string)>> GluonInternal::ABIUtil<Delegate<char(string)>>::ToABI(const Delegate<char(string)>& x)
    {
        ABIOf<Delegate<char(string)>> x_abi;
        x_abi.Fn = &DW_F757A1EF::AbiFunc;
        x_abi.Ctx = DW_F757A1EF::GetWrapper(x);
        return x_abi;
    }

    static Delegate<void(int)> GluonInternal::ABIUtil<Delegate<void(int)>>::FromABI(void* fptr, IObject* ctx)
    {
        if (fptr == &DW_5C0C3D4E::AbiFunc)
        {
            auto wrapper = runtime_cast<DW_5C0C3D4E>(ctx);
            if (!wrapper) throw Exception("Unexpected context type for delegate translation");
            return wrapper->Func;
        }

        return [fn = (fn_ptr<HRESULT(IObject*,int)>)fptr, cp = com_ptr<IObject>(ctx)](int obj)
        {
            TRANSLATE_TO_EXCEPTIONS(fn(
                cp.Get(),
                obj));
        };
    }

    static ABIOf<Delegate<void(int)>> GluonInternal::ABIUtil<Delegate<void(int)>>::ToABI(const Delegate<void(int)>& x)
    {
        ABIOf<Delegate<void(int)>> x_abi;
        x_abi.Fn = &DW_5C0C3D4E::AbiFunc;
        x_abi.Ctx = DW_5C0C3D4E::GetWrapper(x);
        return x_abi;
    }
}

namespace GluonTest
{
    template<typename>
    DummyClass _P_DummyClass::__P_Create()
    {
        ::ABI::GluonTest::DummyClass* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_DummyClass_1(
            &instance));
        return ::ABI::Wrapper::Of<DummyClass>(instance);
    }

    template<typename>
    string _P_DummyClass::__P_GetNugget() const
    {
        string ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetNugget(
            ABICallbackRef<string>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_DummyClass::__P_SetNugget(string value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetNugget(
            ABIUtil<string>::ToABI(value)));
    }
}

namespace GluonTest
{
    template<typename>
    ConversionUnitTest _P_ConversionUnitTest::__P_Create()
    {
        ::ABI::GluonTest::ConversionUnitTest* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_ConversionUnitTest_1(
            &instance));
        return ::ABI::Wrapper::Of<ConversionUnitTest>(instance);
    }

    template<typename>
    PrimitivesCB _P_ConversionUnitTest::__P_GetPrimitivesCB() const
    {
        PrimitivesCB_t ___ret;
        {
            ABICallbackRef<PrimitivesCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetPrimitivesCB(
                (fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetPrimitivesCB(const PrimitivesCB_t& value) const
    {
        auto value_abi = ABIUtil<PrimitivesCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetPrimitivesCB(
            (fn_ptr<HRESULT(IObject*,bool,char*,int*,double*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    StringsCB _P_ConversionUnitTest::__P_GetStringsCB() const
    {
        StringsCB_t ___ret;
        {
            ABICallbackRef<StringsCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetStringsCB(
                (fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetStringsCB(const StringsCB_t& value) const
    {
        auto value_abi = ABIUtil<StringsCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetStringsCB(
            (fn_ptr<HRESULT(IObject*,char*,char**,char**,char**)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    SimpleStructsCB _P_ConversionUnitTest::__P_GetSimpleStructsCB() const
    {
        SimpleStructsCB_t ___ret;
        {
            ABICallbackRef<SimpleStructsCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetSimpleStructsCB(
                (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetSimpleStructsCB(const SimpleStructsCB_t& value) const
    {
        auto value_abi = ABIUtil<SimpleStructsCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetSimpleStructsCB(
            (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*,::ABI::GluonTest::BlittableStruct*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    ComplexStructsCB _P_ConversionUnitTest::__P_GetComplexStructsCB() const
    {
        ComplexStructsCB_t ___ret;
        {
            ABICallbackRef<ComplexStructsCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetComplexStructsCB(
                (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetComplexStructsCB(const ComplexStructsCB_t& value) const
    {
        auto value_abi = ABIUtil<ComplexStructsCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetComplexStructsCB(
            (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*,::ABI::GluonTest::ComplexStruct*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    ObjectsCB _P_ConversionUnitTest::__P_GetObjectsCB() const
    {
        ObjectsCB_t ___ret;
        {
            ABICallbackRef<ObjectsCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetObjectsCB(
                (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetObjectsCB(const ObjectsCB_t& value) const
    {
        auto value_abi = ABIUtil<ObjectsCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetObjectsCB(
            (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass*,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**,::ABI::GluonTest::DummyClass**)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    NamedDelegatesCB _P_ConversionUnitTest::__P_GetNamedDelegatesCB() const
    {
        NamedDelegatesCB_t ___ret;
        {
            ABICallbackRef<NamedDelegatesCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetNamedDelegatesCB(
                (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetNamedDelegatesCB(const NamedDelegatesCB_t& value) const
    {
        auto value_abi = ABIUtil<NamedDelegatesCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetNamedDelegatesCB(
            (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>,IObject*,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,char*,int*)>*,IObject**)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    GenericDelegatesCB _P_ConversionUnitTest::__P_GetGenericDelegatesCB() const
    {
        GenericDelegatesCB_t ___ret;
        {
            ABICallbackRef<GenericDelegatesCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetGenericDelegatesCB(
                (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetGenericDelegatesCB(const GenericDelegatesCB_t& value) const
    {
        auto value_abi = ABIUtil<GenericDelegatesCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetGenericDelegatesCB(
            (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,char*)>,IObject*,fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*,IObject**,fn_ptr<HRESULT(IObject*,char*,int,char***,int*)>*,IObject**,fn_ptr<HRESULT(IObject*,int,int*)>*,IObject**)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    PrimitiveArraysCB _P_ConversionUnitTest::__P_GetPrimitiveArraysCB() const
    {
        PrimitiveArraysCB_t ___ret;
        {
            ABICallbackRef<PrimitiveArraysCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetPrimitiveArraysCB(
                (fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetPrimitiveArraysCB(const PrimitiveArraysCB_t& value) const
    {
        auto value_abi = ABIUtil<PrimitiveArraysCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetPrimitiveArraysCB(
            (fn_ptr<HRESULT(IObject*,bool*,int,char**,int*,int**,int*,double**,int*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    StringArraysCB _P_ConversionUnitTest::__P_GetStringArraysCB() const
    {
        StringArraysCB_t ___ret;
        {
            ABICallbackRef<StringArraysCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetStringArraysCB(
                (fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetStringArraysCB(const StringArraysCB_t& value) const
    {
        auto value_abi = ABIUtil<StringArraysCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetStringArraysCB(
            (fn_ptr<HRESULT(IObject*,char**,int,char***,int*,char***,int*,char***,int*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    SimpleStructArraysCB _P_ConversionUnitTest::__P_GetSimpleStructArraysCB() const
    {
        SimpleStructArraysCB_t ___ret;
        {
            ABICallbackRef<SimpleStructArraysCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetSimpleStructArraysCB(
                (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetSimpleStructArraysCB(const SimpleStructArraysCB_t& value) const
    {
        auto value_abi = ABIUtil<SimpleStructArraysCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetSimpleStructArraysCB(
            (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::BlittableStruct*,int,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*,::ABI::GluonTest::BlittableStruct**,int*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    ComplexStructArraysCB _P_ConversionUnitTest::__P_GetComplexStructArraysCB() const
    {
        ComplexStructArraysCB_t ___ret;
        {
            ABICallbackRef<ComplexStructArraysCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetComplexStructArraysCB(
                (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetComplexStructArraysCB(const ComplexStructArraysCB_t& value) const
    {
        auto value_abi = ABIUtil<ComplexStructArraysCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetComplexStructArraysCB(
            (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::ComplexStruct*,int,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*,::ABI::GluonTest::ComplexStruct**,int*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    ObjectArraysCB _P_ConversionUnitTest::__P_GetObjectArraysCB() const
    {
        ObjectArraysCB_t ___ret;
        {
            ABICallbackRef<ObjectArraysCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetObjectArraysCB(
                (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetObjectArraysCB(const ObjectArraysCB_t& value) const
    {
        auto value_abi = ABIUtil<ObjectArraysCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetObjectArraysCB(
            (fn_ptr<HRESULT(IObject*,::ABI::GluonTest::DummyClass**,int,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*,::ABI::GluonTest::DummyClass***,int*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    NamedDelegateArraysCB _P_ConversionUnitTest::__P_GetNamedDelegateArraysCB() const
    {
        NamedDelegateArraysCB_t ___ret;
        {
            ABICallbackRef<NamedDelegateArraysCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetNamedDelegateArraysCB(
                (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetNamedDelegateArraysCB(const NamedDelegateArraysCB_t& value) const
    {
        auto value_abi = ABIUtil<NamedDelegateArraysCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetNamedDelegateArraysCB(
            (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    GenericDelegateArraysCB _P_ConversionUnitTest::__P_GetGenericDelegateArraysCB() const
    {
        GenericDelegateArraysCB_t ___ret;
        {
            ABICallbackRef<GenericDelegateArraysCB_t> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetGenericDelegateArraysCB(
                (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetGenericDelegateArraysCB(const GenericDelegateArraysCB_t& value) const
    {
        auto value_abi = ABIUtil<GenericDelegateArraysCB_t>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetGenericDelegateArraysCB(
            (fn_ptr<HRESULT(IObject*,ABI::DelegateBlob*,int,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*,ABI::DelegateBlob**,int*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    StructMemberTest _P_ConversionUnitTest::__P_GetStructMembers() const
    {
        StructMemberTest ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetStructMembers(
            ABICallbackRef<StructMemberTest>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_SetStructMembers(const StructMemberTest& value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetStructMembers(
            ABIUtil<StructMemberTest>::ToABI(value)));
    }

    template<typename>
    double _P_ConversionUnitTest::__P_Primitives(bool inTest, char& outOutTest, int& inoutRefTest) const
    {
        double ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_Primitives(
            inTest,
            ABICallbackRef<char>(outOutTest),
            ABICallbackRef<int>(inoutRefTest),
            ABICallbackRef<double>(___ret)));
        return ___ret;
    }

    template<typename>
    string _P_ConversionUnitTest::__P_Strings(string inTest, string& outOutTest, string& inoutRefTest) const
    {
        string ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_Strings(
            ABIUtil<string>::ToABI(inTest),
            ABICallbackRef<string>(outOutTest),
            ABICallbackRef<string>(inoutRefTest),
            ABICallbackRef<string>(___ret)));
        return ___ret;
    }

    template<typename>
    BlittableStruct _P_ConversionUnitTest::__P_SimpleStructs(const BlittableStruct& inTest, BlittableStruct& outOutTest, BlittableStruct& inoutRefTest) const
    {
        BlittableStruct ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_SimpleStructs(
            inTest,
            ABICallbackRef<BlittableStruct>(outOutTest),
            ABICallbackRef<BlittableStruct>(inoutRefTest),
            ABICallbackRef<BlittableStruct>(___ret)));
        return ___ret;
    }

    template<typename>
    ComplexStruct _P_ConversionUnitTest::__P_ComplexStructs(const ComplexStruct& inTest, ComplexStruct& outOutTest, ComplexStruct& inoutRefTest) const
    {
        ComplexStruct ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_ComplexStructs(
            ABIUtil<ComplexStruct>::ToABI(inTest),
            ABICallbackRef<ComplexStruct>(outOutTest),
            ABICallbackRef<ComplexStruct>(inoutRefTest),
            ABICallbackRef<ComplexStruct>(___ret)));
        return ___ret;
    }

    template<typename>
    DummyClass _P_ConversionUnitTest::__P_Objects(const DummyClass& inTest, DummyClass& outOutTest, DummyClass& inoutRefTest) const
    {
        DummyClass ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_Objects(
            ABIUtil<DummyClass>::ToABI(inTest),
            ABICallbackRef<DummyClass>(outOutTest),
            ABICallbackRef<DummyClass>(inoutRefTest),
            ABICallbackRef<DummyClass>(___ret)));
        return ___ret;
    }

    template<typename>
    NamedDelegate _P_ConversionUnitTest::__P_NamedDelegates(const NamedDelegate& inTest, NamedDelegate& outOutTest, NamedDelegate& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<NamedDelegate>::ToABI(inTest);
        ABICallbackRef<NamedDelegate> outOutTest_abi(outOutTest);
        ABICallbackRef<NamedDelegate> inoutRefTest_abi(inoutRefTest);
        NamedDelegate ___ret;
        {
            ABICallbackRef<NamedDelegate> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_NamedDelegates(
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>)inTest_abi.Fn, inTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&outOutTest_abi.Fn, &outOutTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&inoutRefTest_abi.Fn, &inoutRefTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,char*,char*,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    Delegate<int(int)> _P_ConversionUnitTest::__P_GenericDelegates(const Delegate<void(string)>& inTest, Delegate<void(const Delegate<int(int)>&)>& outOutTest, Delegate<string(Array<char>)>& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<Delegate<void(string)>>::ToABI(inTest);
        ABICallbackRef<Delegate<void(const Delegate<int(int)>&)>> outOutTest_abi(outOutTest);
        ABICallbackRef<Delegate<string(Array<char>)>> inoutRefTest_abi(inoutRefTest);
        Delegate<int(int)> ___ret;
        {
            ABICallbackRef<Delegate<int(int)>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GenericDelegates(
                (fn_ptr<HRESULT(IObject*,char*)>)inTest_abi.Fn, inTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,fn_ptr<HRESULT(IObject*,int,int*)>,IObject*)>*)&outOutTest_abi.Fn, &outOutTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,char*,int,char**)>*)&inoutRefTest_abi.Fn, &inoutRefTest_abi.Ctx,
                (fn_ptr<HRESULT(IObject*,int,int*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    Array<double> _P_ConversionUnitTest::__P_PrimitiveArrays(Array<bool> inTest, Array<char>& outOutTest, Array<int>& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<Array<bool>>::ToABI(inTest);
        ABICallbackRef<Array<char>> outOutTest_abi(outOutTest);
        ABICallbackRef<Array<int>> inoutRefTest_abi(inoutRefTest);
        Array<double> ___ret;
        {
            ABICallbackRef<Array<double>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_PrimitiveArrays(
                inTest_abi.begin(), inTest_abi.size(),
                &outOutTest_abi.Data, &outOutTest_abi.Count,
                &inoutRefTest_abi.Data, &inoutRefTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    Array<string> _P_ConversionUnitTest::__P_StringArrays(Array<string> inTest, Array<string>& outOutTest, Array<string>& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<Array<string>>::ToABI(inTest);
        ABICallbackRef<Array<string>> outOutTest_abi(outOutTest);
        ABICallbackRef<Array<string>> inoutRefTest_abi(inoutRefTest);
        Array<string> ___ret;
        {
            ABICallbackRef<Array<string>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_StringArrays(
                inTest_abi.begin(), inTest_abi.size(),
                &outOutTest_abi.Data, &outOutTest_abi.Count,
                &inoutRefTest_abi.Data, &inoutRefTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    Array<BlittableStruct> _P_ConversionUnitTest::__P_SimpleStructArrays(Array<BlittableStruct> inTest, Array<BlittableStruct>& outOutTest, Array<BlittableStruct>& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<Array<BlittableStruct>>::ToABI(inTest);
        ABICallbackRef<Array<BlittableStruct>> outOutTest_abi(outOutTest);
        ABICallbackRef<Array<BlittableStruct>> inoutRefTest_abi(inoutRefTest);
        Array<BlittableStruct> ___ret;
        {
            ABICallbackRef<Array<BlittableStruct>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_SimpleStructArrays(
                inTest_abi.begin(), inTest_abi.size(),
                &outOutTest_abi.Data, &outOutTest_abi.Count,
                &inoutRefTest_abi.Data, &inoutRefTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    Array<ComplexStruct> _P_ConversionUnitTest::__P_ComplexStructArrays(Array<ComplexStruct> inTest, Array<ComplexStruct>& outOutTest, Array<ComplexStruct>& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<Array<ComplexStruct>>::ToABI(inTest);
        ABICallbackRef<Array<ComplexStruct>> outOutTest_abi(outOutTest);
        ABICallbackRef<Array<ComplexStruct>> inoutRefTest_abi(inoutRefTest);
        Array<ComplexStruct> ___ret;
        {
            ABICallbackRef<Array<ComplexStruct>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_ComplexStructArrays(
                inTest_abi.begin(), inTest_abi.size(),
                &outOutTest_abi.Data, &outOutTest_abi.Count,
                &inoutRefTest_abi.Data, &inoutRefTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    Array<DummyClass> _P_ConversionUnitTest::__P_ObjectArrays(Array<DummyClass> inTest, Array<DummyClass>& outOutTest, Array<DummyClass>& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<Array<DummyClass>>::ToABI(inTest);
        ABICallbackRef<Array<DummyClass>> outOutTest_abi(outOutTest);
        ABICallbackRef<Array<DummyClass>> inoutRefTest_abi(inoutRefTest);
        Array<DummyClass> ___ret;
        {
            ABICallbackRef<Array<DummyClass>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_ObjectArrays(
                inTest_abi.begin(), inTest_abi.size(),
                &outOutTest_abi.Data, &outOutTest_abi.Count,
                &inoutRefTest_abi.Data, &inoutRefTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    Array<NamedDelegate> _P_ConversionUnitTest::__P_NamedDelegateArrays(Array<NamedDelegate> inTest, Array<NamedDelegate>& outOutTest, Array<NamedDelegate>& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<Array<NamedDelegate>>::ToABI(inTest);
        ABICallbackRef<Array<NamedDelegate>> outOutTest_abi(outOutTest);
        ABICallbackRef<Array<NamedDelegate>> inoutRefTest_abi(inoutRefTest);
        Array<NamedDelegate> ___ret;
        {
            ABICallbackRef<Array<NamedDelegate>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_NamedDelegateArrays(
                inTest_abi.begin(), inTest_abi.size(),
                &outOutTest_abi.Data, &outOutTest_abi.Count,
                &inoutRefTest_abi.Data, &inoutRefTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    Array<Delegate<int(int)>> _P_ConversionUnitTest::__P_GenericDelegateArrays(Array<Delegate<void(string)>> inTest, Array<Delegate<void(const Delegate<int(int)>&)>>& outOutTest, Array<Delegate<string(Array<char>)>>& inoutRefTest) const
    {
        auto inTest_abi = ABIUtil<Array<Delegate<void(string)>>>::ToABI(inTest);
        ABICallbackRef<Array<Delegate<void(const Delegate<int(int)>&)>>> outOutTest_abi(outOutTest);
        ABICallbackRef<Array<Delegate<string(Array<char>)>>> inoutRefTest_abi(inoutRefTest);
        Array<Delegate<int(int)>> ___ret;
        {
            ABICallbackRef<Array<Delegate<int(int)>>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GenericDelegateArrays(
                inTest_abi.begin(), inTest_abi.size(),
                &outOutTest_abi.Data, &outOutTest_abi.Count,
                &inoutRefTest_abi.Data, &inoutRefTest_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    void _P_ConversionUnitTest::__P_ExCheckNullReference() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_ExCheckNullReference(
        ));
    }

    template<typename>
    void _P_ConversionUnitTest::__P_ExCheckArgumentNull() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_ExCheckArgumentNull(
        ));
    }

    template<typename>
    void _P_ConversionUnitTest::__P_ExCheckArgument() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_ExCheckArgument(
        ));
    }

    template<typename>
    void _P_ConversionUnitTest::__P_ExCheckInvalidOperation() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_ExCheckInvalidOperation(
        ));
    }

    template<typename>
    void _P_ConversionUnitTest::__P_ExCheckAccessDenied() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_ExCheckAccessDenied(
        ));
    }

    template<typename>
    void _P_ConversionUnitTest::__P_ExCheckGeneric() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_ExCheckGeneric(
        ));
    }

    template<typename>
    void _P_ConversionUnitTest::__P_ExCheckGenericStd() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_ExCheckGenericStd(
        ));
    }

    template<typename>
    void _P_ConversionUnitTest::__P_ExCheckNotImplemented() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_ExCheckNotImplemented(
        ));
    }
}

namespace GluonTest
{
    template<typename>
    ITestClass _P_ITestClass::__P_Create()
    {
        ::ABI::GluonTest::ITestClass* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_ITestClass_1(
            &instance));
        return ::ABI::Wrapper::Of<ITestClass>(instance);
    }

    template<typename>
    void _P_ITestClass::__P_AddBigEventHandler(const Delegate<void(int)>& handler) const
    {
        auto handler_abi = ABIUtil<Delegate<void(int)>>::ToABI(handler);
        TRANSLATE_TO_EXCEPTIONS(_abi->_AddBigEventHandler(
            (fn_ptr<HRESULT(IObject*,int)>)handler_abi.Fn, handler_abi.Ctx));
    }

    template<typename>
    void _P_ITestClass::__P_RemoveBigEventHandler(const Delegate<void(int)>& handler) const
    {
        auto handler_abi = ABIUtil<Delegate<void(int)>>::ToABI(handler);
        TRANSLATE_TO_EXCEPTIONS(_abi->_RemoveBigEventHandler(
            (fn_ptr<HRESULT(IObject*,int)>)handler_abi.Fn, handler_abi.Ctx));
    }

    template<typename>
    AddSomeShit _P_ITestClass::__P_GetAdder() const
    {
        AddSomeShit ___ret;
        {
            ABICallbackRef<AddSomeShit> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetAdder(
                (fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ITestClass::__P_SetAdder(const AddSomeShit& value) const
    {
        auto value_abi = ABIUtil<AddSomeShit>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetAdder(
            (fn_ptr<HRESULT(IObject*,int,int,::ABI::GluonTest::ITestClass**)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    int _P_ITestClass::__P_GetProperty() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetProperty(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_ITestClass::__P_SetProperty(int value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetProperty(
            value));
    }

    template<typename>
    int _P_ITestClass::__P_GetReadOnlyProperty() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetReadOnlyProperty(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    Array<TestStruct> _P_ITestClass::__P_GetHardProperty() const
    {
        Array<TestStruct> ___ret;
        {
            ABICallbackRef<Array<TestStruct>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetHardProperty(
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    void _P_ITestClass::__P_SetHardProperty(Array<TestStruct> value) const
    {
        auto value_abi = ABIUtil<Array<TestStruct>>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetHardProperty(
            value_abi.begin(), value_abi.size()));
    }

    template<typename>
    Array<Delegate<string(char, int)>> _P_ITestClass::__P_GetHarderProperty() const
    {
        Array<Delegate<string(char, int)>> ___ret;
        {
            ABICallbackRef<Array<Delegate<string(char, int)>>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetHarderProperty(
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }

    template<typename>
    void _P_ITestClass::__P_SetHarderProperty(Array<Delegate<string(char, int)>> value) const
    {
        auto value_abi = ABIUtil<Array<Delegate<string(char, int)>>>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetHarderProperty(
            value_abi.begin(), value_abi.size()));
    }

    template<typename>
    Delegate<char(string)> _P_ITestClass::__P_GetDumbDelegate() const
    {
        Delegate<char(string)> ___ret;
        {
            ABICallbackRef<Delegate<char(string)>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_GetDumbDelegate(
                (fn_ptr<HRESULT(IObject*,char*,char*)>*)&___ret_abi.Fn, &___ret_abi.Ctx));
        }
        return ___ret;
    }

    template<typename>
    void _P_ITestClass::__P_SetDumbDelegate(const Delegate<char(string)>& value) const
    {
        auto value_abi = ABIUtil<Delegate<char(string)>>::ToABI(value);
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetDumbDelegate(
            (fn_ptr<HRESULT(IObject*,char*,char*)>)value_abi.Fn, value_abi.Ctx));
    }

    template<typename>
    void _P_ITestClass::__P_Methody() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Methody(
        ));
    }

    template<typename>
    int _P_ITestClass::__P_RetMethod() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_RetMethod(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_ITestClass::__P_OutMethod(int& outX) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_OutMethod(
            ABICallbackRef<int>(outX)));
    }

    template<typename>
    void _P_ITestClass::__P_RefMethod(string& inoutThing) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_RefMethod(
            ABICallbackRef<string>(inoutThing)));
    }

    template<typename>
    void _P_ITestClass::__P_Ref2(ITestClass& inoutThing) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Ref2(
            ABICallbackRef<ITestClass>(inoutThing)));
    }

    template<typename>
    void _P_ITestClass::__P_Ref3(const TestStruct& thing) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Ref3(
            ABIUtil<TestStruct>::ToABI(thing)));
    }

    template<typename>
    Array<int> _P_ITestClass::__P_ComplexMethod(string& inoutA, IUnknown* _dumb, void* p, Array<char>& outFart) const
    {
        ABICallbackRef<Array<char>> outFart_abi(outFart);
        Array<int> ___ret;
        {
            ABICallbackRef<Array<int>> ___ret_abi(___ret);
            TRANSLATE_TO_EXCEPTIONS(_abi->_ComplexMethod(
                ABICallbackRef<string>(inoutA),
                _dumb,
                p,
                &outFart_abi.Data, &outFart_abi.Count,
                &___ret_abi.Data, &___ret_abi.Count));
        }
        return ___ret;
    }
}

namespace GluonTest
{
    template<typename>
    int _P_Generator::__P_GetChannelCount() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetChannelCount(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    int _P_Generator::__P_GetSampleRate() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetSampleRate(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_Generator::__P_Initialize(int channels, int sampleRate) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Initialize(
            channels,
            sampleRate));
    }

    template<typename>
    void _P_Generator::__P_Eval(double t, double& inoutOutSample) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Eval(
            t,
            ABICallbackRef<double>(inoutOutSample)));
    }

    template<typename>
    void _P_Generator::__P_EvalBuffer(double t, const SignalBuffer& inoutBuffer) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_EvalBuffer(
            t,
            ABIUtil<SignalBuffer>::ToABI(inoutBuffer)));
    }
}

namespace GluonTest
{
    template<typename>
    SignalBuffer _P_SignalBuffer::__P_Create(int samples, int channels, int alignment)
    {
        ::ABI::GluonTest::SignalBuffer* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_SignalBuffer_1(
            samples,
            channels,
            alignment,
            &instance));
        return ::ABI::Wrapper::Of<SignalBuffer>(instance);
    }

    template<typename>
    SignalBuffer _P_SignalBuffer::__P_Create(int samples)
    {
        ::ABI::GluonTest::SignalBuffer* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_SignalBuffer_2(
            samples,
            &instance));
        return ::ABI::Wrapper::Of<SignalBuffer>(instance);
    }

    template<typename>
    int _P_SignalBuffer::__P_GetChannelCount() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetChannelCount(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    int _P_SignalBuffer::__P_GetSampleCount() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetSampleCount(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    int _P_SignalBuffer::__P_CopyTo(Array<double> arr) const
    {
        auto arr_abi = ABIUtil<Array<double>>::ToABI(arr);
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_CopyTo(
            arr_abi.begin(), arr_abi.size(),
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    int _P_SignalBuffer::__P_CopyTo(Array<float> arr) const
    {
        auto arr_abi = ABIUtil<Array<float>>::ToABI(arr);
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_CopyTo_1(
            arr_abi.begin(), arr_abi.size(),
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    int _P_SignalBuffer::__P_CopyTo(Array<short> arr) const
    {
        auto arr_abi = ABIUtil<Array<short>>::ToABI(arr);
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_CopyTo_2(
            arr_abi.begin(), arr_abi.size(),
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }
}

namespace GluonTest
{
    template<typename>
    Waveform _P_Waveform::__P_Create(Array<double> samples)
    {
        ::ABI::GluonTest::Waveform* instance;
        auto samples_abi = ABIUtil<Array<double>>::ToABI(samples);
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_Waveform_1(
            samples_abi.begin(), samples_abi.size(),
            &instance));
        return ::ABI::Wrapper::Of<Waveform>(instance);
    }

    template<typename>
    double _P_Waveform::__P_Phase(double t) const
    {
        double ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_Phase(
            t,
            ABICallbackRef<double>(___ret)));
        return ___ret;
    }
}

namespace GluonTest
{
    template<typename>
    SinusoidalWaveform _P_SinusoidalWaveform::__P_Create()
    {
        ::ABI::GluonTest::SinusoidalWaveform* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_SinusoidalWaveform_1(
            &instance));
        return ::ABI::Wrapper::Of<SinusoidalWaveform>(instance);
    }
}

namespace GluonTest
{
    template<typename>
    SquareWaveform _P_SquareWaveform::__P_Create()
    {
        ::ABI::GluonTest::SquareWaveform* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_SquareWaveform_1(
            &instance));
        return ::ABI::Wrapper::Of<SquareWaveform>(instance);
    }
}

namespace GluonTest
{
    template<typename>
    TriangleWaveform _P_TriangleWaveform::__P_Create()
    {
        ::ABI::GluonTest::TriangleWaveform* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_TriangleWaveform_1(
            &instance));
        return ::ABI::Wrapper::Of<TriangleWaveform>(instance);
    }
}

namespace GluonTest
{
    template<typename>
    SawtoothRightWaveform _P_SawtoothRightWaveform::__P_Create()
    {
        ::ABI::GluonTest::SawtoothRightWaveform* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_SawtoothRightWaveform_1(
            &instance));
        return ::ABI::Wrapper::Of<SawtoothRightWaveform>(instance);
    }
}

namespace GluonTest
{
    template<typename>
    SawtoothLeftWaveform _P_SawtoothLeftWaveform::__P_Create()
    {
        ::ABI::GluonTest::SawtoothLeftWaveform* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_SawtoothLeftWaveform_1(
            &instance));
        return ::ABI::Wrapper::Of<SawtoothLeftWaveform>(instance);
    }
}

namespace GluonTest
{
    template<typename>
    GTone _P_GTone::__P_Create()
    {
        ::ABI::GluonTest::GTone* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_GTone_1(
            &instance));
        return ::ABI::Wrapper::Of<GTone>(instance);
    }

    template<typename>
    double _P_GTone::__P_GetFrequency() const
    {
        double ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetFrequency(
            ABICallbackRef<double>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_GTone::__P_SetFrequency(double value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetFrequency(
            value));
    }

    template<typename>
    const Waveform& _P_GTone::__P_GetWaveform() const
    {
        Waveform_t ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetWaveform(
            ABICallbackRef<Waveform_t>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_GTone::__P_SetWaveform(const Waveform_t& value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetWaveform(
            ABIUtil<Waveform_t>::ToABI(value)));
    }

    template<typename>
    double _P_GTone::__P_GetAmplitude() const
    {
        double ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetAmplitude(
            ABICallbackRef<double>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_GTone::__P_SetAmplitude(double value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetAmplitude(
            value));
    }

    template<typename>
    void _P_GTone::__P_Eval(double t, double& inoutOutSample) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Eval(
            t,
            ABICallbackRef<double>(inoutOutSample)));
    }
}

namespace GluonTest
{
    template<typename>
    GWhiteNoise _P_GWhiteNoise::__P_Create()
    {
        ::ABI::GluonTest::GWhiteNoise* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_GWhiteNoise_1(
            &instance));
        return ::ABI::Wrapper::Of<GWhiteNoise>(instance);
    }

    template<typename>
    void _P_GWhiteNoise::__P_Eval(double t, double& inoutOutSample) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Eval(
            t,
            ABICallbackRef<double>(inoutOutSample)));
    }
}

namespace GluonTest
{
    template<typename>
    NoiseEngine _P_NoiseEngine::__P_Create()
    {
        ::ABI::GluonTest::NoiseEngine* instance;
        TRANSLATE_TO_EXCEPTIONS(Create_GluonTest_NoiseEngine_1(
            &instance));
        return ::ABI::Wrapper::Of<NoiseEngine>(instance);
    }

    template<typename>
    string _P_NoiseEngine::__P_GetError() const
    {
        string ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetError(
            ABICallbackRef<string>(___ret)));
        return ___ret;
    }

    template<typename>
    NoiseEngineState _P_NoiseEngine::__P_GetState() const
    {
        NoiseEngineState ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetState(
            ABICallbackRef<NoiseEngineState>(___ret)));
        return ___ret;
    }

    template<typename>
    int _P_NoiseEngine::__P_GetSampleRate() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetSampleRate(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_NoiseEngine::__P_SetSampleRate(int value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetSampleRate(
            value));
    }

    template<typename>
    NoiseChannels _P_NoiseEngine::__P_GetChannels() const
    {
        NoiseChannels ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetChannels(
            ABICallbackRef<NoiseChannels>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_NoiseEngine::__P_SetChannels(NoiseChannels value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetChannels(
            value));
    }

    template<typename>
    int _P_NoiseEngine::__P_GetBlockDuration() const
    {
        int ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetBlockDuration(
            ABICallbackRef<int>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_NoiseEngine::__P_SetBlockDuration(int value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetBlockDuration(
            value));
    }

    template<typename>
    NoiseDistribution _P_NoiseEngine::__P_GetDistribution() const
    {
        NoiseDistribution ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetDistribution(
            ABICallbackRef<NoiseDistribution>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_NoiseEngine::__P_SetDistribution(NoiseDistribution value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetDistribution(
            value));
    }

    template<typename>
    bool _P_NoiseEngine::__P_GetIsFilterEnabled() const
    {
        bool ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetIsFilterEnabled(
            ABICallbackRef<bool>(___ret)));
        return ___ret;
    }

    template<typename>
    void _P_NoiseEngine::__P_SetIsFilterEnabled(bool value) const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_SetIsFilterEnabled(
            value));
    }

    template<typename>
    void _P_NoiseEngine::__P_Play() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Play(
        ));
    }

    template<typename>
    void _P_NoiseEngine::__P_Pause() const
    {
        TRANSLATE_TO_EXCEPTIONS(_abi->_Pause(
        ));
    }

    template<typename>
    SignalBuffer _P_NoiseEngine::__P_GetPlot(double durationSeconds, PlotType type) const
    {
        SignalBuffer ___ret;
        TRANSLATE_TO_EXCEPTIONS(_abi->_GetPlot(
            durationSeconds,
            type,
            ABICallbackRef<SignalBuffer>(___ret)));
        return ___ret;
    }
}
