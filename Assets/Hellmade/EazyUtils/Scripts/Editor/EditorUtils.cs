using UnityEditor;
using UnityEngine;

namespace Hellmade.EazyUtils.Editor
{
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
