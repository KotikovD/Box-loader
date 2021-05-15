using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;


namespace BoxLoader
{
	class InitializeBoxCreatorExecuteSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _context;
		private List<BoxData> _boxesData;
		private readonly Array _maxBoxTypes;

		public InitializeBoxCreatorExecuteSystem(Contexts context)
		{
			_context = context;
			_maxBoxTypes = Enum.GetValues(typeof(BoxType));
		}
		
		public void Initialize()
		{
			_boxesData = _context.game.dataService.value.BoxesData;
		}
		
		public void Execute()
		{
			var conveyorsWithBoxes = _context.game.GetGroup(GameMatcher.ConveyorReceiver);
			
			foreach (var entity in conveyorsWithBoxes)
			{
				if(!AllowedToCreateNewBox(entity)) continue;
				
				var boxType = GetRandomBoxType();
				var boxEntity = _context.game.CreateEntity();
				var boxData = _boxesData.Find(b => b.BoxType == boxType);
				
				boxEntity.AddAsset(boxData.AssetName, boxData.SceneParentName);
				boxEntity.AddPosition(entity.conveyorView.value.StartMovePoint);

				var rotation = entity.conveyorView.value.GetMovingDirectionRotation;
				boxEntity.ReplaceRotation(rotation);

				boxEntity.AddBox(boxData.BoxType);
				entity.boxes.value.Add(boxEntity);
			}
		}
		
		private bool AllowedToCreateNewBox(GameEntity entity)
		{
			if (entity.boxes.value.Count == 0)
				return true;

			var lastBox = entity.boxes.value.Last();
			if(!lastBox.hasBoxView)
				return false;
			
			var startMovingPoint = entity.conveyorView.value.StartMovePoint;
			var boxView = lastBox.boxView.value;
			
			if (boxView.IsPointInsideBox(startMovingPoint))
				return false;

			var currentDistance = Vector3.Distance(boxView.ClosestPoint(startMovingPoint), startMovingPoint);
			if (_context.game.dataService.value.Constants.MnDistanceBetweenBoxes > currentDistance)
				return false;

			return true;
		}
		
		private BoxType GetRandomBoxType()
		{
			var index = UnityEngine.Random.Range(0, _maxBoxTypes.Length);
			return (BoxType) _maxBoxTypes.GetValue(index);
		}
		
	}
}