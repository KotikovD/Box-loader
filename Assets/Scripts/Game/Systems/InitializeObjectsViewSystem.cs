using Entitas;

namespace BoxLoader
{
	public class InitializeObjectsViewSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public InitializeObjectsViewSystem(Contexts context)
		{
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetViewObjectsService(new ViewObjectsService(new PrefabLoader()));
		}
	}
}