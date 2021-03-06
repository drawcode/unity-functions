﻿ 
using System;
using System.Collections.Generic;
using Unianio.Extensions;
using UnityEngine;

namespace UnityFunctions
{



    internal static class fun
    {
        internal const float RTD = (float)(180 / Math.PI);
        internal const float DTR = (float)(Math.PI / 180);
        internal const float PI = (float)Math.PI;

        internal static int abs(int n) { return n < 0 ? n*-1 : n; }
        internal static float abs(float n) { return n < 0 ? n*-1 : n; }
        internal static float abs(double n) { return n < 0 ? (float)n*-1 : (float)n; }
        internal static int sign(double n) { return n < 0 ? -1 : 1; }
        internal static int min(int a, int b) { return a > b ? b : a; }
        internal static int max(int a, int b) { return a < b ? b : a; }
        internal static float min(double a, double b) { return a > b ? (float)b : (float)a; }
        internal static float max(double a, double b) { return a < b ? (float)b : (float)a; }
        internal static float sqrt(double n) { return (float)Math.Sqrt(n); }
        internal static float sin(double n) { return (float)Math.Sin(n); }
        internal static float cos(double n) { return (float)Math.Cos(n); }
        internal static float atan2(double a, double b) { return (float)Math.Atan2(a, b); }
        internal static float pow(double n, double p) { return (float)Math.Pow(n, p); }
        internal static float tan(double n) { return (float)Math.Tan(n); }

        internal static class angle
        {
            private const double TwiseRadiansToDegrees = 2.0*57.2957801818848;
            internal static float Between(Quaternion a, Quaternion b)
            {
                return (float) ((double) Math.Acos(Math.Min(Math.Abs(fun.dot.Product(ref a, ref b)), 1f)) * TwiseRadiansToDegrees);
            }
            internal static float Between(ref Quaternion a, ref Quaternion b)
            {
                return (float) ((double) Math.Acos(Math.Min(Math.Abs(fun.dot.Product(ref a, ref b)), 1f)) * TwiseRadiansToDegrees);
            }
            internal static float BetweenVectorsUnSignedInRadians(ref Vector3 from, ref Vector3 to)
            {
                return Mathf.Acos(Mathf.Clamp(Vector3.Dot(from.normalized, to.normalized), -1f, 1f));
            }
            internal static float BetweenVectorsSigned(ref Vector2 lhs, ref Vector2 rhs)
            {
                var perpDot = lhs.x * rhs.y - lhs.y * rhs.x;
 
                return -RTD * (float)Math.Atan2(perpDot, fun.dot.Product(ref lhs, ref rhs));
            }
            internal static float BetweenVectorsSigned(double v1x, double v1y, double v2x, double v2y)
            {
                var perpDot = v1x * v2y - v1y * v2x;
 
                return -RTD * (float)Math.Atan2(perpDot, fun.dot.Product(v1x, v1y, v2x, v2y));
            }
            internal static float ShortestBetweenVectorsSigned(ref Vector3 lhs, ref Vector3 rhs)
            {
                Vector3 normal;
                fun.vector.GetNormal(ref lhs, ref rhs, out normal);
                var x = fun.cross.Product(ref lhs, ref rhs);
                return (float)Math.Atan2(fun.dot.Product(ref normal, ref x), fun.dot.Product(ref lhs, ref rhs)) * RTD;
            }
            internal static float BetweenVectorsSigned(ref Vector3 lhs, ref Vector3 rhs, ref Vector3 normal)
            {
                var x = fun.cross.Product(ref lhs, ref rhs);
                return (float)Math.Atan2(fun.dot.Product(ref normal, ref x), fun.dot.Product(ref lhs, ref rhs)) * RTD;
            }
            internal static float BetweenVectorsSigned(Vector3 lhs, Vector3 rhs, Vector3 normal)
            {
                var x = fun.cross.Product(ref lhs, ref rhs);
                return (float)Math.Atan2(fun.dot.Product(ref normal, ref x), fun.dot.Product(ref lhs, ref rhs)) * RTD;
            }
            internal static float BetweenPointsSigned(ref Vector3 lhsPoint, ref Vector3 centerPoint, ref Vector3 rhsPoint)
            {
                Vector3 normal;
                fun.point.GetNormal(ref lhsPoint, ref centerPoint, ref rhsPoint, out normal);
                var lhs = lhsPoint - centerPoint;
                var rhs = rhsPoint - centerPoint;
                return BetweenVectorsSigned(ref lhs, ref rhs, ref normal);
            }
            internal static float BetweenPointsSigned(Vector3 lhsPoint, Vector3 centerPoint, Vector3 rhsPoint)
            {
                Vector3 normal;
                fun.point.GetNormal(ref lhsPoint, ref centerPoint, ref rhsPoint, out normal);
                var lhs = lhsPoint - centerPoint;
                var rhs = rhsPoint - centerPoint;
                return BetweenVectorsSigned(ref lhs, ref rhs, ref normal);
            }
            internal static float BetweenPointsSigned(ref Vector3 lhsPoint, ref Vector3 centerPoint, ref Vector3 rhsPoint, ref Vector3 normal)
            {
                var lhs = lhsPoint - centerPoint;
                var rhs = rhsPoint - centerPoint;
                return BetweenVectorsSigned(ref lhs, ref rhs, ref normal);
            }
            internal static float BetweenPointsSigned(Vector3 lhsPoint, Vector3 centerPoint, Vector3 rhsPoint, Vector3 normal)
            {
                var lhs = lhsPoint - centerPoint;
                var rhs = rhsPoint - centerPoint;
                return BetweenVectorsSigned(ref lhs, ref rhs, ref normal);
            }
        }

        internal static class color
        {
            internal static Color Parse(uint color)
            {
                byte r = (byte)(color >> 24);
                byte g = (byte)(color >> 16);
                byte b = (byte)(color >> 8);
                byte a = (byte)(color >> 0);
                return new Color(r/(float)0xFF, g/(float)0xFF, b/(float)0xFF, a/(float)0xFF);
            }
        }

        internal static class cross
        {
            internal static Vector3 Product(ref Vector3 leftVector, ref Vector3 rightVector)
            {
                return new Vector3(leftVector.y * rightVector.z - leftVector.z * rightVector.y, leftVector.z * rightVector.x - leftVector.x * rightVector.z, leftVector.x * rightVector.y - leftVector.y * rightVector.x);
            }
            internal static Vector3 Product(Vector3 leftVector, Vector3 rightVector)
            {
                return new Vector3(leftVector.y * rightVector.z - leftVector.z * rightVector.y, leftVector.z * rightVector.x - leftVector.x * rightVector.z, leftVector.x * rightVector.y - leftVector.y * rightVector.x);
            }
            internal static void Product(ref Vector3 leftVector, ref Vector3 rightVector, out Vector3 result)
            {
                result = new Vector3(leftVector.y * rightVector.z - leftVector.z * rightVector.y, leftVector.z * rightVector.x - leftVector.x * rightVector.z, leftVector.x * rightVector.y - leftVector.y * rightVector.x);
            }
        }

        internal static class distance
        {
            internal static float Between(Vector2 a, Vector2 b)
            {
                var vectorX = a.x - b.x;
                var vectorY = a.y - b.y;
                return (float)Math.Sqrt((((double)vectorX * (double)vectorX) + ((double)vectorY * (double)vectorY)));
            }
            internal static float Between(ref Vector2 a, ref Vector2 b)
            {
                var vectorX = a.x - b.x;
                var vectorY = a.y - b.y;
                return (float)Math.Sqrt((((double)vectorX * (double)vectorX) + ((double)vectorY * (double)vectorY)));
            }
            internal static float Between(ref Vector2 a, float bx, float by)
            {
                var vector = new Vector2(a.x - bx, a.y - by);
                return (float)Math.Sqrt((((double)vector.x * (double)vector.x) + ((double)vector.y * (double)vector.y)));
            }
            internal static float Between(ref Vector3 a, ref Vector3 b)
            {
                var vectorX = a.x - b.x;
                var vectorY = a.y - b.y;
                var vectorZ = a.z - b.z;
                return (float)Math.Sqrt((((double)vectorX * (double)vectorX) + ((double)vectorY * (double)vectorY)) + ((double)vectorZ * (double)vectorZ));
            }
            internal static float Between(Vector3 a, Vector3 b)
            {
                var vectorX = a.x - b.x;
                var vectorY = a.y - b.y;
                var vectorZ = a.z - b.z;
                return (float)Math.Sqrt((((double)vectorX * (double)vectorX) + ((double)vectorY * (double)vectorY)) + ((double)vectorZ * (double)vectorZ));
            }
            internal static float BetweenIgnoreY(Vector3 a, Vector3 b)
            {
                var vectorX = a.x - b.x;
                var vectorZ = a.z - b.z;
                return (float)Math.Sqrt(((double)vectorX * (double)vectorX) + ((double)vectorZ * (double)vectorZ));
            }
            internal static float BetweenIgnoreY(ref Vector3 a, ref Vector3 b)
            {
                var vectorX = a.x - b.x;
                var vectorZ = a.z - b.z;
                return (float)Math.Sqrt(((double)vectorX * (double)vectorX) + ((double)vectorZ * (double)vectorZ));
            }
            internal static float Between(float ax, float ay, float bx, float by)
            {
                var vx = ax - bx;
                var vy = ay - by;
                return (float)Math.Sqrt(((vx * vx) + (vy * vy)));
            }
            internal static float Between(float ax, float ay, float az, float bx, float by, float bz)
            {
                var vx = ax - bx;
                var vy = ay - by;
                var vz = az - bz;
                return (float)Math.Sqrt((((double)vx * (double)vx) + ((double)vy * (double)vy)) + ((double)vz * (double)vz));
            }
        }

        internal static class distanceSquared
        {
            internal static float Between(Vector2 a, Vector2 b)
            {
                var vectorX = (double)(a.x - b.x);
                var vectorY = (double)(a.y - b.y);
                return (float)((vectorX * vectorX) + (vectorY * vectorY));
            }
            internal static float Between(ref Vector2 a, ref Vector2 b)
            {
                var vectorX = (double)(a.x - b.x);
                var vectorY = (double)(a.y - b.y);
                return (float)((vectorX * vectorX) + (vectorY * vectorY));
            }
            internal static float Between(ref Vector2 a, float bx, float by)
            {
                var vector = new Vector2(a.x - bx, a.y - by);
                return (float)(((double)vector.x * (double)vector.x) + ((double)vector.y * (double)vector.y));
            }
            internal static float Between(ref Vector3 a, ref Vector3 b)
            {
                var vectorX = (double)(a.x - b.x);
                var vectorY = (double)(a.y - b.y);
                var vectorZ = (double)(a.z - b.z);
                return (float)(((vectorX * vectorX) + (vectorY * vectorY)) + (vectorZ * vectorZ));
            }
            internal static float Between(Vector3 a, Vector3 b)
            {
                var vectorX = (double)(a.x - b.x);
                var vectorY = (double)(a.y - b.y);
                var vectorZ = (double)(a.z - b.z);
                return (float)(((vectorX * vectorX) + (vectorY * vectorY)) + (vectorZ * vectorZ));
            }
            internal static float BetweenIgnoreY(Vector3 a, Vector3 b)
            {
                var vectorX = (double)(a.x - b.x);
                var vectorZ = (double)(a.z - b.z);
                return (float)((vectorX * vectorX) + (vectorZ * vectorZ));
            }
            internal static float BetweenIgnoreY(ref Vector3 a, ref Vector3 b)
            {
                var vectorX = (double)(a.x - b.x);
                var vectorZ = (double)(a.z - b.z);
                return (float)((vectorX * vectorX) + (vectorZ * vectorZ));
            }
            internal static float Between(float ax, float ay, float bx, float by)
            {
                var vx = ax - bx;
                var vy = ay - by;
                return (vx * vx) + (vy * vy);
            }
            internal static float Between(float ax, float ay, float az, float bx, float by, float bz)
            {
                var vx = ax - bx;
                var vy = ay - by;
                var vz = az - bz;
                return (float)((((double)vx * (double)vx) + ((double)vy * (double)vy)) + ((double)vz * (double)vz));
            }
        }
        
        internal static class dot
        {
            internal static float Product(double lhsX, double lhsY, double rhsX, double rhsY)
            {
                return (float)(lhsX * rhsX + lhsY * rhsY);
            }
            internal static float Product(ref Vector2 lhs, ref Vector2 rhs)
            {
                return (float)((double)lhs.x * (double)rhs.x + (double)lhs.y * (double)rhs.y);
            }
            internal static float Product(Vector2 lhs, Vector2 rhs)
            {
                return (float)((double)lhs.x * (double)rhs.x + (double)lhs.y * (double)rhs.y);
            }
            internal static float Product(ref Vector3 lhs, ref Vector3 rhs)
            {
                return (float)((double)lhs.x * (double)rhs.x + (double)lhs.y * (double)rhs.y + (double)lhs.z * (double)rhs.z);
            }
            internal static float Product(Vector3 lhs, Vector3 rhs)
            {
                return (float)((double)lhs.x * (double)rhs.x + (double)lhs.y * (double)rhs.y + (double)lhs.z * (double)rhs.z);
            }
            internal static float Product(Quaternion a, Quaternion b)
            {
                return (float) ((double) a.x * (double) b.x + (double) a.y * (double) b.y + (double) a.z * (double) b.z + (double) a.w * (double) b.w);
            }
            internal static float Product(ref Quaternion a, ref Quaternion b)
            {
                return (float) ((double) a.x * (double) b.x + (double) a.y * (double) b.y + (double) a.z * (double) b.z + (double) a.w * (double) b.w);
            }
        }

        internal static class ellipse
        {
            internal static float RadiusByAngle(double horzRadius, double vertRadius, double degrees)
            {
                var angleRadians = DTR*degrees;
                return (float)((horzRadius*vertRadius)/Math.Sqrt(horzRadius*horzRadius*Math.Pow(Math.Sin(angleRadians),2) + vertRadius*vertRadius*Math.Pow(Math.Cos(angleRadians),2)));
            }
        }

        internal static class intersection
        {
            /// <summary>
            /// The points of the capsule are the centers of the spheres at the end of capsules
            /// </summary>
            /// <param name="csb">capsule sphere below center</param>
            /// <param name="csa">capsule sphere above center</param>
            /// <param name="capsuleRadius">capsule radius</param>
            /// <param name="diskCenter">The center point of the disk</param>
            /// <param name="diskUp">disk up normal</param>
            /// <param name="diskRadius">disk radius</param>
            /// <param name="collision">the point best describing the collision point - might not be precise!</param>
            /// <returns></returns>
            internal static bool BetweenCapsuleAndDisk(
                ref Vector3 csb, ref Vector3 csa, float capsuleRadius, 
                ref Vector3 diskCenter, ref Vector3 diskUp, float diskRadius, out Vector3 collision)
            {
                // see if disk center is within the capsule cylinder
                Vector3 diskCenterOnAxis;
                var diskCenIsWithinCylPl = 
                    point.TryProjectOnLineSegment(ref diskCenter, ref csb, ref csa, out diskCenterOnAxis);
                if (diskCenIsWithinCylPl && 
                    distance.Between(ref diskCenterOnAxis, ref diskCenter) <= capsuleRadius)
                {
                    collision = diskCenter;
                    return true;
                }
                var capsuleUp = (csa - csb).normalized;
                var maxDistance = capsuleRadius + diskRadius;

                // test collision with below sphere
                Vector3 capEndOnDiskPl;
                point.ProjectOnPlane(ref csb, ref diskUp, ref diskCenter, out capEndOnDiskPl);
                var diskToSph = capEndOnDiskPl - diskCenter;
                if (diskToSph.sqrMagnitude < 0.000001f)
                {
                    if (distance.Between(ref csb, ref diskCenter) < maxDistance)
                    {
                        var diff = (csb - diskCenter);
                        collision = diskCenter + diff.normalized*min(diff.magnitude/2, diskRadius);
                        return true;
                    }
                }
                else
                {
                    diskToSph = diskToSph.normalized;
                    if (BetweenRayAndSphere(ref diskToSph, ref diskCenter, ref csb, capsuleRadius, out collision))
                    {
                        if (distance.Between(ref collision, ref diskCenter) <= diskRadius)
                        {
                            Vector3 collisionOnAxis;
                            if (point.TryProjectOnLineSegment(ref collision, ref csb, ref csa, out collisionOnAxis))
                            {
                                Vector3 diskOnPlane;
                                point.ProjectOnPlane(ref diskCenter, ref capsuleUp, ref collisionOnAxis, out diskOnPlane);
                                collision = (diskOnPlane - collisionOnAxis).normalized*capsuleRadius + collisionOnAxis;
                            }
                            return true;
                        }
                    }
                }
                // test collision with above sphere
                point.ProjectOnPlane(ref csa, ref diskUp, ref diskCenter, out capEndOnDiskPl);
                diskToSph = capEndOnDiskPl - diskCenter;
                if (diskToSph.sqrMagnitude < 0.000001f)
                {
                    if (distance.Between(ref csa, ref diskCenter) < maxDistance)
                    {
                        var diff = (csa - diskCenter);
                        collision = diskCenter + diff.normalized*min(diff.magnitude/2, diskRadius);
                        return true;
                    }
                }
                else
                {
                    diskToSph = diskToSph.normalized;
                    if (BetweenRayAndSphere(ref diskToSph, ref diskCenter, ref csa, capsuleRadius, out collision))
                    {
                        if (distance.Between(ref collision, ref diskCenter) <= diskRadius)
                        {
                            Vector3 collisionOnAxis;
                            if (point.TryProjectOnLineSegment(ref collision, ref csb, ref csa, out collisionOnAxis))
                            {
                                Vector3 diskOnPlane;
                                point.ProjectOnPlane(ref diskCenter, ref capsuleUp, ref collisionOnAxis, out diskOnPlane);
                                collision = (diskOnPlane - collisionOnAxis).normalized*capsuleRadius + collisionOnAxis;
                            }
                            return true;
                        }
                    }
                }

                // middle part
                Vector3 diskCenOnCapPl;
                point.ProjectOnPlane(ref diskCenter, ref capsuleUp, ref csb, out diskCenOnCapPl);
                var capToDisk = (diskCenOnCapPl - csb).normalized*capsuleRadius;
                var csaShifted = csa + capToDisk;
                var csbShifted = csb + capToDisk;
                if (BetweenPlaneAndLineSegment(ref diskUp, ref diskCenter, ref csaShifted, ref csbShifted, out collision))
                {
                    if (distance.Between(ref collision, ref diskCenter) <= diskRadius)
                    {
                        return true;
                    }
                }
                collision = Vector3.zero;
                return false;
            }

            internal static bool BetweenRayAndSphere(
                ref Vector3 rayFw, ref Vector3 rayOr, 
                ref Vector3 sphereCenter, float sphereRadius,
                out Vector3 collision)
            {
                var radiusSquared = sphereRadius*sphereRadius;
                var rayToSphere = sphereCenter - rayOr; 
                var tca = fun.dot.Product(ref rayToSphere, ref rayFw); 
                var d2 = fun.dot.Product(ref rayToSphere, ref rayToSphere) - tca * tca;
                if (d2 > radiusSquared)
                {
                    collision = Vector3.zero;
                    return false;
                } 
                var thc = (float)Math.Sqrt(radiusSquared - d2); 
                var t0 = tca - thc; 
                var t1 = tca + thc;

                if (t0 > t1)
                {
                    var temp = t0;
                    t0 = t1;
                    t1 = temp;
                } 
 
                if (t0 < 0)
                { 
                    t0 = t1; // if t0 is negative, let's use t1 instead 
                    if (t0 < 0)
                    {
                        collision = Vector3.zero;
                        return false; // both t0 and t1 are negative 
                    }
                } 
 
                var t = t0;

                collision = rayOr + rayFw*t;
 
                return true;
            }

            /// <summary>
            /// The points of the capsule are the centers of the spheres at the end of capsules
            /// </summary>
            /// <param name="csb">capsule sphere below center</param>
            /// <param name="csa">capsule sphere above center</param>
            /// <param name="capsuleRadius">capsule radius</param>
            /// <param name="sphereCenter">sphere center point</param>
            /// <param name="sphereRadius">sphere radius</param>
            /// <returns></returns>
            internal static bool BetweenCapsuleAndSphere(
                ref Vector3 csb, ref Vector3 csa, float capsuleRadius, 
                ref Vector3 sphereCenter, float sphereRadius)
            {
                var aboveVec = (csa - csb).normalized;
                var maxDistance = capsuleRadius + sphereRadius;
                // is above
                if (point.IsAbovePlane(ref sphereCenter, ref aboveVec, ref csa))
                {
                    return distance.Between(ref sphereCenter, ref csa) <= maxDistance;
                }
                var belowVec = -aboveVec;
                // is below
                if (point.IsAbovePlane(ref sphereCenter, ref belowVec, ref csb))
                {
                    return distance.Between(ref sphereCenter, ref csb) <= maxDistance;
                }
                // is in the middle
                Vector3 proj;
                fun.point.ProjectOnLine(ref sphereCenter, ref csb, ref csa, out proj);
                return distance.Between(ref sphereCenter, ref proj) <= maxDistance;
            }

            /// <summary>
            /// The points are the centers of the spheres at the end of capsules
            /// </summary>
            /// <param name="c1sb">capsule 1 sphere below center</param>
            /// <param name="c1sa">capsule 1 sphere above center</param>
            /// <param name="radius1">radius of capsule 1 sphere</param>
            /// <param name="c2sb">capsule 2 sphere below center</param>
            /// <param name="c2sa">capsule 2 sphere above center</param>
            /// <param name="radius2">radius of capsule 2 sphere</param>
            /// <returns>true if there is overlap false otherwise</returns>
            internal static bool BetweenCapsules(
                ref Vector3 c1sb, ref Vector3 c1sa, float radius1, 
                ref Vector3 c2sb, ref Vector3 c2sa, float radius2)
            {

                Vector3 belowA, middleA, middleB, aboveA, aboveB;
                var belowB = middleA = middleB = aboveB = Vector3.zero;
                bool hasMiddle, hasBelow, isAboveThePlane;
                var hasAbove = hasMiddle = hasBelow = isAboveThePlane = false;
                // below section
                var norm1 = (c1sa - c1sb).normalized;
                if (BetweenPlaneAndLineSegment(ref norm1, ref c1sb, ref c2sb, ref c2sa, out belowA))
                {
                    isAboveThePlane = point.IsAbovePlane(ref c2sb, ref norm1, ref c1sb);
                    belowB = isAboveThePlane ? c2sa : c2sb;
                    hasBelow = true;
                }
                // above section
                var norm2 = (c1sb - c1sa).normalized;
                if (BetweenPlaneAndLineSegment(ref norm2, ref c1sa, ref c2sb, ref c2sa, out aboveA))
                {
                    isAboveThePlane = point.IsAbovePlane(ref c2sb, ref norm2, ref c1sa);
                    aboveB = isAboveThePlane ? c2sa : c2sb;
                    hasAbove = true;
                }
                if (hasBelow)
                {
                    // hasBelow + hasAbove
                    if (hasAbove)
                    {
                        middleA = belowA;
                        middleB = aboveA;
                        hasMiddle = true;
                    }
                    // hasBelow
                    else
                    {
                        middleA = belowA;
                        middleB = isAboveThePlane ? c2sb : c2sa;
                        hasMiddle = true;
                    }
                }
                // hasAbove
                else if (hasAbove)
                {
                    middleA = aboveA;
                    middleB = isAboveThePlane ? c2sb : c2sa;
                    hasMiddle = true;
                }
                // none
                else
                {
                    // is above
                    if (point.IsAbovePlane(ref c2sb, ref norm1, ref c1sa))
                    {
                        aboveA = c2sb;
                        aboveB = c2sa;
                        hasAbove = true;
                    }
                    else
                    {
                        belowA = c2sb;
                        belowB = c2sa;
                        hasBelow = true;
                    }

                }

                var maxDist = radius1 + radius2;

                Vector3 normX, normY;

                if (hasBelow)
                {
                    var vecA = belowA - c1sb;
                    var vecB = belowB - c1sb;
                    Vector3 belowNorm;
                    vector.GetNormal(ref vecA, ref vecB, out belowNorm);
                    ComputeAnyNormals(ref belowNorm, out normX, out normY);
                    var belowA2D = vecA.As2d(ref normX, ref normY);
                    var belowB2D = vecB.As2d(ref normX, ref normY);
                    if (IsLineGettingCloserToOriginThan(ref belowA2D, ref belowB2D, maxDist)) return true;
                }
                if (hasMiddle)
                {
                    ComputeAnyNormals(ref norm1, out normX, out normY);
                    var middleA2D = (middleA-c1sb).As2d(ref normX, ref normY);
                    var middleB2D = (middleB-c1sb).As2d(ref normX, ref normY);
                    if (IsLineGettingCloserToOriginThan(ref middleA2D, ref middleB2D, maxDist)) return true;
                }
                if (hasAbove)
                {
                    var vecA = aboveA - c1sa;
                    var vecB = aboveB - c1sa;
                    Vector3 aboveNorm;
                    vector.GetNormal(ref vecA, ref vecB, out aboveNorm);
                    ComputeAnyNormals(ref aboveNorm, out normX, out normY);
                    var aboveA2D = vecA.As2d(ref normX, ref normY);
                    var aboveB2D = vecB.As2d(ref normX, ref normY);
                    if (IsLineGettingCloserToOriginThan(ref aboveA2D, ref aboveB2D, maxDist)) return true;
                }
                return false;
            }

            private static bool IsLineGettingCloserToOriginThan(ref Vector2 a, ref Vector2 b, float maxDist)
            {
                var k = ((b.y - a.y)*-a.x - (b.x - a.x)*-a.y)/((b.y - a.y) *(b.y - a.y) + (b.x - a.x) *(b.x - a.x));
                var p = new Vector2(-k*(b.y - a.y), k*(b.x - a.x));
                if (point.IsOn2DSegment(ref a, ref p, ref b))
                {
                    return p.magnitude <= maxDist;
                }
                return min(a.magnitude, b.magnitude) <= maxDist;
            }

            private static void ComputeAnyNormals(ref Vector3 normZ, out Vector3 normX, out Vector3 normY)
            {
                var fw = Vector3.forward;
                cross.Product(ref normZ, ref fw, out normX);
                if (normX.sqrMagnitude < 0.00001)
                {
                    var rt = Vector3.right;
                    cross.Product(ref normZ, ref rt, out normX);
                }
                normX = normX.normalized;
                vector.GetNormal(ref normZ, ref normX, out normY);
            }



            internal static bool BetweenLines(ref Vector3 ray1Origin, ref Vector3 ray1Dir, ref Vector3 ray2Origin, ref Vector3 ray2Dir, out Vector3 intersection)
            {
                var lineVec3 = ray2Origin - ray1Origin;
		        var crossVec1and2 = cross.Product(ref ray1Dir, ref ray2Dir);
		        var crossVec3and2 = cross.Product(ref lineVec3, ref ray2Dir);
 
		        var planarFactor = dot.Product(ref lineVec3, ref crossVec1and2);
 
		        //is coplanar, and not parrallel
		        if(abs(planarFactor) < 0.0001f && crossVec1and2.sqrMagnitude > 0.0001f)
		        {
			        var s = dot.Product(ref crossVec3and2, ref crossVec1and2) / crossVec1and2.sqrMagnitude;
			        intersection = ray1Origin + (ray1Dir * s);
			        return true;
		        }
		        intersection = Vector3.zero;
			    return false;
            }

            internal static bool BetweenTriangleAndLine(
                ref Vector3 p1, ref Vector3 p2, ref Vector3 p3, 
                ref Vector3 line1, ref Vector3 line2)
            {
                var diff = line1 - line2;
                var rayForward = diff.normalized;
                var rayOrigin = line2;
                var rayCollides = BetweenTriangleAndRay(ref p1, ref p2, ref p3, ref rayForward, ref rayOrigin);
                if (rayCollides)
                {
                    Vector3 planeNormal;
                    point.GetNormal(ref p1, ref p2, ref p3, out planeNormal);
                    Vector3 collision;
                    if (BetweenPlaneAndRay(ref planeNormal, ref p1, ref rayForward, ref rayOrigin, out collision))
                    {
                        return (collision - rayOrigin).sqrMagnitude <= diff.sqrMagnitude;
                    }
                }
                return false;
            }

            internal static bool BetweenTriangleAndRay(ref Vector3 p1, ref Vector3 p2, ref Vector3 p3, ref Vector3 rayForward, ref Vector3 rayOrigin)
            {
                //Find vectors for two edges sharing vertex/point p1
                var e1 = p2 - p1;
                var e2 = p3 - p1;
 
                // calculating determinant 
                var p = cross.Product(ref rayForward, ref e2);
 
                //Calculate determinat
                var det = dot.Product(ref e1, ref p);
 
                //if determinant is near zero, ray lies in plane of triangle otherwise not
                if (det > -0.000001 && det < 0.000001) { return false; }
                var invDet = 1.0f / det;
 
                //calculate distance from p1 to ray origin
                var t = rayOrigin - p1;
 
                //Calculate u parameter
                var u = dot.Product(ref t, ref p) * invDet;
 
                //Check for ray hit
                if (u < 0 || u > 1) { return false; }
 
                //Prepare to test v parameter
                var q = cross.Product(ref t, ref e1);
 
                //Calculate v parameter
                var v = dot.Product(ref rayForward, ref q) * invDet;
 
                //Check for ray hit
                if (v < 0 || u + v > 1) { return false; }
 
                if ((dot.Product(ref e2, ref q) * invDet) > 0.000001)
                { 
                    //ray does intersect
                    return true;
                }
 
                // No hit at all
                return false;
            }

            internal static bool BetweenPlaneAndRay(
                ref Vector3 planeNormal, ref Vector3 planePoint,
                ref Vector3 rayNormal, ref Vector3 rayOrigin, out float distanceToCollision)
            {
                planeNormal = planeNormal.normalized;
                var planeDistance = -dot.Product(ref planeNormal, ref planePoint);
                var a = dot.Product(ref rayNormal, ref planeNormal);
                var num = -dot.Product(ref rayOrigin, ref planeNormal) - planeDistance;
                if (a < 0.000001f && a > -0.000001f)
                {
                    distanceToCollision = 0.0f;
                    return false;
                }
                distanceToCollision = num / a;
                return distanceToCollision > 0.0;
            }

            internal static bool BetweenPlaneAndRay(
                ref Vector3 planeNormal, ref Vector3 planePoint,
                ref Vector3 rayNormal, ref Vector3 rayOrigin, 
                out Vector3 collisionPoint)
            {
                planeNormal = planeNormal.normalized;
                var planeDistance = -dot.Product(ref planeNormal, ref planePoint);
                var a = dot.Product(ref rayNormal, ref planeNormal);
                var num = -dot.Product(ref rayOrigin, ref planeNormal) - planeDistance;
                if (a < 0.000001f && a > -0.000001f)
                {
                    collisionPoint = Vector3.zero;
                    return false;
                }
                var distanceToCollision = num / a;
                if (distanceToCollision > 0.0)
                {
                    collisionPoint = rayOrigin + rayNormal*distanceToCollision;
                    return true;
                }
                collisionPoint = Vector3.zero;
                return false;
            }

            internal static bool BetweenPlaneAndRay(
                ref Vector3 planeNormal, ref Vector3 planePoint,
                ref Vector3 rayNormal, ref Vector3 rayOrigin, 
                out float distanceToCollision, out Vector3 collisionPoint)
            {
                planeNormal = planeNormal.normalized;
                var planeDistance = -dot.Product(ref planeNormal, ref planePoint);
                var a = dot.Product(ref rayNormal, ref planeNormal);
                var num = -dot.Product(ref rayOrigin, ref planeNormal) - planeDistance;
                if (a < 0.000001f && a > -0.000001f)
                {
                    collisionPoint = Vector3.zero;
                    distanceToCollision = 0;
                    return false;
                }
                distanceToCollision = num / a;
                if (distanceToCollision > 0.0)
                {
                    collisionPoint = rayOrigin + rayNormal*distanceToCollision;
                    return true;
                }
                distanceToCollision = 0;
                collisionPoint = Vector3.zero;
                return false;
            }

            internal static bool BetweenPlaneAndLineSegment(
                ref Vector3 planeNormal, ref Vector3 planePoint,
                ref Vector3 line1, ref Vector3 line2, out Vector3 collisionPoint)
            {
                var distanceToCollision = 0f;
                return 
                    BetweenPlaneAndLineSegment( ref planeNormal, ref planePoint, 
                        ref line1, ref line2, 
                        out distanceToCollision, out collisionPoint);
            }
            internal static bool BetweenPlaneAndLineSegment(
                ref Vector3 planeNormal, ref Vector3 planePoint,
                ref Vector3 line1, ref Vector3 line2, out float distanceToCollision, out Vector3 collisionPoint)
            {
                var rayNormal = (line2 - line1).normalized;
                planeNormal = planeNormal.normalized;
                var planeDistance = -dot.Product(ref planeNormal, ref planePoint);
                var a = dot.Product(ref rayNormal, ref planeNormal);
                var num = -dot.Product(ref line1, ref planeNormal) - planeDistance;
                if (a < 0.000001f && a > -0.000001f)
                {
                    collisionPoint = Vector3.zero;
                    distanceToCollision = 0;
                    return false;
                }
                distanceToCollision = num / a;
                if (distanceToCollision > 0.0000001 || distanceToCollision < -0.0000001)
                {
                    collisionPoint = line1 + rayNormal*distanceToCollision;
                    if (!point.IsOnSegment(ref line1, ref collisionPoint, ref line2))
                    {
                        collisionPoint = Vector3.zero;
                        distanceToCollision = 0;
                        return false;
                    }
                    distanceToCollision = abs(distanceToCollision);
                    return true;
                }
                distanceToCollision = 0;
                collisionPoint = Vector3.zero;
                return false;
            }

            internal static int BetweenLineAndUnitCircle(
                Vector2 point1, Vector2 point2, 
                out Vector2 intersection1, out Vector2 intersection2)
            {
                float t;

                var dx = point2.x - point1.x;
                var dy = point2.y - point1.y;

                var a = dx * dx + dy * dy;
                var b = 2 * (dx * point1.x + dy * point1.y);
                var c = point1.x * point1.x + point1.y * point1.y - 1;

                var determinate = b * b - 4 * a * c;
                if ((a <= 0.0000001) || (determinate < -0.0000001))
                {
                    // No real solutions.
                    intersection1 = new Vector2(float.NaN, float.NaN);
                    intersection2 = new Vector2(float.NaN, float.NaN);
                    return 0;
                }
                if (determinate < 0.0000001 && determinate > -0.0000001)
                {
                    // One solution.
                    t = -b / (2 * a);
                    intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
                    intersection2 = new Vector2(float.NaN, float.NaN);
                    return 1;
                }
                
                // Two solutions.
                t = (float)((-b + Math.Sqrt(determinate)) / (2 * a));
                intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
                t = (float)((-b - Math.Sqrt(determinate)) / (2 * a));
                intersection2 = new Vector2(point1.x + t * dx, point1.y + t * dy);
                return 2;
            }
            internal static int BetweenLineAndCircle(
                float cx, float cy, 
                float radius, 
                Vector2 point1, Vector2 point2, 
                out Vector2 intersection1, out Vector2 intersection2)
            {
                float t;

                var dx = point2.x - point1.x;
                var dy = point2.y - point1.y;

                var a = dx * dx + dy * dy;
                var b = 2 * (dx * (point1.x - cx) + dy * (point1.y - cy));
                var c = (point1.x - cx) * (point1.x - cx) + (point1.y - cy) * (point1.y - cy) - radius * radius;

                var determinate = b * b - 4 * a * c;
                if ((a <= 0.0000001) || (determinate < -0.0000001))
                {
                    // No real solutions.
                    intersection1 = new Vector2(float.NaN, float.NaN);
                    intersection2 = new Vector2(float.NaN, float.NaN);
                    return 0;
                }
                if (determinate < 0.0000001 && determinate > -0.0000001)
                {
                    // One solution.
                    t = -b / (2 * a);
                    intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
                    intersection2 = new Vector2(float.NaN, float.NaN);
                    return 1;
                }
                
                // Two solutions.
                t = (float)((-b + Math.Sqrt(determinate)) / (2 * a));
                intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
                t = (float)((-b - Math.Sqrt(determinate)) / (2 * a));
                intersection2 = new Vector2(point1.x + t * dx, point1.y + t * dy);
                return 2;
            }

            internal static bool BetweenLinesIgnoreY(
                   ref Vector3 line1point1, ref Vector3 line1point2,
                   ref Vector3 line2point1, ref Vector3 line2point2,
                   out Vector3? intersection)
            {
                var a1 = line1point2.z - line1point1.z;
                var b1 = line1point1.x - line1point2.x;
                var c1 = a1 * line1point1.x + b1 * line1point1.z;

                var a2 = line2point2.z - line2point1.z;
                var b2 = line2point1.x - line2point2.x;
                var c2 = a2 * line2point1.x + b2 * line2point1.z;

                var det = a1 * b2 - a2 * b1;
                const float epsilon = 0.00001f;
                if (det < epsilon && det > -epsilon)
                {
                    // Lines are parallel
                    intersection = null;
                    return false;
                }
                var x = (b2 * c1 - b1 * c2) / det;
                var z = (a1 * c2 - a2 * c1) / det;


                intersection = new Vector3(x, (line1point1.y + line1point2.y) / 2f, z);

                var maxX1 = Math.Max(line1point1.x, line1point2.x);
                var minX1 = Math.Min(line1point1.x, line1point2.x);
                var maxZ1 = Math.Max(line1point1.z, line1point2.z);
                var minZ1 = Math.Min(line1point1.z, line1point2.z);
                var maxX2 = Math.Max(line2point1.x, line2point2.x);
                var minX2 = Math.Min(line2point1.x, line2point2.x);
                var maxZ2 = Math.Max(line2point1.z, line2point2.z);
                var minZ2 = Math.Min(line2point1.z, line2point2.z);

                return x >= minX1 && x <= maxX1 &&
                       z >= minZ1 && z <= maxZ1 &&
                       x >= minX2 && x <= maxX2 &&
                       z >= minZ2 && z <= maxZ2;
            }

            internal static bool BetweenPlanes(ref Vector3 plane1Normal, ref Vector3 plane2Normal, out Vector3 intersectionNormal)
            {
                var zero = Vector3.zero;
                Vector3 intersectionPoint;
                return BetweenPlanes(ref plane1Normal, ref zero, ref plane2Normal, ref zero, out intersectionPoint, out intersectionNormal);
            }

            internal static bool BetweenPlanes(
                ref Vector3 plane1Normal, ref Vector3 plane1Position, 
                ref Vector3 plane2Normal, ref Vector3 plane2Position, 
                out Vector3 intersectionPoint, out Vector3 intersectionNormal)
            {
                
 
		        //We can get the direction of the line of intersection of the two planes by calculating the 
		        //cross product of the normals of the two planes. Note that this is just a direction and the line
		        //is not fixed in space yet. We need a point for that to go with the line vector.
		        cross.Product(ref plane1Normal, ref plane2Normal, out intersectionNormal);
                intersectionNormal = intersectionNormal.normalized;
		        //Next is to calculate a point on the line to fix it's position in space. This is done by finding a vector from
		        //the plane2 location, moving parallel to it's plane, and intersecting plane1. To prevent rounding
		        //errors, this vector also has to be perpendicular to lineDirection. To get this vector, calculate
		        //the cross product of the normal of plane2 and the lineDirection.		
		        Vector3 ldir;
                cross.Product(ref plane2Normal, ref intersectionNormal, out ldir);		
 
		        var denominator = dot.Product(ref plane1Normal, ref ldir);
		        //Prevent divide by zero
		        if(abs(denominator) > 0.00001){
 
			        var plane1ToPlane2 = plane1Position - plane2Position;
			        var t = dot.Product(ref plane1Normal, ref plane1ToPlane2) / denominator;
			        intersectionPoint = plane2Position + t * ldir;
 
			        return true;
		        }
                intersectionPoint = Vector3.zero;
			    return false;
            }

            internal static bool BetweenPlanes(Vector3 plane1Normal, Vector3 plane2Normal, out Vector3 intersectionNormal)
            {
                var zero = Vector3.zero;
                Vector3 intersectionPoint;
                return BetweenPlanes(plane1Normal, zero, plane1Normal, zero, out intersectionPoint, out intersectionNormal);
            }

            internal static bool BetweenPlanes(
                Vector3 plane1Normal, Vector3 plane1Position, 
                Vector3 plane2Normal, Vector3 plane2Position, 
                out Vector3 intersectionPoint, out Vector3 intersectionNormal)
            {
                
 
		        //We can get the direction of the line of intersection of the two planes by calculating the 
		        //cross product of the normals of the two planes. Note that this is just a direction and the line
		        //is not fixed in space yet. We need a point for that to go with the line vector.
		        cross.Product(ref plane1Normal, ref plane2Normal, out intersectionNormal);
                intersectionNormal = intersectionNormal.normalized;
		        //Next is to calculate a point on the line to fix it's position in space. This is done by finding a vector from
		        //the plane2 location, moving parallel to it's plane, and intersecting plane1. To prevent rounding
		        //errors, this vector also has to be perpendicular to lineDirection. To get this vector, calculate
		        //the cross product of the normal of plane2 and the lineDirection.		
		        Vector3 ldir;
                cross.Product(ref plane2Normal, ref intersectionNormal, out ldir);		
 
		        var denominator = dot.Product(ref plane1Normal, ref ldir);
		        //Prevent divide by zero
		        if(abs(denominator) > 0.00001){
 
			        var plane1ToPlane2 = plane1Position - plane2Position;
			        var t = dot.Product(ref plane1Normal, ref plane1ToPlane2) / denominator;
			        intersectionPoint = plane2Position + t * ldir;
 
			        return true;
		        }
                intersectionPoint = Vector3.zero;
			    return false;
            }

            internal static float BetweenRayAndSphere(
                ref Vector3 rayOrigin, 
                ref Vector3 rayDirection, 
                ref Vector3 sphereCenter, 
                float radius)
            {
                var xDiff = sphereCenter.x - rayOrigin.x;
                var yDiff = sphereCenter.y - rayOrigin.y;
                var zDiff = sphereCenter.z - rayOrigin.z;
                var sumOfSquares = ((xDiff * xDiff) + (yDiff * yDiff)) + (zDiff * zDiff);
                var squareOfRadius = radius * radius;
                if (sumOfSquares <= squareOfRadius)
                {
                    return 0f;
                }
                var num = ((xDiff * rayDirection.x) + (yDiff * rayDirection.y)) + (zDiff * rayDirection.z);
                if (num < 0f)
                {
                    return Single.NaN;
                }
                var sqDiff = sumOfSquares - (num * num);
                if (sqDiff > squareOfRadius)
                {
                    return Single.NaN;
                }
                return num - (float)Math.Sqrt(squareOfRadius - sqDiff);
            }

            internal static bool Between2DLines(Vector2 line1p1, Vector2 line1p2, Vector2 line2p1, Vector2 line2p2)
            {
                return Between2DLines(ref line1p1, ref line1p2, ref line2p1, ref line2p2);
            }
            internal static bool Between2DLines(ref Vector2 line1p1, ref Vector2 line1p2, ref Vector2 line2p1, ref Vector2 line2p2)
            {
                // Find the four orientations needed for general and
                // special cases
                var o1 = Orientation(ref line1p1, ref line1p2, ref line2p1);
                var o2 = Orientation(ref line1p1, ref line1p2, ref line2p2);
                var o3 = Orientation(ref line2p1, ref line2p2, ref line1p1);
                var o4 = Orientation(ref line2p1, ref line2p2, ref line1p2);
 
                // General case
                if (o1 != o2 && o3 != o4)
                    return true;
 
                // Special Cases : colinear
                if (o1 == 0 && point.IsOn2DSegment(ref line1p1, ref line2p1, ref line1p2)) return true;
 
                if (o2 == 0 && point.IsOn2DSegment(ref line1p1, ref line2p2, ref line1p2)) return true;
 
                if (o3 == 0 && point.IsOn2DSegment(ref line2p1, ref line1p1, ref line2p2)) return true;
 
                if (o4 == 0 && point.IsOn2DSegment(ref line2p1, ref line1p2, ref line2p2)) return true;
 
                return false; // Doesn't fall in any of the above cases
            }
 
            // To find orientation of ordered triplet (p, q, r).
            // The function returns following values
            // 0 --> p, q and r are colinear
            // 1 --> Clockwise
            // 2 --> Counterclockwise
            private static int Orientation(ref Vector2 p, ref Vector2 q, ref Vector2 r)
            {
                // See http://www.geeksforgeeks.org/orientation-3-ordered-points/
                // for details of below formula.
                var val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);
 
                if (val < 0.000001 && val > -0.000001) return 0;  // colinear
 
                return (val > 0)? 1: 2; // clock or counterclock wise
            }

            internal static bool BetweenTriangleAndSphere(ref Vector3 t1, ref Vector3 t2, ref Vector3 t3, ref Vector3 sphereCenter, float sphereRadius)
            {
                Vector3 triangleNormal;
                point.GetNormal(ref t1, ref t2, ref t3, out triangleNormal);

                Vector3 proj;
                fun.point.ProjectOnPlane(ref sphereCenter, ref triangleNormal, ref t1, out proj);
                var x2d = (t2 - t1).normalized;
                Vector3 y2d;
                fun.vector.GetNormal(ref x2d, ref triangleNormal, out y2d);

                var dist = fun.distance.Between(ref sphereCenter, ref proj);
                var ratio = dist/sphereRadius;
                if (ratio <= 1.0)
                {

                    var t1in2d = t1.As2d(ref x2d, ref y2d) + Vector2.right;
                    var t2in2d = t2.As2d(ref x2d, ref y2d) + Vector2.right;
                    var t3in2d = t3.As2d(ref x2d, ref y2d) + Vector2.right;
                    var spin2d = sphereCenter.As2d(ref x2d, ref y2d) + Vector2.right;
                    var radius2d = (float) Math.Sqrt(1.0 - ratio*ratio)*sphereRadius;

                    return HasCircleTriangleCollision2D(ref spin2d, radius2d, ref t1in2d, ref t2in2d, ref t3in2d);
                }
                return false;
            }
            private static bool HasCircleTriangleCollision2D(ref Vector2 centre, float radius, ref Vector2 t1, ref Vector2 t2, ref Vector2 t3)
            {
                //
                // TEST 1: Vertex within circle
                //
                var c1x = centre.x - t1.x;
                var c1y = centre.y - t1.y;

                var radiusSqr = radius*radius;
                var c1sqr = c1x*c1x + c1y*c1y - radiusSqr;

                if (c1sqr <= 0) return true;

                var c2x = centre.x - t2.x;
                var c2y = centre.y - t2.y;
                var c2sqr = c2x*c2x + c2y*c2y - radiusSqr;

                if (c2sqr <= 0) return true;

                var c3x = centre.x - t3.x;
                var c3y = centre.y - t3.y;
                var c3sqr = c3x*c3x + c3y*c3y - radiusSqr;

                if (c3sqr <= 0) return true;

                //
                // TEST 2: Circle centre within triangle
                //

                //
                // Calculate edges
                //
                if (fun.triangle.IsPointInside(ref centre, ref t1, ref t2, ref t3)) return true;


                //
                // TEST 3: Circle intersects edge
                //
                var e1x = t2.x - t1.x;
                var e1y = t2.y - t1.y;

                var e2x = t3.x - t2.x;
                var e2y = t3.y - t2.y;

                var e3x = t1.x - t3.x;
                var e3y = t1.y - t3.y;

                var k = c1x*e1x + c1y*e1y;

                if (k > 0)
                {
                    var len = e1x*e1x + e1y*e1y;     // squared len

                    if (k < len)
                    {
                        if ((c1sqr*len) <= k*k)
                            return true;
                    }
                }

                // Second edge
                k = c2x*e2x + c2y*e2y;

                if (k > 0)
                {
                    var len = e2x*e2x + e2y*e2y;

                    if (k < len)
                    {
                        if ((c2sqr*len) <= k*k)
                            return true;
                    }
                }

                // Third edge
                k = c3x*e3x + c3y*e3y;

                if (k > 0)
                {
                    var len = e3x*e3x + e3y*e3y;

                    if (k < len)
                    {
                        if ((c3sqr * len) <= k*k)
                            return true;
                    }
                }
                // We're done, no intersection
                return false;
            }
            internal static bool BetweenTriangleAndDisk(ref Vector3 t1, ref Vector3 t2, ref Vector3 t3, ref Vector3 diskNormal, ref Vector3 diskCenter, float diskRadius)
            {
                Vector3 triangleNormal;
                point.GetNormal(ref t1, ref t2, ref t3, out triangleNormal);

                Vector3 intPoint,intNorm;
                var linesIntersect = BetweenPlanes(ref triangleNormal, ref t1, ref diskNormal, ref diskCenter, out intPoint, out intNorm);
                if (linesIntersect)
                {
                    var distToInt = distance.Between(ref intPoint, ref diskCenter);
                    var ratio = distToInt/diskRadius;
                    if (ratio <= 1.0)
                    {
                        var side = (float) Math.Sqrt(1.0 - ratio*ratio)*diskRadius;
                        var xPos = diskCenter + (intPoint - diskCenter);
                        var w1 = xPos + intNorm*side;
                        var w2 = xPos + intNorm*-side;

                        var x2d = intNorm;
                        Vector3 y2d;
                        vector.GetNormal(ref intNorm, ref triangleNormal, out y2d);

                        var t1in2d = t1.As2d(ref x2d, ref y2d);
                        var t2in2d = t2.As2d(ref x2d, ref y2d);
                        var t3in2d = t3.As2d(ref x2d, ref y2d);
                        var w1in2d = w1.As2d(ref x2d, ref y2d);
                        var w2in2d = w2.As2d(ref x2d, ref y2d);

                        if (triangle.IsPointInside(ref w1in2d, ref t1in2d, ref t2in2d, ref t3in2d) ||
                            triangle.IsPointInside(ref w2in2d, ref t1in2d, ref t2in2d, ref t3in2d) ||
                            Between2DLines(ref t1in2d, ref t2in2d, ref w1in2d, ref w2in2d) ||
                            Between2DLines(ref t2in2d, ref t3in2d, ref w1in2d, ref w2in2d) ||
                            Between2DLines(ref t3in2d, ref t1in2d, ref w1in2d, ref w2in2d))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        internal static class meshes
        {
            private static GameObject CreateGameObject(string prefix, DtBase data, out Mesh mesh)
            {
                var gameObject = new GameObject(data.name ?? prefix+"_"+DateTime.UtcNow.Ticks);
                var renderer = gameObject.AddComponent<MeshRenderer>();
                renderer.material = new Material(Shader.Find("Standard"));
                var meshFilter = gameObject.AddComponent<MeshFilter>();
                
                mesh = meshFilter.mesh;
                mesh.Clear();
                mesh.name = prefix;
                data.mesh = mesh;
                if (data.set != null) data.set(gameObject.transform);
                return gameObject;
            }
            #region Box
            internal static GameObject CreateBox()
            {
                return CreateBox(new DtBox());
            }
            internal static GameObject CreateBox(DtBox dt)
            {
                Mesh m;
                var gameObject = CreateGameObject("Box", dt, out m);

                var x = (float)dt.x;
                var y = (float)dt.y;
                var z = (float)dt.z;

                #region Vertices
		        var p0 = new Vector3( -x * .5f,	-y * .5f, z * .5f );
		        var p1 = new Vector3( x * .5f, 	-y * .5f, z * .5f );
		        var p2 = new Vector3( x * .5f, 	-y * .5f, -z * .5f );
		        var p3 = new Vector3( -x * .5f,	-y * .5f, -z * .5f );	
		
		        var p4 = new Vector3( -x * .5f,	y * .5f,  z * .5f );
		        var p5 = new Vector3( x * .5f, 	y * .5f,  z * .5f );
		        var p6 = new Vector3( x * .5f, 	y * .5f,  -z * .5f );
		        var p7 = new Vector3( -x * .5f,	y * .5f,  -z * .5f );
		
		        var vertices = new []
		        {
			        // Bottom
			        p0, p1, p2, p3,
			
			        // Left
			        p7, p4, p0, p3,
			
			        // Front
			        p4, p5, p1, p0,
			
			        // Back
			        p6, p7, p3, p2,
			
			        // Right
			        p5, p6, p2, p1,
			
			        // Top
			        p7, p6, p5, p4
		        };
		        #endregion
		
		        #region normals
		        var up 	= Vector3.up;
		        var down 	= Vector3.down;
		        var front 	= Vector3.forward;
		        var back 	= Vector3.back;
		        var left 	= Vector3.left;
		        var right 	= Vector3.right;
		
		        var normals = new []
		        {
			        // Bottom
			        down, down, down, down,
			
			        // Left
			        left, left, left, left,
			
			        // Front
			        front, front, front, front,
			
			        // Back
			        back, back, back, back,
			
			        // Right
			        right, right, right, right,
			
			        // Top
			        up, up, up, up
		        };
		        #endregion	
		
		        #region UVs
		        var p00 = new Vector2( 0f, 0f );
		        var p10 = new Vector2( 1f, 0f );
		        var p01 = new Vector2( 0f, 1f );
		        var p11 = new Vector2( 1f, 1f );
		
		        var uvs = new []
		        {
			        // Bottom
			        p11, p01, p00, p10,
			
			        // Left
			        p11, p01, p00, p10,
			
			        // Front
			        p11, p01, p00, p10,
			
			        // Back
			        p11, p01, p00, p10,
			
			        // Right
			        p11, p01, p00, p10,
			
			        // Top
			        p11, p01, p00, p10,
		        };
		        #endregion
		
		        #region Triangles
		        var triangles = new []
		        {
			        // Bottom
			        3, 1, 0,
			        3, 2, 1,			
			
			        // Left
			        3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
			        3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
			
			        // Front
			        3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
			        3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
			
			        // Back
			        3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
			        3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
			
			        // Right
			        3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
			        3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
			
			        // Top
			        3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
			        3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
			
		        };
		        #endregion
                
                m.vertices = vertices;
                m.normals = normals;
                m.uv = uvs;
                m.triangles = triangles;
 
                m.RecalculateBounds();
                m.Optimize();
                return gameObject;
            }
            #endregion

            #region Triangle Plane
            internal static GameObject CreateTwoSidedTrianglePlane()
            {
                return CreateTwoSidedTrianglePlane(new DtTrianglePlane());
            }
            internal static GameObject CreateTwoSidedTrianglePlane(DtTrianglePlane dt)
            {
                Mesh m;
                var gameObject = CreateGameObject("TwoSidedTrianglePlane", dt, out m);

                var length = (float)dt.length;
                var width = (float)dt.width;

		        #region Vertices		
		        var vertices = new Vector3[4];
                vertices[0] = new Vector3(length*-0.5f, width*-0.5f,0);
		        vertices[1] = new Vector3(length*0.5f, width*-0.5f,0);
                vertices[2] = new Vector3(length*-0.5f, width*0.5f,0);
		        #endregion
		
		        #region Normales
		        var normals = new Vector3[ vertices.Length ];
                normals[0] = Vector3.forward;
		        normals[1] = Vector3.forward;
                normals[2] = Vector3.forward;
		        #endregion
		
		        #region UVs		
		        Vector2[] uvs = new Vector2[ vertices.Length ];
                uvs[0] = new Vector2( 0, 0 );
		        uvs[1] = new Vector2( 1, 0 );
                uvs[2] = new Vector2( 0, 1 );
		        #endregion
		
		        #region Triangles
		        var triangles = new int[ 6 ];
		        int t = 0;
			
			    triangles[t++] = 0;
			    triangles[t++] = 1;
			    triangles[t++] = 2;

                triangles[t++] = 2;
			    triangles[t++] = 1;
			    triangles[t++] = 0;
		        #endregion
                
                m.vertices = vertices;
                m.normals = normals;
                m.uv = uvs;
                m.triangles = triangles;
 
                m.RecalculateBounds();
                m.Optimize();
                return gameObject;
            }
            #endregion

            #region Square Plane
            internal static GameObject CreateTwoSidedSquarePlane()
            {
                return CreateTwoSidedSquarePlane(new DtSquarePlane());
            }
            internal static GameObject CreateTwoSidedSquarePlane(DtSquarePlane dt)
            {
                Mesh m;
                var gameObject = CreateGameObject("TwoSidedSquarePlane", dt, out m);

                var length = (float)dt.length;
                var width = (float)dt.width;

		        #region Vertices		
		        var vertices = new Vector3[4];
                vertices[0] = new Vector3(length*-0.5f, width*-0.5f,0);
		        vertices[1] = new Vector3(length*0.5f, width*-0.5f,0);
                vertices[2] = new Vector3(length*-0.5f, width*0.5f,0);
                vertices[3] = new Vector3(length*0.5f, width*0.5f,0);
		        #endregion
		
		        #region Normales
		        var normals = new Vector3[ vertices.Length ];
                normals[0] = Vector3.forward;
		        normals[1] = Vector3.forward;
                normals[2] = Vector3.forward;
                normals[3] = Vector3.forward;
		        #endregion
		
		        #region UVs		
		        Vector2[] uvs = new Vector2[ vertices.Length ];
                uvs[0] = new Vector2( 0, 0 );
		        uvs[1] = new Vector2( 1, 0 );
                uvs[2] = new Vector2( 0, 1 );
                uvs[3] = new Vector2( 1, 1 );
		        #endregion
		
		        #region Triangles
		        var triangles = new int[ 12 ];
		        int t = 0;
			
			    triangles[t++] = 0;
			    triangles[t++] = 1;
			    triangles[t++] = 2;
			
			    triangles[t++] = 3;
			    triangles[t++] = 2;
			    triangles[t++] = 1;
                
                triangles[t++] = 1;
			    triangles[t++] = 2;
			    triangles[t++] = 3;

                triangles[t++] = 2;
			    triangles[t++] = 1;
			    triangles[t++] = 0;
		        #endregion
                
                m.vertices = vertices;
                m.normals = normals;
                m.uv = uvs;
                m.triangles = triangles;
 
                m.RecalculateBounds();
                m.Optimize();
                return gameObject;
            }
            internal static GameObject CreateSquarePlane()
            {
                return CreateSquarePlane(new DtSquarePlane());
            }
            internal static GameObject CreateSquarePlane(DtSquarePlane dt)
            {
                Mesh m;
                var gameObject = CreateGameObject("SquarePlane", dt, out m);

                var length = (float)dt.length;
                var width = (float)dt.width;

		        #region Vertices		
		        var vertices = new Vector3[4];
                vertices[0] = new Vector3(length*-0.5f, width*-0.5f,0);
		        vertices[1] = new Vector3(length*0.5f, width*-0.5f,0);
                vertices[2] = new Vector3(length*-0.5f, width*0.5f,0);
                vertices[3] = new Vector3(length*0.5f, width*0.5f,0);
		        #endregion
		
		        #region Normales
		        var normals = new Vector3[ vertices.Length ];
                normals[0] = Vector3.forward;
		        normals[1] = Vector3.forward;
                normals[2] = Vector3.forward;
                normals[3] = Vector3.forward;
		        #endregion
		
		        #region UVs		
		        Vector2[] uvs = new Vector2[ vertices.Length ];
                uvs[0] = new Vector2( 0, 0 );
		        uvs[1] = new Vector2( 1, 0 );
                uvs[2] = new Vector2( 0, 1 );
                uvs[3] = new Vector2( 1, 1 );
		        #endregion
		
		        #region Triangles
		        var triangles = new int[ 6 ];
		        int t = 0;
			
			    triangles[t++] = 0;
			    triangles[t++] = 1;
			    triangles[t++] = 2;
			
			    triangles[t++] = 3;	
			    triangles[t++] = 2;
			    triangles[t++] = 1; 
		        #endregion
                
                m.vertices = vertices;
                m.normals = normals;
                m.uv = uvs;
                m.triangles = triangles;
 
                m.RecalculateBounds();
                m.Optimize();
                return gameObject;
            }
            #endregion

            #region Cone
            internal static GameObject CreateCone()
            {
                return CreateCone(new DtCone());
            }
            internal static GameObject CreateCone(DtCone dt)
            {
                Mesh m;
                var gameObject = CreateGameObject("Cone", dt, out m);
 
                var height = (float)dt.height;
                var bottomRadius = (float)dt.bottomRadius;
                var topRadius = (float)dt.topRadius;
                var numSides = dt.numSides;
                var numHeightSeg = 1;
 
                var nbVerticesCap = numSides + 1;
                #region Vertices
 
                // bottom + top + sides
                Vector3[] vertices = new Vector3[nbVerticesCap + nbVerticesCap + numSides * numHeightSeg * 2 + 2];
                int vert = 0;
                float _2pi = Mathf.PI * 2f;
 
                // Bottom cap
                vertices[vert++] = new Vector3(0f, 0f, 0f)+dt.localPos;
                while( vert <= numSides )
                {
	                float rad = (float)vert / numSides * _2pi;
	                vertices[vert] = new Vector3(Mathf.Cos(rad) * bottomRadius, 0f, Mathf.Sin(rad) * bottomRadius)+dt.localPos;
	                vert++;
                }
 
                // Top cap
                vertices[vert++] = new Vector3(0f, height, 0f)+dt.localPos;
                while (vert <= numSides * 2 + 1)
                {
	                float rad = (float)(vert - numSides - 1)  / numSides * _2pi;
	                vertices[vert] = new Vector3(Mathf.Cos(rad) * topRadius, height, Mathf.Sin(rad) * topRadius)+dt.localPos;
	                vert++;
                }

 
                // Sides
                int v = 0;
                while (vert <= vertices.Length - 4 )
                {
	                float rad = (float)v / numSides * _2pi;
	                vertices[vert] = new Vector3(Mathf.Cos(rad) * topRadius, height, Mathf.Sin(rad) * topRadius)+dt.localPos;
	                vertices[vert + 1] = new Vector3(Mathf.Cos(rad) * bottomRadius, 0, Mathf.Sin(rad) * bottomRadius)+dt.localPos;
	                vert+=2;
	                v++;
                }
                vertices[vert] = vertices[ numSides * 2 + 2 ];
                vertices[vert + 1] = vertices[numSides * 2 + 3 ];
                #endregion
 
                #region Normales
 
                // bottom + top + sides
                Vector3[] normales = new Vector3[vertices.Length];
                vert = 0;
 
                // Bottom cap
                while( vert  <= numSides )
                {
	                normales[vert++] = Vector3.down;
                }
 
                // Top cap
                while( vert <= numSides * 2 + 1 )
                {
	                normales[vert++] = Vector3.up;
                }
 
                // Sides
                v = 0;
                while (vert <= vertices.Length - 4 )
                {			
	                float rad = (float)v / numSides * _2pi;
	                float cos = Mathf.Cos(rad);
	                float sin = Mathf.Sin(rad);
 
	                normales[vert] = new Vector3(cos, 0f, sin);
	                normales[vert+1] = normales[vert];
 
	                vert+=2;
	                v++;
                }
                normales[vert] = normales[ numSides * 2 + 2 ];
                normales[vert + 1] = normales[numSides * 2 + 3 ];
                #endregion
 
                #region UVs
                Vector2[] uvs = new Vector2[vertices.Length];
 
                // Bottom cap
                int u = 0;
                uvs[u++] = new Vector2(0.5f, 0.5f);
                while (u <= numSides)
                {
                    float rad = (float)u / numSides * _2pi;
                    uvs[u] = new Vector2(Mathf.Cos(rad) * .5f + .5f, Mathf.Sin(rad) * .5f + .5f);
                    u++;
                }
 
                // Top cap
                uvs[u++] = new Vector2(0.5f, 0.5f);
                while (u <= numSides * 2 + 1)
                {
                    float rad = (float)u / numSides * _2pi;
                    uvs[u] = new Vector2(Mathf.Cos(rad) * .5f + .5f, Mathf.Sin(rad) * .5f + .5f);
                    u++;
                }
 
                // Sides
                int u_sides = 0;
                while (u <= uvs.Length - 4 )
                {
                    float t = (float)u_sides / numSides;
                    uvs[u] = new Vector3(t, 1f);
                    uvs[u + 1] = new Vector3(t, 0f);
                    u += 2;
                    u_sides++;
                }
                uvs[u] = new Vector2(1f, 1f);
                uvs[u + 1] = new Vector2(1f, 0f);
                #endregion 
 
                #region Triangles
                int nbTriangles = numSides + numSides + numSides*2;
                int[] triangles = new int[nbTriangles * 3 + 3];
 
                // Bottom cap
                int tri = 0;
                int i = 0;
                while (tri < numSides - 1)
                {
	                triangles[ i ] = 0;
	                triangles[ i+1 ] = tri + 1;
	                triangles[ i+2 ] = tri + 2;
	                tri++;
	                i += 3;
                }
                triangles[i] = 0;
                triangles[i + 1] = tri + 1;
                triangles[i + 2] = 1;
                tri++;
                i += 3;
 
                // Top cap
                //tri++;
                while (tri < numSides*2)
                {
	                triangles[ i ] = tri + 2;
	                triangles[i + 1] = tri + 1;
	                triangles[i + 2] = nbVerticesCap;
	                tri++;
	                i += 3;
                }
 
                triangles[i] = nbVerticesCap + 1;
                triangles[i + 1] = tri + 1;
                triangles[i + 2] = nbVerticesCap;		
                tri++;
                i += 3;
                tri++;
 
                // Sides
                while( tri <= nbTriangles )
                {
	                triangles[ i ] = tri + 2;
	                triangles[ i+1 ] = tri + 1;
	                triangles[ i+2 ] = tri + 0;
	                tri++;
	                i += 3;
 
	                triangles[ i ] = tri + 1;
	                triangles[ i+1 ] = tri + 2;
	                triangles[ i+2 ] = tri + 0;
	                tri++;
	                i += 3;
                }
                #endregion
 
                m.vertices = vertices;
                m.normals = normales;
                m.uv = uvs;
                m.triangles = triangles;
 
                m.RecalculateBounds();
                m.Optimize();
                return gameObject;
            }
            internal static GameObject CreatePointyCone()
            {
                return CreateCone(new DtCone());
            }
            internal static GameObject CreatePointyCone(DtCone dt)
            {
                Mesh m;
                var gameObject = CreateGameObject("PointyCone", dt, out m);
 
                var height = (float)dt.height;
                var bottomRadius = (float)dt.bottomRadius;
                var topRadius = (float)dt.topRadius;
                var nbSides = dt.numSides;
                var nbHeightSeg = 1;
 
                int nbVerticesCap = nbSides + 1;
                #region Vertices
 
                // bottom + top + sides
                Vector3[] vertices = new Vector3[nbVerticesCap + nbVerticesCap + nbSides * nbHeightSeg * 2 + 2];
                int vert = 0;
                float _2pi = Mathf.PI * 2f;
 
                // Bottom cap
                vertices[vert++] = new Vector3(0f, 0f, 0f);
                while( vert <= nbSides )
                {
	                float rad = (float)vert / nbSides * _2pi;
                    var isXtop = Mathf.Sin(rad) > 0.95f;
                    var nose = isXtop ? 0.75f*bottomRadius : 0;
                    var noseShift = isXtop ? 0 : 1;
	                vertices[vert] = new Vector3(Mathf.Cos(rad) * bottomRadius * noseShift, 0f, Mathf.Sin(rad) * bottomRadius + nose);
	                vert++;
                }
 
                // Top cap
                vertices[vert++] = new Vector3(0f, height, 0f);
                while (vert <= nbSides * 2 + 1)
                {
	                float rad = (float)(vert - nbSides - 1)  / nbSides * _2pi;
                    
	                vertices[vert] = new Vector3(Mathf.Cos(rad) * topRadius, height, Mathf.Sin(rad) * topRadius);
	                vert++;
                }

 
                // Sides
                int v = 0;
                while (vert <= vertices.Length - 4 )
                {
	                float rad = (float)v / nbSides * _2pi;
                    
                    var isXtop = Mathf.Sin(rad) > 0.95f;
                    var nose = isXtop ? 0.75f*bottomRadius : 0;
                    var noseShift = isXtop ? 0 : 1;
	                vertices[vert] = new Vector3(Mathf.Cos(rad) * topRadius, height, Mathf.Sin(rad) * topRadius);
	                vertices[vert + 1] = new Vector3(Mathf.Cos(rad) * bottomRadius*noseShift, 0, Mathf.Sin(rad) * bottomRadius+nose);
	                vert+=2;
	                v++;
                }
                vertices[vert] = vertices[ nbSides * 2 + 2 ];
                vertices[vert + 1] = vertices[nbSides * 2 + 3 ];
                #endregion
 
                #region Normales
 
                // bottom + top + sides
                Vector3[] normales = new Vector3[vertices.Length];
                vert = 0;
 
                // Bottom cap
                while( vert  <= nbSides )
                {
	                normales[vert++] = Vector3.down;
                }
 
                // Top cap
                while( vert <= nbSides * 2 + 1 )
                {
	                normales[vert++] = Vector3.up;
                }
 
                // Sides
                v = 0;
                while (vert <= vertices.Length - 4 )
                {			
	                float rad = (float)v / nbSides * _2pi;
	                float cos = Mathf.Cos(rad);
	                float sin = Mathf.Sin(rad);
 
	                normales[vert] = new Vector3(cos, 0f, sin);
	                normales[vert+1] = normales[vert];
 
	                vert+=2;
	                v++;
                }
                normales[vert] = normales[ nbSides * 2 + 2 ];
                normales[vert + 1] = normales[nbSides * 2 + 3 ];
                #endregion
 
                #region UVs
                Vector2[] uvs = new Vector2[vertices.Length];
 
                // Bottom cap
                int u = 0;
                uvs[u++] = new Vector2(0.5f, 0.5f);
                while (u <= nbSides)
                {
                    float rad = (float)u / nbSides * _2pi;
                    uvs[u] = new Vector2(Mathf.Cos(rad) * .5f + .5f, Mathf.Sin(rad) * .5f + .5f);
                    u++;
                }
 
                // Top cap
                uvs[u++] = new Vector2(0.5f, 0.5f);
                while (u <= nbSides * 2 + 1)
                {
                    float rad = (float)u / nbSides * _2pi;
                    uvs[u] = new Vector2(Mathf.Cos(rad) * .5f + .5f, Mathf.Sin(rad) * .5f + .5f);
                    u++;
                }
 
                // Sides
                int u_sides = 0;
                while (u <= uvs.Length - 4 )
                {
                    float t = (float)u_sides / nbSides;
                    uvs[u] = new Vector3(t, 1f);
                    uvs[u + 1] = new Vector3(t, 0f);
                    u += 2;
                    u_sides++;
                }
                uvs[u] = new Vector2(1f, 1f);
                uvs[u + 1] = new Vector2(1f, 0f);
                #endregion 
 
                #region Triangles
                int nbTriangles = nbSides + nbSides + nbSides*2;
                int[] triangles = new int[nbTriangles * 3 + 3];
 
                // Bottom cap
                int tri = 0;
                int i = 0;
                while (tri < nbSides - 1)
                {
	                triangles[ i ] = 0;
	                triangles[ i+1 ] = tri + 1;
	                triangles[ i+2 ] = tri + 2;
	                tri++;
	                i += 3;
                }
                triangles[i] = 0;
                triangles[i + 1] = tri + 1;
                triangles[i + 2] = 1;
                tri++;
                i += 3;
 
                // Top cap
                //tri++;
                while (tri < nbSides*2)
                {
	                triangles[ i ] = tri + 2;
	                triangles[i + 1] = tri + 1;
	                triangles[i + 2] = nbVerticesCap;
	                tri++;
	                i += 3;
                }
 
                triangles[i] = nbVerticesCap + 1;
                triangles[i + 1] = tri + 1;
                triangles[i + 2] = nbVerticesCap;		
                tri++;
                i += 3;
                tri++;
 
                // Sides
                while( tri <= nbTriangles )
                {
	                triangles[ i ] = tri + 2;
	                triangles[ i+1 ] = tri + 1;
	                triangles[ i+2 ] = tri + 0;
	                tri++;
	                i += 3;
 
	                triangles[ i ] = tri + 1;
	                triangles[ i+1 ] = tri + 2;
	                triangles[ i+2 ] = tri + 0;
	                tri++;
	                i += 3;
                }
                #endregion
 
                m.vertices = vertices;
                m.normals = normales;
                m.uv = uvs;
                m.triangles = triangles;
 
                m.RecalculateBounds();
                m.Optimize();
                return gameObject;
            }
            #endregion

            #region Sphere
            internal static GameObject CreateSphere()
            {
                return CreateSphere(new DtSphere());
            }

            internal static GameObject CreateSphere(DtSphere dt)
            {
                Mesh m;
                var gameObject = CreateGameObject("Sphere", dt, out m);

                var radius = (float)dt.radius;

                // Longitude |||
                int nbLong = dt.longitude;
                // Latitude ---
                int nbLat = dt.latitude;
 
                #region Vertices
                Vector3[] vertices = new Vector3[(nbLong+1) * nbLat + 2];
                float _pi = Mathf.PI;
                float _2pi = _pi * 2f;
 
                vertices[0] = Vector3.up * radius + dt.localPos;
                for( int lat = 0; lat < nbLat; lat++ )
                {
	                float a1 = _pi * (float)(lat+1) / (nbLat+1);
	                float sin1 = Mathf.Sin(a1);
	                float cos1 = Mathf.Cos(a1);
 
	                for( int lon = 0; lon <= nbLong; lon++ )
	                {
		                float a2 = _2pi * (float)(lon == nbLong ? 0 : lon) / nbLong;
		                float sin2 = Mathf.Sin(a2);
		                float cos2 = Mathf.Cos(a2);
 
		                vertices[ lon + lat * (nbLong + 1) + 1] = new Vector3( sin1 * cos2, cos1, sin1 * sin2 ) * radius + dt.localPos;
	                }
                }
                vertices[vertices.Length-1] = Vector3.up * -radius + dt.localPos;
                #endregion
 
                #region Normales		
                Vector3[] normales = new Vector3[vertices.Length];
                for( int n = 0; n < vertices.Length; n++ )
	                normales[n] = (vertices[n] - dt.localPos).normalized;
                #endregion
 
                #region UVs
                Vector2[] uvs = new Vector2[vertices.Length];
                uvs[0] = Vector2.up;
                uvs[uvs.Length-1] = Vector2.zero;
                for( int lat = 0; lat < nbLat; lat++ )
	                for( int lon = 0; lon <= nbLong; lon++ )
		                uvs[lon + lat * (nbLong + 1) + 1] = new Vector2( (float)lon / nbLong, 1f - (float)(lat+1) / (nbLat+1) );
                #endregion
 
                #region Triangles
                int nbFaces = vertices.Length;
                int nbTriangles = nbFaces * 2;
                int nbIndexes = nbTriangles * 3;
                int[] triangles = new int[ nbIndexes ];
 
                //Top Cap
                int i = 0;
                for( int lon = 0; lon < nbLong; lon++ )
                {
	                triangles[i++] = lon+2;
	                triangles[i++] = lon+1;
	                triangles[i++] = 0;
                }
 
                //Middle
                for( int lat = 0; lat < nbLat - 1; lat++ )
                {
	                for( int lon = 0; lon < nbLong; lon++ )
	                {
		                int current = lon + lat * (nbLong + 1) + 1;
		                int next = current + nbLong + 1;
 
		                triangles[i++] = current;
		                triangles[i++] = current + 1;
		                triangles[i++] = next + 1;
 
		                triangles[i++] = current;
		                triangles[i++] = next + 1;
		                triangles[i++] = next;
	                }
                }
 
                //Bottom Cap
                for( int lon = 0; lon < nbLong; lon++ )
                {
	                triangles[i++] = vertices.Length - 1;
	                triangles[i++] = vertices.Length - (lon+2) - 1;
	                triangles[i++] = vertices.Length - (lon+1) - 1;
                }
                #endregion
 
                m.vertices = vertices;
                m.normals = normales;
                m.uv = uvs;
                m.triangles = triangles;
 
                m.RecalculateBounds();
                m.Optimize();

                return gameObject;
            }


            internal static GameObject CreateHalfSphere()
            {
                return CreateHalfSphere(new DtSphere());
            }

            internal static GameObject CreateHalfSphere(DtSphere dt)
            {
                Mesh m;
                var gameObject = CreateGameObject("Cone", dt, out m);

                var radius = (float)dt.radius;
                // Longitude |||
                int nbLong = dt.longitude;
                // Latitude ---
                int nbLat = dt.latitude;
                if (nbLat%2 == 0) nbLat -= 1;
 
                #region Vertices

                var nbHalfLat = nbLat/2 + 1;
                Vector3[] vertices = new Vector3[(nbLong+1) * nbLat + 2];
                float _pi = Mathf.PI;
                float _2pi = _pi * 2f;
 
                vertices[0] = Vector3.up * radius + dt.localPos;
                for( int lat = 0; lat < nbHalfLat; lat++ )
                {
	                float a1 = _pi * (float)(lat+1) / (nbLat+1);
	                float sin1 = Mathf.Sin(a1);
	                float cos1 = Mathf.Cos(a1);
 
	                for( int lon = 0; lon <= nbLong; lon++ )
	                {
		                float a2 = _2pi * (float)(lon == nbLong ? 0 : lon) / nbLong;
		                float sin2 = Mathf.Sin(a2);
		                float cos2 = Mathf.Cos(a2);
 
		                vertices[ lon + lat * (nbLong + 1) + 1] = new Vector3( sin1 * cos2, cos1, sin1 * sin2 ) * radius + dt.localPos;
	                }
                }
                vertices[vertices.Length-1] = Vector3.up * -radius + dt.localPos;
                #endregion
 
                #region Normales		
                Vector3[] normales = new Vector3[vertices.Length];
                for( int n = 0; n < vertices.Length; n++ )
	                normales[n] = (vertices[n] - dt.localPos).normalized;
                #endregion
 
                #region UVs
                Vector2[] uvs = new Vector2[vertices.Length];
                uvs[0] = Vector2.up;
                uvs[uvs.Length-1] = Vector2.zero;
                for( int lat = 0; lat < nbLat; lat++ )
	                for( int lon = 0; lon <= nbLong; lon++ )
		                uvs[lon + lat * (nbLong + 1) + 1] = new Vector2( (float)lon / nbLong, 1f - (float)(lat+1) / (nbLat+1) );
                #endregion
 
                #region Triangles
                int nbFaces = vertices.Length;
                int nbTriangles = nbFaces * 2;
                int nbIndexes = nbTriangles * 3;
                int[] triangles = new int[ nbIndexes ];
 
                //Top Cap
                int i = 0;
                for( int lon = 0; lon < nbLong; lon++ )
                {
	                triangles[i++] = lon+2;
	                triangles[i++] = lon+1;
	                triangles[i++] = 0;
                }
 
                //Middle
                for( int lat = 0; lat < nbLat - 1; lat++ )
                {
	                for( int lon = 0; lon < nbLong; lon++ )
	                {
		                int current = lon + lat * (nbLong + 1) + 1;
		                int next = current + nbLong + 1;
 
		                triangles[i++] = current;
		                triangles[i++] = current + 1;
		                triangles[i++] = next + 1;
 
		                triangles[i++] = current;
		                triangles[i++] = next + 1;
		                triangles[i++] = next;
	                }
                }
 
                //Bottom Cap
                for( int lon = 0; lon < nbLong; lon++ )
                {
	                triangles[i++] = vertices.Length - 1;
	                triangles[i++] = vertices.Length - (lon+2) - 1;
	                triangles[i++] = vertices.Length - (lon+1) - 1;
                }
                #endregion
 
                m.vertices = vertices;
                m.normals = normales;
                m.uv = uvs;
                m.triangles = triangles;
 
                m.RecalculateBounds();
                m.Optimize();

                return gameObject;
            }

            #endregion
        }

        internal static class point
        {
            const float epsilon = 0.0000001f;
            internal static bool IsOn2DSegment(ref Vector2 segStart, ref Vector2 point, ref Vector2 segEnd)
            {
                if (point.x <= max(segStart.x, segEnd.x)+epsilon && 
                    point.x >= min(segStart.x, segEnd.x)-epsilon && 
                    point.y <= max(segStart.y, segEnd.y)+epsilon && 
                    point.y >= min(segStart.y, segEnd.y)-epsilon)
                   return true;
 
                return false;
            }

            internal static bool IsOnSegment(ref Vector3 segStart, ref Vector3 point, ref Vector3 segEnd)
            {
                if (point.x <= max(segStart.x, segEnd.x)+epsilon && 
                    point.x >= min(segStart.x, segEnd.x)-epsilon && 
                    point.y <= max(segStart.y, segEnd.y)+epsilon && 
                    point.y >= min(segStart.y, segEnd.y)-epsilon && 
                    point.z <= max(segStart.z, segEnd.z)+epsilon && 
                    point.z >= min(segStart.z, segEnd.z)-epsilon)
                   return true;
 
                return false;
            }

	        //Two non-parallel lines which may or may not touch each other have a point on each line which are closest
	        //to each other. This function finds those two points. If the lines are not parallel, the function 
	        //outputs true, otherwise false.
	        internal static bool ClosestOnTwoLines(ref Vector3 line1p1, ref Vector3 line1Direction, ref Vector3 line2p1, ref Vector3 line2Direction, out Vector3 closestPointLine1, out Vector3 closestPointLine2)
	        {

                var a = dot.Product(ref line1Direction, ref line1Direction);
		        var b = dot.Product(ref line1Direction, ref line2Direction);
		        var e = dot.Product(ref line2Direction, ref line2Direction);
 
		        var d = a*e - b*b;
 
		        //lines are not parallel
		        if(d > 0.000001 || d < -0.000001){
 
			        var r = line1p1 - line2p1;
			        var c = dot.Product(ref line1Direction, ref r);
			        var f = dot.Product(ref line2Direction, ref r);
 
			        var s = (b*f - c*e) / d;
			        var t = (a*f - c*b) / d;
 
			        closestPointLine1 = line1p1 + line1Direction * s;
			        closestPointLine2 = line2p1 + line2Direction * t;
 
			        return true;
		        }

 		        closestPointLine1 = Vector3.zero;
		        closestPointLine2 = Vector3.zero;

		        return false;
	        }
            internal static bool IsLeftOfLine2D(ref Vector2 point, ref Vector2 linePoint1, ref Vector2 linePoint2)
            {
                return ((linePoint2.x - linePoint1.x)*(point.y - linePoint1.y) - (linePoint2.y - linePoint1.y)*(point.x - linePoint1.x)) > 0;
            }
            internal static bool IsLeftOfLine2D(Vector2 point, Vector2 linePoint1, Vector2 linePoint2)
            {
                return ((linePoint2.x - linePoint1.x)*(point.y - linePoint1.y) - (linePoint2.y - linePoint1.y)*(point.x - linePoint1.x)) > 0;
            }
            internal static bool IsAbovePlane(ref Vector3 point, ref Vector3 planeNormal, ref Vector3 planePoint)
            {
                var vectorToPlane = point - planePoint;
                var distance = -dot.Product(ref vectorToPlane, ref planeNormal);
                return distance < 0;
            }
            internal static bool IsAbovePlane(Vector3 point, Vector3 planeNormal, Vector3 planePoint)
            {
                var vectorToPlane = point - planePoint;
                var distance = -dot.Product(ref vectorToPlane, ref planeNormal);
                return distance < 0;
            }
            internal static bool IsAbovePlane(ref Vector3 point, ref Vector3 planeNormal)
            {
                var zero = Vector3.zero;
                return IsAbovePlane(ref point, ref planeNormal, ref zero);
            }
            internal static bool IsAbovePlane(Vector3 point, Vector3 planeNormal)
            {
                var zero = Vector3.zero;
                return IsAbovePlane(ref point, ref planeNormal, ref zero);
            }
            internal static Vector3 ProjectOnPlane(ref Vector3 point, ref Vector3 planeNormal, ref Vector3 planePoint)
            {
                planeNormal = planeNormal.normalized;
                var vectorToPlane = point - planePoint;
                var distance = -dot.Product(ref planeNormal, ref vectorToPlane);
                return point + planeNormal * distance;
            }
            internal static void ProjectOnPlane(ref Vector3 point, ref Vector3 planeNormal, ref Vector3 planePoint, out Vector3 projection)
            {
                planeNormal = planeNormal.normalized;
                var vectorToPlane = point - planePoint;
                var distance = -dot.Product(ref planeNormal, ref vectorToPlane);
                projection = point + planeNormal * distance;
            }
            internal static Vector3 ProjectOnPlane(Vector3 point, Vector3 planeNormal, Vector3 planePoint)
            {
                planeNormal = planeNormal.normalized;
                var vectorToPlane = point - planePoint;
                var distance = -dot.Product(ref planeNormal, ref vectorToPlane);
                return point + planeNormal * distance;
            }
            internal static Vector3 ProjectOnLine(Vector3 point, Vector3 line1, Vector3 line2)
            {
                var pointToLine = point - line1;
                var lineVector = line2 - line1;
                Vector3 onNormal;
                vector.ProjectOnNormal(ref pointToLine, ref lineVector, out onNormal);
                return onNormal + line1;
            }
            internal static Vector3 ProjectOnLine(ref Vector3 point, ref Vector3 line1, ref Vector3 line2)
            {
                var pointToLine = point - line1;
                var lineVector = line2 - line1;
                Vector3 onNormal;
                vector.ProjectOnNormal(ref pointToLine, ref lineVector, out onNormal);
                return onNormal + line1;
            }
            internal static void ProjectOnLine(ref Vector3 point, ref Vector3 line1, ref Vector3 line2, out Vector3 projection)
            {
                var pointToLine = point - line1;
                var lineVector = line2 - line1;
                Vector3 onNormal;
                vector.ProjectOnNormal(ref pointToLine, ref lineVector, out onNormal);
                projection = onNormal + line1;
            }
            internal static bool TryProjectOnLineSegment(ref Vector3 point, ref Vector3 line1, ref Vector3 line2, out Vector3 projection)
            {
                var pointToLine = point - line1;
                var lineVector = line2 - line1;
                Vector3 onNormal;
                vector.ProjectOnNormal(ref pointToLine, ref lineVector, out onNormal);
                projection = onNormal + line1;
                if (!IsOnSegment(ref line1, ref projection, ref line2))
                {
                    projection = Vector3.zero;
                    return false;
                }
                return true;
            }
            internal static void ProjectOnLine2D(ref Vector2 point, ref Vector2 linePoint1, ref Vector2 linePoint2, out Vector2 result)
            {
                var line = linePoint1 - linePoint2;
                var newPoint = point - linePoint2;

                result = ((dot.Product(ref newPoint, ref line)/dot.Product(ref line, ref line))*line)  + linePoint2;

            }
            internal static Vector3 ReflectOfPlane(Vector3 point, Vector3 planeNormal, Vector3 planePoint)
            {
                Vector3 projection;
                ProjectOnPlane(ref point, ref planeNormal, ref planePoint, out projection);
                var distance = fun.distance.Between(ref point, ref projection);
                Vector3 mirrorPoint;
                fun.point.TryMoveAbs(ref point, ref projection, distance*2, out mirrorPoint);
                return mirrorPoint;
            }
            internal static Vector3 ReflectOfPlane(ref Vector3 point, ref Vector3 planeNormal, ref Vector3 planePoint)
            {
                Vector3 projection;
                ProjectOnPlane(ref point, ref planeNormal, ref planePoint, out projection);
                var distance = fun.distance.Between(ref point, ref projection);
                Vector3 mirrorPoint;
                fun.point.TryMoveAbs(ref point, ref projection, distance*2, out mirrorPoint);
                return mirrorPoint;
            }
            internal static void ReflectOfPlane(ref Vector3 point, ref Vector3 planeNormal, ref Vector3 planePoint, out Vector3 mirrorPoint)
            {
                Vector3 projection;
                ProjectOnPlane(ref point, ref planeNormal, ref planePoint, out projection);
                var distance = fun.distance.Between(ref point, ref projection);
                fun.point.TryMoveAbs(ref point, ref projection, distance*2, out mirrorPoint);
            }

            internal static Vector3 GetNormal(Vector3 p1, Vector3 p2,  Vector3 p3)
            {
                var lhs = p1 - p2;
                var rhs = p3 - p2;
                Vector3 r;
                vector.GetNormal(ref lhs, ref rhs, out r);
                return r;
            }
            internal static void GetNormal(ref Vector3 p1, ref Vector3 p2, ref Vector3 p3, out Vector3 r)
            {
                var lhs = p1 - p2;
                var rhs = p3 - p2;
                vector.GetNormal(ref lhs, ref rhs, out r);
            }
            internal static Vector2 MoveRel2D(Vector2 from, Vector2 to, double ratio)
            {
                var r = (float) ratio;
                if (r < 0.0000001 && r > -0.0000001)
                {
                    return from;
                }
                return new Vector2
                            {
                                x = from.x + (to.x - from.x) * r,
                                y = from.y + (to.y - from.y) * r
                            };
            }
            internal static Vector2 MoveRel2D(ref Vector2 from, ref Vector2 to, double ratio)
            {
                var r = (float) ratio;
                if (r < 0.0000001 && r > -0.0000001)
                {
                    return from;
                }
                return new Vector2
                            {
                                x = from.x + (to.x - from.x) * r,
                                y = from.y + (to.y - from.y) * r
                            };
            }
            internal static Vector3 MoveRel(ref Vector3 from, ref Vector3 to, double ratio)
            {
                var r = (float) ratio;
                if (r < 0.0000001 && r > -0.0000001)
                {
                    return from;
                }
                return new Vector3
                {
                    x = from.x + (to.x - from.x) * r,
                    y = from.y + (to.y - from.y) * r,
                    z = from.z + (to.z - from.z) * r
                };
            }
            internal static void MoveRel(ref Vector3 from, ref Vector3 to, double ratio, out Vector3 result)
            {
                var r = (float) ratio;
                if (r < 0.0000001 && r > -0.0000001)
                {
                    result = from;
                    return;
                }
                result = new Vector3
                {
                    x = from.x + (to.x - from.x) * r,
                    y = from.y + (to.y - from.y) * r,
                    z = from.z + (to.z - from.z) * r
                };
            }
            internal static Vector3 MoveRel(Vector3 from, Vector3 to, double ratio)
            {
                var r = (float) ratio;
                if (r < 0.0000001 && r > -0.0000001)
                {
                    return from;
                }
                return new Vector3
                {
                    x = from.x + (to.x - from.x) * r,
                    y = from.y + (to.y - from.y) * r,
                    z = from.z + (to.z - from.z) * r
                };
            }

            internal static Vector3 MoveRel(Vector3 from, Vector3 to, double ratio, 
                Func<float,float> xFunc, Func<float,float> yFunc, Func<float,float> zFunc )
            {
                var r = (float) ratio;
                if (r < 0.0000001 && r > -0.0000001)
                {
                    return from;
                }
                if (xFunc == null) xFunc = n => n;
                if (yFunc == null) yFunc = n => n;
                if (zFunc == null) zFunc = n => n;
                return new Vector3
                {
                    x = from.x + (to.x - from.x) * xFunc(r),
                    y = from.y + (to.y - from.y) * yFunc(r),
                    z = from.z + (to.z - from.z) * zFunc(r)
                };
            }

            internal static bool TryMoveRel2D(ref Vector2 from, ref Vector2 to, double ratio, out Vector2 result)
            {
                var r = (float) ratio;
                if (r < 0.0000001 && r > -0.0000001)
                {
                    result = from;
                    return false;
                }
                result = new Vector2
                {
                    x = from.x + (to.x - from.x) * r,
                    y = from.y + (to.y - from.y) * r
                };
                return true;
            }
            internal static bool TryMoveRel(ref Vector3 from, ref Vector3 to, double ratio, out Vector3 result)
            {
                var r = (float) ratio;
                if (r < 0.0000001 && r > -0.0000001)
                {
                    result = from;
                    return false;
                }
                result = new Vector3
                {
                    x = from.x + (to.x - from.x) * r,
                    y = from.y + (to.y - from.y) * r,
                    z = from.z + (to.z - from.z) * r
                };
                return true;
            }
            internal static bool TryMoveAbs(float fromX, float fromY, float toX, float toY, double distance, out float x, out float y)
            {
                if (distance < 0.0000001 && distance > -0.0000001)
                {
                    x = fromX;
                    y = fromY;
                    return false;
                }

                var preDistance = fun.distance.Between(fromX, fromY, toX, toY);

                if (preDistance < 0.0000001 && preDistance > -0.0000001)
                {
                    x = toX;
                    y = toY;
                    return false;
                }

                var amount = (float)distance / preDistance;
                x = fromX + (toX - fromX)*amount;
                y = fromY + (toY - fromY)*amount;
                return true;
            }
            internal static bool TryMoveAbs2D(ref Vector2 from, ref Vector2 to, double distance, out Vector2 result)
            {
                if (distance < 0.0000001 && distance > -0.0000001)
                {
                    result = from;
                    return false;
                }

                var preDistance = fun.distance.Between(ref from, ref to);

                if (preDistance < 0.0000001 && preDistance > -0.0000001)
                {
                    result = to;
                    return false;
                }

                var amount = (float)distance / preDistance;
                result = new Vector2
                {
                    x = from.x + (to.x - from.x) * amount,
                    y = from.y + (to.y - from.y) * amount
                };
                return true;
            }
            internal static bool TryMoveAbs(ref Vector3 from, ref Vector3 to, double distance, out Vector3 result)
            {
                if (distance < 0.0000001 && distance > -0.0000001)
                {
                    result = from;
                    return false;
                }

                var dir = (to - from);

                if (dir.magnitude < 0.00001)
                {
                    result = to;
                    return false;
                }

                dir = dir.normalized;

                result = from + dir*(float)distance;
                return true;
            }
            internal static Vector2 MoveAbs2D(Vector2 from, Vector2 to, double distance)
            {
                if (distance < 0.0000001 && distance > -0.0000001)
                {
                    return from;
                }

                var dir = (to - from);

                if (dir.magnitude < 0.00001) return to;

                dir = dir.normalized;

                return from + dir*(float)distance;
            }
            internal static Vector3 MoveAbs(Vector3 from, Vector3 to, double distance)
            {
                if (distance < 0.0000001 && distance > -0.0000001)
                {
                    return from;
                }

                var dir = (to - from);

                if (dir.magnitude < 0.00001) return to;

                dir = dir.normalized;

                return from + dir*(float)distance;
            }
            internal static Vector3 MoveAbs(ref Vector3 from, ref Vector3 to, float distance)
            {
                if (distance < 0.0000001 && distance > -0.0000001)
                {
                    return from;
                }

                var dir = (to - from);

                if (dir.magnitude < 0.00001) return to;

                dir = dir.normalized;

                return from + dir*distance;
            }
        }

        internal static class polygon
        {
            internal static bool IsPointWithin(Vector2 point, Vector2[] points)
            {
                var result = false;
                int curr;
                var count = points.Length;
                var prevPoint = points[points.Length - 1];
                for (curr = 0; curr < count; curr++)
                {
                    var currPoint = points[curr];

                    if (((currPoint.y > point.y) != (prevPoint.y > point.y)) &&
                         (point.x < (prevPoint.x - currPoint.x) * (point.y - currPoint.y) / (prevPoint.y - currPoint.y) + currPoint.x))
                        result = !result;

                    prevPoint = currPoint;
                }
                return result;
            }
        }

        internal static class random
        {
            private static readonly System.Random _rnd = new System.Random((int)(DateTime.UtcNow.Ticks%1000000000));
            internal static float Between(double min, double max)
            {
                return Between((float)min, (float)max);
            }
            // probabilityDistribFunc => 0; would mean non altered probability, func [0-1]
            internal static float Between(double min, double max, Func<double, double> probabilityDistribFunc)
            {
                return Between((float)min, (float)max, probabilityDistribFunc);
            }
            internal static int Between(int min, int max)
            {
                return _rnd.Next(min, max + 1);
            }
            internal static float Between(float min, float max)
            {
                var n = (float)_rnd.NextDouble();
                return (max - min) * n + min;
            }

            // probabilityDistribFunc => 0; would mean non altered probability, func [0-1]
            internal static float Between(float min, float max, Func<double, double> probabilityDistribFunc)
            {
                var nd = _rnd.NextDouble();
                var n = (float)probabilityDistribFunc(nd);
                var range = (max - min);
                var candidate = range * n + min;
                return Mathf.Clamp(candidate, min, max);
            }
            internal static T Of<T>(IList<T> arr)
            {
                return arr[Index(arr.Count)];
            }
            internal static T Of<T>(Func<double, double> probabilityDistribFunc, IList<T> arr)
            {
                return arr[Index(arr.Count, probabilityDistribFunc)];
            }
            internal static T Of<T>(params T[] arr)
            {
                return arr[Index(arr.Length)];
            }
            internal static T Of<T>(Func<double, double> probabilityDistribFunc, params T[] arr)
            {
                return arr[Index(arr.Length)];
            }

            internal static T OfExcept<T>(T[] arr, T except)
            {
                T curr;
                var i = 0;
                do
                {
                    curr = Of(arr);
                    if(++i > 16) break;// check to prevent endless loop
                }
                while (curr.Equals(except));
                return curr;
            }
            internal static T Between<T>(IList<T> arr, int exceptIndex)
            {
                return arr[Index(arr.Count, exceptIndex)];
            }
            internal static int Index(int count)
            {
                return _rnd.Next(0, count);
            }
            internal static int Index(int count, int exceptIndex)
            {
                if (exceptIndex < 0 || exceptIndex >= count) return Index(count);
                var i = Index(count - 1);
                if (i >= exceptIndex) ++i;
                return i;
            }
            internal static int Index(int count, Func<double, double> probabilityDistribFunc)
            {
                var nd = _rnd.NextDouble();
                var n = (float)probabilityDistribFunc(nd);
                var index = (int)Math.Round(count * n);
                return Mathf.Clamp(index,0, count - 1);
            }
            internal static bool Bool(double probability)
            {
                if (probability < 0.000001) return false;
                if (probability > 0.999999) return true;
                var n = (float)_rnd.NextDouble();
                return n <= probability;
            }
            internal static Vector2 V2(float x1, float y1, float x2, float y2)
            {
                return new Vector2(Between(x1, x2), Between(y1, y2));
            }

            internal static Vector3 PointOnPlane(Vector3 position, Vector3 normal, float radius)
            {
                Vector3 randomPoint;
 
                do
                {
                    randomPoint = Vector3.Cross(UnityEngine.Random.insideUnitSphere, normal);
                } while (randomPoint == Vector3.zero);
       
                randomPoint.Normalize();
                randomPoint *= radius;
                randomPoint += position;
       
                return randomPoint;
            }

            internal static void PointOnPlane(ref Vector3 position, ref Vector3 normal, float radius, out Vector3 result)
            {
                Vector3 randomPoint;
 
                do
                {
                    randomPoint = Vector3.Cross(UnityEngine.Random.insideUnitSphere, normal);
                } while (randomPoint == Vector3.zero);
       
                randomPoint.Normalize();
                randomPoint *= radius;
                randomPoint += position;
       
                result = randomPoint;
            }
        }

        internal static class rotate
        {
            internal static void AngleAndAxisToQuaternion(float degrees, ref Vector3 axis, out Quaternion quaternion)
            {
                var radians = degrees*DTR;
                var s = (float)Math.Sin(radians/2f);
                var x = axis.x*s;
                var y = axis.y*s;
                var z = axis.z*s;
                var w = (float)Math.Cos(radians/2);
                quaternion = new Quaternion(x, y, z, w);
            }

            internal static void Vector(ref Vector3 vector, ref Vector3 aboutAxis, double degrees, out Vector3 result)
            {
                //var rotation = Quaternion.AngleAxis(degrees, aboutAxis);
                Quaternion rotation;
                AngleAndAxisToQuaternion((float)degrees, ref aboutAxis, out rotation);

                var num1 = rotation.x * 2f;
                var num2 = rotation.y * 2f;
                var num3 = rotation.z * 2f;
                var num4 = rotation.x * num1;
                var num5 = rotation.y * num2;
                var num6 = rotation.z * num3;
                var num7 = rotation.x * num2;
                var num8 = rotation.x * num3;
                var num9 = rotation.y * num3;
                var num10 = rotation.w * num1;
                var num11 = rotation.w * num2;
                var num12 = rotation.w * num3;
                Vector3 vector3;
                vector3.x = (float)((1.0 - ((double)num5 + (double)num6)) * (double)vector.x + ((double)num7 - (double)num12) * (double)vector.y + ((double)num8 + (double)num11) * (double)vector.z);
                vector3.y = (float)(((double)num7 + (double)num12) * (double)vector.x + (1.0 - ((double)num4 + (double)num6)) * (double)vector.y + ((double)num9 - (double)num10) * (double)vector.z);
                vector3.z = (float)(((double)num8 - (double)num11) * (double)vector.x + ((double)num9 + (double)num10) * (double)vector.y + (1.0 - ((double)num4 + (double)num5)) * (double)vector.z);
                result = vector3;
            }

            internal static void PointAbout(ref Vector3 rotatePoint, ref Vector3 pivot, ref Vector3 aboutAxis, double degrees, out Vector3 result)
            {
                var rotation = Quaternion.AngleAxis((float)degrees, aboutAxis);

                var point = rotatePoint - pivot;

                var num1 = rotation.x * 2f;
                var num2 = rotation.y * 2f;
                var num3 = rotation.z * 2f;
                var num4 = rotation.x * num1;
                var num5 = rotation.y * num2;
                var num6 = rotation.z * num3;
                var num7 = rotation.x * num2;
                var num8 = rotation.x * num3;
                var num9 = rotation.y * num3;
                var num10 = rotation.w * num1;
                var num11 = rotation.w * num2;
                var num12 = rotation.w * num3;
                Vector3 vector3;
                vector3.x = (float)((1.0 - ((double)num5 + (double)num6)) * (double)point.x + ((double)num7 - (double)num12) * (double)point.y + ((double)num8 + (double)num11) * (double)point.z);
                vector3.y = (float)(((double)num7 + (double)num12) * (double)point.x + (1.0 - ((double)num4 + (double)num6)) * (double)point.y + ((double)num9 - (double)num10) * (double)point.z);
                vector3.z = (float)(((double)num8 - (double)num11) * (double)point.x + ((double)num9 + (double)num10) * (double)point.y + (1.0 - ((double)num4 + (double)num5)) * (double)point.z);
                result = vector3 + pivot;
            }

            internal static Vector3 PointAbout(ref Vector3 rotatePoint, ref Vector3 pivot, ref Vector3 aboutAxis, double degrees)
            {
                var rotation = Quaternion.AngleAxis((float)degrees, aboutAxis);

                var point = rotatePoint - pivot;

                var num1 = rotation.x * 2f;
                var num2 = rotation.y * 2f;
                var num3 = rotation.z * 2f;
                var num4 = rotation.x * num1;
                var num5 = rotation.y * num2;
                var num6 = rotation.z * num3;
                var num7 = rotation.x * num2;
                var num8 = rotation.x * num3;
                var num9 = rotation.y * num3;
                var num10 = rotation.w * num1;
                var num11 = rotation.w * num2;
                var num12 = rotation.w * num3;
                Vector3 vector3;
                vector3.x = (float)((1.0 - ((double)num5 + (double)num6)) * (double)point.x + ((double)num7 - (double)num12) * (double)point.y + ((double)num8 + (double)num11) * (double)point.z);
                vector3.y = (float)(((double)num7 + (double)num12) * (double)point.x + (1.0 - ((double)num4 + (double)num6)) * (double)point.y + ((double)num9 - (double)num10) * (double)point.z);
                vector3.z = (float)(((double)num8 - (double)num11) * (double)point.x + ((double)num9 + (double)num10) * (double)point.y + (1.0 - ((double)num4 + (double)num5)) * (double)point.z);
                return vector3 + pivot;
            }

            internal static void Vector(ref Vector3 vector, ref Vector3 aboutAxis, ref Quaternion rotation, out Vector3 result)
            {
                var num1 = rotation.x * 2f;
                var num2 = rotation.y * 2f;
                var num3 = rotation.z * 2f;
                var num4 = rotation.x * num1;
                var num5 = rotation.y * num2;
                var num6 = rotation.z * num3;
                var num7 = rotation.x * num2;
                var num8 = rotation.x * num3;
                var num9 = rotation.y * num3;
                var num10 = rotation.w * num1;
                var num11 = rotation.w * num2;
                var num12 = rotation.w * num3;
                Vector3 vector3;
                vector3.x = (float)((1.0 - ((double)num5 + (double)num6)) * (double)vector.x + ((double)num7 - (double)num12) * (double)vector.y + ((double)num8 + (double)num11) * (double)vector.z);
                vector3.y = (float)(((double)num7 + (double)num12) * (double)vector.x + (1.0 - ((double)num4 + (double)num6)) * (double)vector.y + ((double)num9 - (double)num10) * (double)vector.z);
                vector3.z = (float)(((double)num8 - (double)num11) * (double)vector.x + ((double)num9 + (double)num10) * (double)vector.y + (1.0 - ((double)num4 + (double)num5)) * (double)vector.z);
                result = vector3;
            }

            internal static void PointAbout(ref Vector3 rotatePoint, ref Vector3 pivot, ref Vector3 aboutAxis, ref Quaternion rotation, out Vector3 result)
            {
                var point = rotatePoint - pivot;

                var num1 = rotation.x * 2f;
                var num2 = rotation.y * 2f;
                var num3 = rotation.z * 2f;
                var num4 = rotation.x * num1;
                var num5 = rotation.y * num2;
                var num6 = rotation.z * num3;
                var num7 = rotation.x * num2;
                var num8 = rotation.x * num3;
                var num9 = rotation.y * num3;
                var num10 = rotation.w * num1;
                var num11 = rotation.w * num2;
                var num12 = rotation.w * num3;
                Vector3 vector3;
                vector3.x = (float)((1.0 - ((double)num5 + (double)num6)) * (double)point.x + ((double)num7 - (double)num12) * (double)point.y + ((double)num8 + (double)num11) * (double)point.z);
                vector3.y = (float)(((double)num7 + (double)num12) * (double)point.x + (1.0 - ((double)num4 + (double)num6)) * (double)point.y + ((double)num9 - (double)num10) * (double)point.z);
                vector3.z = (float)(((double)num8 - (double)num11) * (double)point.x + ((double)num9 + (double)num10) * (double)point.y + (1.0 - ((double)num4 + (double)num5)) * (double)point.z);
                result = vector3 + pivot;
            }
        }

        internal static class statistics
        {
            private const float epsilon = 0.00001f;
            internal static Vector2 LerpAverageV2(Vector2 lastAverage, Vector2 current, int count)
            {
                return (count <= 1) ? current : new Vector2(Average(lastAverage.x, current.x, count), Average(lastAverage.y, current.y, count));
            }
            internal static Vector2 LerpAverageV2(ref Vector2 lastAverage, ref Vector2 current, int count)
            {
                return (count <= 1) ? current : new Vector2(Average(lastAverage.x, current.x, count), Average(lastAverage.y, current.y, count));
            }
            internal static Vector3 LerpAverage(Vector3 lastAverage, Vector3 current, int count)
            {
                return (count <= 1) ? current : new Vector3(Average(lastAverage.x, current.x, count), Average(lastAverage.y, current.y, count), Average(lastAverage.z, current.z, count));
            }
            internal static Vector3 LerpAverage(ref Vector3 lastAverage, ref Vector3 current, int count)
            {
                return (count <= 1) ? current : new Vector3(Average(lastAverage.x, current.x, count), Average(lastAverage.y, current.y, count), Average(lastAverage.z, current.z, count));
            }
            internal static Vector3 SlerpAverage(Vector3 lastAverage, Vector3 current, int count)
            {
                if (count <= 1) return current;
                var lastAverageMag = lastAverage.magnitude;
                var currentMag = current.magnitude;
                if (lastAverageMag < epsilon || currentMag < epsilon)
                {
                    return LerpAverage(ref lastAverage, ref current, count);
                }
                return Vector3.Slerp(lastAverage, current, 1/(float) count).normalized*
                       Average(lastAverageMag, currentMag, count);
            }
            internal static Vector3 SlerpAverage(ref Vector3 lastAverage, ref Vector3 current, int count)
            {
                if (count <= 1) return current;
                var lastAverageMag = lastAverage.magnitude;
                var currentMag = current.magnitude;
                if (lastAverageMag < epsilon || currentMag < epsilon)
                {
                    return LerpAverage(ref lastAverage, ref current, count);
                }
                return Vector3.Slerp(lastAverage, current, 1/(float) count).normalized*
                       Average(lastAverageMag, currentMag, count);
            }
            internal static Vector3 SlerpAverageFavorSameDirection(Vector3 lastAverage, Vector3 current, int count)
            {
                if (count <= 1) return current;
                var lastAverageMag = lastAverage.magnitude;
                var currentMag = current.magnitude;
                if (lastAverageMag < epsilon || currentMag < epsilon)
                {
                    return LerpAverage(ref lastAverage, ref current, count);
                }
                currentMag = currentMag * fun.dot.Product(ref lastAverage, ref current);
                return Vector3.Slerp(lastAverage, current, 1/(float) count).normalized*
                       Average(lastAverageMag, currentMag, count);
            }
            internal static Vector3 SlerpAverageFavorSameDirection(ref Vector3 lastAverage, ref Vector3 current, int count)
            {
                if (count <= 1) return current;
                var lastAverageMag = lastAverage.magnitude;
                var currentMag = current.magnitude;
                if (lastAverageMag < epsilon || currentMag < epsilon)
                {
                    return LerpAverage(ref lastAverage, ref current, count);
                }
                currentMag = currentMag * fun.dot.Product(ref lastAverage, ref current);
                return Vector3.Slerp(lastAverage, current, 1/(float) count).normalized*
                       Average(lastAverageMag, currentMag, count);
            }

            internal static Quaternion QuaternionAverageFavorSameDirection(Quaternion lastAverage, Quaternion current, int count)
            {
                if (count <= 1) return current;
                float aAngle, bAngle;
                Vector3 aAxis, bAxis;
                lastAverage.ToAngleAxis(out aAngle, out aAxis);
                current.ToAngleAxis(out bAngle, out bAxis);
                var axis = SlerpAverageFavorSameDirection(ref aAxis, ref bAxis, count);
                return Quaternion.AngleAxis(Average(aAngle,bAngle,count), axis);
            }
            internal static Quaternion QuaternionAverageFavorSameDirection(ref Quaternion lastAverage, ref Quaternion current, int count)
            {
                if (count <= 1) return current;
                float aAngle, bAngle;
                Vector3 aAxis, bAxis;
                lastAverage.ToAngleAxis(out aAngle, out aAxis);
                current.ToAngleAxis(out bAngle, out bAxis);
                var axis = SlerpAverageFavorSameDirection(ref aAxis, ref bAxis, count);
                return Quaternion.AngleAxis(Average(aAngle,bAngle,count), axis);
            }
            internal static float Average(double lastAverage, double current, int count)
            {
                return (count <= 1.0f) ? (float)current : ((float)lastAverage * (count - 1.0f) + (float)current) / count;
            }
            internal static float Average(float lastAverage, float current, int count)
            {
                return (count <= 1.0f) ? current : (lastAverage * (count - 1.0f) + current) / count;
            }
            internal static float PopulationVariance(double sumOfSquared, double sum, int count)
            {
                if (count <= 0) return 0;
                return ((float)sumOfSquared - (((float)sum * (float)sum) / count)) / count;
            }
            internal static float PopulationStandardDeviation(double sumOfSquared, double sum, int count)
            {
                return (count <= 1)
                        ? 0.0f
                        : (float)Math.Sqrt(PopulationVariance(sumOfSquared, sum, count));
            }
        }

        internal static class triangle
        {
            /*
               ^
              /|\  
           a / |h\ b
            /__|__\
               c
            height starts between sides a and b and falls info side c
            */
            internal static float GetHeight(double a, double b, double c)
            {
                if (abs(c) < 0.000001) return (float)((a+b)/2);
                var s = (a + b + c) / 2f;
                var n = s*(s - a)*(s - b)*(s - c);
                if (n < 0) return 0;
                return (float)((2 * Math.Sqrt(n)) / c);
            }
            /*
               ^
              /|\  
           a / |h\ b
            /__|__\
             ac+bc = c

            ac+bc = c
            ac^2 + h^2 = a^2
            bc^2 + h^2 = b^2
            */
            internal static void GetBaseSubSides(double a, double b, double c, out float ac, out float bc)
            {
                var h = GetHeight(a, b, c);
                ac = sqrt(a*a - h*h);
                bc = sqrt(b*b - h*h);
            }
            /*
               ^
              /|\  
           a / |h\ b
            /__|__\
             ac+bc = c

            ac+bc = c
            ac^2 + h^2 = a^2
            bc^2 + h^2 = b^2
            */
            internal static float GetBaseSubSideAc(double a, double b, double c)
            {
                var h = GetHeight(a, b, c);
                return sqrt(a*a - h*h);
            }
            internal static bool IsPointInside(Vector2 point, Vector2 t1, Vector2 t2, Vector2 t3)
            {
                var b1 = Sign3(ref point, ref t1, ref t2) < 0.0f;
                var b2 = Sign3(ref point, ref t2, ref t3) < 0.0f;
                var b3 = Sign3(ref point, ref t3, ref t1) < 0.0f;

                return (b1 == b2) && (b2 == b3);
            }
            internal static bool IsPointInside(ref Vector2 point, ref Vector2 t1, ref Vector2 t2, ref Vector2 t3)
            {
                var b1 = Sign3(ref point, ref t1, ref t2) < 0.0f;
                var b2 = Sign3(ref point, ref t2, ref t3) < 0.0f;
                var b3 = Sign3(ref point, ref t3, ref t1) < 0.0f;

                return (b1 == b2) && (b2 == b3);
            }
            private static float Sign3 (ref Vector2 p1, ref Vector2 p2, ref Vector2 p3)
            {
                return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
            }


            internal static bool Overlap(Vector3 t1p1, Vector3 t1p2, Vector3 t1p3, Vector3 t2p1, Vector3 t2p2, Vector3 t2p3)
            {
                return Overlap(ref t1p1, ref t1p2, ref t1p3, ref t2p1, ref t2p2, ref t2p3);
            }
            internal static bool Overlap(ref Vector3 t1p1, ref Vector3 t1p2, ref Vector3 t1p3, ref Vector3 t2p1, ref Vector3 t2p2, ref Vector3 t2p3)
            {
                Vector2 isect1 = Vector2.zero, isect2 = Vector2.zero;

                // compute plane equation of triangle(v0,v1,v2) 
                var e1 = t1p2 - t1p1;
                var e2 = t1p3 - t1p1;
                var n1 = cross.Product(ref e1, ref e2);
                var d1 = -dot.Product(ref n1, ref t1p1);
                // plane equation 1: N1.X+d1=0 */
 
                // put u0,u1,u2 into plane equation 1 to compute signed distances to the plane
                var du0 = dot.Product(ref n1, ref t2p1) + d1;
                var du1 = dot.Product(ref n1, ref t2p2) + d1;
                var du2 = dot.Product(ref n1, ref t2p3) + d1;
 
                // coplanarity robustness check 
                if (abs(du0) < Mathf.Epsilon) { du0 = 0.0f; }
                if (abs(du1) < Mathf.Epsilon) { du1 = 0.0f; }
                if (abs(du2) < Mathf.Epsilon) { du2 = 0.0f; }
 
                var du0du1 = du0 * du1;
                var du0du2 = du0 * du2;
 
                // same sign on all of them + not equal 0 ? 
                if (du0du1 > 0.0f && du0du2 > 0.0f)
                {
                    // no intersection occurs
                    return false;                    
                }
 
                // compute plane of triangle (u0,u1,u2)
                e1 = t2p2 - t2p1;
                e2 = t2p3 - t2p1;
                var n2 = cross.Product(ref e1, ref e2);
                var d2 = -dot.Product(ref n2, ref t2p1);
 
                // plane equation 2: N2.X+d2=0 
                // put v0,v1,v2 into plane equation 2
                var dv0 = dot.Product(ref n2, ref t1p1) + d2;
                var dv1 = dot.Product(ref n2, ref t1p2) + d2;
                var dv2 = dot.Product(ref n2, ref t1p3) + d2;
 
                if (abs(dv0) < Mathf.Epsilon) { dv0 = 0.0f; }
                if (abs(dv1) < Mathf.Epsilon) { dv1 = 0.0f; }
                if (abs(dv2) < Mathf.Epsilon) { dv2 = 0.0f; }
 
 
                var dv0dv1 = dv0 * dv1;
                var dv0dv2 = dv0 * dv2;
 
                // same sign on all of them + not equal 0 ? 
                if (dv0dv1 > 0.0f && dv0dv2 > 0.0f)
                {
                    // no intersection occurs
                    return false;                    
                }
 
                // compute direction of intersection line 
                var dd = Vector3.Cross(n1, n2);
 
                // compute and index to the largest component of D 
                var max = abs(dd.x);
                short index = 0;
                var bb = abs(dd.y);
                var cc = abs(dd.z);
                if (bb > max) { max = bb; index = 1; }
                if (cc > max) { max = cc; index = 2; }
 
                // this is the simplified projection onto L
                var vp0 = t1p1[index];
                var vp1 = t1p2[index];
                var vp2 = t1p3[index];
 
                var up0 = t2p1[index];
                var up1 = t2p2[index];
                var up2 = t2p3[index];
 
                // compute interval for triangle 1 
                float a = 0, b = 0, c = 0, x0 = 0, x1 = 0;
                if (ComputeIntervals(vp0, vp1, vp2, dv0, dv1, dv2, dv0dv1, dv0dv2, ref a, ref b, ref c, ref x0, ref x1)) 
                { 
                    return TriTriCoplanar(ref n1, ref t1p1, ref t1p2, ref t1p3, ref t2p1, ref t2p2, ref t2p3); 
                }
 
                // compute interval for triangle 2 
                float d = 0, e = 0, f = 0, y0 = 0, y1 = 0;
                if (ComputeIntervals(up0, up1, up2, du0, du1, du2, du0du1, du0du2, ref d, ref e, ref f, ref y0, ref y1)) 
                { 
                    return TriTriCoplanar(ref n1, ref t1p1, ref t1p2, ref t1p3, ref t2p1, ref t2p2, ref t2p3); 
                }

                var xx = x0 * x1;
                var yy = y0 * y1;
                var xxyy = xx * yy;
 
                var tmp = a * xxyy;
                isect1.x = tmp + b * x1 * yy;
                isect1.y = tmp + c * x0 * yy;
 
                tmp = d * xxyy;
                isect2.x = tmp + e * xx * y1;
                isect2.y = tmp + f * xx * y0;
 
                Sort(ref isect1);
                Sort(ref isect2);
 
                return !(isect1.y < isect2.x || isect2.y < isect1.x);
            }
            private static bool ComputeIntervals(float VV0, float VV1, float VV2,
                               float D0, float D1, float D2, float D0D1, float D0D2,
                               ref float A, ref float B, ref float C, ref float X0, ref float X1)
            {
                if (D0D1 > 0.0f)
                {
                    // here we know that D0D2<=0.0 
                    // that is D0, D1 are on the same side, D2 on the other or on the plane 
                    A = VV2; B = (VV0 - VV2) * D2; C = (VV1 - VV2) * D2; X0 = D2 - D0; X1 = D2 - D1;
                }
                else if (D0D2 > 0.0f)
                {
                    // here we know that d0d1<=0.0 
                    A = VV1; B = (VV0 - VV1) * D1; C = (VV2 - VV1) * D1; X0 = D1 - D0; X1 = D1 - D2;
                }
                else if (D1 * D2 > 0.0f || D0 > 0.000001f || D0 < -0.000001f)
                {
                    // here we know that d0d1<=0.0 or that D0!=0.0 
                    A = VV0; B = (VV1 - VV0) * D0; C = (VV2 - VV0) * D0; X0 = D0 - D1; X1 = D0 - D2;
                }
                else if (D1 > 0.000001f || D1 < -0.000001f)
                {
                    A = VV1; B = (VV0 - VV1) * D1; C = (VV2 - VV1) * D1; X0 = D1 - D0; X1 = D1 - D2;
                }
                else if (D2 > 0.000001f || D2 < -0.000001f)
                {
                    A = VV2; B = (VV0 - VV2) * D2; C = (VV1 - VV2) * D2; X0 = D2 - D0; X1 = D2 - D1;
                }
                else
                {
                    return true;
                }
 
                return false;
            }
            private static bool TriTriCoplanar(ref Vector3 N, ref Vector3 v0, ref Vector3 v1, ref Vector3 v2, ref Vector3 u0, ref Vector3 u1, ref Vector3 u2)
            {
                var A = new float[3];
                short i0, i1;
 
                // first project onto an axis-aligned plane, that maximizes the area
                // of the triangles, compute indices: i0,i1. 
                A[0] = abs(N[0]);
                A[1] = abs(N[1]);
                A[2] = abs(N[2]);
                if (A[0] > A[1])
                {
                    if (A[0] > A[2])
                    {
                        // A[0] is greatest
                        i0 = 1;      
                        i1 = 2;
                    }
                    else
                    {
                        // A[2] is greatest
                        i0 = 0;      
                        i1 = 1;
                    }
                }
                else  
                {
                    if (A[2] > A[1])
                    {
                        // A[2] is greatest 
                        i0 = 0;      
                        i1 = 1;
                    }
                    else
                    {
                        // A[1] is greatest 
                        i0 = 0;      
                        i1 = 2;
                    }
                }
 
                // test all edges of triangle 1 against the edges of triangle 2 
                if (EdgeAgainstTriEdges(ref v0, ref v1, ref u0, ref u1, ref u2, i0, i1)) { return true; }
                if (EdgeAgainstTriEdges(ref v1, ref v2, ref u0, ref u1, ref u2, i0, i1)) { return true; }
                if (EdgeAgainstTriEdges(ref v2, ref v0, ref u0, ref u1, ref u2, i0, i1)) { return true; }
 
                // finally, test if tri1 is totally contained in tri2 or vice versa 
                if (PointInTri(ref v0, ref u0, ref u1, ref u2, i0, i1)) { return true; }
                if (PointInTri(ref u0, ref v0, ref v1, ref v2, i0, i1)) { return true; }
 
                return false;
            }
            private static bool EdgeAgainstTriEdges(ref Vector3 v0, ref Vector3 v1, ref Vector3 u0, ref Vector3 u1, ref Vector3 u2, short i0, short i1)
            {
                // test edge u0,u1 against v0,v1
                if (EdgeEdgeTest(ref v0, ref v1, ref u0, ref u1, i0, i1)) { return true; }
 
                // test edge u1,u2 against v0,v1 
                if (EdgeEdgeTest(ref v0, ref v1, ref u1, ref u2, i0, i1)) { return true; }
 
                // test edge u2,u1 against v0,v1 
                if (EdgeEdgeTest(ref v0, ref v1, ref u2, ref u0, i0, i1)) { return true; }
 
                return false;
            }
            private static bool EdgeEdgeTest(ref Vector3 v0, ref Vector3 v1, ref Vector3 u0, ref Vector3 u1, int i0, int i1)
            {
                var Ax = v1[i0] - v0[i0];
                var Ay = v1[i1] - v0[i1];
 
                var Bx = u0[i0] - u1[i0];
                var By = u0[i1] - u1[i1];
                var Cx = v0[i0] - u0[i0];
                var Cy = v0[i1] - u0[i1];
                var f = Ay * Bx - Ax * By;
                var d = By * Cx - Bx * Cy;
                if ((f > 0 && d >= 0 && d <= f) || (f < 0 && d <= 0 && d >= f))
                {
                    var e = Ax * Cy - Ay * Cx;
                    if (f > 0)
                    {
                        if (e >= 0 && e <= f) { return true; }
                    }
                    else
                    {
                        if (e <= 0 && e >= f) { return true; }
                    }
                }

                return false;
            }
            private static bool PointInTri(ref Vector3 v0, ref Vector3 u0, ref Vector3 u1, ref Vector3 u2, short i0, short i1)
            {
                // is T1 completly inside T2?
                // check if v0 is inside tri(u0,u1,u2)
                var a = u1[i1] - u0[i1];
                var b = -(u1[i0] - u0[i0]);
                var c = -a * u0[i0] - b * u0[i1];
                var d0 = a * v0[i0] + b * v0[i1] + c;
 
                a = u2[i1] - u1[i1];
                b = -(u2[i0] - u1[i0]);
                c = -a * u1[i0] - b * u1[i1];
                var d1 = a * v0[i0] + b * v0[i1] + c;
 
                a = u0[i1] - u2[i1];
                b = -(u0[i0] - u2[i0]);
                c = -a * u2[i0] - b * u2[i1];
                var d2 = a * v0[i0] + b * v0[i1] + c;
 
                if (d0 * d1 > 0.0f)
                {
                    if (d0 * d2 > 0.0f) { return true; }
                }
 
                return false;
            }
            private static void Sort(ref Vector2 v)
            {
                if (v.x > v.y)
                {
                    var temp = v.x;
                    v.x = v.y;
                    v.y = temp;
                }
            }
        }

        internal static class vector
        {
            internal static bool IsAbovePlane(ref Vector3 vectorToPlane, ref Vector3 planeNormal)
            {
                var distance = -dot.Product(ref vectorToPlane, ref planeNormal);
                return distance < 0;
            }
            internal static bool IsAbovePlane(Vector3 vectorToPlane, Vector3 planeNormal)
            {
                var distance = -dot.Product(ref vectorToPlane, ref planeNormal);
                return distance < 0;
            }
            internal static float ProjectionLength(ref Vector3 ofVector, ref Vector3 ontoVector)
            {
                var unitOntoVector = ontoVector.normalized;
                return dot.Product(ref ofVector, ref unitOntoVector);
            }
            internal static float ProjectionLength(Vector3 ofVector, Vector3 ontoVector)
            {
                var unitOntoVector = ontoVector.normalized;
                return dot.Product(ref ofVector, ref unitOntoVector);
            }
            internal static Vector3 ProjectOnNormal(Vector3 vector, Vector3 onNormal)
            {
                var dotProduct = ((double) onNormal.x * (double) onNormal.x + (double) onNormal.y * (double) onNormal.y + (double) onNormal.z * (double) onNormal.z);
                if (dotProduct < (double) Mathf.Epsilon)
                    return Vector3.zero;
                return onNormal * dot.Product(ref vector, ref onNormal) / (float)dotProduct;
            }
            internal static Vector3 ProjectOnNormal(ref Vector3 vector, ref Vector3 onNormal)
            {
                var dotProduct = ((double) onNormal.x * (double) onNormal.x + (double) onNormal.y * (double) onNormal.y + (double) onNormal.z * (double) onNormal.z);
                if (dotProduct < (double) Mathf.Epsilon)
                    return Vector3.zero;
                return onNormal * dot.Product(ref vector, ref onNormal) / (float)dotProduct;
            }
            internal static void ProjectOnNormal(ref Vector3 vector, ref Vector3 onNormal, out Vector3 projection)
            {
                var dotProduct = (float)((double) onNormal.x * (double) onNormal.x + (double) onNormal.y * (double) onNormal.y + (double) onNormal.z * (double) onNormal.z);;
                if ((double)dotProduct < (double) Mathf.Epsilon)
                    projection = Vector3.zero;
                else
                    projection = onNormal * dot.Product(ref vector, ref onNormal) / (float)dotProduct;
            }
            internal static Vector3 ProjectOnPlane(ref Vector3 vector, ref Vector3 planeNormal)
            {
                var normPlaneNormal = planeNormal.normalized;
                var distance = -dot.Product(ref normPlaneNormal, ref vector);
                return vector + normPlaneNormal * distance;
            }
            internal static void ProjectOnPlane(ref Vector3 vector, ref Vector3 planeNormal, out Vector3 projection)
            {
                var normPlaneNormal = planeNormal.normalized;
                var distance = -dot.Product(ref normPlaneNormal, ref vector);
                projection = vector + normPlaneNormal * distance;
            }
            internal static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
            {
                var normPlaneNormal = planeNormal.normalized;
                var distance = -dot.Product(ref normPlaneNormal, ref vector);
                return vector + normPlaneNormal * distance;
            }
            internal static Vector3 ReflectOfPlane(ref Vector3 vector, ref Vector3 planeNormal)
            {
                Vector3 projection;
                ProjectOnPlane(ref vector, ref planeNormal, out projection);
                return Vector3.SlerpUnclamped(vector, projection.normalized, 2);
            }
            internal static void ReflectOfPlane(ref Vector3 vector, ref Vector3 planeNormal, out Vector3 reflection)
            {
                Vector3 projection;
                ProjectOnPlane(ref vector, ref planeNormal, out projection);
                reflection = Vector3.SlerpUnclamped(vector, projection.normalized, 2);
            }
            internal static Vector3 GetNormal(Vector3 lhs, Vector3 rhs)
            {
                var normal = new Vector3((lhs.y * rhs.z - lhs.z * rhs.y), (lhs.z * rhs.x - lhs.x * rhs.z), (lhs.x * rhs.y - lhs.y * rhs.x));

                // normalize:
                var len = Math.Sqrt(normal.x * normal.x + normal.y * normal.y + normal.z * normal.z);
                if (len > 9.99999974737875E-06)
                    normal = normal / (float)len;
                else
                    normal = new Vector3(0, 0, 0);
                return normal;
            }
            internal static void GetNormal(ref Vector3 lhs, ref Vector3 rhs, out Vector3 normal)
            {
                normal = new Vector3((lhs.y * rhs.z - lhs.z * rhs.y), (lhs.z * rhs.x - lhs.x * rhs.z), (lhs.x * rhs.y - lhs.y * rhs.x));

                // normalize:
                var len = Math.Sqrt(normal.x * normal.x + normal.y * normal.y + normal.z * normal.z);
                if (len > 9.99999974737875E-06)
                    normal = normal / (float)len;
                else
                    normal = new Vector3(0, 0, 0);
            }

            internal static void GetRealUp(ref Vector3 forward, ref Vector3 rawUp, out Vector3 realUp)
            {
                Vector3 right;
                cross.Product(ref rawUp, ref forward, out right);
                right.Normalize();
                cross.Product(ref forward, ref right, out realUp);
                realUp.Normalize();
            }
            internal static Vector3 GetRealUp(Vector3 forward, Vector3 rawUp)
            {
                Vector3 right, realUp;
                cross.Product(ref rawUp, ref forward, out right);
                right.Normalize();
                cross.Product(ref forward, ref right, out realUp);
               return realUp.normalized;
            }
        }
    }

    internal abstract class DtBase
    {
        internal string name;
        internal Mesh mesh;
        internal Action<Transform> set;
    }
    internal class DtSquarePlane : DtBase
    {
        internal double length = 1f;
        internal double width = 1f;
    }
    internal class DtTrianglePlane : DtBase
    {
        internal double length = 1f;
        internal double width = 1f;
    }
    internal class DtCone : DtBase
    {
        internal double height = 1f;
        internal double bottomRadius = .5f;
        internal double topRadius = .01f;
        internal int numSides = 18;
        internal Vector3 localPos = Vector3.zero;
    }
    internal class DtBox : DtBase
    {
        internal double x = 1;
        internal double y = 1;
        internal double z = 1;

        internal double side
        {
            get { return (x + y + z)/3.0; }
            set { x = y = z = value; }
        }
    }

    internal class DtSphere : DtBase
    {
        internal double radius = 1;
        internal int longitude = 24;
        internal int latitude = 16;
        internal Vector3 localPos = Vector3.zero;
    }
}