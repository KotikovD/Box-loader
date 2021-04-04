using Entitas;

namespace BoxLoader
{
	public class InitializeSceneServiceServiceSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private ISceneParentsNamesKeeper _sceneService;

		public InitializeSceneServiceServiceSystem(Contexts context, ISceneParentsNamesKeeper sceneService)
		{
			_sceneService = sceneService;
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetSceneService(new SceneService(_sceneService));
		}
	}
}