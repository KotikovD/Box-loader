using System;
using System.IO;
using UnityEngine;

namespace BoxLoader
{
	public class PrefabLoader : IPrefabLoader
	{
		public GameObject GetPrefab(string name)
		{
			var path = Path.Combine(PathKeeper.PrefabsFolder, name);
			var prefab = Resources.Load<GameObject>(path);

			if (prefab == null)
				throw new Exception("Prefab by path: " + path + " not found");

			return prefab;
		}
	}
}