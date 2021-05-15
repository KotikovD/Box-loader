using System.Collections.Generic;
using Entitas;


namespace BoxLoader
{
	public class InitializeConveyorUiOrderReactiveSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext _context;
		private OrderConveyorUiData _orderUiData;

		public InitializeConveyorUiOrderReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			_orderUiData = _context.dataService.value.OrderConveyorUiData;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ObjectsView.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasConveyor;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var gameEntity in entities)
			{
				var orderUiView = gameEntity.objectsView.Value.GameObject.GetComponent<IOrderUiView>();
				var localization = Localization.GetKeyValue(_orderUiData.NoOrderLocalizationKey);

				orderUiView.Initialize(
					_orderUiData.OrderStrokeUiView,
					_orderUiData.DefaultStrokeColor,
					_orderUiData.CompleteStrokeColor,
					_orderUiData.AlarmTime,
					_orderUiData.DefaultTimerColor,
					_orderUiData.AlarmTimerColor,
					localization);

				gameEntity.conveyor.value.AddOrderUiView(orderUiView);
				gameEntity.RemoveConveyor();
			}
		}

	}
}
