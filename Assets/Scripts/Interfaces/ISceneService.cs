using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, ComponentName("SceneService")]
public interface ISceneService
{
	Camera Camera { get; }
}