using BoxLoader;
using Entitas;
using UnityEngine;

public class InitializeCameraSystem : IInitializeSystem
{
	private Contexts _contexts;
	private GameEntity _cameraEntity;
	
	public InitializeCameraSystem(Contexts contexts)
	{
		_contexts = contexts;
	}
	
	public void Initialize()
	{
		var cameraData = _contexts.game.dataService.value.Camera;
		_cameraEntity = _contexts.game.CreateEntity();
		_cameraEntity.AddPosition(cameraData.StartPosition);
		_cameraEntity.AddRotation(Quaternion.Euler(cameraData.StartRotation));
		_cameraEntity.isCamera = true;
		var gameObject = GameObject.FindWithTag("MainCamera");
		var view = gameObject.GetComponent<ObjectsView>();
		view.InitializeView(_cameraEntity);
	}
	
}