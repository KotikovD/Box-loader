using Entitas;
using UnityEngine;

namespace BoxLoader
{
	public class StandByTimerExecuteSystem : IExecuteSystem
	{
		private readonly GameContext _context;

		public StandByTimerExecuteSystem(Contexts contexts)
		{
			_context = contexts.game;
		}
		
		public void Execute()
		{
			var entities = _context.GetGroup(GameMatcher.StandByTimer);
			
			foreach (var gameEntity in entities)
			{
				var standByTime = UpdateTimer(gameEntity.standByTimer);
				if(standByTime < 0)
				{
					gameEntity.isReadyForOrders = true;
				}
			}
		}
		
		private float UpdateTimer(StandByTimerComponent timer)
		{
			return timer.duration - (Time.time - timer.startTime);
		}
	}
}