using System.Collections.Generic;
using Entitas;


namespace BoxLoader
{
	public class RemoveBoxesFromConveyorsExecuteSystem : IExecuteSystem
	{
		private readonly GameContext _context;

		public RemoveBoxesFromConveyorsExecuteSystem(Contexts contexts)
		{
			_context = contexts.game;
		}
//TODO remove
		// protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		// {
		// 	return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Using.Added(), GameMatcher.SubmittedBox.Added()));
		// }
		//
		// protected override bool Filter(GameEntity entity)
		// {
		// 	return entity.hasObjectsView && entity.hasBoxView;
		// }
		//
		// protected override void Execute(List<GameEntity> entities)
		// {
		// 	var conveyorsWithBoxes = _context.GetGroup(GameMatcher.Boxes);
		//
		// 	foreach (var conveyor in conveyorsWithBoxes)
		// 	{
		// 		for (var i = conveyor.boxes.value.Count - 1; i >= 0; i--)
		// 		{
		// 			var isNeedRemove = conveyor.boxes.value[i].isUsing || 
		// 			                   conveyor.boxes.value[i].isSubmittedBox && conveyor.boxes.value[i].isReadyForUse;
		// 			
		// 			if (isNeedRemove)
		// 				conveyor.boxes.value.RemoveAt(i);
		// 			
		// 		}
		// 	}
		// }

		public void Execute()
		{
			var conveyorsWithBoxes = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Boxes));

			foreach (var conveyor in conveyorsWithBoxes)
			{
				for (var i = conveyor.boxes.value.Count - 1; i >= 0; i--)
				{
					var isNeedRemove = conveyor.boxes.value[i].isUsing ||
					                   conveyor.boxes.value[i].isSubmittedBox && conveyor.boxes.value[i].isReadyForUse;

					if (isNeedRemove)
						conveyor.boxes.value.RemoveAt(i);

				}
			}
		}
	}
}