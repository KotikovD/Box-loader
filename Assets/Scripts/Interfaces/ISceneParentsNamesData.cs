using System.Collections.Generic;

namespace BoxLoader
{
	public interface ISceneParentsNamesData
	{
		Dictionary<SceneTagNames, string> Parents { get; }
	}
}