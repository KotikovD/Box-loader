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