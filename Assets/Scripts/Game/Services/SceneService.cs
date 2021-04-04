using System.Collections.Generic;
using UnityEngine;


namespace BoxLoader
{
	public class SceneService : ISceneService
	{
		private Dictionary<SceneTagNames, GameObject> _sceneCache;
		private ISceneParentsNamesKeeper _sceneParentsNamesKeeper;

		public SceneService(ISceneParentsNamesKeeper sceneParentsNamesKeeper)
		{
			_sceneParentsNamesKeeper = sceneParentsNamesKeeper;
			_sceneCache = new Dictionary<SceneTagNames, GameObject>();
		}
		
		
		public GameObject GetMainParentGameObject(SceneTagNames tagNames)
		{
			if (_sceneCache.ContainsKey(tagNames))
				return _sceneCache[tagNames];
			
			var name = _sceneParentsNamesKeeper.GetParentName(tagNames);
			var newParent = new GameObject(name);
			_sceneCache.Add(tagNames, newParent);

			return _sceneCache[tagNames];
		}
	}
}