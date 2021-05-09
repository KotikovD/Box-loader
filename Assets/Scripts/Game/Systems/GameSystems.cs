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
			
			// Init - Reactive
			Add(new CharactersReactiveSystem(contexts));
			Add(new ObjectsViewReactiveSystem(contexts));
			Add(new ConveyorsViewReactiveSystem(contexts));	
			Add(new ConveyorsSetModeReactiveSystem(contexts));
			Add(new BoxesViewReactiveSystem(contexts));
			Add(new RemoveBoxesFromConveyorsReactiveSystem(contexts));
			

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
			Add(new ReceiverMoveBoxesExecuteSystem(contexts));

			
			
			// Cleanup
			// Add(new DestroyEntitySystem(contexts));

		}
	}
}