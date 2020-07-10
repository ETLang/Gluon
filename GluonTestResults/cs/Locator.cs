/* This file is automatically maintained by Gluon.
 * Do not attempt to modify, as any modifications will be overwritten.
 */

using UnityEngine;
using System;
using Gluon;
using System.Runtime.InteropServices;

namespace LocatorDefinition
{
    [GluonGenerated(abi: typeof(ABI.LocatorDefinition.Locator))]
    public class Locator : GluonObject
    {
        static Locator()
        {
            ABI.GluonTest.Native.RegisterTypes();
        }

        public Locator() : this(Make()) { }

        public Vector2 FocalLength
        {
            get { Marshal.ThrowExceptionForHR(_i.GetFocalLength(out Vector2 x)); return x; }
            set { Marshal.ThrowExceptionForHR(_i.SetFocalLength(value)); }
        }

        public Vector2 PrincipalPoint
        {
            get { Marshal.ThrowExceptionForHR(_i.GetPrincipalPoint(out Vector2 x)); return x; }
            set { Marshal.ThrowExceptionForHR(_i.SetPrincipalPoint(value)); }
        }

        public Vector3 RadialDistortion
        {
            get { Marshal.ThrowExceptionForHR(_i.GetRadialDistortion(out Vector3 x)); return x; }
            set { Marshal.ThrowExceptionForHR(_i.SetRadialDistortion(value)); }
        }

        public Vector2 TangentialDistortion
        {
            get { Marshal.ThrowExceptionForHR(_i.GetTangentialDistortion(out Vector2 x)); return x; }
            set { Marshal.ThrowExceptionForHR(_i.SetTangentialDistortion(value)); }
        }

        public Vector3 LatestPosition
        {
            get { Marshal.ThrowExceptionForHR(_i.GetLatestPosition(out Vector3 x)); return x; }
            set { Marshal.ThrowExceptionForHR(_i.SetLatestPosition(value)); }
        }

        public Quaternion LatestRotation
        {
            get { Marshal.ThrowExceptionForHR(_i.GetLatestRotation(out Quaternion x)); return x; }
            set { Marshal.ThrowExceptionForHR(_i.SetLatestRotation(value)); }
        }

        public void GenerateFaceImages(int sizeCentimeters, string outFolder)
        {
            Marshal.ThrowExceptionForHR(_i.GenerateFaceImages(sizeCentimeters, outFolder));
        }

        #region Internal

        internal Locator(object i) : base(i) { _i = (ABI.LocatorDefinition.Locator)i; }

        private static ABI.LocatorDefinition.Locator Make()
        {
            ABI.LocatorDefinition.Locator newInstance;
            Marshal.ThrowExceptionForHR(ABI.LocatorDefinition.Factory.Create_Locator(out newInstance));
            return newInstance; 
        }


        ABI.LocatorDefinition.Locator _i;

        #endregion
    }
}
