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
			var enties = _context.game.GetEntities(GameMatcher.ObjectsView);
			foreach (var e in enties)
			{
				e.ReplacePosition(e.objectsView.Value.GetPosition);
				e.ReplaceRotation(e.objectsView.Value.GetLocalRotation);
			}
		}
		
	}
}