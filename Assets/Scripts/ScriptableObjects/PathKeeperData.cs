using UnityEngine;

namespace BoxLoader
{
	[CreateAssetMenu(menuName = "MainOptions/PathKeeperData")]
	public sealed class PathKeeperData : ScriptableObject, IPathKeeperData
	{
		[Header("FoldersNames")]
		[SerializeField] private string _dataFolder = "Data";
		[SerializeField] private string _prefabsFolder = "Prefabs";

		[Header("ScriptableObjectFilesNames")]
		[SerializeField] private string _camera = "CameraData";
		[SerializeField] private string _player = "PlayerData";
		
		public string DataFolder => _dataFolder;

		public string PrefabsFolder => _prefabsFolder;

		public string Camera => _camera;

		public string Player => _player;
	}
}