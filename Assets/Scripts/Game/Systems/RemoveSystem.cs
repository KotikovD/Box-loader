using System.Collections.Generic;
using Entitas;


namespace BoxLoader
{
	public class RemoveReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		
		public RemoveReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Remove.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasObjectsView;
		}

		protected override void Execute(List<GameEntity> boxes)
		{
			var conveyorsWithBoxes = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Boxes,GameMatcher.ConveyorSubmitter));
			
			foreach (var box in boxes)
			{
				foreach (var conveyor in conveyorsWithBoxes)
				{
					if (conveyor.boxes.value.Contains(box))
					{
						conveyor.boxes.value.Remove(box);
						break;
					}
				}
				
				_context.viewObjectsService.value.DestroyView(box);
				box.Destroy();
				
				//TODO return boxes to pull
			}
		}
	}
}