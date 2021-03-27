public interface IDataLoader
{
	T GetData<T>(string name) where T : UnityEngine.Object;
}