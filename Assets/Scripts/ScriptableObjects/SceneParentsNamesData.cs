using System;
using System.Collections.Generic;
using UnityEngine;


namespace BoxLoader
{
	[CreateAssetMenu(menuName = "MainOptions/SceneGameObjectsHierarchy")]
	public sealed class SceneParentsNamesData : ScriptableObject, ISceneParentsNamesData
	{
		[SerializeField] private List<NameData<SceneParentName, string>> _names;
		private readonly Dictionary<SceneParentName, string> _parents = new Dictionary<SceneParentName, string>();

		public Dictionary<SceneParentName, string> Parents
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
		private sealed class NameData<T,S>
		{
			[SerializeField] internal T _tag;
			[SerializeField] internal S _name;
		}
	}
}