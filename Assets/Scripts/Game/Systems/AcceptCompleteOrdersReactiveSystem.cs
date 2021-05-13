using System.Collections.Generic;
using Entitas;

namespace BoxLoader
{
	public class AcceptCompleteOrdersReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;

		public AcceptCompleteOrdersReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.OrderCompleted.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasOrder;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var gameEntity in entities)
			{
				UpdateScore(gameEntity);
				
				gameEntity.isOrderCompleted = false;
				gameEntity.isOrderFinished = true;
			}
		}

		private void UpdateScore(GameEntity gameEntity)
		{
			var scorePoints = GetScorePoints(gameEntity.order.value);
			var currentScore = _context.score.value;
			_context.ReplaceScore(scorePoints + currentScore);
		}

		private int GetScorePoints(List<BoxesOrder> boxes)
		{
			var result = 0;
			foreach (var box in boxes)
				result += _context.dataService.value.BoxesData.Find(x => x.BoxType == box.BoxType).ScorePoints;
			
			return result;
		}
		
	}
}