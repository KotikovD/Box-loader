using UnityEngine;

namespace BoxLoader
{
	public class GameController : MonoBehaviourExt
	{
		[SerializeField] private SceneParentsNamesData _sceneParentsNamesData;
		[SerializeField] private PathKeeperData _pathKeeper;
		
		private GameSystems _gameSystems;
		private Contexts _contexts;
		private MainOptions _mainOptions;
		
		void Start()
		{
			_contexts = new Contexts();
			_mainOptions = new MainOptions(
				new SceneParentsNamesKeeper(_sceneParentsNamesData),
				_pathKeeper
			);
			
			_gameSystems = new GameSystems(_contexts, _mainOptions);
			_gameSystems.Initialize();
		}

		private void Update()
		{
			_gameSystems.Execute();
		}
	}
}