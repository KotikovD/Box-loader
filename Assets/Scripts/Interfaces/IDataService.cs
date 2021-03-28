using Entitas.CodeGeneration.Attributes;


[Game, Unique, ComponentName("DataService")]
public interface IDataService
{
	CameraData CameraData { get; }
	public PlayerData PlayerData { get; }
}