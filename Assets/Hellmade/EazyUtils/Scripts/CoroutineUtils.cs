using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils
{
    /// <summary>
    /// Various functions and utilities to work with Coroutines.
    /// </summary>
    public class CoroutineUtils
    {
        /// <summary>
        /// Waits for real seconds. It does not depend on delta time, and is unaffected by the timescale
        /// </summary>
        /// <param name="time">The time to wait</param>
        /// <returns></returns>
        public static IEnumerator WaitForRealSeconds(float time)
        {
            float start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + time)
            {
                yield return null;
            }
        }
    }
}
