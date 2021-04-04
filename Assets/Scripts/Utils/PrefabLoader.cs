using System;
using System.IO;
using UnityEngine;

namespace BoxLoader
{
	public class PrefabLoader : IPrefabLoader
	{
		private readonly string _prefabsFolder;

		public PrefabLoader(IPathKeeperData pathKeeperData)
		{
			_prefabsFolder = pathKeeperData.PrefabsFolder;
		}
		public GameObject GetPrefab(string name)
		{
			var path = Path.Combine(_prefabsFolder, name);
			var prefab = Resources.Load<GameObject>(path);

			if (prefab == null)
				throw new Exception("Prefab by path: " + path + " not found");

			return prefab;
		}
	}
}