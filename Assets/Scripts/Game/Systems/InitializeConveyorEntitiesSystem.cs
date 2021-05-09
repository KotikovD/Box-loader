using Entitas;

namespace BoxLoader
{
	public class InitializeConveyorEntitiesSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public InitializeConveyorEntitiesSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			var conveyorsData = _context.dataService.value.ConveyorsData;

			foreach (var conveyor in conveyorsData)
			{
				var conveyorEntity = _context.CreateEntity();
				conveyorEntity.AddAsset(conveyor.AssetName, conveyor.SceneParentName);
				conveyorEntity.AddPosition(conveyor.GetPosition);
				conveyorEntity.AddRotation(conveyor.GetLocalRotation);
				conveyorEntity.AddConveyorData(conveyor);
			}
	
		}

	}
}