namespace BoxLoader
{
	public interface IPathKeeperData
	{
		string DataFolder { get; }
		string PrefabsFolder { get; }
		string Camera { get; }
		string OrderConveyorUi { get; }
		string LocalizationData { get; }
		string ConstantsData { get; }
		string Character { get; }
	}
}