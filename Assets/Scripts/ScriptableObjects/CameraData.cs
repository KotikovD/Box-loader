using BoxLoader;
using UnityEngine;


[CreateAssetMenu(menuName = @"GameData/CameraData")]
public sealed class CameraData : ScriptableObjectExt
{
	[Header("View")]
	[SerializeField] private string _assetName;
	[SerializeField] private Vector3 _offsetByPlayer;
	[SerializeField] private Vector3 _startRotation;
	[SerializeField] private SceneParentName sceneParentName;
	[Header("Camera")]
	[SerializeField] private float _lerpSpeed;
	
	public float LerpSpeed => _lerpSpeed;
	public override Vector3 GetLocalPosition => _offsetByPlayer;
	public override Quaternion GetLocalRotation => Quaternion.Euler(_startRotation);
	public override string AssetName => _assetName;
	public override SceneParentName SceneParentName => sceneParentName;
}