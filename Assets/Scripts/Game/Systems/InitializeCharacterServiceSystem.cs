using Entitas;

namespace BoxLoader
{
	public class InitializeCharacterServiceSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private IPathKeeperData _pathData;

		public InitializeCharacterServiceSystem(Contexts context, IPathKeeperData pathData)
		{
			_pathData = pathData;
			_context = context.game;
		}

		public void Initialize()
		{
			_context.SetCharacterService(new CharacterService(new PrefabLoader(_pathData)));
		}
	}
}