using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace BoxLoader
{
	public class CreateOrdersReactiveSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		private OrdersData _ordersData;
		private Array _maxBoxTypes;

		
		public CreateOrdersReactiveSystem(Contexts contexts, MainOptions mainOptions) : base(contexts.game)
		{
			_ordersData = mainOptions.OrdersData;
			_context = contexts.game;
			_maxBoxTypes = Enum.GetValues(typeof(BoxType));
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ReadyForOrders.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return _context.hasScore;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var gameEntity in entities)
			{
				if(gameEntity.hasStandByTimer)
					gameEntity.RemoveStandByTimer();
				
				gameEntity.isReadyForOrders = false;
				var generatedOrder = GenerateOrder();
				gameEntity.ReplaceOrder(generatedOrder.order, generatedOrder.seconds, generatedOrder.stratTime);
				gameEntity.ReplaceOrderTimer(generatedOrder.seconds);
				gameEntity.orderUiView.value.CreateOrderUi(gameEntity.order.value, gameEntity.order.duration);
			}
		}
		
		private (List<BoxesOrder> order, int seconds, float stratTime) GenerateOrder()
		{
			var result = new List<BoxesOrder>();
			var score = _context.score.value;
			var coeficient = score > 0
				? Mathf.Round(score / _ordersData.RaiseScoreStep) * _ordersData.MultiplyingCoefficient + 1
				: 1;

			var boxesCount = _ordersData.StartCountBoxesInOrder * coeficient;
			boxesCount = boxesCount > _ordersData.MaxCountBoxesInOrder ? _ordersData.MaxCountBoxesInOrder : (int)boxesCount;
			
			for (var i = 0; i < boxesCount; i++)
			{
				var index = UnityEngine.Random.Range(0, _maxBoxTypes.Length);
				var boxType = (BoxType) _maxBoxTypes.GetValue(index);
				var localizationKey = _context.dataService.value.BoxesData.Find(b => b.BoxType == boxType).LocalizationKey;
				var localization = _context.dataService.value.Localization.GetKeyValue(localizationKey);
				result.Add(new BoxesOrder(boxType, localization,false));
			}
			
			var seconds = Mathf.RoundToInt(boxesCount * _ordersData.BaseTimePerOneBox);
			
			return (result, seconds, Time.time);
		}
		
	}
}