using UnityEditor;
using UnityEngine;

namespace Hellmade.EazyUtils.Editor
{
    /// <summary>
    /// Various functions and utilities for editor programming. These are created to make creating custom editors and inspectors easier.
    /// </summary>
    public class EditorUtils
    {
        /// <summary>
        /// Focuses on an object in the editor
        /// </summary>
        /// <param name="obj"></param>
        public static void FocusOnObject(GameObject obj)
        {
            Selection.activeGameObject = obj;
            EditorGUIUtility.PingObject(obj);
            if (SceneView.lastActiveSceneView != null)
            {
                SceneView.lastActiveSceneView.FrameSelected();
            }
        }

        /// <summary>
        /// Unfocuses from all controls in the editor
        /// </summary>
        public static void Unfocus()
        {
            GUIUtility.keyboardControl = 0;
        }
    }
}
