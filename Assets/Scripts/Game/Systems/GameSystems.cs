namespace BoxLoader
{
	public class GameSystems : Feature
	{
		public GameSystems(Contexts contexts)
		{
			//TODO implement Teardown methods for all sys
			
			// Init - Global systems
			Add(new GameEventSystems(contexts));
			Add(new InputEventSystems(contexts));
			Add(new InitializeDataSystem(contexts));
			Add(new InitializeCharacterServiceSystem(contexts));
			Add(new InitializeObjectsViewServiceSystem(contexts));
			Add(new CharactersReactiveSystem(contexts));
			Add(new ObjectsViewReactiveSystem(contexts));
			
			
			// Init - Usual systems
			Add(new InitializePlayerEntitySystem(contexts));
			Add(new InitializePlayerInputReactiveSystem(contexts));	
			Add(new InitializeCameraEntitySystem(contexts));
			Add(new InitializeCameraMoveReactiveEventSystem(contexts));
			Add(new InitializeProcessInputSystem(contexts));
			
			
			// Execute
			Add(new VisualSynchronizerExecuteSystem(contexts));
			
			
			// Cleanup
			// Add(new DestroyEntitySystem(contexts));

		}
	}
}