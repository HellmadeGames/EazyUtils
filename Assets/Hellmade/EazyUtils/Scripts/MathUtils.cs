using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils.Math
{
    /// <summary>
    /// Various mathematical functions and utilities
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Checks whether an integer is even
        /// </summary>
        /// <param name="num">The integer number to check</param>
        /// <returns>True if the number is even</returns>
        public static bool IsEven(int num)
        {
            return Mod(num, 2) == 0;
        }

        /// <summary>
        /// Calculate the angle between two vectors
        /// </summary>
        /// <param name="from">The first vector</param>
        /// <param name="to">The second vector</param>
        /// <returns>The angle in 0-360 range</returns>
        public static float Calculate360Angle(Vector3 from, Vector3 to)
        {
            return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
        }

        /// <summary>
        /// Transforms value X in the range [a,b], to a number y in the range [0,1] 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float GetNormalizedValue(float x, float a, float b)
        {
            return RangeTransformation(x, a, b, 0, 1);
        }

        /// <summary>
        /// Transforms value X in the range [a,b], to a number y in the range [c,d] 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public static float RangeTransformation(float x, float a, float b, float c, float d)
        {
            return RangeTransformation(x, a, b, c, d, false);
        }

        /// <summary>
        /// Transforms value X in the range [a,b], to a number y in the range [c,d]. Set clamped to True to always return a clamped result based on [c,d].
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="clamped"></param>
        public static float RangeTransformation(float x, float a, float b, float c, float d, bool clamped)
        {
            float value = (x - a) * ((d - c) / (b - a)) + c;
            return clamped ? Mathf.Clamp(value, c, d) : value;
        }

        /// <summary>
        /// Converts circle coordinates to square coordinates
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ConvertCoordinatesCircleToSquare(float u, float v, ref float x, ref float y)
        {
            float u2 = u * u;
            float v2 = v * v;
            float twosqrt2 = 2.0f * Mathf.Sqrt(2.0f);
            float subtermx = 2.0f + u2 - v2;
            float subtermy = 2.0f - u2 + v2;
            float termx1 = subtermx + u * twosqrt2;
            float termx2 = subtermx - u * twosqrt2;
            float termy1 = subtermy + v * twosqrt2;
            float termy2 = subtermy - v * twosqrt2;
            x = 0.5f * Mathf.Sqrt(termx1) - 0.5f * Mathf.Sqrt(termx2);
            y = 0.5f * Mathf.Sqrt(termy1) - 0.5f * Mathf.Sqrt(termy2);
        }

        /// <summary>
        /// Picks a random position (Vector) in a sphere
        /// </summary>
        /// <param name="center">The center of the sphere</param>
        /// <param name="radius">The radius of the sphere</param>
        /// <returns>A Vector3 position</returns>
        public static Vector3 RandomPositionInSphere(Vector3 center, float radius)
        {
            float ang = Random.value * 360;
            Vector3 pos;
            pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            pos.z = center.z;
            return pos;
        }

        /// <summary>
        /// Calculates the mod of two integer numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }
    }
}
