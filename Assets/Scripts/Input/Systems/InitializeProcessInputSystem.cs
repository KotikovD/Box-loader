using System.Linq;
using Entitas;
using RSG;
using UnityEngine;


namespace BoxLoader
{
	public sealed class InitializeProcessInputEventSystem : IInitializeSystem, ITargetListener
	{
		readonly GameContext _gameContext;
		readonly InputContext _inputContext;
		private GameEntity _playerEntity;
		private float maxDistanceForSearchUsedObjects = 1.5f; //TODO move to constants
		private float boxesUsingOffset = 0.3f; //TODO move to constants
		private MainOptions _mainOptions;

		public InitializeProcessInputEventSystem(Contexts contexts, MainOptions mainOptions)
		{
			_mainOptions = mainOptions;
			_gameContext = contexts.game;
			_inputContext = contexts.input;
		}

		public void Initialize()
		{
			_inputContext.inputEntity.AddTargetListener(this);
			_playerEntity = _gameContext.playerEntity;
		}

		public void OnTarget(InputEntity entity, Vector3 sourceTarget)
		{
			var targetDestination = sourceTarget;
			var readyForUseEntities = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.ReadyForUse, GameMatcher.BoxView));
			var usingEntities = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Using, GameMatcher.BoxView));
			
			if (entity.isUse && usingEntities.count > 0)
			{
				DropBox(usingEntities);
			}
			else if (entity.isUse && readyForUseEntities.count > 0)
			{
				PickupBox(sourceTarget, readyForUseEntities);
			}
			else
			{
				_playerEntity.character.Value.Move(targetDestination);
			}
		}

		private void PickupBox(Vector3 sourceTarget, IGroup<GameEntity> readyForUseEntities)
		{
			var isObjectFound = FindUsedObject(sourceTarget, readyForUseEntities, out var usedObject);
			
			if(!isObjectFound)
				return;
			
			var targetDestination = GetUsedPosition(usedObject);
			var lookAtTarget = usedObject.objectsView.Value.GetPosition;

			_playerEntity.character.Value.Move(targetDestination)
				.Then(() => _playerEntity.character.Value.LookAt(lookAtTarget))
				.Then(() => usedObject.isWantToUse = true);
		}

		private void DropBox(IGroup<GameEntity> usingEntities)
		{
			var one = usingEntities.GetSingleEntity();
			one.objectsView.Value.SetParent(
				_mainOptions.SceneGameObjectsHierarchy.GetParent(SceneParentName.BoxPool));
			one.isUsing = false;
			_playerEntity.character.Value.DropBox(0.07f) //TODO move to const
				.Then(() => one.boxView.value.DropAnimation(0.7f)) //TODO move to const
				.Then(() =>
				{
					//TODO return to pool
					_gameContext.viewObjectsService.value.DestroyView(one);
					one.Destroy();
				});
		}

		private bool FindUsedObject(Vector3 sourceTarget, IGroup<GameEntity> readyForUseEntities, out GameEntity closestEntity)
		{
			var closestDistance = float.MaxValue;
			closestEntity = null;
			
			foreach (var one in readyForUseEntities)
			{
				var currentDistance = Vector3.Distance(sourceTarget, one.objectsView.Value.GetPosition);

				if (currentDistance < maxDistanceForSearchUsedObjects && currentDistance < closestDistance)
				{
					closestDistance = currentDistance;
					closestEntity = one;
				}
			}

			return closestEntity != null;
		}

		private Vector3 GetUsedPosition(GameEntity entity)
		{
			var closetPos = Vector3.zero;

			if (entity.hasBoxView)
			{
				var currentPosition = _playerEntity.objectsView.Value.GetPosition;
				var posVariants = entity.boxView.value.GetUsingPositions(boxesUsingOffset);
				var closestDistance = float.MaxValue;

				foreach (var pos in posVariants)
				{
					var newDistance = Vector3.Distance(pos, currentPosition);
					if (newDistance < closestDistance)
					{
						closetPos = pos;
						closestDistance = newDistance;
					}
				}
			}
			else
			{
				closetPos = entity.objectsView.Value.GetPosition;
			}

			return closetPos;
		}
	}
}