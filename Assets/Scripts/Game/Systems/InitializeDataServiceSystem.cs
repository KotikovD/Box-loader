using Entitas;

namespace BoxLoader
{
	public class InitializeDataServiceSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private IPathKeeperData _pathData;

		public InitializeDataServiceSystem(Contexts context, IPathKeeperData pathData)
		{
			_pathData = pathData;
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetDataService(new DataService(new DataLoader(_pathData), _pathData));
		}
	}
}