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
		private bool isInited = false;
		
		public InitializeCameraMoveReactiveEventSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
		}
		public void Initialize()
		{
			_cameraData = _contexts.game.dataService.value.CameraData;
			_camera = _contexts.game.cameraEntity;
			isInited = true;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Camera.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return isInited && entity.isCamera && entity.hasObjectsView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			_contexts.game.playerEntity.AddPositionListener(this);
		}
		
		public void OnPosition(GameEntity entity, Vector3 value)
		{
			var newPosition = Utils.CalculateOffsetPosition(value, _cameraData.GetPosition);
			var lerpPosition = Vector3.Lerp(_camera.position.value, newPosition,_cameraData.LerpSpeed);
			_camera.objectsView.Value.SetPosition(lerpPosition);
		}

		public void TearDown()
		{
			_contexts.game.playerEntity.RemovePositionListener(this);
		}
	}
}