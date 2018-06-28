using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils.Mesh
{
    /// <summary>
    /// Various functions and utilities to work with meshes, mesh renderers and mesh filters.
    /// </summary>
    public class MeshUtils
    {
        /// <summary>
        /// Returns a list of all the shared materials used by the transform and its children
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static List<Material> GetSharedMaterialsList(Transform transform)
        {
            return GetSharedMaterialsList(transform, false);
        }

        /// <summary>
        /// Returns a list of all the shared materials used by the transform and its children
        /// </summary>
        /// <param name="transform">The transform to be searched</param>
        /// <param name="includeInactive">Whether to include inactiver gameobjects in the search</param>
        /// <returns>A list of materials</returns>
        public static List<Material> GetSharedMaterialsList(Transform transform, bool includeInactive)
        {
            List<Material> mats = new List<Material>();
            MeshRenderer[] renderers = transform.GetComponentsInChildren<MeshRenderer>(includeInactive);

            foreach (MeshRenderer rend in renderers)
            {
                foreach (Material mat in rend.sharedMaterials)
                {
                    mats.Add(mat);
                }
            }

            return mats;
        }

        /// <summary>
        /// Returns a list of all the materials used by the transform and its children
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static List<Material> GetMaterialsList(Transform transform)
        {
            return GetMaterialsList(transform, false);
        }

        /// <summary>
        /// Returns a list of all the materials used by the transform and its children
        /// </summary>
        /// <param name="transform">The transform to be searched</param>
        /// <param name="includeInactive">Whether to include inactiver gameobjects in the search</param>
        /// <returns>A list of materials</returns>
        public static List<Material> GetMaterialsList(Transform transform, bool includeInactive)
        {
            List<Material> mats = new List<Material>();
            MeshRenderer[] renderers = transform.GetComponentsInChildren<MeshRenderer>(includeInactive);

            foreach (MeshRenderer rend in renderers)
            {
                foreach (Material mat in rend.materials)
                {
                    mats.Add(mat);
                }
            }

            return mats;
        }
    }
}
