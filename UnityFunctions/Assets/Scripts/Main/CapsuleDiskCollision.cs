﻿using System;
using Extensions;
using Unianio.Extensions;
using UnityEngine;
using UnityFunctions;

namespace Main
{
    public class CapsuleDiskCollision : BaseMainScript
    {
        private const float CapsuleRadius = 0.1f;
        private const float CapsuleHeight = 0.8f;
        private const float DiskRadius = 0.8f;
        private Transform[] _capsule;
        private Transform _disk;
        private Transform _projection;

        void Start ()
	    {
            _capsule = CreateCapsule(CapsuleRadius,CapsuleHeight);
            _disk =
                fun.meshes.CreateCone(
                    new DtCone
                    {
                        name = "Disk",
                        bottomRadius = DiskRadius,
                        height = 0.001f,
                        topRadius = 0.001f
                    })
                    .transform;
            _disk.position += Vector3.forward*0.5f;

            _projection = 
                fun.meshes.CreateSphere(new DtSphere {radius = 0.01})
                    .SetStandardShaderTransparentColor(1,0,0,0.9).transform;
	    }

        void Update()
        {
            var c1p1 = _capsule[0].position - _capsule[0].up*(CapsuleHeight/2 - CapsuleRadius);
            var c1p2 = _capsule[0].position + _capsule[0].up*(CapsuleHeight/2 - CapsuleRadius);
            var diskCenter = _disk.position;
            var diskUp = _disk.up;

            
            // test code STARTS here -----------------------------------------------
            Vector3 collision;
            var hasCollision = 
                fun.intersection.BetweenCapsuleAndDisk(
                    ref c1p1, ref c1p2, CapsuleRadius, ref diskCenter, ref diskUp, DiskRadius, out collision);
            // test code ENDS here -------------------------------------------------

            _projection.position = hasCollision ? collision : new Vector3(0,999,0);

            SetColorOnChanged(hasCollision, rgba(0, 1, 0, 0.5), rgba(0.5,0.5,0.5,0.5), _capsule);
            SetColorOnChanged(hasCollision, rgba(0, 0, 1, 0.5), rgba(0.5,0.5,0.5,0.5), _disk);
        }

    }
}