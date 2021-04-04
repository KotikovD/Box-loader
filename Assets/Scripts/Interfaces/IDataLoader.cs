using System.Collections.Generic;

public interface IDataLoader
{
	T GetData<T>(string name) where T : UnityEngine.Object;
	List<T> GetAllDataByType<T>() where T : UnityEngine.Object;
}