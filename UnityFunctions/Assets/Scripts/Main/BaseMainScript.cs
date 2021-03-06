﻿using System;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityFunctions;

namespace Main
{
    public abstract class BaseMainScript : MonoBehaviour
    {
        protected Transform _a, _b,_c;
        protected Mesh _mesh;

        protected readonly IDictionary<string,bool> ChangeNames = new Dictionary<string, bool>(StringComparer.InvariantCultureIgnoreCase);

        protected GameObject CreateTriangle(double pointSize)
        {
            var dt = new DtTrianglePlane();
	        var tr = fun.meshes.CreateTwoSidedTrianglePlane(dt).SetStandardShaderTransparentColor(0,0,1,0.5);

	        _a = fun.meshes.CreateSphere(new DtSphere {radius = pointSize, name = "Tri_ver_a"}).SetStandardShaderTransparentColor(0,1,0,0.9).transform;
            _b = fun.meshes.CreateSphere(new DtSphere {radius = pointSize, name = "Tri_ver_b"}).SetStandardShaderTransparentColor(0,1,0,0.9).transform;
            _c = fun.meshes.CreateSphere(new DtSphere {radius = pointSize, name = "Tri_ver_c"}).SetStandardShaderTransparentColor(0,1,0,0.9).transform;
            _mesh = dt.mesh;

            _a.position = _mesh.vertices[0];
            _b.position = _mesh.vertices[1];
            _c.position = _mesh.vertices[2];

            return tr;
        }

        protected GameObject CreateTriangle(double pointSize, out Transform a, out Transform b, out Transform c, out Mesh mesh)
        {
            var dt = new DtTrianglePlane();
	        var tr = fun.meshes.CreateTwoSidedTrianglePlane(dt).SetStandardShaderTransparentColor(0,0,1,0.5);

	        a = fun.meshes.CreateSphere(new DtSphere {radius = pointSize, name = "Tri_ver_a"}).SetStandardShaderTransparentColor(0,1,0,0.9).transform;
            b = fun.meshes.CreateSphere(new DtSphere {radius = pointSize, name = "Tri_ver_b"}).SetStandardShaderTransparentColor(0,1,0,0.9).transform;
            c = fun.meshes.CreateSphere(new DtSphere {radius = pointSize, name = "Tri_ver_c"}).SetStandardShaderTransparentColor(0,1,0,0.9).transform;
            mesh = dt.mesh;

            a.position = mesh.vertices[0];
            b.position = mesh.vertices[1];
            c.position = mesh.vertices[2];

            return tr;
        }

        protected void SetTriangle(out Vector3 a, out Vector3 b, out Vector3 c)
        {
            a = _a.position;
            b = _b.position;
            c = _c.position;

	        _mesh.vertices = new [] {a,b,c};
        }
        protected void SetTriangle(out Vector3 a, out Vector3 b, out Vector3 c, out Vector3 planeNormal)
        {
            SetTriangle(out a, out b, out c);
            planeNormal = fun.point.GetNormal(a, b, c);
        }

        protected void SetTriangle(Transform t1, Transform t2, Transform t3, Mesh m, out Vector3 a, out Vector3 b, out Vector3 c)
        {
            a = t1.position;
            b = t2.position;
            c = t3.position;

	        m.vertices = new [] {a,b,c};
        }
        protected void SetTriangle(Transform t1, Transform t2, Transform t3, Mesh m, out Vector3 a, out Vector3 b, out Vector3 c, out Vector3 planeNormal)
        {
            SetTriangle(t1, t2, t3, m,out a, out b, out c);
            planeNormal = fun.point.GetNormal(a, b, c);
        }
        protected static void SetColor(bool hasIntersection, Color ifTrue, Color ifFalse, params Transform[] ts)
        {
            foreach (var t in ts)
            {
                t.gameObject.SetStandardShaderTransparentColor(hasIntersection ? ifTrue : ifFalse);
            }
        }

        protected void SetColorOnChanged(bool hasIntersection, Color ifTrue, Color ifFalse, params Transform[] ts)
        {
            if(ts.Length == 0) throw new ArgumentException("Please provide 1 or more Transform parameters for SetColorOnChanged method");
            SetColorOnChanged("hc"+ts[0].GetHashCode(), hasIntersection, ifTrue, ifFalse, ts);
        }
        protected void SetColorOnChanged(string changeName, bool hasIntersection, Color ifTrue, Color ifFalse, params Transform[] ts)
        {
            bool val;
            var found = ChangeNames.TryGetValue(changeName, out val);
            if(found && val == hasIntersection) return;// no change;
            ChangeNames[changeName] = hasIntersection;
            foreach (var t in ts)
            {
                t.gameObject.SetStandardShaderTransparentColor(hasIntersection ? ifTrue : ifFalse);
            }
        }

        protected static Color rgba(double r, double g, double b, double a)
        {
            return new Color((float)r,(float)g,(float)b,(float)a);
        }

        protected Transform[] CreateCapsule(double radius, double height)
        {
            var hMin2Rad = (float)(height - radius*2);
            var cyl = 
                fun.meshes.CreateCone(
                    new DtCone
                    {
                        name = "Capsule",
                        bottomRadius = radius,
                        height = hMin2Rad,
                        topRadius = radius,
                        localPos = new Vector3(0,-hMin2Rad/2f,0)
                    })
                    .transform;

            // lower end
            var sp1Go = 
                fun.meshes.CreateHalfSphere(
                    new DtSphere
                    {
                        name = "CapsuleLowerSphere",
                        radius = radius
                    })
                    .transform;
            sp1Go.SetParent(cyl);
            sp1Go.localPosition = Vector3.up*-hMin2Rad/2f;
            sp1Go.localRotation = Quaternion.Euler(180,0,0);
            sp1Go.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable;

            // upper end
            var sp2Go = 
                fun.meshes.CreateHalfSphere(
                    new DtSphere
                    {
                        name = "CapsuleUpperSphere",
                        radius = radius
                    })
                    .transform;
            sp2Go.SetParent(cyl);
            sp2Go.localPosition = Vector3.up*hMin2Rad/2f;
            sp2Go.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable;
            return new [] { cyl, sp1Go, sp2Go };
        }
    }
}