namespace BoxLoader
{
	public sealed class MainOptions
	{
		public IPathKeeperData PathKeeper { get; }
		public ISceneGameObjectsHierarchy SceneGameObjectsHierarchy { get; }

		public MainOptions(ISceneGameObjectsHierarchy sceneGameObjectsHierarchy, IPathKeeperData pathKeeper)
		{
			PathKeeper = pathKeeper;
			SceneGameObjectsHierarchy = sceneGameObjectsHierarchy;
		}
	}


}