using BoxLoader;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/OrderConveyorUiData", fileName = "OrderConveyorUiData")]
public sealed class OrderConveyorUiData : ScriptableObjectExt
{
	[Header("View")] 
	
	[ReadOnly] [SerializeField]
	private SceneParentName _sceneParentName = SceneParentName.Ui;

	[Header("OrderConveyorUi")]
	[SerializeField] private string _orderConveyorUiData = "OrderConveyorUiData";
	[SerializeField, Tooltip("Localization key for box name")] private string _noOrderLocalizationKey = "#no_order_localization_key";
	[SerializeField, Range(0,1)] private float _alarmTime = 0.1f;
	[SerializeField] private Color _defaultTimerColor;
	[SerializeField] private Color _alarmTimerColor;
	
	
	[Header("OrderStrokeUiView")]
	[SerializeField, Tooltip("Prefab for order strokes")] private OrderStrokeUiView _orderStrokeUiView;
	[SerializeField] private Color _defaultStrokeColor;
	[SerializeField] private Color _completeStrokeColor;
	
	
	public override Vector3 GetPosition => Vector3.zero;
	public override Quaternion GetLocalRotation => Quaternion.identity;
	public override string AssetName => _orderConveyorUiData;
	public override SceneParentName SceneParentName => _sceneParentName;
	
	public OrderStrokeUiView OrderStrokeUiView => _orderStrokeUiView;
	public string NoOrderLocalizationKey => _noOrderLocalizationKey;
	public float AlarmTime => _alarmTime;
	public Color DefaultStrokeColor => _defaultStrokeColor;
	public Color CompleteStrokeColor => _completeStrokeColor;
	public Color AlarmTimerColor => _alarmTimerColor;
	public Color DefaultTimerColor => _defaultTimerColor;
	
}