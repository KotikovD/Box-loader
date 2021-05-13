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
			var box = entities.Last();
			var conveyorsWithBoxes = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Boxes,GameMatcher.ConveyorReceiver));
			
			foreach (var conveyor in conveyorsWithBoxes)
			{
				if (conveyor.boxes.value.Contains(box))
				{
					conveyor.boxes.value.Remove(box);
					break;
				}
			}
			
			_playerEntity.character.Value.Pickup(0.25f) //TODO move to const
				.Then(() =>
				{
					box.isWantToUse = false;
					box.isReadyForUse = false;
					box.objectsView.Value.SetParent(_playerEntity.character.Value.CarryPoint);
					box.isUsing = true;
					
				});
		}
		
	
	
	}
}