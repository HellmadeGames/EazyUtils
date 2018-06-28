using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils
{
    /// <summary>
    /// Various extensions for the Transform class.
    /// </summary>
    public static class TransformExtension
    {
        /// <summary>
        /// Destroys all the children of the transform
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static Transform Clear(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            return transform;
        }
    }
}
