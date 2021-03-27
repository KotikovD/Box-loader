using Entitas.CodeGeneration.Attributes;

namespace BoxLoader
{
	[Game, Unique, ComponentName("ViewCharacterService")]
	public interface IViewCharacterService
	{
		void CreateView(GameContext context, GameEntity entity);
		void DestroyView(GameEntity entity);
		void SetParent(GameEntity entity);
		void SetPosition(GameEntity entity);
	}
}