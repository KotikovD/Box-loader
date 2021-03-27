namespace BoxLoader
{
	public class GameController : MonoBehaviourExt
	{
		private GameSystems _gameSystems;
		private Contexts _contexts;

		void Start()
		{
			_contexts = new Contexts();

			_gameSystems = new GameSystems(_contexts);
			_gameSystems.Initialize();
		}

		private void Update()
		{
			_gameSystems.Execute();
		}
	}
}