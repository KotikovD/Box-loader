using System.Collections.Generic;
using Entitas;

namespace BoxLoader
{
	public class BoxesViewReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		
		public BoxesViewReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Box.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasObjectsView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				var view = entity.objectsView.Value.GameObject.GetComponent<BoxView>();
				entity.AddBoxView(view);
			}
		}
	}
}