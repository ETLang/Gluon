using ABI.Gluon;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Gluon
{
    public class GluonObject : IDisposable
    {
        public IntPtr NativePtr { get; private set; }

        public static implicit operator bool(GluonObject obj)
        {
            return obj != null && !obj._disposed;
        }

        public static bool operator!(GluonObject obj)
        {
            return obj == null || obj._disposed;
        }

        /// <summary>
        /// Processes exceptions thrown by handlers of callback events.
        /// </summary>
        /// <remarks>
        /// If this is not set, exceptions thrown while processing callback events will be swallowed and ignored.
        /// </remarks>
        public static Action<Exception> CallbackEventExceptionHandler;

        protected GluonObject(AbiPtr native)
        {
            // Reference counting model: Callees with output parameters are responsible for adding a reference to output objects
            //Marshal.AddRef(native.Value);
            NativePtr = GetRootPointer(native.Value);

            lock (All)
            {
                All.Add(NativePtr, new WeakReference(this));
            }
        }

        #region Disposal

        ~GluonObject()
        {
            OnDispose(true);
        }

#if !WINDOWS_UWP
        public static void DisposeAssembly(Assembly a)
        {
            List<IDisposable> toDispose = new List<IDisposable>();

            lock(All)
            {
                foreach(var weakRef in All.Values)
                {
                    var go = weakRef.Target as IDisposable;

                    if(go != null)
                    {
                        if (go.GetType().Assembly == a)
                            toDispose.Add(go);
                    }
                }
            }

            foreach (var obj in toDispose)
                obj.Dispose();
        }
#endif

        public static void DisposeAll()
        {
            List<IDisposable> toDispose = new List<IDisposable>();

            lock (All)
            {
                foreach (var weakRef in All.Values)
                {
                    var go = weakRef.Target as IDisposable;

                    if (go != null)
                        toDispose.Add(go);
                }
            }

            foreach (var obj in toDispose)
                obj.Dispose();
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            GC.SuppressFinalize(this);

            OnDispose(false);
        }

        protected virtual void OnDispose(bool finalizing)
        {
            lock (All)
            {
                All.Remove(NativePtr);
            }

            if(NativePtr != IntPtr.Zero)
                Marshal.Release(NativePtr);

            NativePtr = IntPtr.Zero;
        }

        private bool _disposed;

        #endregion

        #region Wrapper Lookup

        private static IntPtr GetRootPointer(IntPtr native)
        {
            var id = VTObject.Id;
            IntPtr ptr;
            Marshal.QueryInterface(native, ref id, out ptr);
            if (ptr == IntPtr.Zero)
                return IntPtr.Zero;
            Marshal.Release(ptr);

            VTObject io = VTUnknown.GetVTable<VTObject>(ptr);
            io.GetTypeId(ptr, ref id);
            return io.CastTo(ptr, ref id);
        }

        public static void RegisterType<T>(Guid id, Func<IntPtr, GluonObject> wrapctor)
        {
            lock (All)
            {
                WrapperTypes[id] = typeof(T);
                WrapperFactories[id] = wrapctor;
            }
        }
        
        /// <summary>
        /// Gets the GluonObject representation of the underlying pointer.
        /// If GluonObject already existed,
        /// calls Marshal.Release() on the native pointer before returning the existing object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="native"></param>
        /// <returns></returns>
        public static T Of<T>(IntPtr native) where T : GluonObject
        {
            if (native == IntPtr.Zero) return null;

            lock (All)
            {
                WeakReference rret;
                GluonObject ret;
                if (All.TryGetValue(native, out rret) || All.TryGetValue(GetRootPointer(native), out rret))
                {
                    ret = rret.Target as GluonObject;
                    Marshal.Release(native);
                }
                else
                {
                    var id = VTObject.Id;

                    IntPtr ioPtr;
                    Marshal.QueryInterface(native, ref id, out ioPtr);

                    if (ioPtr == IntPtr.Zero)
                        return null;

                    VTObject io = VTUnknown.GetVTable<VTObject>(ioPtr);
                    io.GetTypeId(ioPtr, ref id);
                    Marshal.Release(ioPtr);
                    Func<IntPtr, GluonObject> factory;
                    if (!WrapperFactories.TryGetValue(id, out factory))
                        return null;

                    ret = factory(ioPtr);
                    if (ret == null)
                        throw new Exception("Failed to construct wrapper for native type " + native.GetType().ToString());
                }

                return ret as T;
            }
        }

        public static IntPtr[] ArrayUnwrap(GluonObject[] arr)
        {
            var ret = new IntPtr[arr.Length];
            for (int i = 0; i < ret.Length; i++)
                ret[i] = (arr[i] == null) ? IntPtr.Zero : arr[i].NativePtr;
            return ret;
        }

        public static T[] ArrayWrap<T>(IntPtr[] native) where T : GluonObject
        {
            var ret = new T[native.Length];
            for (int i = 0; i < ret.Length; i++)
                ret[i] = Of<T>(native[i]);
            return ret;
        }

        public static HResult ExceptionToHResult(Exception e)
        {
            if (e is ArgumentNullException)
                return HResult.E_POINTER;
            if (e is ArgumentException)
                return HResult.E_INVALIDARG;
            if (e is InvalidOperationException)
                return HResult.E_UNEXPECTED;
            if (e is NotImplementedException)
                return HResult.E_NOTIMPL;
            if (e is UnauthorizedAccessException)
                return HResult.E_ACCESSDENIED;

            if (e != null)
                return HResult.E_FAIL;

            return HResult.S_OK;
        }

        private static Dictionary<IntPtr, WeakReference> All = new Dictionary<IntPtr, WeakReference>();
        private static Dictionary<Guid, Type> WrapperTypes = new Dictionary<Guid, Type>();
        private static Dictionary<Guid, Func<IntPtr, GluonObject>> WrapperFactories = new Dictionary<Guid, Func<IntPtr, GluonObject>>();

        #endregion
    }
}
