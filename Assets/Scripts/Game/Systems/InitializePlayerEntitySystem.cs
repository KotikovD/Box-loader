using Entitas;
using UnityEngine;

namespace BoxLoader
{
	public class InitializePlayerEntitySystem : IInitializeSystem
	{
		private Contexts _contexts;

		public InitializePlayerEntitySystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var playerData = _contexts.game.dataService.value.PlayerData;
			var playerEntity = _contexts.game.CreateEntity();
			
			playerEntity.AddSpeed(playerData.Speed);
			playerEntity.AddAsset(playerData.AssetName, playerData.SceneTagName);
			playerEntity.AddPosition(playerData.GetPosition);
			playerEntity.AddRotation(playerData.GetRotation);
			playerEntity.isPlayer = true;
		}

	}
}