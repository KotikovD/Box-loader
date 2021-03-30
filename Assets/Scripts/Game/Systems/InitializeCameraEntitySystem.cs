using Entitas;
using UnityEngine;


namespace BoxLoader
{
	public class InitializeCameraEntitySystem : IInitializeSystem
	{
		private Contexts _contexts;
		private GameEntity _cameraEntity;


		public InitializeCameraEntitySystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var cameraData = _contexts.game.dataService.value.CameraData;
			var playerPosition = _contexts.game.dataService.value.PlayerData.StartPosition;
			var cameraPosition = Utils.CalculateOffsetPosition(playerPosition, cameraData.OffsetByPlayer);

			_cameraEntity = _contexts.game.CreateEntity();
			_cameraEntity.AddPosition(cameraPosition);
			_cameraEntity.AddRotation(Quaternion.Euler(cameraData.StartRotation));
			_cameraEntity.isCamera = true;
			
			var camera = _contexts.game.sceneService.value.Camera;
			var view = camera.GetComponent<ObjectsView>();
			view.InitializeView(_cameraEntity);
		}
	}
}