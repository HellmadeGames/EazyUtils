using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils
{
	/// <summary>
    /// Various extensions for the enums
    /// </summary>
	public static class EnumExtensions
	{ 
		/// <summary>
        /// Returns the next value in an enum
        /// </summary>
        /// <returns></returns>
		public static T GetNext<T>(this T src) where T : struct
		{
			if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

			T[] Arr = (T[])Enum.GetValues(src.GetType());
			int j = Array.IndexOf<T>(Arr, src) + 1;
			return (Arr.Length == j) ? Arr[0] : Arr[j];
		}
	}
}
