using Entitas;

namespace BoxLoader
{
	public class InitializeGameUiSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public InitializeGameUiSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var gameUiData = _contexts.game.dataService.value.GameUiData;

			foreach (var someObject in gameUiData)
			{
				var someEntity = _contexts.game.CreateEntity();
				// someEntity.AddPosition(someObject.GetPosition);
				// someEntity.AddRotation(someObject.GetLocalRotation);
				someEntity.AddAsset(someObject.AssetName, someObject.SceneParentName);
				someEntity.AddScore(0);
			}
		}

	}
}