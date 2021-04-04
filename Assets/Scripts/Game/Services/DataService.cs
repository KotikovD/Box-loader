using System.Collections.Generic;

namespace BoxLoader
{
	public class DataService : IDataService
	{
		public CameraData CameraData { get; }
		public PlayerData PlayerData { get; }
		public List<ConveyorData> ConveyorData { get; }

		public DataService(IDataLoader loader, IPathKeeperData path)
		{
			CameraData = loader.GetData<CameraData>(path.Camera);
			PlayerData = loader.GetData<PlayerData>(path.Player);
			ConveyorData = loader.GetAllDataByType<ConveyorData>();
		}

	}
}