using UnityEngine;


namespace BoxLoader
{
	public class CharacterService : ICharacterService
	{
		private readonly IPrefabLoader _prefabLoader;
		public CharacterService(PrefabLoader prefabLoader)
		{
			_prefabLoader = prefabLoader;
		}

		public void InitializeCharacter(GameContext context, GameEntity entity)
		{
			var characterComponent = entity.objectsView.Value.GameObject.GetComponent<Character>();
			if (characterComponent == null)
				entity.objectsView.Value.GameObject.AddComponent<Character>();

			characterComponent.InitializeView(entity);
		}

		public void DestroyCharacter(GameEntity entity)
		{
			 if (!entity.hasCharacter) return;
	
			 entity.character.Value.DestroyCharacterComponent();
			 entity.RemoveCharacter();
		}
		
	}
}