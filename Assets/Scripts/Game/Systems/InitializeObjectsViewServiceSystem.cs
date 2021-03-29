using Entitas;

namespace BoxLoader
{
	public class InitializeObjectsViewServiceSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public InitializeObjectsViewServiceSystem(Contexts context)
		{
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetViewObjectsService(new ViewObjectsService(new PrefabLoader()));
		}
	}
}