using BoxLoader;
using NaughtyAttributes;
using UnityEngine;


[CreateAssetMenu(menuName = "GameData/ConveyorData")]
public sealed class ConveyorData : ScriptableObjectExt
{
	[Header("View")]
	[SerializeField] private string _assetName = "ConveyorView";
	[SerializeField] private Vector3 _startPosition;
	[SerializeField] private Vector3 _startRotation;
	[SerializeField] private SceneParentName sceneParentName;
	[Header("ConveyorView")]
	[SerializeField] private ConveyorMode _conveyorMode = ConveyorMode.Receiver;
	[SerializeField, Range(0,5)] private float _workingSpeed = 3f;
	[SerializeField, Range(0,10)] private float _spaceBetweenBoxes = 3f;

	public override Vector3 GetPosition => _startPosition;
	public override Quaternion GetLocalRotation => Quaternion.Euler(_startRotation);
	public override string AssetName => _assetName;
	public override SceneParentName SceneParentName => sceneParentName;
	public ConveyorMode ConveyorMode => _conveyorMode;
	public float WorkingSpeed => _workingSpeed;
	public float SpaceBetweenBoxes => _spaceBetweenBoxes;
}