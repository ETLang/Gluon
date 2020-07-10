using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gluon
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VTTaskABI
    {
        public VTUnknown Unknown;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SetCompletionCallback_t SetCompletionCallback;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate uint SetCompletionCallback_t(IntPtr i, IntPtr fn, IntPtr fn_ctx);
    }
}
