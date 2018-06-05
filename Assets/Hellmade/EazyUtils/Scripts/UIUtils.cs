using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hellmade.EazyUtils.UI
{
    public class UIUtils : MonoBehaviour
    {
        /// <summary>
        /// Checks if a click/touch was done inside the boundaries of a UI object. Returns false if no click/touch was done at all
        /// </summary>
        /// <param name="UIObject"></param>
        /// <returns></returns>
        public static bool ClickedInsideUIObject(GameObject UIObject)
        {
            return ClickedInsideUIObject(UIObject.GetComponent<RectTransform>());
        }

        /// <summary>
        /// Checks if a click/touch was done inside the boundaries of a UI object. Returns false if no click/touch was done at all
        /// </summary>
        /// <param name="UIObject"></param>
        /// <returns></returns>
        public static bool ClickedInsideUIObject(RectTransform UIObject)
        {
            return Input.GetMouseButton(0) &&
                UIObject.gameObject.activeSelf && RectTransformUtility.RectangleContainsScreenPoint(UIObject, Input.mousePosition, Camera.main);
        }
    }
}
