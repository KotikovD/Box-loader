using DG.Tweening;
using Entitas;
using UnityEngine;

namespace BoxLoader
{
	public class CameraMoveEventSystem : IInitializeSystem, IAnyPlayerListener, IPositionListener
	{
		private Contexts _contexts;
		private GameEntity _cachePlayer;
		private CameraData _cameraDataData;
		private Sequence _animationTween;
		private GameEntity _cacheCamera;
		
		public CameraMoveEventSystem(Contexts contexts)
		{
			_contexts = contexts;
		}
		public void Initialize()
		{
			_cachePlayer = _contexts.game.playerEntity;
			_cameraDataData = _contexts.game.dataService.value.CameraData;
			_cacheCamera = _contexts.game.cameraEntity;
			
			_cachePlayer.AddPositionListener(this);
			_cachePlayer.AddAnyPlayerListener(this);
		}
		
		//TODO self action
		public void OnAnyPlayer(GameEntity entity)
		{
			if (_cachePlayer.creationIndex != entity.creationIndex)
			{
				_cachePlayer.RemovePositionListener();
				entity.AddPositionListener(this);
				_cachePlayer = entity;
				MoveCamera(entity);
			}
		}

		public void OnPosition(GameEntity entity, Vector3 value)
		{
			MoveCamera(entity);
		}
	 
		private void MoveCamera(GameEntity entity)
		{
			//TODO move to visual?
			var endPosition = new []{Utils.CalculateOffsetPosition(entity.position.value, _cameraDataData.OffsetByPlayer)};
			var duration = new []{_cameraDataData.LerpSpeed};
		
			_animationTween?.Kill();
			var tween = DOTween.Sequence();
			tween.Append(DOTween.ToArray(() => _cacheCamera.position.value, _cacheCamera.ReplacePosition, endPosition,
				duration).SetEase(Ease.Linear));
			_animationTween = tween;
		}
	


		
	}
}