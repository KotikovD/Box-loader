using BoxLoader;
using UnityEngine;

[CreateAssetMenu(menuName = @"GameData/ConstantsData")]
public sealed class ConstantsData : ScriptableObject
{
	[Header("Constants")]
	[SerializeField] private float _animationDropBoxEvent = 0.15f;
	[SerializeField] private float _animationPickupBoxEvent = 0.25f;
	[SerializeField] private float _minDistanceBetweenBoxes = 2.3f;

	

	[SerializeField] private float _dropBoxFallSpeed = 0.7f;
	[SerializeField] private float _boxStopDistanceConst = 0.1f;
	[SerializeField] private float _standbyTimeBetweenOrders = 5f;
	[SerializeField] private float _maxDistanceForSearchUsedObjects = 1.5f;
	[SerializeField] private float _boxesUsingOffset = 0.3f;
	[SerializeField] private float _charactersLookAtDuration = 0.3f;
	[SerializeField] private float _conveyorStopDuration = 0.5f;
	
	
	public float AnimationDropBoxEvent => _animationDropBoxEvent;
	public float AnimationPickupBoxEvent => _animationPickupBoxEvent;
	public float MnDistanceBetweenBoxes => _minDistanceBetweenBoxes;
	public float BoxStopDistanceConst => _boxStopDistanceConst;
	public float StandbyTimeBetweenOrders => _standbyTimeBetweenOrders;
	public float DropBoxFallSpeed => _dropBoxFallSpeed;
	public float MaxDistanceForSearchUsedObjects => _maxDistanceForSearchUsedObjects;
	public float BoxesUsingOffset => _boxesUsingOffset;
	public float CharactersLookAtDuration => _charactersLookAtDuration;
	public float ConveyorStopDuration => _conveyorStopDuration;
}