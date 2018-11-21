using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Various extensions for the String class
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Removes a substring from the end of the string, only if it exists
    /// </summary>
    /// <param name="str">The string containing the substring to remove</param>
    /// <param name="suffix">The substring to remove</param>
    /// <returns>The modified string</returns>
    public static string RemoveFromEnd(this string str, string suffix)
    {
        if (str.EndsWith(suffix))
        {
            return str.Substring(0, str.Length - suffix.Length);
        }
        else
        {
            return str;
        }
    }

    /// <summary>
    /// Checks whether the string represents an integer
    /// </summary>
    /// <param name="str">The string to check</param>
    /// <returns>True if the string represents an integer</returns>
    public static bool IsInt(this string str)
    {
        int x;
        return int.TryParse(str, out x);
    }

    /// <summary>
    /// Checks whether the string represents a boolean
    /// </summary>
    /// <param name="str">The string to check</param>
    /// <returns>True if the string represents a boolean</returns>
    public static bool IsBool(this string str)
    {
        bool x;
        return bool.TryParse(str, out x);
    }

    /// <summary>
    /// Checks whether the string represents a float
    /// </summary>
    /// <param name="str">The string to check</param>
    /// <returns>True if the string represents a float</returns>
    public static bool IsFloat(this string str)
    {
        float x;
        return float.TryParse(str, out x);
    }
}
