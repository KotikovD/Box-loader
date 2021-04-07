using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;


[Game, Unique, ComponentName("DataService")]
public interface IDataService
{
	CameraData CameraData { get; }
	public PlayerData PlayerData { get; }
	List<ConveyorData> ConveyorData { get; }
	public List<SomeObjectData> SomeObjectsData { get; }
}