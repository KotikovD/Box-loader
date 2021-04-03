namespace BoxLoader
{
	public class DataService : IDataService
	{
		public CameraData CameraData { get; }
		public PlayerData PlayerData { get; }

		public DataService(IDataLoader loader)
		{
			CameraData = loader.GetData<CameraData>(PathKeeper.Camera);
			PlayerData = loader.GetData<PlayerData>(PathKeeper.Player);
		}

	}
}