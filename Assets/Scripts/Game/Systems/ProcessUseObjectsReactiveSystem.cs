using System.Collections.Generic;
using System.Linq;
using Entitas;
	

namespace BoxLoader
{
	public class InitializeProcessUseObjectsReactiveSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext _context;
		private GameEntity _playerEntity;
		
		public InitializeProcessUseObjectsReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			_playerEntity = _context.playerEntity;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.WantToUse.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasObjectsView && entity.isReadyForUse;
		}
		protected override void Execute(List<GameEntity> entities)
		{
			var entity = entities.Last();
			
			_playerEntity.character.Value.Pickup(0.25f) //TODO move to const
				.Then(() =>
				{
					entity.isWantToUse = false;
					entity.isReadyForUse = false;
					entity.objectsView.Value.SetParent(_playerEntity.character.Value.CarryPoint);
					entity.isUsing = true;
				});
		}
		
	
	
	}
}