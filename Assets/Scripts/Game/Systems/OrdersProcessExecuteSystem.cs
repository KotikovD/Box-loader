using System.Linq;
using Entitas;
using UnityEngine;


namespace BoxLoader
{
	public class OrdersProcessExecuteSystem : IExecuteSystem, IInitializeSystem
	{
		private readonly Contexts _context;
		private OrderConveyorUiData _orderConveyorUiData;

		public OrdersProcessExecuteSystem(Contexts context)
		{
			_context = context;
			
		}
		
		public void Initialize()
		{
			_orderConveyorUiData = _context.game.dataService.value.OrderConveyorUiData;
		}
		
		public void Execute()
		{
			var conveyors = _context.game.GetEntities(GameMatcher.AllOf(GameMatcher.Order, GameMatcher.Boxes, GameMatcher.ConveyorSubmitter, GameMatcher.OrderTimer));
			
			foreach (var conveyor in conveyors)
			{
				
				var order = conveyor.order;
				var remainingTime = UpdateTimer(order);
				conveyor.ReplaceOrderTimer(remainingTime);

				UpdateLampBehaviour(remainingTime, order.duration, conveyor);
				
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
						if (oneOrder.BoxType == firstBox.box.value && !oneOrder.IsComplete) 
						{
							oneOrder.IsComplete = true;
							conveyor.orderUiView.value.SetNextComplete();
							firstBox.isSubmittedBox = false;
							break;
						}
						else if (oneOrder.BoxType != firstBox.box.value && !oneOrder.IsComplete)
						{
							conveyor.isOrderFinished = true;
							firstBox.isSubmittedBox = false;
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
		
		private void UpdateLampBehaviour(float remainingTime, float orderDuration, GameEntity conveyor)
		{
			var time = _orderConveyorUiData.AlarmTime * orderDuration;
			
			if(remainingTime < time)
				conveyor.conveyorView.value.Lamp.TimeOffOrderLampBehaviour();
			else
				conveyor.conveyorView.value.Lamp.ProcessingOrderLampBehaviour();
			
		}

		
	}
}