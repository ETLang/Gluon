using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gluon
{
    [StructLayout(LayoutKind.Sequential)]
    struct VTGluonObject
    {
        public static readonly Guid Id = new Guid("1c4bc992-f5ad-4af7-ae86-c7f6a7474d91");
        public readonly VTObject Object;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetObjectTypeId_sig GetObjectTypeId;
        public delegate int GetObjectTypeId_sig(IntPtr i, ref Guid id);

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly GetObjectTypeName_sig GetObjectTypeName;
        public delegate int GetObjectTypeName_sig(IntPtr i, [Out, MarshalAs(UnmanagedType.LPStr)] out string name);
    }
}
