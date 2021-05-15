using System.Collections.Generic;


namespace BoxLoader
{
	public class DataService : IDataService
	{
		public CameraData CameraData { get; }
		public OrderConveyorUiData OrderConveyorUiData { get; }
		public List<CharacterData> CharactersData { get; }
		public List<ConveyorData> ConveyorsData { get; }
		public List<BoxData> BoxesData { get; }
		public List<SomeObjectData> SomeObjectsData { get; }
		public List<GameUiData> GameUiData { get; }
		public LocalizationData Localization { get; }
		public ConstantsData Constants { get; }
		
		
		public DataService(IDataLoader loader, IPathKeeperData path)
		{
			CameraData = loader.GetData<CameraData>(path.Camera);
			OrderConveyorUiData = loader.GetData<OrderConveyorUiData>(path.OrderConveyorUi);
			Localization = loader.GetData<LocalizationData>(path.LocalizationData);
			Constants = loader.GetData<ConstantsData>(path.ConstantsData);
			CharactersData = loader.GetAllDataByType<CharacterData>();
			ConveyorsData = loader.GetAllDataByType<ConveyorData>();
			SomeObjectsData = loader.GetAllDataByType<SomeObjectData>();
			BoxesData = loader.GetAllDataByType<BoxData>();
			GameUiData = loader.GetAllDataByType<GameUiData>();
			
		}

	}
}