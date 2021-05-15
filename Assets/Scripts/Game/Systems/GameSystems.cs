namespace BoxLoader
{
	public class GameSystems : Feature
	{
		public GameSystems(Contexts contexts, MainOptions mainOptions)
		{
			
			// Init - Global
			Add(new GameEventSystems(contexts));
			Add(new InputEventSystems(contexts));
			Add(new InitializeDataServiceSystem(contexts, mainOptions.PathKeeper));
			Add(new InitializeCharacterServiceSystem(contexts, mainOptions.PathKeeper));
			Add(new InitializeObjectsViewServiceSystem(contexts, mainOptions));
			Add(new InitializeScoreUiReactiveSystem(contexts));
			
			// Init - Reactive
			Add(new CharactersReactiveSystem(contexts));
			Add(new ObjectsViewReactiveSystem(contexts));
			Add(new ConveyorsViewReactiveSystem(contexts));	
			Add(new ConveyorsSetModeReactiveSystem(contexts));
			Add(new BoxesViewReactiveSystem(contexts));
			Add(new RemoveBoxesFromConveyorsExecuteSystem(contexts));
			Add(new RemoveReactiveSystem(contexts));
			Add(new CreateOrdersReactiveSystem(contexts, mainOptions));
			Add(new ResetOrdersReactiveSystem(contexts));
			Add(new AcceptCompleteOrdersReactiveSystem(contexts));
			Add(new UpdateScoreViewReactiveSystem(contexts));
			Add(new InitializeConveyorUiOrderReactiveSystem(contexts));
			Add(new ReadyOrdersSetterReactiveSystem(contexts));
			
			// Init - Usual
			Add(new InitializeSimpleObjectsEntitiesSystem(contexts));
			Add(new InitializeCharactersEntitiesSystem(contexts));
			Add(new InitializePlayerInputReactiveSystem(contexts));	
			Add(new InitializeConveyorEntitiesSystem(contexts));
			Add(new InitializeCameraMoveReactiveEventSystem(contexts));
			Add(new InitializeProcessUseObjectsReactiveSystem(contexts));
			
			// Init - Event
			Add(new InitializeProcessInputEventSystem(contexts, mainOptions));

			// Execute
			Add(new VisualSynchronizerExecuteSystem(contexts));
			Add(new InitializeBoxCreatorExecuteSystem(contexts));
			Add(new ConveyorsMoveBoxesExecuteSystem(contexts));
			Add(new OrdersProcessExecuteSystem(contexts));
			Add(new ConveyorUiUpdateAnchorsExecuteSystem(contexts));
			Add(new StandByTimerExecuteSystem(contexts));
			
			
			// Cleanup
			// Add(new DestroyEntitySystem(contexts));
		}
	}
}