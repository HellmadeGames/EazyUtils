using UnityEngine;

namespace Hellmade.EazyUtils
{
    /// <summary>
    /// Singleton class for Monobehaviours. The purpose of using this class is to be able to have singleton scripts that can also can be attached to gameobjects, and therefore have their own instance.
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class MonoSingleton<T> : MonoBehaviour where T : Component
	{
		private static T instance;
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<T>();
					if (instance == null)
					{
						GameObject obj = new GameObject();
						obj.name = typeof(T).Name;
						instance = obj.AddComponent<T>();
					}
				}
				return instance;
			}
		}

		public virtual void Awake()
		{
			if (instance == null)
			{
				instance = this as T;
				DontDestroyOnLoad(this.gameObject);
			}
		}
	}
}
