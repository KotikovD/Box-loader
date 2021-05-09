using System.Collections.Generic;
using Entitas;


namespace BoxLoader
{
	public class RemoveBoxesFromConveyorsReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		
		public RemoveBoxesFromConveyorsReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Using.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasObjectsView && entity.hasBoxView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var conveyorsWithBoxes = _context.GetGroup(GameMatcher.Boxes);

			foreach (var conveyor in conveyorsWithBoxes)
			{
				for (var i = conveyor.boxes.value.Count - 1; i >= 0; i--)
				{
					if (conveyor.boxes.value[i].isUsing)
						conveyor.boxes.value.RemoveAt(i);
				}
			}
		}
		
	}
}