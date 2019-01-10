using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// Various extensions for the String class
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Adds a substring to the start of a string
    /// </summary>
    /// <param name="str">The string to which the substring is to be added to</param>
    /// <param name="suffix">The substring to add</param>
    /// <returns>The modified string</returns>
    public static string AddToStart(this string str, string prefix)
    {
        return str.AddToStart(prefix, false);
    }

    /// <summary>
    /// Adds a substring to the start of a string
    /// </summary>
    /// <param name="str">The string to which the substring is to be added to</param>
    /// <param name="suffix">The substring to add</param>
    /// <param name="ignoreDuplicate">Set to true if the substring addition should be ignored when the string already starts with the same substring</param>
    /// <returns>The modified string</returns>
    public static string AddToStart(this string str, string prefix, bool ignoreDuplicate)
    {
        if (ignoreDuplicate && str.StartsWith(prefix))
        {
            return str;
        }
        else
        {
            return prefix + str;
        }
    }

    /// <summary>
    /// Adds a substring to the end of a string
    /// </summary>
    /// <param name="str">The string to which the substring is to be added to</param>
    /// <param name="suffix">The substring to add</param>
    /// <returns>The modified string</returns>
    public static string AddToEnd(this string str, string suffix)
    {
        return str.AddToEnd(suffix, false);
    }

    /// <summary>
    /// Adds a substring to the end of a string
    /// </summary>
    /// <param name="str">The string to which the substring is to be added to</param>
    /// <param name="suffix">The substring to add</param>
    /// <param name="ignoreDuplicate">Set to true if the substring addition should be ignored when the string already ends with the same substring</param>
    /// <returns>The modified string</returns>
    public static string AddToEnd(this string str, string suffix, bool ignoreDuplicate)
    {
        if (ignoreDuplicate && str.EndsWith(suffix))
        {
            return str;
        }
        else
        {
            return str + suffix;
        }
    }

    /// <summary>
    /// Removes a substring from the start of a string, only if it exists
    /// </summary>
    /// <param name="str">The string containing the substring to remove</param>
    /// <param name="prefix">he substring to remove</param>
    /// <returns>The modified string</returns>
    public static string RemoveFromStart(this string str, string prefix)
    {
        if (str.StartsWith(prefix))
        {
            return str.RemoveFromStart(prefix.Length);
        }
        else
        {
            return str;
        }
    }

    /// <summary>
    /// Removes a specific number of characters from the start of the string.
    /// </summary>
    /// <param name="str">The string from which the characters are going to be removed</param>
    /// <param name="numberOfChars">The number of characters to remove</param>
    /// <returns></returns>
    public static string RemoveFromStart(this string str, int numberOfChars)
    {
        numberOfChars = Mathf.Clamp(numberOfChars, 0, str.Length);
        return str.Substring(numberOfChars, str.Length - numberOfChars);
    }

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
            return str.RemoveFromEnd(suffix.Length);
        }
        else
        {
            return str;
        }
    }

    /// <summary>
    /// Removes a specific number of characters from the end of the string.
    /// </summary>
    /// <param name="str">The string from which the characters are going to be removed</param>
    /// <param name="numberOfChars">The number of characters to remove</param>
    /// <returns></returns>
    public static string RemoveFromEnd(this string str, int numberOfChars)
    {
        numberOfChars = Mathf.Clamp(numberOfChars, 0, str.Length);
        return str.Substring(0, str.Length - numberOfChars);
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

    public static bool HasArabicCharacters(this string str)
    {
        Regex regex = new Regex(
          "[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");
        return regex.IsMatch(str);
    }
}
