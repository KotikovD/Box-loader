using UnityEngine;

namespace BoxLoader
{
	public class DataService : IDataService
	{
		public Camera Camera { get; }
		public Player Player { get; }

		public DataService(IDataLoader loader)
		{
			Camera = loader.GetData<Camera>(PathKeeper.Camera);
			Player = loader.GetData<Player>(PathKeeper.Player);
		}

	}
}