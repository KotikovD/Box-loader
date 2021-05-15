using Entitas;


namespace BoxLoader
{
	public class ConveyorUiUpdateAnchorsExecuteSystem : IExecuteSystem
	{
		private readonly Contexts _context;

		public ConveyorUiUpdateAnchorsExecuteSystem(Contexts context)
		{
			_context = context;
		}

		public void Execute()
		{
			var entitiesGroup = _context.game.GetEntities(GameMatcher.AllOf(GameMatcher.OrderUiView, GameMatcher.ConveyorSubmitter));
			
			foreach (var conveyor in entitiesGroup)
				SynchronizerAnchorsPosition(conveyor);
		}
		
		private void SynchronizerAnchorsPosition(GameEntity conveyor)
		{
			var orderUiPointPosition = conveyor.conveyorView.value.OrderUiPoint;
			var screenPoint = _context.game.camera.value.WorldToScreenPoint(orderUiPointPosition);
			conveyor.orderUiView.value.UpdateAnchors(screenPoint);
		}
		
		
	}
}