using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Hellmade.EazyUtils
{
    /// <summary>
    /// Various functions and utilities to work with images, textures or sprites.
    /// </summary>
    public class ImageUtils
    {
        /// <summary>
        /// Load an image from disk into a Texture2D
        /// </summary>
        /// <param name="path">The full path to the image file</param>
        /// <returns>Texture2D</returns>
		public static Texture2D LoadTexture(string path)
        {
            byte[] texBytes = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(64, 64, TextureFormat.ARGB32, false);
            tex.LoadImage(texBytes);

            return tex;
        }

        /// <summary>
        /// Load an image from disk into a Sprite
        /// </summary>
        /// <param name="path">The full path to the image file</param>
        /// <returns>Sprite</returns>
        public static Sprite LoadSprite(string path)
        {
            return TextureToSprite(LoadTexture(path));
        }

        /// <summary>
        /// Genenrates a solid texture of a specific color and size
        /// </summary>
        /// <param name="width">The width of the generated texture</param>
        /// <param name="height">The height of the generated texture</param>
        /// <param name="color">The color of the generated texture</param>
        /// <returns>A solid texture2D</returns>
        public static Texture2D GenerateSolidTexture(int width, int height, Color color)
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

        /// <summary>
        /// Genenrates a solid sprite of a specific color and size
        /// </summary>
        /// <param name="width">The width of the generated sprite</param>
        /// <param name="height">The height of the generated sprite</param>
        /// <param name="color">The color of the generated sprite</param>
        /// <returns>A solid Sprite</returns>
        public static Sprite GenerateSolidSprite(int width, int height, Color color)
        {
            return TextureToSprite(GenerateSolidTexture(width, height, color));
        }

        /// <summary>
        /// Converts a Texture2D into a Sprite
        /// </summary>
        /// <param name="texture">The texture to be converted</param>
        /// <returns>A sprite</returns>
        public static Sprite TextureToSprite(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }

        /// <summary>
        /// Converts a Sprite into a Texture2d
        /// </summary>
        /// <param name="sprite">The sprite to be converted</param>
        /// <returns></returns>
        public static Texture2D SpriteToTexture(Sprite sprite)
        {
            return sprite.texture;
        }
    }
}
