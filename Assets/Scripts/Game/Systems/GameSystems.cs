namespace BoxLoader
{
	public class GameSystems : Feature
	{
		public GameSystems(Contexts contexts)
		{

			// Init
			Add(new InitializeDataSystem(contexts));
			Add(new InitializeSceneSystem(contexts));
			Add(new InitializeCharacterViewSystem(contexts));
			Add(new InitializeObjectsViewSystem(contexts));
			
			Add(new GameEventSystems(contexts));
			Add(new InputEventSystems(contexts));
			
			Add(new InitializePlayerInputSystem(contexts));
			Add(new InitializePlayerSystem(contexts));
			Add(new InitializeCameraSystem(contexts));
			Add(new CameraMoveEventSystem(contexts));
			Add(new ProcessInputReactiveSystem(contexts));
			
			
			// Add(new InitializeNpcSystem(contexts));
			// Add(new InitializeLevelSystem(contexts));
			// Add(new MeshColorReactiveSystem(contexts));
			// Add(new GameEventSystems(contexts));
			//
			//
			// // Input
			 
			// Add(new ApplyPlayerUnitMovementSystem(contexts));
			
			
			// // Update
			// Add(new HealthReactiveSystem(contexts));
			// Add(new PositionMoveReactiveSystem(contexts));
			// Add(new RotationMoveReactiveSystem(contexts));
			// Add(new ApplyDamageReactiveSystem(contexts));
			// Add(new SetCameraParentReactiveSystem(contexts));
			// //Add(new CameraMoveSystem(contexts));
			//
			// // View
			Add(new CreatePalyerViewByAssetReactiveSystem(contexts));
			
			//
			//
			// //Cleanup
			// Add(new DestroyEntitySystem(contexts));

		}
	}
}