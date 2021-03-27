using UnityEngine;

namespace BoxLoader
{
	public interface IPrefabLoader
	{
		GameObject GetPrefab(string name);
	}
}