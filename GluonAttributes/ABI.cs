using Gluon;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ABI.Gluon
{
    public class GluonExceptionAssertionFail : Exception
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AbiPtr
    {
        public IntPtr Value;

        public AbiPtr(IntPtr value) { Value = value; }
    }

    public enum ExceptionType : uint
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

    public struct DelegateBlob
    {
        public IntPtr Fn;
        public IntPtr Ctx;

        public DelegateBlob(IntPtr fn, IntPtr ctx) { Fn = fn; Ctx = ctx; }
    }

    public struct ArrayBlob
    {
        public IntPtr Ptr;
        public int Count;

        public ArrayBlob(IntPtr ptr, int count) { Ptr = ptr; Count = count; }
    }

    public static class Translate
    {
        public static ExceptionType Exception(Exception ex)
        {
#if WINDOWS_UWP
            if (ex is UnauthorizedAccessException)
                return ExceptionType.AccessDenied;
#else
            if (ex is AccessViolationException)
                return ExceptionType.AccessDenied;
#endif
            else if (ex is ArgumentException)
                return ExceptionType.Argument;
            else if (ex is ArgumentNullException)
                return ExceptionType.ArgumentNull;
            else if (ex is InvalidOperationException)
                return ExceptionType.InvalidOperation;
            else if (ex is NotImplementedException)
                return ExceptionType.NotImplemented;
            else if (ex is NullReferenceException)
                return ExceptionType.NullReference;
            else
                return ExceptionType.Generic;
        }

        public static Exception Exception(ExceptionType type, string msg)
        {
            switch (type)
            {
                case ExceptionType.AccessDenied:
#if WINDOWS_UWP
                    return new UnauthorizedAccessException(msg);
#else
                    return new AccessViolationException(msg);
#endif
                case ExceptionType.Argument:
                    return new ArgumentException(msg);
                case ExceptionType.ArgumentNull:
                    return new ArgumentNullException(msg);
                case ExceptionType.InvalidOperation:
                    return new InvalidOperationException(msg);
                case ExceptionType.NotImplemented:
                    return new NotImplementedException(msg);
                case ExceptionType.NullReference:
                    return new NullReferenceException(msg);
                default:
                    return new Exception(msg);
            }
        }
    }
    
    public class D_Base
    {
        protected IntPtr _ctx;

        public D_Base(IntPtr ctx)
        {
            _ctx = ctx;
        }

        ~D_Base() { Marshal.Release(_ctx); }

        //public static T Of<T>(object native) where T : GluonObject
        //{
        //    return GluonObject.Of<T>(native);
        //}
    }

    public static class MConv_
    {
        [DllImport("msvcrt.dll", SetLastError = false)]
        static extern unsafe IntPtr memcpy(void* dest, void* src, int count);

#region Primitives

#region uint

        public static unsafe uint[] FromABI_uint(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new uint[count];
            fixed (void* dest = &r[0])
            {
                memcpy(dest, (void*)data, count * sizeof(uint));
            }
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static unsafe ArrayBlob ToABI_uint(uint[] arr)
        {
            var r = new ArrayBlob();
            var sz = arr.Length * sizeof(uint);
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz);
            fixed(void* src = &arr[0])
            {
                memcpy((void*)r.Ptr, src, sz);
            }
            return r;
        }

        public static void FreeABI_uint(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region ushort

        public static unsafe ushort[] FromABI_ushort(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new ushort[count];
            fixed (void* dest = &r[0])
            {
                memcpy(dest, (void*)data, count * sizeof(ushort));
            }
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static unsafe ArrayBlob ToABI_ushort(ushort[] arr)
        {
            var r = new ArrayBlob();
            var sz = arr.Length * sizeof(ushort);
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz);
            fixed (void* src = &arr[0])
            {
                memcpy((void*)r.Ptr, src, sz);
            }
            return r;
        }

        public static void FreeABI_ushort(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region sbyte

        public static unsafe sbyte[] FromABI_sbyte(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new sbyte[count];
            fixed (void* dest = &r[0])
            {
                memcpy(dest, (void*)data, count * sizeof(sbyte));
            }
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static unsafe ArrayBlob ToABI_sbyte(sbyte[] arr)
        {
            var r = new ArrayBlob();
            var sz = arr.Length * sizeof(sbyte);
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz);
            fixed (void* src = &arr[0])
            {
                memcpy((void*)r.Ptr, src, sz);
            }
            return r;
        }

        public static void FreeABI_sbyte(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region ulong

        public static unsafe ulong[] FromABI_ulong(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new ulong[count];
            fixed (void* dest = &r[0])
            {
                memcpy(dest, (void*)data, count * sizeof(ulong));
            }
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static unsafe ArrayBlob ToABI_ulong(ulong[] arr)
        {
            var r = new ArrayBlob();
            var sz = arr.Length * sizeof(ulong);
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(sz);
            fixed (void* src = &arr[0])
            {
                memcpy((void*)r.Ptr, src, sz);
            }
            return r;
        }

        public static void FreeABI_ulong(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region byte

        public static byte[] FromABI_byte(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new byte[count];
            Marshal.Copy(data, r, 0, count);
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_byte(byte[] arr)
        {
            var r = new ArrayBlob();
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sizeof(byte));
            Marshal.Copy(arr, 0, r.Ptr, arr.Length);
            return r;
        }

        public static void FreeABI_byte(IntPtr data, int count)
        {
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region char

        public static unsafe char[] FromABI_char(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new char[count];
            fixed (char* rb = &r[0])
            {
                Encoding.ASCII.GetChars((byte*)data, count, rb, count);
            }
            //Marshal.Copy(data, r, 0, count);
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static unsafe ArrayBlob ToABI_char(char[] arr)
        {
            var r = new ArrayBlob();
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sizeof(char));
            fixed (char* arrb = &arr[0])
            {
                Encoding.ASCII.GetBytes(arrb, arr.Length, (byte*)r.Ptr, arr.Length);
            }
            //Marshal.Copy(arr, 0, r.Ptr, arr.Length);
            return r;
        }

        public static void FreeABI_char(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region double

        public static double[] FromABI_double(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new double[count];
            Marshal.Copy(data, r, 0, count);
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_double(double[] arr)
        {
            var r = new ArrayBlob();
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sizeof(double));
            Marshal.Copy(arr, 0, r.Ptr, arr.Length);
            return r;
        }

        public static void FreeABI_double(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region float

        public static float[] FromABI_float(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new float[count];
            Marshal.Copy(data, r, 0, count);
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_float(float[] arr)
        {
            var r = new ArrayBlob();
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sizeof(float));
            Marshal.Copy(arr, 0, r.Ptr, arr.Length);
            return r;
        }

        public static void FreeABI_float(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region int

        public static int[] FromABI_int(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new int[count];
            Marshal.Copy(data, r, 0, count);
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_int(int[] arr)
        {
            var r = new ArrayBlob();
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sizeof(int));
            Marshal.Copy(arr, 0, r.Ptr, arr.Length);
            return r;
        }

        public static void FreeABI_int(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region short

        public static short[] FromABI_short(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new short[count];
            Marshal.Copy(data, r, 0, count);
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_short(short[] arr)
        {
            var r = new ArrayBlob();
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sizeof(short));
            Marshal.Copy(arr, 0, r.Ptr, arr.Length);
            return r;
        }

        public static void FreeABI_short(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region long

        public static long[] FromABI_long(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new long[count];
            Marshal.Copy(data, r, 0, count);
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_long(long[] arr)
        {
            var r = new ArrayBlob();
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sizeof(long));
            Marshal.Copy(arr, 0, r.Ptr, arr.Length);
            return r;
        }

        public static void FreeABI_long(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#region IntPtr

        public static IntPtr[] FromABI_IntPtr(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;
            var r = new IntPtr[count];
            Marshal.Copy(data, r, 0, count);
            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_IntPtr(IntPtr[] arr)
        {
            var r = new ArrayBlob();
            if (arr == null) return r;
            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * IntPtr.Size);
            Marshal.Copy(arr, 0, r.Ptr, arr.Length);
            return r;
        }

        public static void FreeABI_IntPtr(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;
            Marshal.FreeCoTaskMem(data);
        }

#endregion

#endregion

#region String

        public static string[] FromABI_string(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return null;

            var r = new string[count];
            var sz = IntPtr.Size;

            for (int i = 0; i < count; i++)
            {
                var ptr = Marshal.ReadIntPtr((IntPtr)((long)data + sz * i));
                r[i] = Marshal.PtrToStringUni(ptr);
                Marshal.FreeCoTaskMem(ptr);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_string(string[] arr)
        {
            var r = new ArrayBlob();
            var sz = IntPtr.Size;

            if (arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sz);

            for(int i = 0;i < arr.Length;i++)
                Marshal.WriteIntPtr((IntPtr)((long)r.Ptr + sz * i), Marshal.StringToCoTaskMemUni(arr[i]));

            return r;
        }

        public static void FreeABI_string(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;

            var sz = IntPtr.Size;
            for(int i = 0;i < count;i++)
                Marshal.FreeCoTaskMem(Marshal.ReadIntPtr((IntPtr)((long)data + sz * i)));
            Marshal.FreeCoTaskMem(data);
        }

        public static unsafe string FromABI_string(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return null;

            var c = (byte*)ptr;
            var i = c;
            while (*i != '\0')
                i++;
            int len = (int)(i - c);
            var data = new byte[len];
            Marshal.Copy(ptr, data, 0, len);
            var s = Encoding.UTF8.GetString(data);
            Marshal.FreeCoTaskMem(ptr);
            return s;
        }

        public static IntPtr ToABI_string(string s)
        {
            if (s == null) return IntPtr.Zero;

            var bytes = Encoding.UTF8.GetByteCount(s);
            var data = new byte[bytes + 1];

            Encoding.UTF8.GetBytes(s, 0, s.Length, data, 0);
            var ret = Marshal.AllocCoTaskMem(bytes + 1);
            Marshal.Copy(data, 0, ret, bytes + 1);
            return ret;
        }

        public static void FreeABI_string(IntPtr ptr)
        {
            Marshal.FreeCoTaskMem(ptr);
        }

#endregion

#region Object

        public static T[] FromABI_Object<T>(IntPtr data, int count) where T : GluonObject
        {
            if (data == IntPtr.Zero)
                return null;

            var r = new T[count];
            var sz = IntPtr.Size;

            for (int i = 0; i < count; i++)
            {
                var unk = Marshal.ReadIntPtr((IntPtr)((long)data + sz * i));
                //var unk = Marshal.ReadIntPtr(ptr);
                r[i] = GluonObject.Of<T>(unk);
            }

            Marshal.FreeCoTaskMem(data);
            return r;
        }
        
        public static ArrayBlob ToABI_Object(GluonObject[] arr)
        {
            var r = new ArrayBlob();
            var sz = IntPtr.Size;

            if (arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sz);

            for (int i = 0; i < arr.Length; i++)
            {
                var unk = (arr[i] == null) ? IntPtr.Zero : arr[i].NativePtr;
                Marshal.WriteIntPtr((IntPtr)((long)r.Ptr + sz * i), unk);

                if(unk != IntPtr.Zero)
                    Marshal.AddRef(unk);
            }

            return r;
        }

        public static void FreeABI_Object(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;

            var sz = IntPtr.Size;
            for (int i = 0; i < count; i++)
            {
                var unk = Marshal.ReadIntPtr((IntPtr)((long)data + sz * i));
                if (unk != IntPtr.Zero)
                    Marshal.Release(unk);
            }
            Marshal.FreeCoTaskMem(data);
        }

        public static T FromABI_Object<T>(IntPtr ptr) where T : GluonObject
        {
            var r = GluonObject.Of<T>(ptr);

            if (ptr != IntPtr.Zero)
                Marshal.Release(ptr);

            return r;
        }
        
        public static IntPtr ToABI_Object(GluonObject x)
        {
            if (x == null) return IntPtr.Zero;

            Marshal.AddRef(x.NativePtr);
            return x.NativePtr;
        }

        public static void FreeABI_Object(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
                Marshal.Release(ptr);
        }

#endregion

#region Blittable Struct

        public static T[] FromABI_BlittableStruct<T>(IntPtr data, int count) where T : struct
        {
            if (data == IntPtr.Zero) return null;

            var r = new T[count];
#if WINDOWS_UWP
            var sz = Marshal.SizeOf<T>();
#else
            var sz = Marshal.SizeOf(typeof(T));
#endif

            for (int i = 0; i < count; i++)
                Marshal.PtrToStructure((IntPtr)((long)data + sz * i), r[i]);

            Marshal.FreeCoTaskMem(data);
            return r;
        }

        public static ArrayBlob ToABI_BlittableStruct<T>(T[] arr) where T : struct
        {
            var r = new ArrayBlob();
#if WINDOWS_UWP
            var sz = Marshal.SizeOf<T>();
#else
            var sz = Marshal.SizeOf(typeof(T));
#endif

            if (arr == null) return r;

            r.Count = arr.Length;
            r.Ptr = Marshal.AllocCoTaskMem(arr.Length * sz);

            for (int i = 0; i < arr.Length; i++)
                Marshal.StructureToPtr(arr[i], (IntPtr)((long)r.Ptr + sz * i), false);

            return r;
        }

        public static void FreeABI_BlittableStruct(IntPtr data, int count)
        {
            if (data == IntPtr.Zero) return;
            Marshal.FreeCoTaskMem(data);
        }

#endregion
    }
}
