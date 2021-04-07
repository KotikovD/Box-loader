using Entitas;

namespace BoxLoader
{
	public class InitializeObjectsViewServiceSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private MainOptions _mainOptions;

		public InitializeObjectsViewServiceSystem(Contexts context, MainOptions mainOptions)
		{
			_mainOptions = mainOptions;
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetViewObjectsService(new ViewObjectsService(new PrefabLoader(_mainOptions.PathKeeper),
				_mainOptions.SceneGameObjectsHierarchy));
		}
	}
}