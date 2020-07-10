#include "PCH.h"
#include "ConversionUnitTest.h"
#include "DummyClass.h"

using namespace GluonTest;
using namespace std;

string S(const BlittableStruct& x)
{
    return "{ " + to_string(x.u) + ", " + to_string(x.v) + ", " + to_string(x.x) + ", " + to_string(x.y) + " }";
}

string S(const ComplexStruct& x)
{
    return "{ " + x.Name + " Del(3,4) = " + to_string(x.Del(3, 4)) + ", " + S(x.Sub) + " }";
}

string S(bool x)
{
    return x ? "true" : "false";
}

string S(int x)
{
    return to_string(x);
}

string S(double x)
{
    return to_string(x);
}

string S(char x)
{
    return string(1, x);
}

string S(string x)
{
    return x;
}

string S(DummyClass* x)
{
    if (x)
        return x->Nugget;
    else
        return "<null>";
}

string S(const com_ptr<DummyClass>& x)
{
    if (x)
        return x->Nugget;
    else
        return "<null>";
}

template<typename T>
string S(Array<T> x)
{
    if (!x)
        return "<null>";

    string s = "{ ";
    if (x.size() > 0)
        s += S(x[0]);
    for (auto i = x.begin() + 1; i != x.end(); i++)
        s += ", " + S(*i);
    return s + " }";
}

template<typename R>
string S(Delegate<R(int,int)> x)
{
    if (!x)
        return "<null>";

    return "(7,11) => " + S(x(7, 11));
}

template<typename R>
string S(Delegate<R(string, string)> x)
{
    if (!x)
        return "<null>";

    return "(\"a\",\"z\") => " + S(x("a", "z"));
}

string S(void* ptr)
{
    char buf[19] = "0000000000000000";

    sprintf_s(buf, "%16Z", (size_t)ptr);

    return buf;
}

string S(const StructMemberTest& x)
{
    return "{\r\n    " + S(x.Boolean) + ", " + S(x.Primitive) + ", " + S(x.PrimitivePtr) + ", " + x.String +
        "\r\n    " + S(x.BlittableSt) +
        "\r\n    " + S(x.ComplexSt) +
        "\r\n    " + S(x.Object) + ", " + S(x.NamedDelegate) + "\r\n}";
}

template<typename T>
void PrintRecv(string title, const T& x)
{
    cout << title << "(C++) Received:" << endl << "x = " << S(x) << endl << endl;
}

template<typename T, typename U>
void PrintRecv(string title, const T& x, U& refx)
{
    cout << title << "(C++) Received:" << endl << "x = " << S(x) << endl << "refx = " << S(refx) << endl << endl;
}

template<typename T>
void PrintRecv(string title, const T* x, com_ptr<T>& refx)
{
    cout << title << "(C++) Received:" << endl << "x = " << S(x) << endl << "refx = " << S(refx) << endl << endl;
}

template<typename T>
void PrintSend(string title, T& ret)
{
    cout << title << "(C++) Sent:" << endl << "ret = " << S(ret) << endl << endl;
}

template<typename T, typename U, typename V>
void PrintSend(string title, T& outx, U& refx, const V& ret)
{
    cout << title << "(C++) Sent:" << endl << "outx = " << S(outx) << endl << "refx = " << S(refx) << endl << "ret = " << S(ret) << endl << endl;
}

template<typename T>
void PrintSend(string title, com_ptr<T>& outx, com_ptr<T>& refx, const com_ptr<T>& ret)
{
    cout << title << "(C++) Sent:" << endl << "outx = " << S(outx) << endl << "refx = " << S(refx) << endl << "ret = " << S(ret) << endl << endl;
}


ConversionUnitTest::ConversionUnitTest()
{
    _primitivesCB = [&](bool x, char& outx, int& refx) -> double
    {
        const string title = "PrimitivesCB";
        PrintRecv(title, x, refx);
        outx = L'~';
        refx = 7376;
        double ret = 513;
        PrintSend(title, outx, refx, ret);
        return ret;
    };

    _stringsCB = [&](string x, string& outx, string& refx) -> string
    {
        const string title = "StringsCB";
        PrintRecv(title, x, refx);

        outx = "StringCBNativeOut";
        refx = "StringCBNativeRef";
        string ret = "StringCBNativeRet";

        PrintSend(title, outx, refx, ret);

        return ret;
    };

    _simpleStructsCB = [&](const BlittableStruct& x, BlittableStruct& outx, BlittableStruct& refx) -> BlittableStruct
    {
        const string title = "SimpleStructsCB";
        PrintRecv(title, x, refx);

        outx = BlittableStruct(1, 2, 3, 4);
        refx = BlittableStruct(11, 12, 13, 14);
        auto ret = BlittableStruct(101, 102, 103, 104);

        PrintSend(title, outx, refx, ret);

        return ret;
    };

    _complexStructsCB = [&](const ComplexStruct& x, ComplexStruct& outx, ComplexStruct& refx) -> ComplexStruct
    {
        const string title = "ComplexStructsCB";
        PrintRecv(title, x, refx);

        outx = ComplexStruct("ComplexCBOutNative", BlittableStruct(1, 2, 3, 4), nullptr, [](int x, int y) { return x * y; });
        refx = ComplexStruct("ComplexCBRefNative", BlittableStruct(10, 9, 8, 7), nullptr, [](int x, int y) { return x + y; });
        auto ret = ComplexStruct("ComplexCBRetNative", BlittableStruct(2, 4, 6, 8), nullptr, [](int x, int y) { return x - y; });

        PrintSend(title, outx, refx, ret);

        return ret;
    };

    _objectsCB = [&](DummyClass* x, com_ptr<DummyClass>& outx, com_ptr<DummyClass>& refx) -> com_ptr<DummyClass>
    {
        const string title = "ObjectsCB";
        PrintRecv(title, x, refx);
        outx = new DummyClass();
        outx->Nugget = "ObjectsCBOutNative";
        refx = new DummyClass();
        refx->Nugget = "ObjectsCBRefNative";
        auto ret = new DummyClass();
        ret->Nugget = "ObjectsCBRetNative";
        PrintSend(title, outx, refx, ret);
        return ret;
    };

    _namedDelegatesCB = [&](const NamedDelegate& x, NamedDelegate& outx, NamedDelegate& refx) -> NamedDelegate
    {
        const string title = "NamedDelegatesCB";
        PrintRecv(title, x, refx);

        outx = [](string x, string y) { return (int)x[0] + (int)y[0]; };
        refx = [](string x, string y) { return (int)x[0] * (int)y[0]; };
        NamedDelegate ret = [](string x, string y) { return (int)x[0] - (int)y[0]; };

        PrintSend(title, outx, refx, ret);

        return ret;
    };

    _primitiveArraysCB = [&](Array<bool> x, Array<char>& outx, Array<int>& refx) -> Array<double>
    {
        const string title = "PrimitiveArraysCB";
        PrintRecv(title, x, refx);

        outx = { L'f', L'a', L'r', L't' };
        refx = { 1, 2, 3, 4, 5, 6 };
        Array<double> ret = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        PrintSend(title, outx, refx, ret);
        return ret;
    };

    _stringArraysCB = [&](Array<string> x, Array<string>& outx, Array<string>& refx) -> Array<string>
    {
        const string title = "StringArraysCB";
        PrintRecv(title, x, refx);

        outx = { "Quick", "Brown", "Fox" };
        refx = { "Jumped", "Over", "The" };
        Array<string> ret = { "Lazy", "Dog" };

        PrintSend(title, outx, refx, ret);
        return ret;
    };

    _simpleStructArraysCB = [&](Array<BlittableStruct> x, Array<BlittableStruct>& outx, Array<BlittableStruct>& refx) -> Array<BlittableStruct>
    {
        const string title = "SimpleStructArraysCB";
        PrintRecv(title, x, refx);

        outx = { BlittableStruct(1,2,3,4), BlittableStruct(5,6,7,8), BlittableStruct(9,10,11,12) };
        refx = { BlittableStruct(2,4,6,8), BlittableStruct(10,12,14,16)};
        Array<BlittableStruct> ret = { };
        PrintSend(title, outx, refx, ret);
        return ret;
    };

    _complexStructArraysCB = [&](Array<ComplexStruct> x, Array<ComplexStruct>& outx, Array<ComplexStruct>& refx) -> Array<ComplexStruct>
    {
        const string title = "ComplexStructArraysCB";
        PrintRecv(title, x, refx);

        outx = { ComplexStruct("ComplexOutNative", BlittableStruct(1, 2, 3, 4), nullptr, [](int x, int y) { return x * y; }), ComplexStruct("ComplexRefNative", BlittableStruct(10, 9, 8, 7), nullptr, [](int x, int y) { return x + y; }) };
        refx = nullptr;
        Array<ComplexStruct> ret = { ComplexStruct("ComplexRetNative", BlittableStruct(2, 4, 6, 8), nullptr, [](int x, int y) { return x - y; }) };

        PrintSend(title, outx, refx, ret);
        return ret;
    };

    _objectArraysCB = [&](Array<com_ptr<DummyClass>> x, Array<com_ptr<DummyClass>>& outx, Array<com_ptr<DummyClass>>& refx) -> Array<com_ptr<DummyClass>>
    {
        const string title = "ObjectArraysCB";
        PrintRecv(title, x, refx);

        outx = { Make<DummyClass>(), Make<DummyClass>() };
        outx[0]->Nugget = "Hi";
        outx[1]->Nugget = "There";
        refx = { Make<DummyClass>(), Make<DummyClass>(), nullptr, Make<DummyClass>() };
        refx[0]->Nugget = "What's";
        refx[1]->Nugget = "Up";
        refx[3]->Nugget = "My";
        Array<com_ptr<DummyClass>> ret = { Make<DummyClass>(), Make<DummyClass>() };
        ret[0]->Nugget = "The";
        ret[1]->Nugget = "Return";
        PrintSend(title, outx, refx, ret);
        return ret;
    };

    _namedDelegateArraysCB = [&](Array<NamedDelegate> x, Array<NamedDelegate>& outx, Array<NamedDelegate>& refx) -> Array<NamedDelegate>
    {
        const string title = "NamedDelegateArraysCB";
        PrintRecv(title, x, refx);

        outx = nullptr;
        refx = { [](string x, string y) { return (int)x[0] + (int)y[0]; }, [](string x, string y) { return (int)x[0] * (int)y[0]; } };
        Array<NamedDelegate> ret = { [](string x, string y) { return (int)x[0] - (int)y[0]; }, nullptr };

        PrintSend(title, outx, refx, ret);
        return ret;
    };
}

string ConversionUnitTest::Strings(string x, string& outx, string& refx)
{
    const string title = "Strings";
    PrintRecv(title, x, refx);

    outx = "StringNativeOut";
    refx = "StringNativeRef";
    string ret = "StringNativeRet";

    PrintSend(title, outx, refx, ret);

    return ret;
}

BlittableStruct ConversionUnitTest::SimpleStructs(const BlittableStruct& x, BlittableStruct& outx, BlittableStruct& refx)
{
    const string title = "SimpleStructs";
    PrintRecv(title, x, refx);

    outx = BlittableStruct(1, 2, 3, 4);
    refx = BlittableStruct(11, 12, 13, 14);
    auto ret = BlittableStruct(101, 102, 103, 104);

    PrintSend(title, outx, refx, ret);
    return ret;
}

ComplexStruct ConversionUnitTest::ComplexStructs(const ComplexStruct& x, ComplexStruct& outx, ComplexStruct& refx)
{
    const string title = "ComplexStructs";
    PrintRecv(title, x, refx);

    outx = ComplexStruct("ComplexOutNative", BlittableStruct(1, 2, 3, 4), nullptr, [](int x, int y) { return x * y; });
    refx = ComplexStruct("ComplexRefNative", BlittableStruct(10, 9, 8, 7), nullptr, [](int x, int y) { return x + y; });
    auto ret = ComplexStruct("ComplexRetNative", BlittableStruct(2, 4, 6, 8), nullptr, [](int x, int y) { return x - y; });

    PrintSend(title, outx, refx, ret);

    return ret;
}

com_ptr<DummyClass> ConversionUnitTest::Objects(DummyClass* x, com_ptr<DummyClass>& outx, com_ptr<DummyClass>& refx)
{
    const string title = "Objects";
    PrintRecv(title, x, refx);
    outx = new DummyClass();
    outx->Nugget = "ObjectsOutNative";
    refx = new DummyClass();
    refx->Nugget = "ObjectsRefNative";
    com_ptr<DummyClass> ret = new DummyClass();
    ret->Nugget = "ObjectsRetNative";
    PrintSend(title, outx, refx, ret);
    return ret;
}

NamedDelegate ConversionUnitTest::NamedDelegates(const NamedDelegate& x, NamedDelegate& outx, NamedDelegate& refx)
{
    const string title = "NamedDelegates";
    PrintRecv(title, x, refx);

    outx = [](string x, string y) { return (int)x[0] + (int)y[0]; };
    refx = [](string x, string y) { return (int)x[0] * (int)y[0]; };
    NamedDelegate ret = [](string x, string y) { return (int)x[0] - (int)y[0]; };

    PrintSend(title, outx, refx, ret);

    return ret;
}

Delegate<int(int)> ConversionUnitTest::GenericDelegates(const Delegate<void(string)>& x, Delegate<void(const Delegate<int(int)>&)>& outx, Delegate<string(Array<char>)>& refx)
{
    Not_Implemented_Warning

    throw NotImplementedException("ConversionUnitTest::GenericDelegates");
}

Array<string> ConversionUnitTest::StringArrays(Array<string> x, Array<string>& outx, Array<string>& refx)
{
    const string title = "StringArrays";
    PrintRecv(title, x, refx);

    outx = { "Quick", "Brown", "Fox" };
    refx = { "Jumped", "Over", "The" };
    Array<string> ret = { "Lazy", "Dog" };

    PrintSend(title, outx, refx, ret);
    return ret;
}

Array<BlittableStruct> ConversionUnitTest::SimpleStructArrays(Array<BlittableStruct> x, Array<BlittableStruct>& outx, Array<BlittableStruct>& refx)
{
    const string title = "SimpleStructArraysCB";
    PrintRecv(title, x, refx);

    outx = { BlittableStruct(1,2,3,4), BlittableStruct(5,6,7,8), BlittableStruct(9,10,11,12) };
    refx = { BlittableStruct(2,4,6,8), BlittableStruct(10,12,14,16) };
    Array<BlittableStruct> ret = {};
    PrintSend(title, outx, refx, ret);
    return ret;
}

Array<ComplexStruct> ConversionUnitTest::ComplexStructArrays(Array<ComplexStruct> x, Array<ComplexStruct>& outx, Array<ComplexStruct>& refx)
{
    const string title = "ComplexStructArraysCB";
    PrintRecv(title, x, refx);

    outx = nullptr;
    refx = { ComplexStruct("ComplexOutNative", BlittableStruct(1, 2, 3, 4), nullptr, [](int x, int y) { return x * y; }), ComplexStruct("ComplexRefNative", BlittableStruct(10, 9, 8, 7), nullptr, [](int x, int y) { return x + y; }) };
    Array<ComplexStruct> ret = { ComplexStruct("ComplexRetNative", BlittableStruct(2, 4, 6, 8), nullptr, [](int x, int y) { return x - y; }) };

    PrintSend(title, outx, refx, ret);
    return ret;
}

Array<NamedDelegate> ConversionUnitTest::NamedDelegateArrays(Array<NamedDelegate> x, Array<NamedDelegate>& outx, Array<NamedDelegate>& refx)
{
    const string title = "NamedDelegateArrays";
    PrintRecv(title, x, refx);

    outx = nullptr;
    refx = { [](string x, string y) { return (int)x[0] + (int)y[0]; }, [](string x, string y) { return (int)x[0] * (int)y[0]; } };
    Array<NamedDelegate> ret = { [](string x, string y) { return (int)x[0] - (int)y[0]; }, nullptr };

    PrintSend(title, outx, refx, ret);
    return ret;
}

Array<Delegate<int(int)>> ConversionUnitTest::GenericDelegateArrays(Array<Delegate<void(string)>> x, Array<Delegate<void(const Delegate<int(int)>&)>>& outx, Array<Delegate<string(Array<char>)>>& refx)
{
    Not_Implemented_Warning

    throw NotImplementedException("ConversionUnityTest::GenericDelegateArrays");
}


double ConversionUnitTest::Primitives(bool x, char& outx, int& refx)
{
    const string title = "Primitives";
    PrintRecv(title, x, refx);
    outx = L'~';
    refx = 7376;
    double ret = 513;
    PrintSend(title, outx, refx, ret);
    return ret;
}


Array<double> ConversionUnitTest::PrimitiveArrays(Array<bool> x, Array<char>& outx, Array<int>& refx)
{
    const string title = "PrimitiveArrays";
    PrintRecv(title, x, refx);

    outx = { L'f', L'a', L'r', L't' };
    refx = { 1, 2, 3, 4, 5, 6 };
    Array<double> ret = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

    PrintSend(title, outx, refx, ret);
    return ret;
}


Array<com_ptr<DummyClass>> ConversionUnitTest::ObjectArrays(Array<com_ptr<DummyClass>> x, Array<com_ptr<DummyClass>>& outx, Array<com_ptr<DummyClass>>& refx)
{
    const string title = "ObjectArrays";
    PrintRecv(title, x, refx);

    outx = { Make<DummyClass>(), Make<DummyClass>() };
    outx[0]->Nugget = "Hi";
    outx[1]->Nugget = "There";
    refx = { Make<DummyClass>(), Make<DummyClass>(), nullptr, Make<DummyClass>() };
    refx[0]->Nugget = "What's";
    refx[1]->Nugget = "Up";
    refx[3]->Nugget = "My";
    Array<com_ptr<DummyClass>> ret = { Make<DummyClass>(), Make<DummyClass>() };
    ret[0]->Nugget = "The";
    ret[1]->Nugget = "Return";
    PrintSend(title, outx, refx, ret);
    return ret;
}


StructMemberTest ConversionUnitTest::GetStructMembers() const
{
    auto dummy = Make<DummyClass>();
    dummy->Nugget = "FakeNugget";

    auto ret = StructMemberTest(
        true,
        3.141592654,
        (void*)0xDEADFACEBABE3210,
        "Random",
        BlittableStruct(5, 6, 7, 8),
        ComplexStruct("ComplexName", BlittableStruct(1, 2, 1, 2), nullptr, [](int a, int b) { return a * b - (a + b); }),
        dummy.Get(),
        [](int a, int b) { return (a + b) * (a - b); },
        [](double x) { return 2 * x; });

    PrintSend("StructMembers", ret);
    return ret;
}


void ConversionUnitTest::SetStructMembers(const StructMemberTest& value)
{
    PrintRecv("StructMembers", value);
}


PrimitivesCB ConversionUnitTest::GetPrimitivesCB() const
{
    return _primitivesCB;
}


void ConversionUnitTest::SetPrimitivesCB(const PrimitivesCB_t& value)
{
    _primitivesCB = value;
}


StringsCB ConversionUnitTest::GetStringsCB() const
{
    return _stringsCB;
}


void ConversionUnitTest::SetStringsCB(const StringsCB_t& value)
{
    _stringsCB = value;
}


SimpleStructsCB ConversionUnitTest::GetSimpleStructsCB() const
{
    return _simpleStructsCB;
}


void ConversionUnitTest::SetSimpleStructsCB(const SimpleStructsCB_t& value)
{
    _simpleStructsCB = value;
}


ComplexStructsCB ConversionUnitTest::GetComplexStructsCB() const
{
    return _complexStructsCB;
}


void ConversionUnitTest::SetComplexStructsCB(const ComplexStructsCB_t& value)
{
    _complexStructsCB = value;
}


ObjectsCB ConversionUnitTest::GetObjectsCB() const
{
    return _objectsCB;
}


void ConversionUnitTest::SetObjectsCB(const ObjectsCB_t& value)
{
    _objectsCB = value;
}

NamedDelegatesCB ConversionUnitTest::GetNamedDelegatesCB() const
{
    return _namedDelegatesCB;
}


void ConversionUnitTest::SetNamedDelegatesCB(const NamedDelegatesCB_t& value)
{
    _namedDelegatesCB = value;
}


GenericDelegatesCB ConversionUnitTest::GetGenericDelegatesCB() const
{
    return _genericDelegatesCB;
}


void ConversionUnitTest::SetGenericDelegatesCB(const GenericDelegatesCB_t& value)
{
    _genericDelegatesCB = value;
}


PrimitiveArraysCB ConversionUnitTest::GetPrimitiveArraysCB() const
{
    return _primitiveArraysCB;
}


void ConversionUnitTest::SetPrimitiveArraysCB(const PrimitiveArraysCB_t& value)
{
    _primitiveArraysCB = value;
}


StringArraysCB ConversionUnitTest::GetStringArraysCB() const
{
    return _stringArraysCB;
}


void ConversionUnitTest::SetStringArraysCB(const StringArraysCB_t& value)
{
    _stringArraysCB = value;
}


SimpleStructArraysCB ConversionUnitTest::GetSimpleStructArraysCB() const
{
    return _simpleStructArraysCB;
}


void ConversionUnitTest::SetSimpleStructArraysCB(const SimpleStructArraysCB_t& value)
{
    _simpleStructArraysCB = value;
}


ComplexStructArraysCB ConversionUnitTest::GetComplexStructArraysCB() const
{
    return _complexStructArraysCB;
}


void ConversionUnitTest::SetComplexStructArraysCB(const ComplexStructArraysCB_t& value)
{
    _complexStructArraysCB = value;
}


ObjectArraysCB ConversionUnitTest::GetObjectArraysCB() const
{
    return _objectArraysCB;
}


void ConversionUnitTest::SetObjectArraysCB(const ObjectArraysCB_t& value)
{
    _objectArraysCB = value;
}


NamedDelegateArraysCB ConversionUnitTest::GetNamedDelegateArraysCB() const
{
    return _namedDelegateArraysCB;
}


void ConversionUnitTest::SetNamedDelegateArraysCB(const NamedDelegateArraysCB_t& value)
{
    _namedDelegateArraysCB = value;
}


GenericDelegateArraysCB ConversionUnitTest::GetGenericDelegateArraysCB() const
{
    return _genericDelegateArraysCB;
}


void ConversionUnitTest::SetGenericDelegateArraysCB(const GenericDelegateArraysCB_t& value)
{
    _genericDelegateArraysCB = value;
}

void ConversionUnitTest::ExCheckNullReference()
{
    throw NullReferenceException("This is a NullReferenceException. Test passed!");
}


void ConversionUnitTest::ExCheckArgumentNull()
{
    throw ArgumentNullException("This is an ArgumentNullException. Test passed!");
}

void ConversionUnitTest::ExCheckArgument()
{
    throw ArgumentException("This is an ArgumentException. Test passed!");
}

void ConversionUnitTest::ExCheckInvalidOperation()
{
    throw InvalidOperationException("This is an InvalidOperationException. Test passed!");
}

void ConversionUnitTest::ExCheckAccessDenied()
{
    throw AccessDeniedException("This is an AccessDeniedException. Test passed!");
}

void ConversionUnitTest::ExCheckGeneric()
{
    throw Exception("This is a generic Exception. Test passed!");
}

void ConversionUnitTest::ExCheckGenericStd()
{
    throw exception("This is a generic std::exception. Test passed!");
}

void ConversionUnitTest::ExCheckNotImplemented()
{
    throw NotImplementedException("This is a NotImplementedException. Test passed!");
}
