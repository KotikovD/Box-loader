using System.Collections.Generic;

namespace BoxLoader
{
	public class DataService : IDataService
	{
		public CameraData CameraData { get; }
		public List<CharacterData> CharactersData { get; }
		public List<ConveyorData> ConveyorsData { get; }
		public List<BoxData> BoxesData { get; }
		public List<SomeObjectData> SomeObjectsData { get; }
		
		public DataService(IDataLoader loader, IPathKeeperData path)
		{
			CameraData = loader.GetData<CameraData>(path.Camera);
			CharactersData = loader.GetAllDataByType<CharacterData>();
			ConveyorsData = loader.GetAllDataByType<ConveyorData>();
			SomeObjectsData = loader.GetAllDataByType<SomeObjectData>();
			BoxesData = loader.GetAllDataByType<BoxData>();
		}

	}
}