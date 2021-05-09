using BoxLoader;
using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/SomeObjectData")]
public sealed class SomeObjectData : ScriptableObjectExt
{
	[Header("View")]
	[SerializeField] private string _assetName;
	[SerializeField] private Vector3 _position;
	[SerializeField] private Vector3 _rotation;
	[SerializeField] private SceneParentName sceneParentName;

	public override Vector3 GetPosition => _position;
	public override Quaternion GetLocalRotation => Quaternion.Euler(_rotation);
	public override string AssetName => _assetName;
	public override SceneParentName SceneParentName => sceneParentName;
}