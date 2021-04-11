using Entitas;
using UnityEngine;

namespace BoxLoader
{
	public class InitializeCharactersEntitiesSystem : IInitializeSystem
	{
		private Contexts _contexts;

		public InitializeCharactersEntitiesSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var charactersData = _contexts.game.dataService.value.CharacterData;

			foreach (var character in charactersData)
			{
				var characterEntity = _contexts.game.CreateEntity();

				characterEntity.AddCharacterData(character);
				characterEntity.AddAsset(character.AssetName, character.SceneTagName);
				characterEntity.AddPosition(character.GetPosition);
				characterEntity.AddRotation(character.GetRotation);

				if (character.IsPlayer)
					characterEntity.isPlayer = true;
			}
		}

	}
}