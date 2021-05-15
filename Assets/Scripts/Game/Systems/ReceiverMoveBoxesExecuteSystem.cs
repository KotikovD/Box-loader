using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Entitas;
using UnityEngine;


namespace BoxLoader
{
	class ConveyorsMoveBoxesExecuteSystem : IExecuteSystem
	{
		private readonly Contexts _context;
		private List<BoxData> _boxesData; 
		private Sequence _moveTween;

		public ConveyorsMoveBoxesExecuteSystem(Contexts context)
		{
			_context = context;
		}

		public void Execute()
		{
			var conveyorsWithBoxes = _context.game.GetGroup(GameMatcher.Boxes);

			foreach (var conveyor in conveyorsWithBoxes)
			{
				if(!CheckBoxesReadyForAnimation(conveyor)) continue;
				
				if (AllowedToMoveBoxes(conveyor))
				{
					if (conveyor.isConveyorSubmitter)
						SubmitterMoveBoxes(conveyor);
					else
						ReceiverMoveBoxes(conveyor);
				}
				else
				{
					StopMovingBoxes(conveyor);
					SetFirstBoxReadyForAction(conveyor);
				}
			}
		}

		private void SetFirstBoxReadyForAction(GameEntity conveyor)
		{
			var firstBox = conveyor.boxes.value.First();
			
			if(conveyor.isConveyorReceiver)
				firstBox.isReadyForUse = true;
			else if (conveyor.isConveyorSubmitter)
				firstBox.isRemove = true;
		}

		private void SubmitterMoveBoxes(GameEntity entity)
		{
			var target = entity.conveyorView.value.DestinationMovePoint;
			var speed = entity.conveyorData.value.WorkingSpeed; //TODO Sincronize speed shader and boxes 

			entity.conveyorView.value.Activate();
			
			foreach (var box in entity.boxes.value)
			{
				box.boxView.value.SubmitterAnimationMove(target, speed);
			}

		}

		private void ReceiverMoveBoxes(GameEntity entity)
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
			return entity.boxes.value.Count > 0 && entity.boxes.value.Last().hasObjectsView;
		}
		
		private bool AllowedToMoveBoxes(GameEntity entity)
		{
			var firstBox = entity.boxes.value.First();
			
			if(Vector3.Distance(firstBox.objectsView.Value.GetPosition,entity.conveyorView.value.DestinationMovePoint) < _context.game.dataService.value.Constants.BoxStopDistanceConst)
				return false;

			return true;
		}
	}
}