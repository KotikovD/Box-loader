using System.Collections.Generic;
using Entitas;

namespace BoxLoader
{
	public class ConveyorsViewReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		
		public ConveyorsViewReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ConveyorData.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasObjectsView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				var view = entity.objectsView.Value.GameObject.GetComponent<ConveyorView>();
				view.InitializeView(entity);
				entity.AddConveyorView(view);
			}
		}
	}
}