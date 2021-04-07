using System.Collections.Generic;
using Entitas;
using UnityEngine;


namespace BoxLoader
{
	public class InitializeCameraMoveReactiveEventSystem : ReactiveSystem<GameEntity>, IInitializeSystem, IPositionListener, ITearDownSystem
	{
		private Contexts _contexts;
		private CameraData _cameraData;
		private GameEntity _camera;
		
		public InitializeCameraMoveReactiveEventSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
		}
		
		public void Initialize()
		{
			_cameraData = _contexts.game.dataService.value.CameraData;
			var playerPosition = _contexts.game.dataService.value.PlayerData.GetPosition;
			var cameraPosition = CalculateOffset(playerPosition, _cameraData.GetPosition);

			_camera = _contexts.game.CreateEntity();
			_camera.AddAsset(_cameraData.AssetName, _cameraData.SceneTagName);
			_camera.AddPosition(cameraPosition);
			_camera.AddRotation(_cameraData.GetRotation);
			_camera.isCamera = true;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Camera.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isCamera && entity.hasObjectsView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			_contexts.game.playerEntity.AddPositionListener(this);
		}
		
		public void OnPosition(GameEntity entity, Vector3 value)
		{
			var newPosition = CalculateOffset(value, _cameraData.GetPosition);
			var lerpPosition = Vector3.Lerp(_camera.position.value, newPosition,_cameraData.LerpSpeed);
			_camera.objectsView.Value.SetPosition(lerpPosition);
		}

		private Vector3 CalculateOffset(Vector3 targetPos, Vector3 offset)
		{
			var resultPos = offset;
			resultPos.x = targetPos.x + offset.x;
			resultPos.z = targetPos.z + offset.z;

			return resultPos;
		}
		
		public void TearDown()
		{
			_contexts.game.playerEntity.RemovePositionListener(this);
		}
	}
}