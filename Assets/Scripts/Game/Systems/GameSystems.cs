namespace BoxLoader
{
	public class GameSystems : Feature
	{
		public GameSystems(Contexts contexts)
		{

			// Event
			Add(new GameEventSystems(contexts));
			Add(new InputEventSystems(contexts));
			
			// Init
			Add(new InitializeDataSystem(contexts));
			Add(new InitializeSceneSystem(contexts));
			Add(new InitializeCharacterServiceSystem(contexts));
			Add(new InitializeObjectsViewServiceSystem(contexts));
			Add(new InitializePlayerEntitySystem(contexts));
			Add(new InitializeCameraEntitySystem(contexts));

			// Input
			Add(new InitializePlayerInputSystem(contexts));
			Add(new ProcessInputReactiveSystem(contexts));
			
			// Update
			Add(new InitializeObjectsViewReactiveSystem(contexts));
			Add(new InitializeCharactersReactiveSystem(contexts));
			Add(new CameraMoveEventSystem(contexts));
			Add(new VisualSynchronizerExecuteSystem(contexts));

			// View
			
			
			// Cleanup
			// Add(new DestroyEntitySystem(contexts));

		}
	}
}