#pragma once

#ifndef _GLUON_NATIVE_STUFF_
#define _GLUON_NATIVE_STUFF_

#include <Sharpish.h>
#include <string>
#include <objbase.h>
#include <ppltasks.h>

#ifdef GLUON_BUILDING
#define ABI_CONSTRUCTOR extern "C" __declspec(dllexport) HRESULT __stdcall
#else
#define ABI_CONSTRUCTOR extern "C" __declspec(dllimport) HRESULT __stdcall
#endif

#define $Line TOSTRING( __LINE__ )
#define Not_Implemented_Warning __pragma( message( __FILE__ "(" $Line "):Warning: " __FUNCTION__ " - Function not yet implemented!" ))

#define ABIArrayArg(T,name) T* name, int name##_count
#define ABIRefArrayArg(T,name) T** name, int* name##_count

#define TRANSLATE_EXCEPTION(ex, hr) catch(CS::ex##Exception const& e) { return ABI::SetException(hr, ABI::ExceptionType::ex, e.what()); }
#define TRANSLATE_EXCEPTIONS                                                                            \
    TRANSLATE_EXCEPTION(NullReference, E_FAIL)                                                          \
    TRANSLATE_EXCEPTION(AccessDenied, E_ACCESSDENIED)                                                   \
    TRANSLATE_EXCEPTION(InvalidOperation, E_UNEXPECTED)                                                 \
    TRANSLATE_EXCEPTION(ArgumentNull, E_POINTER)                                                        \
    TRANSLATE_EXCEPTION(Argument, E_INVALIDARG)                                                         \
    TRANSLATE_EXCEPTION(NotImplemented, E_NOTIMPL)                                                      \
    catch(std::exception const& e) { return ABI::SetException(E_FAIL, ABI::ExceptionType::Generic, e.what()); }   \
    catch(...) { return ABI::SetException(E_FAIL, ABI::ExceptionType::Generic, "Unknown Exception"); }

#define TRANSLATE_TO_EXCEPTIONS(hr)  {                                      \
    HRESULT r = (hr);                                                       \
    if (r == E_NOTIMPL) throw CS::NotImplementedException();                \
    if (r == E_INVALIDARG) throw CS::ArgumentException("");                 \
    if (r == E_POINTER) throw CS::ArgumentNullException("");                \
    if (r == E_ACCESSDENIED) throw CS::AccessDeniedException();             \
    if (r == E_UNEXPECTED) throw CS::InvalidOperationException();           \
    if (r == E_FAIL) throw CS::Exception();                                 \
}

struct IUnknown;

namespace CS
{
    template<class Signature, class C, typename nothing = typename std::enable_if<!std::is_base_of<DelegateBase, Signature>::value, void>::type>
    class VirtualEvent
    {
    public:
        VirtualEvent(C* pThis, void (C::*adder)(const Delegate<Signature>&), void (C::*remover)(const Delegate<Signature>&))
            : _this(pThis), _adder(adder), _remover(remover) { }

        VirtualEvent(VirtualEvent&& copy) : _this(copy._this), _adder(copy._adder), _remover(copy._remover) { }

        template<typename F>
        void operator += (F&& handler) const
        {
            (_this->*_adder)(std::forward<F>(handler));
        }

        template<typename F>
        VirtualEvent<Signature, C> operator + (F&& rhs) const
        {
            (_this->*_adder)(std::forward<F>(rhs)); return *this;
        }

        template<typename F>
        void operator -= (F&& handler) const
        {
            (_this->*_remover)(std::forward<F>(handler));
        }

        template<typename F>
        VirtualEvent<Signature, C> operator - (F&& rhs) const
        {
            (_this->*_remover)(std::forward<F>(rhs)); return *this;
        }

        template<typename T>
        void operator =(T rhs)
        {
            static_assert(false, "Events cannot be assigned");
        }

    private:
        C * _this;
        void (C::*_adder)(const Delegate<Signature>&);
        void (C::*_remover)(const Delegate<Signature>&);
    };

    template<class Signature, class C>
    class VirtualEvent <Delegate<Signature>, C> : public VirtualEvent<Signature, C>
    {
    public:
        VirtualEvent(C* pThis, void (C::*adder)(const Delegate<Signature>&), void (C::*remover)(const Delegate<Signature>&))
            : VirtualEvent<Signature>(pThis, adder, remover) { }
    };
}

namespace ABI
{
    template<typename Sig>
    struct fn_ptr_container;

    template<typename... P>
    struct fn_ptr_container<HRESULT(P...)>
    {
        typedef HRESULT(__stdcall *ptr_type)(P...);
    };

    template<typename... P>
    struct fn_ptr_container<HRESULT(__stdcall*)(P...)>
    {
        typedef HRESULT(__stdcall *ptr_type)(P...);
    };

    template<typename T>
    void AbiFree(T& x);
}

template<typename Sig>
using fn_ptr = typename ABI::fn_ptr_container<Sig>::ptr_type;

namespace ABI
{
    enum class ExceptionType : uint32_t
    {
        NoException = 0,
        NullReference,
        AccessDenied,
        InvalidOperation,
        ArgumentNull,
        Argument,
        NotImplemented,
        Generic = 0xFFFFFFFF
    };

    extern HRESULT SetException(HRESULT hr, ExceptionType type, const char* msg);

    struct DelegateBlob
    {
        void* Fn;
        CS::IObject* Ctx;

        DelegateBlob() { }
        DelegateBlob(void* fn, CS::IObject* ctx) : Fn(fn), Ctx(ctx) { }
    };

    //template<typename Sig>
    //class GluonDelegate
    template<typename T>
    class Array sealed
    {
    public:
        Array() : _ptr(nullptr), _length(0) { }
        Array(T* wrapped, int size) : _ptr(wrapped), _length(size) { }

        Array<T>& operator =(const Array<T>& rhs) { _ptr = rhs._ptr; _length = rhs._length; return *this; }

        T& operator [](int index) { return _ptr[index]; }
        const T& operator [](int index) const { return _ptr[index]; }

        T& operator [](size_t index) { return _ptr[index]; }
        const T& operator [](size_t index) const { return _ptr[index]; }

        typedef T* iterator;
        typedef const T* const_iterator;

        iterator begin() { return _ptr; }
        const_iterator begin() const { return _ptr; }
        iterator end() { return _ptr + _length; }
        const_iterator end() const { return _ptr + _length; }
        int size() const { return _length; }

        template<typename T>
        bool operator ==(const T& other) const { _ptr == other.begin(); }
        template<typename T>
        bool operator !=(const T& other) const { return _ptr != other.begin(); }

        operator bool() const { return !!_ptr; }
        bool operator !() const { return !_ptr; }

    private:
        int _length;
        T* _ptr;
    };

    template<typename T>
    class ArrayRef sealed
    {
    public:
        ArrayRef() : _ptr(nullptr), _length(nullptr) { }
        ArrayRef(T** wrapped, int* length) : _ptr(wrapped), _length(length) { }

        ArrayRef<T>& operator =(Array<T>& rhs) { *_ptr = rhs.begin(); *_length = (int)rhs.size(); return *this; }

        T& operator [](int index) { return (*_ptr)[index]; }
        const T& operator [](int index) const { return (*_ptr)[index]; }

        T& operator [](size_t index) { return (*_ptr)[index]; }
        const T& operator [](size_t index) const { return (*_ptr)[index]; }

        typedef T* iterator;
        typedef const T* const_iterator;

        iterator begin() { return *_ptr; }
        const_iterator begin() const { return *_ptr; }
        iterator end() { return *_ptr + *_length; }
        const_iterator end() const { return *_ptr + *_length; }
        size_t size() const { return *_length; }

        template<typename T>
        bool operator ==(const T& other) const { return *_ptr == other.begin(); }

        template<typename T>
        bool operator !=(const T& other) const { return *_ptr != other.begin(); }

        operator bool() const { return !!*this; }
        bool operator !() const { return !_ptr; }

    private:
        int* _length;
        T** _ptr;
    };

    template<typename Sig>
    class DelegateRef sealed
    {
    public:
        DelegateRef() : _fn(nullptr), _ctx(nullptr) { }
        DelegateRef(fn_ptr<Sig>* fn, CS::IObject** ctx) : _fn(fn), _ctx(ctx) { }

        DelegateRef<Sig>& operator =(const DelegateBlob& rhs) { *_fn = (fn_ptr<Sig>)rhs.Fn; *_ctx = rhs.Ctx; return *this; }

    private:
        fn_ptr<Sig>* _fn;
        CS::IObject** _ctx;
    };
}

namespace GluonInternal
{
    template<typename Sig>
    class comid("CD849D44-0E94-4428-9403-EF8009561A61") DelegateContext : public CS::ComObject<DelegateContext<Sig>, CS::Object>
    {
    public:
        DelegateContext(const CS::Delegate<Sig>& d) : _d(d) { }
        const CS::Delegate<Sig>& Get() const { return _d; }
    private:
        CS::Delegate<Sig> _d;
    };

    template<typename T>
    struct PrimitiveRefConverter
    {
        PrimitiveRefConverter(T*& ref) : _ref(ref) { }

        operator T&() { return *_ref; }

    private:
        T * & _ref;
    };

    template<typename T>
    struct PrimitiveRefCallbackConverter
    {
        PrimitiveRefCallbackConverter(T& ref) : _ref(ref) { }

        operator T*() { return &_ref; }

    private:
        T & _ref;
    };

    struct StringRefConverter
    {
        StringRefConverter(char**& ref) : _ref(ref)
        {
            _conv = *ref ? *ref : "";
        }

        ~StringRefConverter()
        {
            auto len = _conv.length();
            auto sz = sizeof(char) * (len + 1);

            if (*_ref)
                CoTaskMemFree(*_ref);

            *_ref = (char*)CoTaskMemAlloc(sz);
            (*_ref)[len] = L'\0';
            memcpy_s(*_ref, sz, &_conv[0], sz - sizeof(char));
        }

        operator std::string&() { return _conv; }

    private:
        char**& _ref;
        std::string _conv;
    };

    struct StringRefCallbackConverter
    {
        StringRefCallbackConverter(std::string& ref) : _ref(ref)
        {
            auto len = ref.length();
            auto sz = sizeof(char) * (len + 1);
            _conv = (char*)CoTaskMemAlloc(sz);
            _conv[len] = L'\0';
            memcpy(_conv, &ref[0], sz - sizeof(char));
        }

        ~StringRefCallbackConverter()
        {
            _ref = _conv ? _conv : "";
            CoTaskMemFree(_conv);
        }

        operator char**() { return &_conv; }

    private:
        std::string& _ref;
        char* _conv;
    };

    template<typename ABI, typename T>
    struct ComRefConverter
    {
        ComRefConverter(ABI** ref) : _ref(ref)
        {
            _conv.Attach(static_cast<T*>(*_ref));
        }

        ~ComRefConverter()
        {
            *_ref = static_cast<ABI*>(_conv.Detach());
        }

        operator CS::com_ptr<T>&() { return _conv; }

    private:
        ABI * * _ref;
        CS::com_ptr<T> _conv;
    };

    template<typename ABI, typename T>
    struct ComRefCallbackConverter
    {
        ComRefCallbackConverter(CS::com_ptr<T>& ref) : _ref(ref)
        {
            _conv = static_cast<ABI*>(_ref.Get());
        }

        ~ComRefCallbackConverter()
        {
            if (_conv != static_cast<ABI*>(_ref.Get()))
            {
                _ref = static_cast<T*>(_conv);
            }
        }

        operator ABI**() { return &_conv; }

    private:
        CS::com_ptr<T>& _ref;
        ABI* _conv;
    };

    template<typename T, typename TABI>
    struct TaskRefConverter
    {
        TaskRefConverter(TABI** ref) : _ref(ref)
        {
            _conv = _orig = ABIUtil<concurrency::task<T>>::FromABI(*ref);
        }

        ~TaskRefConverter()
        {
            if (_conv == _orig) return;

            if (*_ref)
                (*_ref)->Release();

            *_ref = ABIUtil<concurrency::task<T>>::ToABI(_conv);
        }

        operator concurrency::task<T>&() { return _conv; }

    private:
        TABI** _ref;
        concurrency::task<T> _orig;
        concurrency::task<T> _conv;
    };

    template<typename T, typename TABI>
    struct TaskRefCallbackConverter
    {
        TaskRefCallbackConverter(concurrency::task<T>& ref) : _ref(ref)
        {
            _orig = _conv = ABIUtil<concurrency::task<T>>::ToABI(ref);
        }

        ~TaskRefCallbackConverter()
        {
            if (_conv == _orig) return;

            _ref = ABIUtil<concurrency::task<T>>::FromABI(_conv);

            if (_conv)
                _conv->Release();
        }

        operator TABI**() { return &_conv; }

    private:
        concurrency::task<T>& _ref;
        TABI* _orig;
        TABI* _conv;
    };

    template<typename, typename = void>
    struct ABIUtil;

    template<typename T, typename ABI>
    struct StructRefConverter
    {
        StructRefConverter(ABI* ref) : _ref(ref), _conv(ABIUtil<T>::FromABI(*ref))
        {
        }

        ~StructRefConverter()
        {
            *_ref = ABIUtil<T>::ToABI(_conv);
        }

        operator T&() { return _conv; }

    private:
        ABI * _ref;
        T _conv;
    };

    template<typename T, typename ABI>
    struct StructRefCallbackConverter
    {
        StructRefCallbackConverter(T& ref) : _ref(&ref), _conv(ABIUtil<T>::ToABI(ref))
        {
        }

        ~StructRefCallbackConverter()
        {
            *_ref = ABIUtil<T>::FromABI(_conv);
        }

        operator ABI*() { return &_conv; }

    private:
        T * _ref;
        ABI _conv;
    };

    template<typename T>
    struct StructRefPassthrough
    {
        StructRefPassthrough(T* ref) : _ref(ref) { }

        ~StructRefPassthrough() { }

        operator T&() { return *_ref; }

    private:
        T * _ref;
    };

    template<typename T>
    struct StructRefCallbackPassthrough
    {
        StructRefCallbackPassthrough(T& ref) : _ref(&ref) { }

        ~StructRefCallbackPassthrough() { }

        operator T*() { return _ref; }

    private:
        T * _ref;
    };

    template<typename T>
    struct ArrayRefConverter
    {
        ArrayRefConverter(typename ABIUtil<T>::ABIElementType** ptr, int* count) : _ptr(ptr), _count(count), _conv(*count)
        {
            for (int i = 0; i < *_count; i++)
                _conv[i] = ABIUtil<T>::FromABI((*ptr)[i]);
        }

        ~ArrayRefConverter()
        {
            if (*_count != _conv.size())
            {
                if (*_ptr)
                    CoTaskMemFree(*_ptr);

                if (_conv.size() == 0)
                    *_ptr = nullptr;
                else
                    *_ptr = (typename ABIUtil<T>::ABIElementType*)CoTaskMemAlloc(sizeof(typename ABIUtil<T>::ABIElementType) * _conv.size());

                *_count = (int)_conv.size();
            }

            for (size_t i = 0; i < _conv.size(); i++)
                (*_ptr)[i] = ABIUtil<T>::ToABI(_conv[i]);
        }

        operator CS::Array<typename ABIUtil<T>::ElementType>&() { return _conv; }
    private:
        typename ABIUtil<T>::ABIElementType** _ptr;
        int* _count;
        CS::Array<typename ABIUtil<T>::ElementType> _conv;
    };

    template<typename T>
    struct ArrayRefCallbackConverter
    {
        ArrayRefCallbackConverter(CS::Array<typename ABIUtil<T>::ElementType>& arr) : Count((int)arr.size()), _arr(arr)
        {
            if (Count == 0)
                Data = nullptr;
            else
                Data = (typename ABIUtil<T>::ABIElementType*)CoTaskMemAlloc(sizeof(typename ABIUtil<T>::ABIElementType) * Count);

            for (size_t i = 0; i < (size_t)Count; i++)
                Data[i] = ABIUtil<T>::ToABI(_arr[i]);
        }

        ~ArrayRefCallbackConverter()
        {
            if (Count != _arr.size())
                _arr = CS::Array<typename ABIUtil<T>::ElementType>(Count);

            for (size_t i = 0; i < (size_t)Count; i++)
                _arr[i] = ABIUtil<T>::FromABI(Data[i]);

            if (Data)
                CoTaskMemFree(Data);
        }

        typename ABIUtil<T>::ABIElementType* Data;
        int Count;

    private:
        CS::Array<typename ABIUtil<T>::ElementType>& _arr;
    };

    template<typename Sig>
    struct DelegateRefConverter
    {
        DelegateRefConverter(void** fn, CS::IObject** ctx) : _fn(fn), _ctx(ctx), _orig(ABIUtil<CS::Delegate<Sig>>::FromABI(*fn, *ctx)), _conv(_orig)
        {
        }

        ~DelegateRefConverter()
        {
            if (_orig != _conv)
            {
                if (*_ctx)
                    (*_ctx)->Release();

                auto tuple = ABIUtil<CS::Delegate<Sig>>::ToABI(_conv);

                *_fn = tuple.Fn;
                *_ctx = tuple.Ctx;
            }
        }

        operator CS::Delegate<Sig>*() { return &_conv; }
        operator CS::Delegate<Sig>&() { return _conv; }

    private:
        void** _fn;
        CS::IObject** _ctx;
        CS::Delegate<Sig> _orig;
        CS::Delegate<Sig> _conv;
    };

    template<typename Sig>
    struct DelegateRefCallbackConverter
    {
        DelegateRefCallbackConverter(CS::Delegate<Sig>& del) : _del(del)
        {
            _orig = ABIUtil<CS::Delegate<Sig>>::ToABI(del);
            Fn = _orig.Fn;
            Ctx = _orig.Ctx;
        }

        DelegateRefCallbackConverter(CS::Delegate<Sig>* del) : _del(*del)
        {
            _orig = ABIUtil<CS::Delegate<Sig>>::ToABI(*del);
            Fn = _orig.Fn;
            Ctx = _orig.Ctx;
        }

        ~DelegateRefCallbackConverter()
        {
            if (_orig.Fn != Fn || _orig.Ctx != Ctx)
            {
                _del = ABIUtil<CS::Delegate<Sig>>::FromABI(Fn, Ctx);
            }

            if (_orig.Ctx)
                _orig.Ctx->Release();
        }

        void* Fn;
        CS::IObject* Ctx;

    private:
        ABI::DelegateBlob _orig;
        CS::Delegate<Sig>& _del;
    };

    template<typename T>
    std::false_type ArrayCheck(T a);

    template<typename T>
    std::true_type ArrayCheck(CS::Array<T> a);

    template<typename T, typename Dumb>
    struct ABIUtil
    {
        const bool DirectRef = true;

        typedef T ABIType;
        typedef T ABIElementType;
        typedef T ElementType;
        typedef PrimitiveRefConverter<T> Ref;
        typedef PrimitiveRefCallbackConverter<T> CBRef;

        static T FromABI(const T& x) { return x; }
        static T ToABI(const T& x) { return x; }
        static T& FromABIRef(T* x) { return *x; }
    };

    template<>
    struct ABIUtil<std::string>
    {
        const bool DirectRef = false;

        typedef char* ABIType;
        typedef char* ABIElementType;
        typedef std::string ElementType;
        typedef StringRefConverter Ref;
        typedef StringRefCallbackConverter CBRef;

        static std::string FromABI(const char* x) { return x ? x : ""; }
        static char* ToABI(const std::string& x) { auto sz = sizeof(char) * (x.length() + 1); auto p = CoTaskMemAlloc(sz); memcpy(p, &x[0], sz); return (char*)p; }
    };

    template<typename T>
    struct ABIUtil<T, typename std::enable_if<std::is_base_of<IUnknown, T>::value && !std::is_same<IUnknown, T>::value, void>::type>
    {
        const bool DirectRef = true;

        typedef typename T::ABIType ABIType;
        typedef typename T::ABIType* ABIElementType;
        typedef com_ptr<T> ElementType;
        typedef ComRefConverter<ABIType, T> Ref;
        typedef ComRefCallbackConverter<ABIType, T> CBRef;

        static T* FromABI(typename T::ABIType* x) { return static_cast<T*>(x); }
        static typename T::ABIType* ToABI(T* x) { return static_cast<typename T::ABIType*>(x); }
        static typename T::ABIType* ToABI(const CS::com_ptr<T>& x) { if (x) x.Get()->AddRef(); return x.Get(); }
    };

    template<>
    struct ABIUtil<IUnknown>
    {
        const bool DirectRef = true;

        typedef IUnknown ABIType;
        typedef IUnknown* ABIElementType;
        typedef CS::com_ptr<IUnknown> ElementType;
        typedef ComRefConverter<IUnknown, IUnknown> Ref;
        typedef ComRefCallbackConverter<IUnknown, IUnknown> CBRef;

        static IUnknown* FromABI(IUnknown* x) { return x; }
        static IUnknown* ToABI(const CS::com_ptr<IUnknown>& x) { if (x) x.Get()->AddRef(); return x.Get(); }
    };

    template<>
    struct ABIUtil<CS::Object>
    {
        const bool DirectRef = true;

        typedef typename IUnknown ABIType;
        typedef typename IUnknown* ABIElementType;
        typedef CS::com_ptr<CS::Object> ElementType;
        typedef ComRefConverter<IUnknown, CS::Object> Ref;
        typedef ComRefCallbackConverter<IUnknown, CS::Object> CBRef;

        static CS::Object* FromABI(IUnknown* x) { return reinterpret_cast<CS::Object*>(x); }
        static IUnknown* ToABI(const CS::com_ptr<CS::Object>& x) { IUnknown* ret = nullptr; if (x) x.Get()->QueryInterface(_uuidof(IUnknown), (void**)&ret); return ret; }
    };

    template<typename T>
    struct ABIUtil<CS::Array<T>>
    {
        const bool DirectRef = false;

        typedef ABI::Array<typename ABIUtil<T>::ABIElementType> ABIType;
        typedef void ABIElementType; // Arrays of arrays are not supported
        typedef void ElementType;
        typedef ArrayRefConverter<T> Ref;
        typedef ArrayRefCallbackConverter<T> CBRef;

        static CS::Array<T> FromABI(typename ABIUtil<T>::ABIElementType* ptr, int count)
        {
            CS::Array<T> ret(count);
            for (size_t i = 0; i < (size_t)count; i++)
                ret[i] = ABIUtil<T>::FromABI(ptr[i]);
            return ret;
        }

        static CS::Array<T> FromABI(const ABIType& x)
        {
            CS::Array<T> ret(x.size());
            for (size_t i = 0; i < (size_t)x.size(); i++)
                ret[i] = ABIUtil<T>::FromABI(x[i]);
            return ret;
        }

        static ABIType ToABI(const CS::Array<T>& x)
        {
            if (!x.size()) return ABIType(nullptr, 0);

            auto data = (typename ABIUtil<T>::ABIElementType*)CoTaskMemAlloc(sizeof(typename ABIUtil<T>::ABIElementType) * x.size());
            for (size_t i = 0; i < (size_t)x.size(); i++)
                data[i] = ABIUtil<T>::ToABI(x[i]);
            return ABIType(data, (int)x.size());
        }

        static void FreeABI(const ABIType& x)
        {
            for (size_t i = 0; i < (size_t)x.size(); i++)
                ABIUtil<T>::FreeABI(x[i]);
        }
    };

    template<typename T>
    struct ABIUtil<CS::Array<CS::com_ptr<T>>>
    {
        const bool DirectRef = false;

        typedef ABI::Array<typename ABIUtil<T>::ABIElementType> ABIType;
        typedef void ABIElementType; // Arrays of arrays are not supported
        typedef void ElementType;
        typedef ArrayRefConverter<T> Ref;
        typedef ArrayRefCallbackConverter<T> CBRef;

        static CS::Array<CS::com_ptr<T>> FromABI(typename ABIUtil<T>::ABIElementType* ptr, int count)
        {
            CS::Array<CS::com_ptr<T>> ret(count);
            for (size_t i = 0; i < (size_t)count; i++)
                ret[i] = ABIUtil<T>::FromABI(ptr[i]);
            return ret;
        }

        static CS::Array<CS::com_ptr<T>> FromABI(const ABIType& x)
        {
            CS::Array<CS::com_ptr<T>> ret(x.size());
            for (size_t i = 0; i < x.size(); i++)
                ret[i] = ABIUtil<T>::FromABI(x[i]);
            return ret;
        }

        static ABIType ToABI(const CS::Array<com_ptr<T>>& x)
        {
            if (!x.size()) return ABIType(nullptr, 0);

            auto data = (typename ABIUtil<T>::ABIElementType*)CoTaskMemAlloc(sizeof(typename ABIUtil<T>::ABIElementType) * x.size());
            for (size_t i = 0; i < x.size(); i++)
                data[i] = ABIUtil<T>::ToABI(x[i]);
            return ABIType(data, (int)x.size());
        }

        static void FreeABI(const ABIType& x)
        {
            for (size_t i = 0; i < x.size(); i++)
                ABIUtil<T>::FreeABI(x[i]);
        }
    };

    template<typename T>
    using ABIReturn = typename ABIUtil<T>::ABIElementType;

    template<typename T>
    using ABIOf = typename ABIUtil<T>::ABIType;

    template<typename T>
    using ABIRef = typename ABIUtil<T>::Ref;

    template<typename T>
    using ABICallbackRef = typename ABIUtil<T>::CBRef;

    template<typename Sig>
    struct ABIUtil<CS::Delegate<Sig>>
    {
        const char* Designation = "Delegate";
        const bool DirectRef = false;

        typedef DelegateRefConverter<Sig> Ref;
        typedef DelegateRefCallbackConverter<Sig> CBRef;
        typedef ABI::DelegateBlob ABIType;
        typedef ABI::DelegateBlob ABIElementType;
        typedef CS::Delegate<Sig> ElementType;

        static CS::Delegate<Sig> FromABI(void* fptr, CS::IObject* ctx);
        static ABIType ToABI(const CS::Delegate<Sig>& x);

        static CS::Delegate<Sig> FromABI(const ABIType& x)
        {
            return FromABI(x.Fn, x.Ctx);
        }
    };

    template<typename T>
    struct is_task
    {
        static const bool value = false;
    };

    template<typename T>
    struct is_task<concurrency::task<T>>
    {
        static const bool value = true;
    };

    template<typename T>
    struct ABIUtil<T, typename std::enable_if<
        std::is_class<T>::value &&
        !std::is_base_of<IUnknown, T>::value &&
        !is_task<T>::value &&
        !std::is_same<std::true_type, decltype(ArrayCheck(T()))>::value &&
        !std::is_base_of<CS::DelegateBase, T>::value>::type>
    {
        typedef typename T ABIType;
        typedef typename T ABIElementType;
        typedef typename T ElementType;
        typedef T ElementType;
        typedef typename StructRefPassthrough<T> Ref;
        typedef typename StructRefCallbackPassthrough<T> CBRef;

        static const T& FromABI(const T& x) { return x; }
        static const T& ToABI(const T& x) { return x; }
        static void FreeABI(const T& x) { }
    };

    template<typename T, typename ABI>
    struct StructABI
    {
        typedef typename ABI ABIType;
        typedef typename ABI ABIElementType;
        typedef T ElementType;
        typedef typename StructRefConverter<T, ABI> Ref;
        typedef typename StructRefCallbackConverter<T, ABI> CBRef;
    };
}

#define MapStructABI(T,ABI_T)                                    \
namespace GluonInternal {                                        \
    template<> struct ABIUtil<T> : public StructABI<T,ABI_T>     \
    {                                                            \
        static T FromABI(const ABI_T& x);                        \
        static ABI_T ToABI(const T& x);                          \
        static void FreeABI(const ABI_T& x);                     \
    };                                                           \
 }


IS_GENERIC_REFTYPE(1, GluonInternal::DelegateContext, "CD849D44-0E94-4428-9403-EF8009561A61");

#endif