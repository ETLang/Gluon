using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gluon.ABI
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void ABITaskCompletedCallback(bool cancelled, int exception, IntPtr result);

    [ComImport, Guid("41D9BE8E-3470-4090-951F-9692FEB20A8C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskABI : IObject
    {
        [PreserveSig]
        new IntPtr CastTo(ref Guid id);

        new Guid GetTypeId();

        new IntPtr Reserved();

        [PreserveSig]
        int SetCallback([MarshalAs(UnmanagedType.FunctionPtr)] ABITaskCompletedCallback callback);
    }
}
