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
			Add(new InitializeSceneServiceServiceSystem(contexts, mainOptions.SceneParentsNamesKeeper));
			Add(new InitializeDataServiceSystem(contexts, mainOptions.PathKeeper));
			Add(new InitializeCharacterServiceSystem(contexts, mainOptions.PathKeeper));
			Add(new InitializeObjectsViewServiceSystem(contexts, mainOptions.PathKeeper));
			
			// Init - Reactive
			Add(new CharactersReactiveSystem(contexts));
			Add(new ObjectsViewReactiveSystem(contexts));
			
			
			// Init - Usual
			Add(new InitializePlayerEntitySystem(contexts));
			Add(new InitializePlayerInputReactiveSystem(contexts));	
			Add(new InitializeConveyorEntitiesSystem(contexts));	
			
			Add(new InitializeCameraMoveReactiveEventSystem(contexts));
			Add(new InitializeProcessInputSystem(contexts));
			
			
			// Execute
			Add(new VisualSynchronizerExecuteSystem(contexts));
			
			
			// Cleanup
			// Add(new DestroyEntitySystem(contexts));

		}
	}
}