using Entitas;
using UnityEngine;


namespace BoxLoader
{
	public class InitializeCameraMoveEventSystem : IInitializeSystem, IPositionListener
	{
		private Contexts _contexts;
		private CameraData _cameraData;
		private GameEntity _camera;
		
		public InitializeCameraMoveEventSystem(Contexts contexts)
		{
			_contexts = contexts;
		}
		public void Initialize()
		{
			_cameraData = _contexts.game.dataService.value.CameraData;
			_camera = _contexts.game.cameraEntity;
			
			_contexts.game.playerEntity.AddPositionListener(this);
		}

		public void OnPosition(GameEntity entity, Vector3 value)
		{
			var newPosition = Utils.CalculateOffsetPosition(value, _cameraData.OffsetByPlayer);
			var lerpPosition = Vector3.Lerp(_camera.position.value, newPosition,_cameraData.LerpSpeed);
			_camera.objectsView.Value.SetPosition(lerpPosition);
		}
		
	}
}