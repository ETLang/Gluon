/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using UnityEngine;
using System;
using System.Runtime.InteropServices;
using ABI.GluonTest;

namespace ABI
{
    namespace LocatorDefinition
    {
        [ComImport, Guid("5125caf4-9ff0-79c3-f78d-f4361bfb851b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface Locator{
            [PreserveSig]
            int GenerateFaceImages(int sizeCentimeters, [MarshalAs(UnmanagedType.LPWStr)] string outFolder);

            [PreserveSig]
            int GetFocalLength(out Vector2 outVal);

            [PreserveSig]
            int SetFocalLength(Vector2 val);

            [PreserveSig]
            int GetPrincipalPoint(out Vector2 outVal);

            [PreserveSig]
            int SetPrincipalPoint(Vector2 val);

            [PreserveSig]
            int GetRadialDistortion(out Vector3 outVal);

            [PreserveSig]
            int SetRadialDistortion(Vector3 val);

            [PreserveSig]
            int GetTangentialDistortion(out Vector2 outVal);

            [PreserveSig]
            int SetTangentialDistortion(Vector2 val);

            [PreserveSig]
            int GetLatestPosition(out Vector3 outVal);

            [PreserveSig]
            int SetLatestPosition(Vector3 val);

            [PreserveSig]
            int GetLatestRotation(out Quaternion outVal);

            [PreserveSig]
            int SetLatestRotation(Quaternion val);
        }

        internal static partial class Factory
        {
            [DllImport(Native.DllPath)]
            public static extern int Create_Locator(out Locator newInstance);

        }
    }
}
