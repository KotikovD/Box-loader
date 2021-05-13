using UnityEngine;

[CreateAssetMenu(menuName = "MainOptions/OrdersData", fileName = "OrdersData")]
public sealed class OrdersData : ScriptableObject
{
	
	[SerializeField, Tooltip("Sec, time for complete an order for one box. Total time order = baseTimePerOneBox * startCountBoxesInOrder")] 
	private float _baseTimePerOneBox = 5f;
	
	[SerializeField] 
	private int _startCountBoxesInOrder = 3;
	
	[SerializeField, Tooltip("Use for rise count of boxes by gotten scores.")]
	private float _multiplyingCoefficient = 0.33f;
	
	[SerializeField, Tooltip("Total count of boxes can't exceed this value")]
	private int _maxCountBoxesInOrder = 10;
	
	[SerializeField, Tooltip("Raises count of boxes every this step score")]
	private int _raiseScoreStep = 50;

	
	public float BaseTimePerOneBox => _baseTimePerOneBox;

	public int StartCountBoxesInOrder => _startCountBoxesInOrder;

	public float MultiplyingCoefficient => _multiplyingCoefficient;

	public int MaxCountBoxesInOrder => _maxCountBoxesInOrder;

	public int RaiseScoreStep => _raiseScoreStep;
}