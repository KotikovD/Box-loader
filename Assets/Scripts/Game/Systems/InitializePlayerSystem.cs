using Entitas;
using UnityEngine;

namespace BoxLoader
{
	public class InitializePlayerSystem : IInitializeSystem
	{
		private Contexts _contexts;

		public InitializePlayerSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var playerData = _contexts.game.dataService.value.Player;
			var playerEntity = _contexts.game.CreateEntity();
			
			playerEntity.AddSpeed(playerData.Speed);
			playerEntity.AddAsset(playerData.AssetName);
			playerEntity.AddPosition(playerData.StartPosition);
			playerEntity.AddRotation(Quaternion.Euler(playerData.StartRotation));
			playerEntity.isPlayer = true;
		}

	}
}