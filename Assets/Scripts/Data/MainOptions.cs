namespace BoxLoader
{
	public sealed class MainOptions
	{
		public IPathKeeperData PathKeeper { get; }
		public ISceneParentsNamesKeeper SceneParentsNamesKeeper { get; }

		public MainOptions(ISceneParentsNamesKeeper sceneParentsNamesKeeper, IPathKeeperData pathKeeper)
		{
			PathKeeper = pathKeeper;
			SceneParentsNamesKeeper = sceneParentsNamesKeeper;
		}
	}


}