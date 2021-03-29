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

			var e1 = _context.game.GetEntities(GameMatcher.CharacterView);
			foreach (var e in e1)
			{
				e.ReplacePosition(e.characterView.Value.GetPosition);
			}
					
			var e2 = _context.game.GetEntities(GameMatcher.ObjectsView);
			foreach (var e in e2)
			{
				e.ReplacePosition(e.objectsView.Value.GetPosition);
			}

		}


	}
}