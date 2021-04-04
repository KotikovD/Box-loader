using BoxLoader;
using UnityEngine;


[CreateAssetMenu(menuName = "GameData/ConveyorData")]
public sealed class ConveyorData : ScriptableObjectExt
{
	[Header("View")]
	[SerializeField] private string _assetName = "Conveyor";
	[SerializeField] private Vector3 _startPosition;
	[SerializeField] private Vector3 _startRotation;
	[Header("Conveyor")]
	[SerializeField] private ConveyorMode _conveyorMode = ConveyorMode.Receiver;

	public override Vector3 GetPosition => _startPosition;
	public override Quaternion GetRotation => Quaternion.Euler(_startRotation);
	public override string AssetName => _assetName;
	public ConveyorMode ConveyorMode => _conveyorMode;
}