using System;
using System.Collections.Generic;
using UnityEngine;


namespace BoxLoader
{
	[CreateAssetMenu(menuName = "MainOptions/SceneParentsNamesKeeper")]
	public sealed class SceneParentsNamesData : ScriptableObject, ISceneParentsNamesData
	{
		[SerializeField] private List<NameData> _names;
		private readonly Dictionary<SceneTagNames, string> _parents = new Dictionary<SceneTagNames, string>();

		public Dictionary<SceneTagNames, string> Parents
		{
			get
			{
				foreach (var nameData in _names)
				{
					if (_parents.ContainsKey(nameData._tag))
						throw new Exception("The name "+ nameData._tag + " tag is duplicate");
				
					if (String.IsNullOrEmpty(nameData._name))
						throw new Exception("Need to fill string name for name tag " + nameData._tag);
					
					_parents.Add(nameData._tag, nameData._name);
				}

				return _parents;
			}
		}
		
		[Serializable]
		private sealed class NameData
		{
			[SerializeField] internal SceneTagNames _tag;
			[SerializeField] internal string _name;
		}
		
	}
}