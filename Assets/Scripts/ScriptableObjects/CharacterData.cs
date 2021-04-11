using BoxLoader;
using UnityEngine;


[CreateAssetMenu(menuName = "GameData/CharacterData")]
public sealed class CharacterData : ScriptableObjectExt
{
	[Header("View")]
	[SerializeField] private string _assetName;
	[SerializeField] private Vector3 _startPosition;
	[SerializeField] private Vector3 _startRotation;
	[SerializeField] private SceneTagNames _sceneTagName;
	[Header("Character")]
	[SerializeField] private bool _isPlayer;
	[SerializeField] private float _runSpeed = 3f;
	[SerializeField]private float _walkSpeed = 1.5f;
	[SerializeField]private float _minPathLengthForRun = 4f;
	[SerializeField]private float _stoppingTime = 0.4f;
	
	public override Vector3 GetPosition => _startPosition;
	public override Quaternion GetRotation => Quaternion.Euler(_startRotation);
	public override string AssetName => _assetName;
	public override SceneTagNames SceneTagName => _sceneTagName;
	public bool IsPlayer => _isPlayer;
	public float StoppingTime => _stoppingTime;
	public float RunSpeed => _runSpeed;
	public float WalkSpeed => _walkSpeed;
	public float MinPathLengthForRun => _minPathLengthForRun;
}
