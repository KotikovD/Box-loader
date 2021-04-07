using Entitas;

namespace BoxLoader
{
	public class InitializeSimpleObjectsEntitiesSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public InitializeSimpleObjectsEntitiesSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var someObjectsData = _contexts.game.dataService.value.SomeObjectsData;

			foreach (var someObject in someObjectsData)
			{
				var someEntity = _contexts.game.CreateEntity();
				someEntity.AddAsset(someObject.AssetName, someObject.SceneTagName);
				someEntity.AddPosition(someObject.GetPosition);
				someEntity.AddRotation(someObject.GetRotation);
			}
		}

	}
}