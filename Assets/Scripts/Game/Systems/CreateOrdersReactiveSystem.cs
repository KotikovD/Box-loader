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
		private int _score;
		
		public CreateOrdersReactiveSystem(Contexts contexts, MainOptions mainOptions) : base(contexts.game)
		{
			_ordersData = mainOptions.OrdersData;
			_context = contexts.game;
			_maxBoxTypes = Enum.GetValues(typeof(BoxType));
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Order.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var gameEntity in entities)
			{
				var generatedOrder = GenerateOrder();
				gameEntity.order.value = generatedOrder.order;
				gameEntity.order.duration = generatedOrder.seconds;
				gameEntity.order.startTime = generatedOrder.stratTime;
			}
		}
		
		private (List<BoxesOrder> order, int seconds, float stratTime) GenerateOrder()
		{
			var result = new List<BoxesOrder>();
			var coeficient = _score > 0
				? Mathf.Round(_score / _ordersData.RaiseScoreStep) * _ordersData.MultiplyingCoefficient + 1
				: 1;

			var boxesCount = _ordersData.StartCountBoxesInOrder * coeficient;
			boxesCount = boxesCount > _ordersData.MaxCountBoxesInOrder ? _ordersData.MaxCountBoxesInOrder : boxesCount;
			
			for (var i = 0; i < boxesCount; i++)
			{
				var index = UnityEngine.Random.Range(0, _maxBoxTypes.Length);
				result.Add(new BoxesOrder((BoxType)_maxBoxTypes.GetValue(index), false));
			}
			
			var seconds = Mathf.RoundToInt(result.Count * _ordersData.BaseTimePerOneBox);
			
			return (result, seconds, Time.time);
		}
		
	}
}