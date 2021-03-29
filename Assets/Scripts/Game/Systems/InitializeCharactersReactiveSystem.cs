using System.Collections.Generic;
using System.Linq;
using Entitas;

namespace BoxLoader
{
	public class InitializeCharactersReactiveSystem : ReactiveSystem<GameEntity>, ITearDownSystem
	{
		private readonly GameContext _context;

		public InitializeCharactersReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ObjectsView.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				_context.characterService.value.DestroyCharacter(entity);
				_context.characterService.value.InitializeCharacter(_context, entity);
			}
		}

		public void TearDown()
		{
			foreach (var entity in _context.GetEntities().Where(a => a.hasCharacter))
				_context.characterService.value.DestroyCharacter(entity);
		}

	}
}