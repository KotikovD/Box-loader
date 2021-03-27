using Entitas;

namespace BoxLoader
{
	public class InitializeCharacterViewSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public InitializeCharacterViewSystem(Contexts context)
		{
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetViewCharacterService(new ViewCharacterService(new PrefabLoader()));
		}
	}
}