using Entitas;

namespace BoxLoader
{
	public class InitializeObjectsViewServiceSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private IPathKeeperData _pathData;

		public InitializeObjectsViewServiceSystem(Contexts context, IPathKeeperData pathData)
		{
			_pathData = pathData;
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetViewObjectsService(new ViewObjectsService(new PrefabLoader(_pathData)));
		}
	}
}