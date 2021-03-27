using System;
using System.IO;
using UnityEngine;


namespace BoxLoader
{
	internal class DataLoader : IDataLoader
	{
		public T GetData<T>(string name) where T : UnityEngine.Object
		{
			var path = Path.Combine(PathKeeper.DataFolder, name);
			var data = Resources.Load<T>(path);

			if (data == null)
				throw new Exception("Data by path: " + path + " not found");

			return data;
		}

	}
}