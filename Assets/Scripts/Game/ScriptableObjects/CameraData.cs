using UnityEngine;


[CreateAssetMenu(menuName = @"GameData/CameraData")]
public sealed class CameraData : ScriptableObjectExt
{
	[Header("View")]
	[SerializeField] private string _assetName;
	[SerializeField] private Vector3 _offsetByPlayer;
	[SerializeField] private Vector3 _startRotation;
	[Header("Camera")]
	[SerializeField] private float _lerpSpeed;
	
	public float LerpSpeed => _lerpSpeed;
	public override Vector3 GetPosition => _offsetByPlayer;
	public override Quaternion GetRotation => Quaternion.Euler(_startRotation);
	public override string AssetName => _assetName;
}