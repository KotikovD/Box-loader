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
			var playerPosition = _contexts.game.dataService.value.PlayerData.GetPosition;
			var cameraPosition = Utils.CalculateOffsetPosition(playerPosition, cameraData.GetPosition);

			_cameraEntity = _contexts.game.CreateEntity();
			_cameraEntity.AddAsset(cameraData.AssetName);
			_cameraEntity.AddPosition(cameraPosition);
			_cameraEntity.AddRotation(cameraData.GetRotation);
			_cameraEntity.isCamera = true;
		}
	}
}