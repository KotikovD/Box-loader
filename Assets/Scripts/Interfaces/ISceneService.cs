using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BoxLoader
{
	[Game, Unique, ComponentName("SceneService")]
	public interface ISceneService
	{
		GameObject GetMainParentGameObject(SceneTagNames tagNames);
	}
}