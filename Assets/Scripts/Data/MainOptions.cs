namespace BoxLoader
{
	public sealed class MainOptions
	{
		public IPathKeeperData PathKeeper { get; }
		public ISceneGameObjectsHierarchy SceneGameObjectsHierarchy { get; }
		public OrdersData OrdersData { get; }

		public MainOptions(ISceneGameObjectsHierarchy sceneGameObjectsHierarchy, IPathKeeperData pathKeeper, OrdersData ordersData)
		{
			PathKeeper = pathKeeper;
			SceneGameObjectsHierarchy = sceneGameObjectsHierarchy;
			OrdersData = ordersData;
		}
	}


}