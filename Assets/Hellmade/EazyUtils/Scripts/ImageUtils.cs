using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Hellmade.EazyUtils
{
    /// <summary>
    /// Various functions and utilities to work with images, textures or sprites.
    /// </summary>
    public class ImageUtils
    {
        private const int MAX_TEX_SIZE = 16384;
        private const string FORMAT_ERROR = "Could not recognise image format.";

        private static Dictionary<byte[], Func<BinaryReader, Vector2Int>> imageFormatDecoders = new Dictionary<byte[], Func<BinaryReader, Vector2Int>>()
        {
            { new byte[] { 0x42, 0x4D }, DecodeBitmap },
            { new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, DecodeGif },
            { new byte[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }, DecodeGif },
            { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, DecodePng },
            { new byte[] { 0xff, 0xd8 }, DecodeJfif },
        };

        /// <summary>      
        /// Gets the dimensions of an image.      
        /// </summary>      
        /// <param name="path">The path of the image to get the dimensions of.</param>      
        /// <returns>The dimensions of the specified image.</returns>      
        /// <exception cref="ArgumentException">The image was of an unrecognised format.</exception>      
        public static Vector2Int GetImageDimensions(string path)
        {
            try
            {
                using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(path)))
                {
                    try
                    {
                        return GetImageDimensions(binaryReader);
                    }
                    catch (ArgumentException e)
                    {
                        string newMessage = string.Format("{0} file: '{1}' ", FORMAT_ERROR, path);

                        throw new ArgumentException(newMessage, "path", e);
                    }
                }
            }
            catch (ArgumentException)
            {
                UnityEngine.Debug.LogError("And error occured");
                return new Vector2Int(0, 0);
            }
        }

        /// <summary>      
        /// Gets the dimensions of an image.      
        /// </summary>      
        /// <param name="path">The path of the image to get the dimensions of.</param>      
        /// <returns>The dimensions of the specified image.</returns>      
        /// <exception cref="ArgumentException">The image was of an unrecognised format.</exception>          
        public static Vector2Int GetImageDimensions(BinaryReader binaryReader)
        {
            int maxMagicBytesLength = imageFormatDecoders.Keys.OrderByDescending(x => x.Length).First().Length;
            byte[] magicBytes = new byte[maxMagicBytesLength];
            for (int i = 0; i < maxMagicBytesLength; i += 1)
            {
                magicBytes[i] = binaryReader.ReadByte();
                foreach (var kvPair in imageFormatDecoders)
                {
                    if (StartsWith(magicBytes, kvPair.Key))
                    {
                        return kvPair.Value(binaryReader);
                    }
                }
            }

            throw new ArgumentException(FORMAT_ERROR, "binaryReader");
        }

        private static bool StartsWith(byte[] thisBytes, byte[] thatBytes)
        {
            for (int i = 0; i < thatBytes.Length; i += 1)
            {
                if (thisBytes[i] != thatBytes[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static short ReadLittleEndianInt16(BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(short)];

            for (int i = 0; i < sizeof(short); i += 1)
            {
                bytes[sizeof(short) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToInt16(bytes, 0);
        }

        private static ushort ReadLittleEndianUInt16(BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(ushort)];

            for (int i = 0; i < sizeof(ushort); i += 1)
            {
                bytes[sizeof(ushort) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToUInt16(bytes, 0);
        }

        private static int ReadLittleEndianInt32(BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(int)];
            for (int i = 0; i < sizeof(int); i += 1)
            {
                bytes[sizeof(int) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToInt32(bytes, 0);
        }

        private static Vector2Int DecodeBitmap(BinaryReader binaryReader)
        {
            binaryReader.ReadBytes(16);
            int width = binaryReader.ReadInt32();
            int height = binaryReader.ReadInt32();
            return new Vector2Int(width, height);
        }

        private static Vector2Int DecodeGif(BinaryReader binaryReader)
        {
            int width = binaryReader.ReadInt16();
            int height = binaryReader.ReadInt16();
            return new Vector2Int(width, height);
        }

        private static Vector2Int DecodePng(BinaryReader binaryReader)
        {
            binaryReader.ReadBytes(8);
            int width = ReadLittleEndianInt32(binaryReader);
            int height = ReadLittleEndianInt32(binaryReader);
            return new Vector2Int(width, height);
        }

        private static Vector2Int DecodeJfif(BinaryReader binaryReader)
        {
            while (binaryReader.ReadByte() == 0xff)
            {
                byte marker = binaryReader.ReadByte();
                short chunkLength = ReadLittleEndianInt16(binaryReader);
                if (marker == 0xc0)
                {
                    binaryReader.ReadByte();
                    int height = ReadLittleEndianInt16(binaryReader);
                    int width = ReadLittleEndianInt16(binaryReader);
                    return new Vector2Int(width, height);
                }

                if (chunkLength < 0)
                {
                    ushort uchunkLength = (ushort)chunkLength;
                    binaryReader.ReadBytes(uchunkLength - 2);
                }
                else
                {
                    binaryReader.ReadBytes(chunkLength - 2);
                }
            }

            throw new ArgumentException(FORMAT_ERROR);
        }

        /// <summary>
        /// Load an image from disk into a Texture2D
        /// </summary>
        /// <param name="path">The full path to the image file</param>
        /// <returns>Texture2D</returns>
		public static Texture2D LoadTexture(string path)
        {
            if (File.Exists(path))
            { 
                try
                {
                    Vector2Int imageDimensions = GetImageDimensions(path);

                    if(imageDimensions.x > MAX_TEX_SIZE || imageDimensions.y > MAX_TEX_SIZE)
                    {
                        throw new FileLoadException("The image " + path + " could not be loaded. Maximum supported dimensions are " + MAX_TEX_SIZE + "x" + MAX_TEX_SIZE);
                    }

                    byte[] texBytes = File.ReadAllBytes(path);
                    Texture2D tex = new Texture2D(2, 2);
                    tex.LoadImage(texBytes);

                    return tex;
                }
                catch(Exception ex)
                {
                    Debug.LogException(ex);
                    return null;
                }
            }

            return null;
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
            if(texture == null)
            {
                return null;
            }

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
