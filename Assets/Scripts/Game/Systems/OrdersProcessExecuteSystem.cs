using System.Linq;
using Entitas;
using UnityEngine;


namespace BoxLoader
{
	public class OrdersProcessExecuteSystem : IExecuteSystem
	{
		private readonly Contexts _context;

		public OrdersProcessExecuteSystem(Contexts context)
		{
			_context = context;
		}

		public void Execute()
		{
			var conveyors = _context.game.GetEntities(GameMatcher.AllOf(GameMatcher.Order, GameMatcher.Boxes, GameMatcher.ConveyorSubmitter, GameMatcher.OrderTimer));
			
			foreach (var conveyor in conveyors)
			{
				
				var order = conveyor.order;
				var remainingTime = UpdateTimer(order);
				conveyor.ReplaceOrderTimer(remainingTime);

				if (order.value.Count == 0 || conveyor.isOrderFinished || conveyor.isOrderCompleted)
				{
					continue;
				}
				
				if (remainingTime < 0)
				{
					conveyor.isOrderFinished = true;
					continue;
				}

				if (CheckOrderComplete(order))
				{
					conveyor.isOrderCompleted = true;
					continue;
				}
				
				var boxes = conveyor.boxes.value;
				if (boxes.Count == 0)
				{
					continue;
				}
				
				var firstBox = boxes.First();
				if (firstBox.isSubmittedBox)
				{
					var orderList = order.value;
					foreach (var oneOrder in orderList)
					{
						if (oneOrder.BoxType == firstBox.box.value && !oneOrder.IsComplete) ;
						{
							oneOrder.IsComplete = true;
						}

						if (oneOrder.BoxType != firstBox.box.value && !oneOrder.IsComplete)
						{
							conveyor.isOrderFinished = true;
							break;
						}
					}
				}
			}
		}
		
		private bool CheckOrderComplete(OrderComponent order)
		{
			return order.value.All(x => x.IsComplete);
		}
		
		private float UpdateTimer(OrderComponent order)
		{
			return order.duration - (Time.time - order.startTime);
		}
		
	}
}