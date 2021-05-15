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
		private Transform _boxPoolParent;

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
			_boxPoolParent = _mainOptions.SceneGameObjectsHierarchy.GetParent(SceneParentName.BoxPool);
		}

		public void OnTarget(InputEntity entity, Vector3 sourceTarget)
		{
			var targetDestination = sourceTarget;
			var readyForUseEntities = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.ReadyForUse, GameMatcher.BoxView));
			var usingEntities = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Using, GameMatcher.BoxView));

			if(entity.isUse)
			{
				if (usingEntities.count > 0)
				{
					DropBox(usingEntities);
				}
				else if (readyForUseEntities.count > 0)
				{
					PickupBox(sourceTarget, readyForUseEntities);
				}
			}
			else
			{
				var submitters = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.ConveyorSubmitter, GameMatcher.Order));
				if (usingEntities.count > 0 && FindClosestTable(sourceTarget, submitters, out var conveyor))
				{
					SubmitBox(usingEntities, conveyor);
				}
				else
				{
					_playerEntity.character.Value.Move(targetDestination);
				}
			}
		}

		private void SubmitBox(IGroup<GameEntity> usingEntities, GameEntity conveyor)
		{
			var box = usingEntities.GetSingleEntity();
			var movePoint = conveyor.conveyorView.value.GetLoadPoint(boxesUsingOffset, box.boxView.value.MaxExtent);
			_playerEntity.character.Value.Move(movePoint)
				.Then(() => _playerEntity.character.Value.LookAt(conveyor.objectsView.Value.GetPosition))
				.Then(() => _playerEntity.character.Value.DropBox(0.15f)) //TODO move to const
				.Then(() =>
				{
					box.objectsView.Value.SetParent(_boxPoolParent);
					box.objectsView.Value.SetPosition(conveyor.conveyorView.value.StartMovePoint);
					box.isUsing = false;
					box.isSubmittedBox = true;
					conveyor.boxes.value.Add(box);
				});
		}

		private void PickupBox(Vector3 sourceTarget, IGroup<GameEntity> readyForUseEntities)
		{
			var isObjectFound = FindClosestObject(sourceTarget, readyForUseEntities, out var usedObject);
			
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
			one.objectsView.Value.SetParent(_boxPoolParent);
			one.isUsing = false;
			_playerEntity.character.Value.DropBox(0.15f) //TODO move to const
				.Then(() => one.boxView.value.DropAnimation(0.7f)) //TODO move to const
				.Then(() => one.isRemove = true);
		}

		private bool FindClosestObject(Vector3 sourceTarget, IGroup<GameEntity> readyForUseEntities, out GameEntity closestEntity)
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
		
		private bool FindClosestTable(Vector3 sourceTarget, IGroup<GameEntity> readyForUseEntities, out GameEntity closestEntity)
		{
			var closestDistance = float.MaxValue;
			closestEntity = null;
			
			foreach (var one in readyForUseEntities)
			{
				var currentDistance = Vector3.Distance(sourceTarget, one.conveyorView.value.Table.Position);

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