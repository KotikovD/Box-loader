using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


namespace BoxLoader
{
	public sealed class DataLoader : IDataLoader
	{
		private readonly string _dataFolder;

		public DataLoader(IPathKeeperData pathKeeperData)
		{
			_dataFolder = pathKeeperData.DataFolder;
		}
		
		public T GetData<T>(string name) where T : UnityEngine.Object
		{
			var path = Path.Combine(_dataFolder, name);
			var data = Resources.Load<T>(path);

			if (data == null)
				throw new Exception("Data by path: " + path + " not found");

			return data;
		}
		
		public List<T> GetAllDataByType<T>() where T : UnityEngine.Object
		{
			var data = Resources.LoadAll<T>(_dataFolder).ToList();

			if (data == null)
				throw new Exception("Data by path: " + _dataFolder + " not found");

			return data;
		}

	}
}