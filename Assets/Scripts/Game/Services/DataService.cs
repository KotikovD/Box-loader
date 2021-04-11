using System.Collections.Generic;

namespace BoxLoader
{
	public class DataService : IDataService
	{
		public CameraData CameraData { get; }
		public List<CharacterData> CharacterData { get; }
		public List<ConveyorData> ConveyorData { get; }
		public List<SomeObjectData> SomeObjectsData { get; }
		
		public DataService(IDataLoader loader, IPathKeeperData path)
		{
			CameraData = loader.GetData<CameraData>(path.Camera);
			CharacterData = loader.GetAllDataByType<CharacterData>();
			ConveyorData = loader.GetAllDataByType<ConveyorData>();
			SomeObjectsData = loader.GetAllDataByType<SomeObjectData>();
		}

	}
}