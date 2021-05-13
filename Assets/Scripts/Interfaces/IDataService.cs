using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;


[Game, Unique, ComponentName("DataService")]
public interface IDataService
{
	CameraData CameraData { get; }
	List<CharacterData> CharactersData { get; }
	List<ConveyorData> ConveyorsData { get; }
	public List<SomeObjectData> SomeObjectsData { get; }
	public List<BoxData> BoxesData { get; }
	List<GameUiData> GameUiData { get; }
}