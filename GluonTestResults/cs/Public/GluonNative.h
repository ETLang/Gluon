#pragma once

#include <CSLike.h>
#include <string>
#include <objbase.h>

#ifdef GLUON_BUILDING
#define ABI_CONSTRUCTOR extern "C" __declspec(dllexport) HRESULT __stdcall
#else
#define ABI_CONSTRUCTOR extern "C" __declspec(dllimport) HRESULT __stdcall
#endif

#define $Line TOSTRING( __LINE__ )
#define Not_Implemented_Warning __pragma( message( __FILE__ "(" $Line "):Warning: " __FUNCTION__ " - Function not yet implemented!" ))

#define ABIArrayArg(T,name) T* name, int name##_count
#define ABIRefArrayArg(T,name) T** name, int* name##_count

#define TRANSLATE_EXCEPTIONS												\
	catch(CS::NullReferenceException const&) { return E_FAIL; }				\
	catch(CS::AccessDeniedException const&) { return E_ACCESSDENIED; }		\
	catch(CS::InvalidOperationException const&) { return E_UNEXPECTED; }	\
	catch(CS::ArgumentNullException const&) { return E_POINTER; }			\
	catch(CS::ArgumentException const&) { return E_INVALIDARG; }			\
	catch(CS::NotImplementedException const&) { return E_NOTIMPL; }			\
	catch(CS::Exception const&) { return E_FAIL; }							\
	catch(std::exception const&) { return E_FAIL; }							\
    catch(...) { return E_FAIL; }

struct IUnknown;

namespace ABI
{
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
		size_t size() const { return _length; }

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


}

namespace GluonInternal
{
	template<typename T, bool isCom = std::is_base_of<IUnknown, T>::value, bool isClass = std::is_class<T>::value>
	struct GTT
	{
		typedef T ABIType;
		typedef T ABIElementType;
		const bool ABIDirectRef = true;
	};

	template<typename T>
	struct GTT<T, true, true>
	{
		typedef typename T::ABIType ABIType;
		typedef typename T::ABIType* ABIElementType;

		const bool ABIDirectRef = true;
	};

	template<typename T>
	struct GTT<T, false, true>
	{
		typedef typename T::ABIType ABIType;
		typedef typename T::ABIType ABIElementType;

		const bool ABIDirectRef = T::MatchesABI;
	};

	template<typename T>
	struct GTT<CS::Array<T>, false, true>
	{
		typedef ABI::Array<typename GTT<typename T::ElementType>::ABIType> ABIType;
		typedef void ABIElementType; // Arrays of arrays not supported

		const bool ABIDirectRef = false;
	};

	template<>
	struct GTT<CS::String, false, false>
	{
		typedef wchar_t* ABIType;
		typedef wchar_t* ABIElementType;
		const bool ABIDirectRef = false;
	};

	template<typename T>
	struct PrimitiveRefConverter
	{
		PrimitiveRefConverter(T*& ref) : _ref(ref) { }

		operator T&() { return *_ref; }

	private:
		T*& _ref;
	};

	struct StringRefConverter
	{
		StringRefConverter(wchar_t**& ref) : _ref(ref)
		{
			_conv = *ref;
		}

		~StringRefConverter()
		{
			auto len = _conv.length();
			auto sz = sizeof(wchar_t) * (len + 1);
			*_ref = (wchar_t*)CoTaskMemAlloc(sz);
			(*_ref)[len] = L'\0';
			memcpy_s(*_ref, sz, &_conv[0], sz - sizeof(wchar_t));
		}

		operator CS::String&() { return _conv; }

	private:
		wchar_t**& _ref;
		CS::String _conv;
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
		ABI** _ref;
		CS::com_ptr<T> _conv;
	};

	template<typename, typename = void>
	struct ABIUtil;

	template<typename T>
	struct StructRefConverter
	{
		StructRefConverter(typename ABIUtil<T>::ABIType* ref) : _ref(ref), _conv(ABIUtil<T>::FromABI(*ref))
		{
		}

		~StructRefConverter()
		{
			*_ref = ABIUtil<T>::ToABI(_conv);
		}

		operator T&() { return _conv; }

	private:
		typename ABIUtil<T>::ABIType* _ref;
		T _conv;
	};

	template<typename T>
	struct ArrayRefConverter
	{
		ArrayRefConverter(typename ABIUtil<T>::ABIType** ptr, int* count) : _ptr(ptr), _count(count), _conv(*count)
		{
			for (size_t i = 0; i < *_count; i++)
				_conv[i] = ABIUtil<T>::FromABI((*ptr)[i]);
		}

		//ArrayRefConverter(ABI::ArrayRef<typename ABIUtil<T>::ABIType>& ref) : _ref(ref), _conv(_ref.size())
		//{
		//	for (size_t i = 0; i < _ref.size(); i++)
		//		_conv[i] = ABIUtil<T>::FromABI(_ref[i]);
		//}

		~ArrayRefConverter()
		{
			if (*_count != _conv.size())
			{
				if (*_ptr)
					CoTaskMemFree(*_ptr);
				*_ptr = (typename ABIUtil<T>::ABIElementType*)CoTaskMemAlloc(sizeof(typename ABIUtil<T>::ABIElementType) * _conv.size());
				*_count = (int)_conv.size();
			}

			for (size_t i = 0; i < _conv.size(); i++)
				(*_ptr)[i] = ABIUtil<T>::ToABI(_conv[i]);
			//_ref = ABI::Array<typename ABIUtil<T>::ABIType>(outPtr, (int)_conv.size());
		}

		operator CS::Array<T>&() { return _conv; }
	private:
		//ABI::ArrayRef<typename ABIUtil<T>::ABIType>& _ref;
		typename ABIUtil<T>::ABIType** _ptr;
		int* _count;
		CS::Array<T> _conv;
	};

	template<typename T>
	std::false_type ArrayCheck(T a);

	template<typename T>
	std::true_type ArrayCheck(CS::Array<T> a);

	template<typename T, typename Dumb>
	struct ABIUtil
	{
		const wchar_t* Designation = L"Primitive";
		const bool DirectRef = true;

		typedef T ABIType;
		typedef T ABIElementType;
		typedef PrimitiveRefConverter<T> Ref;

		static T FromABI(const T& x) { return x; }
		static T ToABI(const T& x) { return x; }
		static T& FromABIRef(T* x) { return *x; }
	};

	template<>
	struct ABIUtil<CS::String>
	{
		const wchar_t* Designation = L"String";
		const bool DirectRef = false;

		typedef wchar_t* ABIType;
		typedef wchar_t* ABIElementType;
		typedef StringRefConverter Ref;

		static std::wstring FromABI(const wchar_t* x) { return x; }
		static wchar_t* ToABI(const std::wstring& x) { auto sz = sizeof(wchar_t) * (x.length() + 1); auto p = CoTaskMemAlloc(sz); memcpy(p, &x[0], sz); return (wchar_t*)p; }
	};

	template<typename T>
	struct ABIUtil<T, typename std::enable_if<std::is_base_of<IUnknown, T>::value, void>::type>
	{
		const wchar_t* Designation = L"Object";
		const bool DirectRef = true;

		typedef typename T::ABIType ABIType;
		typedef typename T::ABIType* ABIElementType;
		typedef ComRefConverter<typename T::ABIType, T> Ref;

		static T* FromABI(typename T::ABIType* x) { return static_cast<T*>(x); }
		static typename T::ABIType* ToABI(const CS::com_ptr<T>& x) { x.Get()->AddRef(); return x.Get(); }
	};

	template<>
	struct ABIUtil<CS::Object>
	{
		const wchar_t* Designation = L"Object";
		const bool DirectRef = true;

		typedef typename IUnknown ABIType;
		typedef typename IUnknown* ABIElementType;
		typedef ComRefConverter<IUnknown, CS::Object> Ref;

		static CS::Object* FromABI(IUnknown* x) { return reinterpret_cast<CS::Object*>(x); }
		static IUnknown* ToABI(const CS::com_ptr<CS::Object>& x) { IUnknown* ret; x.Get()->QueryInterface(_uuidof(IUnknown), (void**)&ret); return ret; }
	};

	template<typename T>
	struct ABIUtil<CS::Array<T>, void>
	{
		const wchar_t* Designation = L"Array";
		const bool DirectRef = false;

		typedef ABI::Array<typename ABIUtil<T>::ABIType> ABIType;
		typedef void ABIElementType; // Arrays of arrays are not supported
		typedef ArrayRefConverter<T> Ref;

		static CS::Array<T> FromABI(typename ABIUtil<T>::ABIElementType* ptr, int count)
		{
			CS::Array<T> ret(count);
			for (size_t i = 0; i < count; i++)
				ret[i] = ABIUtil<T>::FromABI(ptr[i]);
			return ret;
		}

		static CS::Array<T> FromABI(const ABIType& x)
		{
			CS::Array<T> ret(x.size());
			for (size_t i = 0; i < x.size(); i++)
				ret[i] = ABIUtil<T>::FromABI(x[i]);
			return ret;
		}

		static ABIType ToABI(const CS::Array<T>& x)
		{
			auto data = (typename ABIUtil<T>::ABIElementType*)CoTaskMemAlloc(sizeof(typename ABIUtil<T>::ABIElementType*) * x.size());
			for (size_t i = 0; i < x.size(); i++)
				data[i] = ABIUtil<T>::ToABI(x[i]);
			return ABIType(data, (int)x.size());
		}
	};

	template<typename T>
	struct ABIUtil<T, typename std::enable_if<std::is_class<T>::value && !std::is_base_of<IUnknown, T>::value && !std::is_same<std::true_type, decltype(ArrayCheck(T()))>::value, void>::type>
	{
		const wchar_t* Designation = L"Class";
		//const bool DirectRef = T::MatchesABI;

		typedef typename T::ABIType ABIType;
		typedef typename T::ABIType ABIElementType;
		typedef StructRefConverter<T> Ref;

		static T FromABI(const typename T::ABIType& x);
		static typename T::ABIType ToABI(const T& x);
		//static T FromABIRef(typename T::ABIType* x) { return T(*x); }

		static T& ABIRefToRef(typename T::ABIType* x) { return *reinterpret_cast<T*>(x); }
	};
}
