using UnityEngine;

namespace BoxLoader
{
	public interface ISceneGameObjectsHierarchy
	{
		Transform GetParent(SceneTagNames nameTag);
	}
}