using Entitas.CodeGeneration.Attributes;

namespace BoxLoader
{
	[Game, Unique, ComponentName("CharacterService")]
	public interface ICharacterService
	{
		void InitializeCharacter(GameContext context, GameEntity entity);
		void DestroyCharacter(GameEntity entity);
	}
}