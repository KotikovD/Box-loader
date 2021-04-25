using System.Collections.Generic;
using Entitas;


namespace BoxLoader
{
	public class ConveyorsSetModeReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _context;

		public ConveyorsSetModeReactiveSystem(Contexts context) : base(context.game)
		{
			_context = context;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ConveyorView.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return !entity.hasBoxes;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				entity.conveyorView.value.SetWorkingMode(entity.conveyorData.value.ConveyorMode);
				
				if (entity.conveyorData.value.ConveyorMode == ConveyorMode.Receiver)
					entity.AddBoxes(new List<GameEntity>());
			}
		}
	}
}