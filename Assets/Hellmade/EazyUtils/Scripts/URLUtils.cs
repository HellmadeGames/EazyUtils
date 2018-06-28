using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils.WWW
{
    /// <summary>
    /// Various functions and utilities to work with URLs and network-related tasks
    /// </summary>
    public class URLUtils
    {
        /// <summary>
        /// Navigates to a given URL using the system's default internet broswer
        /// </summary>
        /// <param name="URL">The full URL to navigate to</param>
        public static void GoToURL(string URL)
        {
            Application.OpenURL(URL);
        }
    }
}
