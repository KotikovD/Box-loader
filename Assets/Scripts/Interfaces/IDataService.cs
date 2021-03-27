using Entitas.CodeGeneration.Attributes;


[Game, Unique, ComponentName("DataService")]
public interface IDataService
{
	Camera Camera { get; }
	public Player Player { get; }
}