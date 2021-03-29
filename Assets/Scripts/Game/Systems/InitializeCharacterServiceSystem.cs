using Entitas;

namespace BoxLoader
{
	public class InitializeCharacterServiceSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public InitializeCharacterServiceSystem(Contexts context)
		{
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetCharacterService(new CharacterService(new PrefabLoader()));
		}
	}
}