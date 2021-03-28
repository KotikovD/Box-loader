using Entitas;

namespace BoxLoader
{
	public class InitializeSceneSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public InitializeSceneSystem(Contexts context)
		{
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetSceneService(new SceneService());
		}
	}
}