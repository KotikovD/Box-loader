using BoxLoader;
using UnityEngine;


[CreateAssetMenu(menuName = "GameData/PlayerData")]
public sealed class PlayerData : ScriptableObjectExt
{
	[Header("View")]
	[SerializeField] private string _assetName;
	[SerializeField] private Vector3 _startPosition;
	[SerializeField] private Vector3 _startRotation;
	[SerializeField] private SceneTagNames _sceneTagName;
	[Header("Player")]
	[SerializeField] private float _speed;
	
	public override Vector3 GetPosition => _startPosition;
	public override Quaternion GetRotation => Quaternion.Euler(_startRotation);
	public override string AssetName => _assetName;
	public override SceneTagNames SceneTagName => _sceneTagName;
	public float Speed => _speed;

}