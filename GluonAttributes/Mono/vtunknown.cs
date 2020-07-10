using System;
using System.Runtime.InteropServices;

namespace Gluon
{
    [Guid("00000000-0000-0000-C000-000000000046")]
    [StructLayout(LayoutKind.Sequential)]
    public struct VTUnknown
    {
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly AddRef_t AddRef;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate uint AddRef_t(IntPtr i);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Release_t Release;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate uint Release_t(IntPtr i);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly QueryInterface_t QueryInterface;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int QueryInterface_t(IntPtr i, ref Guid iid, out IntPtr pptr);

        public static VT GetVTable<VT>(IntPtr ptr) where VT : struct
        {
            var vtptr = Marshal.ReadIntPtr(ptr);
#if WINDOWS_UWP
            return Marshal.PtrToStructure<VT>(vtptr);
#else
            return (VT)Marshal.PtrToStructure(vtptr, typeof(VT));
#endif
            //return (VT)Marshal.PtrToStructure(ptr, typeof(VT));
        }
    }
}
