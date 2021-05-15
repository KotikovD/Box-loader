namespace BoxLoader
{
	public interface IPathKeeperData
	{
		string DataFolder { get; }
		string PrefabsFolder { get; }
		string Camera { get; }
		string OrderConveyorUi { get; }
		string Character { get; }
	}
}