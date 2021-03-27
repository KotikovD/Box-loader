using System.Collections.Generic;
using System.Linq;
using Entitas;

namespace BoxLoader
{
	public class CreatePalyerViewByAssetReactiveSystem : ReactiveSystem<GameEntity>, ITearDownSystem
	{
		private readonly GameContext _context;

		public CreatePalyerViewByAssetReactiveSystem(Contexts contexts) : base(contexts.game)
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
				_context.viewCharacterService.value.DestroyView(entity);
				_context.viewCharacterService.value.CreateView(_context, entity);
			}
		}

		public void TearDown()
		{
			foreach (var entity in _context.GetEntities().Where(a => a.hasCharacterView))
				_context.viewCharacterService.value.DestroyView(entity);
		}

	}
}