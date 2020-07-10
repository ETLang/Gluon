using System;
using System.Runtime.InteropServices;

namespace Gluon
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VTObject
    {
        public static readonly Guid Id = new Guid("428EDA6A-3C61-4FE9-AAE5-012C69672D38");
        public readonly VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly CastTo_sig CastTo;
        public delegate IntPtr CastTo_sig(IntPtr i, ref Guid id);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetTypeId_sig GetTypeId;
        public delegate int GetTypeId_sig(IntPtr i, ref Guid id);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly Reserved_sig Reserved;
        public delegate int Reserved_sig(IntPtr i, out IntPtr ptr);
    }
}
