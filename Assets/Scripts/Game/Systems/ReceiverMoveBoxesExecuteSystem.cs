using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Entitas;
using UnityEngine;


namespace BoxLoader
{
	class ReceiverMoveBoxesExecuteSystem : IExecuteSystem
	{
		private readonly Contexts _context;
		private List<BoxData> _boxesData; 
		private Sequence _moveTween;
		private float _boxStopDistanceConst = 0.1f;  //TODO move to constants

		public ReceiverMoveBoxesExecuteSystem(Contexts context)
		{
			_context = context;
		}

		public void Execute()
		{
			var conveyorsWithBoxes = _context.game.GetGroup(GameMatcher.Boxes);

			foreach (var entity in conveyorsWithBoxes)
			{
				if(!CheckBoxesReadyForAnimation(entity)) continue;
				
				if (AllowedToMoveBoxes(entity))
				{
					MoveBoxes(entity);
				}
				else
				{
					StopMovingBoxes(entity);
					CheckFirstBoxReadyForUse(entity);
				}
			}
		}

		private void CheckFirstBoxReadyForUse(GameEntity entity)
		{
			var firstBox = entity.boxes.value.First();
			firstBox.isReadyForUse = true;
		}

		private void MoveBoxes(GameEntity entity)
		{
			var target = entity.conveyorView.value.DestinationMovePoint;
			var speed = entity.conveyorData.value.WorkingSpeed; //TODO Sincronize speed shader and boxes 

			entity.conveyorView.value.Activate();
			
			foreach (var box in entity.boxes.value)
			{
				box.boxView.value.AnimationMove(target, speed);
			}

		}

		private void StopMovingBoxes(GameEntity entity)
		{
			entity.conveyorView.value.Stop();
			
			foreach (var box in entity.boxes.value)
				box.boxView.value.StopAnimationMoving();
			
		}

		private bool CheckBoxesReadyForAnimation(GameEntity entity)
		{
			return entity.boxes.value.Last().hasObjectsView;
		}
		
		private bool AllowedToMoveBoxes(GameEntity entity)
		{
			var firstBox = entity.boxes.value.First();
			
			if(Vector3.Distance(firstBox.objectsView.Value.GetPosition,entity.conveyorView.value.DestinationMovePoint) < _boxStopDistanceConst)
				return false;

			return true;
		}
	}
}