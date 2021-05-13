using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static System.String;

namespace BoxLoader
{
	public sealed class SceneGameObjectsHierarchy : ISceneGameObjectsHierarchy
	{
		private readonly Dictionary<SceneParentName, Transform> _parents;

		public SceneGameObjectsHierarchy(ISceneParentsNamesData sceneParentsNamesData)
		{
			_parents = new Dictionary<SceneParentName, Transform>();


			foreach (var parent in sceneParentsNamesData.Parents)
			{
				var names = parent.Value.Split('/').ToList();
				CreateHierarchy(names, parent.Key);
			}
		}
		
		private void CreateHierarchy(List<string> names, SceneParentName tag, Transform parent = null)
		{
			var name = names.First();
			if(IsNullOrEmpty(name))
			{
				_parents.Add(tag, null);
				return;
			}

			Transform foundChild;
			var haveParent = parent != null;
			if (haveParent)
			{
				foundChild = parent.Find(name);
			} 
			else
			{
				var go = GameObject.Find(name);
				foundChild = go ? go.transform : null;
			}

			if (!foundChild)
			{
				var newGo = new GameObject(name);
				var transform = newGo.transform;
				if (haveParent)
				{
					transform.SetParent(parent);
				}
				
				if (names.Count > 1)
				{
					names.Remove(name);
					CreateHierarchy(names, tag, transform);
				}
				else
				{
					_parents.Add(tag, transform);
				}
			}
			else
			{
				if (names.Count > 1)
				{
					names.Remove(name);
					CreateHierarchy(names, tag, foundChild);
				}
				else
				{
					var transform = foundChild;
					foundChild.SetParent(transform);
					_parents.Add(tag, transform);
				}
			}
		}

		public Transform GetParent(SceneParentName nameTag)
		{
			if (_parents.ContainsKey(nameTag))
				return _parents[nameTag];
			else
				throw new Exception("SceneParentsNamesData dose not have a name tag = " + nameTag);
		}
	}
}