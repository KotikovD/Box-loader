﻿using System;
using System.Collections.Generic;
using UnityEngine;


namespace BoxLoader
{
	[CreateAssetMenu(menuName = "MainOptions/SceneGameObjectsHierarchy")]
	public sealed class SceneParentsNamesData : ScriptableObject, ISceneParentsNamesData
	{
		[SerializeField] private List<NameData> _names;
		private readonly Dictionary<SceneParentName, string> _parents = new Dictionary<SceneParentName, string>();

		public Dictionary<SceneParentName, string> Parents
		{
			//TODO move to generic utils
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
			[SerializeField] internal SceneParentName _tag;
			[SerializeField] internal string _name;
		}
		
	}
}