namespace BoxLoader
{
	public class GameSystems : Feature
	{
		public GameSystems(Contexts contexts, MainOptions mainOptions)
		{
			//TODO implement Teardown methods for all sys
			//TODO refactor namespaces
			
			// Init - Global
			Add(new GameEventSystems(contexts));
			Add(new InputEventSystems(contexts));
			Add(new InitializeDataServiceSystem(contexts, mainOptions.PathKeeper));
			Add(new InitializeCharacterServiceSystem(contexts, mainOptions.PathKeeper));
			Add(new InitializeObjectsViewServiceSystem(contexts, mainOptions));
			Add(new InitializeGameUiSystem(contexts));
			
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

			
			
			// Cleanup
			// Add(new DestroyEntitySystem(contexts));

			
			// доделать сабимттер в конвеер вью, туда Тайбл скрипт, на который можно тыкнуть и получить точки, куда встать и повернуться, положить коробку
			// систему создания заказов для конвееров мола саббмиттер. Только создание заказов
			// система обработки коробок саббмитерами, она принимает коробки, редактирует заказ или перезапускает его
			
		}
	}
}