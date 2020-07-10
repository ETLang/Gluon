using System;
using System.Runtime.InteropServices;

namespace Gluon
{
    public enum HResult : uint
    {
        S_OK = 0,
        S_FALSE = 1,
        E_ABORT = 0x80004004,
        E_ACCESSDENIED = 0x80070005,
        E_FAIL = 0x80004005,
        E_HANDLE = 0x80070006,
        E_INVALIDARG = 0x80070057,
        E_NOINTERFACE = 0x80004002,
        E_NOTIMPL = 0x80004001,
        E_OUTOFMEMORY = 0x8007000E,
        E_POINTER = 0x80004003,
        E_UNEXPECTED = 0x8000FFFF,
    }

    /// <summary>
    /// Stand-in for IUnknown in Gluon type definitions. At runtime, IUnknown is simply treated as object
    /// </summary>
    public interface IUnknown { }

    [ComImport, Guid("428EDA6A-3C61-4FE9-AAE5-012C69672D38")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObject
    {
        [PreserveSig]
        IntPtr CastTo(ref Guid id);

        Guid GetTypeId();

        IntPtr Reserved();
    }
}