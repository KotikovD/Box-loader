using System;
using System.Collections.Generic;

namespace BoxLoader
{
	public sealed class SceneParentsNamesKeeper : ISceneParentsNamesKeeper
	{
		private readonly Dictionary<SceneTagNames, string> _parents;
		
		public SceneParentsNamesKeeper(ISceneParentsNamesData sceneParentsNamesData)
		{
			_parents = sceneParentsNamesData.Parents;
		}
		
		public string GetParentName(SceneTagNames nameTag)
		{
			if (_parents.ContainsKey(nameTag))
				return _parents[nameTag];
			else
				throw new Exception("SceneParentsNamesData dose not have a name tag = " + nameTag);
		}
		
		
	}
}