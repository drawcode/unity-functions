﻿using System;
using Extensions;
using Unianio.Extensions;
using UnityEngine;
using UnityFunctions;

namespace Main
{
    public class CapsuleSphereCollision : BaseMainScript
    {
        private const float CapsuleRadius = 0.15f;
        private const float CapsuleHeight = 0.8f;
        private const float SphereRadius = 0.3f;
        private Transform[] _capsule;
        private Transform _sphere;

        void Start ()
	    {
            _capsule = CreateCapsule(CapsuleRadius,CapsuleHeight);
            _sphere = fun.meshes.CreateSphere(new DtSphere {radius = SphereRadius}).transform;
            _sphere.position += Vector3.forward*0.5f;
	    }

        void Update()
        {

            var c1p1 = _capsule[0].position - _capsule[0].up*(CapsuleHeight/2 - CapsuleRadius);
            var c1p2 = _capsule[0].position + _capsule[0].up*(CapsuleHeight/2 - CapsuleRadius);
            var sp = _sphere.position;

            
            // test code STARTS here -----------------------------------------------
            var hasCollision = 
                fun.intersection.BetweenCapsuleAndSphere(
                    ref c1p1, ref c1p2, CapsuleRadius, ref sp, SphereRadius);
            // test code ENDS here -------------------------------------------------

            SetColorOnChanged(hasCollision, rgba(0, 1, 0, 0.5), rgba(0.5,0.5,0.5,0.5), _capsule);
            SetColorOnChanged(hasCollision, rgba(0, 1, 0, 0.5), rgba(0.5,0.5,0.5,0.5), _sphere);
        }

        

        


    }
}