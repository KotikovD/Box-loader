using System.Collections.Generic;
using Entitas;

namespace BoxLoader
{
	public class UpdateScoreViewReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;

		public UpdateScoreViewReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Score.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasUiView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var gameEntity in entities)
			{
				gameEntity.uiView.value.Count = _context.score.value.ToString();
			}
		}
	}
}