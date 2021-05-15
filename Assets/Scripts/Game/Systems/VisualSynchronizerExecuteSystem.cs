using Entitas;


namespace BoxLoader
{
	public class VisualSynchronizerExecuteSystem : IExecuteSystem
	{
		private readonly Contexts _context;

		public VisualSynchronizerExecuteSystem(Contexts context)
		{
			_context = context;
		}
		
		public void Execute()
		{
			var entitiesGroup = _context.game.GetEntities(GameMatcher.AllOf(GameMatcher.ObjectsView, GameMatcher.Position, GameMatcher.Rotation));
			foreach (var e in entitiesGroup)
			{
				e.ReplacePosition(e.objectsView.Value.GetPosition);
				e.ReplaceRotation(e.objectsView.Value.GetLocalRotation);
			}
			
			
		}
		
	}
}