using System;
using System.Collections.Generic;
using UnityEngine;

namespace BoxLoader
{
	[CreateAssetMenu(menuName = "GameData/LocalizationData")]
	public sealed class LocalizationData : ScriptableObject
	{
		[SerializeField] private List<NameData<string, string>> _keys;
		private Dictionary<string, string> _localization;

		private Dictionary<string, string> Localization
		{
			get
			{
				if (_localization != null)
					return _localization;

				_localization = new Dictionary<string, string>();
				foreach (var nameData in _keys)
				{
					if (_localization.ContainsKey(nameData._tag))
						throw new Exception("The name " + nameData._tag + " tag is duplicate");

					if (String.IsNullOrEmpty(nameData._name))
						throw new Exception("Need to fill string name for name tag " + nameData._tag);

					_localization.Add(nameData._tag, nameData._name);
				}

				return _localization;
				
			}
		}

		public string GetKeyValue(string key)
		{
			if(Localization.ContainsKey(key))
				return Localization[key];

			return key;
		}
		
		[Serializable]
		private sealed class NameData<T,S>
		{
			[SerializeField] internal T _tag;
			[SerializeField] internal S _name;
		}
	}
}