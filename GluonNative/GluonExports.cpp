#include <Sharpish.h>
using namespace CS;

#include "GluonNative.h"

CriticalSection g_ExceptionCSec;
HRESULT g_ExceptionHR = S_OK;
ABI::ExceptionType g_ExceptionType = ABI::ExceptionType::NoException;
std::string g_ExceptionMsg;

extern HRESULT ABI::SetException(HRESULT hr, ABI::ExceptionType type, const char* msg)
{
    AutoLock lock(g_ExceptionCSec);
    g_ExceptionHR = hr;
    g_ExceptionType = type;
    g_ExceptionMsg = msg;

    return hr;
};

//void TRANSLATE_TO_EXCEPTIONS(HRESULT hr) {
//	HRESULT r = (hr);
//	if (r == E_NOTIMPL) throw CS::NotImplementedException();
//	if (r == E_INVALIDARG) throw CS::ArgumentException("");
//	if (r == E_POINTER) throw CS::ArgumentNullException("");
//	if (r == E_ACCESSDENIED) throw CS::AccessDeniedException();
//	if (r == E_UNEXPECTED) throw CS::InvalidOperationException();
//	if (!SUCCEEDED(r)) throw CS::Exception(hr);
//}

extern "C" __declspec(dllexport) HRESULT __stdcall $_GetGluonExceptionDetails(HRESULT* outHR, ABI::ExceptionType* outType, const char** outText)
{
    if (!outHR || !outText) return E_POINTER;

    AutoLock lock(g_ExceptionCSec);
    *outHR = g_ExceptionHR;
    *outType = g_ExceptionType;
    *outText = g_ExceptionMsg.c_str();

    return S_OK;
}
