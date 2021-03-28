using UnityEngine;

namespace BoxLoader
{
	public class SceneService : ISceneService
	{
		public Camera Camera { get; }
		
		public SceneService()
		{
			Camera = Object.FindObjectOfType<Camera>();
		}
		
	}
}