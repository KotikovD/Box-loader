using Entitas.CodeGeneration.Attributes;


[Game, Unique, ComponentName("ViewObjectsService")]
public interface IViewObjectsService
{
	void CreateView(GameContext context, GameEntity entity);
	void DestroyView(GameEntity entity);
}