using BoxLoader;
using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/SomeObjectData")]
public sealed class SomeObjectData : ScriptableObjectExt
{
	[Header("View")]
	[SerializeField] private string _assetName;
	[SerializeField] private Vector3 _position;
	[SerializeField] private Vector3 _rotation;
	[SerializeField] private SceneTagNames _sceneTagName;

	public override Vector3 GetPosition => _position;
	public override Quaternion GetRotation => Quaternion.Euler(_rotation);
	public override string AssetName => _assetName;
	public override SceneTagNames SceneTagName => _sceneTagName;
}