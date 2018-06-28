using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils
{
    /// <summary>
    /// Various functions and utilities to work with strings.
    /// </summary>
    public class StringUtils
    {
        /// <summary>
        /// Generates a unique string
        /// </summary>
        /// <returns>A unique alphanumeric string</returns>
        public static string GenerateUniqueString()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        /// <summary>
        /// Checks if a string is unique among a list of other strings
        /// </summary>
        /// <param name="str">The string to be checked for uniqueness</param>
        /// <param name="otherStrings">An array of strings to check the provided str against</param>
        /// <returns>True if it is unique, false if it is not</returns>
        public static bool IsUnique(string str, string[] otherStrings)
        {
            for (int i = 0; i < otherStrings.Length; i++)
            {
                if (str == otherStrings[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
