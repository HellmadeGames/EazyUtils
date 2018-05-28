using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils
{
    public class ImageUtils
    {
        /// <summary>
        /// Geenrates a solid texture of a specific color and size
        /// </summary>
        /// <param name="width">The width of the generated texture</param>
        /// <param name="height">The height of the generated texture</param>
        /// <param name="color">The color of the generated texture</param>
        /// <returns>A solid texture2D</returns>
        private static Texture2D GenerateSolidTexture(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];

            for (int i = 0; i < pix.Length; i++)
            {
                pix[i] = color;
            }

            Texture2D tex = new Texture2D(width, height);
            tex.SetPixels(pix);
            tex.Apply();

            return tex;
        }
    }
}
