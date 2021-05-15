using System;
using System.Collections.Generic;
using Entitas;
using RSG;
using UnityEngine;

namespace BoxLoader
{
	public class ResetOrdersReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;

		public ResetOrdersReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.OrderFinished.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasOrder && entity.hasConveyorView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var gameEntity in entities)
			{
				gameEntity.isOrderFinished = false;
				gameEntity.RemoveOrder();
				gameEntity.RemoveOrderTimer();
				gameEntity.orderUiView.value.RemoveCurrentOrder(true);
				gameEntity.AddStandByTimer(Time.time, _context.dataService.value.Constants.StandbyTimeBetweenOrders);
				gameEntity.conveyorView.value.Lamp.NoOrderLampBehaviour();
			}
		}
	}
}