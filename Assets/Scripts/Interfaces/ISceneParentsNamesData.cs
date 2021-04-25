using System.Collections.Generic;

namespace BoxLoader
{
	public interface ISceneParentsNamesData
	{
		Dictionary<SceneParentName, string> Parents { get; }
	}
}