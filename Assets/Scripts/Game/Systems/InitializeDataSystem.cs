using Entitas;

namespace BoxLoader
{
	public class InitializeDataSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public InitializeDataSystem(Contexts context)
		{
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetDataService(new DataService(new DataLoader()));
		}
	}
}