using System.Collections.Generic;
using Entitas;

namespace BoxLoader
{
	public class ReadyOrdersSetterReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;

		public ReadyOrdersSetterReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.OrderUiView.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasOrder;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var gameEntity in entities)
			{
				gameEntity.isReadyForOrders = true;
			}
		}
	}
}