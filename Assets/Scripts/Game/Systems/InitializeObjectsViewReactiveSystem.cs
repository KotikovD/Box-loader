using System.Collections.Generic;
using System.Linq;
using Entitas;


namespace BoxLoader
{
	public class InitializeObjectsViewReactiveSystem : ReactiveSystem<GameEntity>, ITearDownSystem
	{
		private readonly GameContext _context;

		public InitializeObjectsViewReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Asset.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasAsset;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				_context.viewObjectsService.value.DestroyView(entity);
				_context.viewObjectsService.value.CreateView(_context, entity);
			}
		}

		public void TearDown()
		{
			foreach (var entity in _context.GetEntities().Where(a => a.hasObjectsView))
				_context.viewObjectsService.value.DestroyView(entity);
		}

	}
}