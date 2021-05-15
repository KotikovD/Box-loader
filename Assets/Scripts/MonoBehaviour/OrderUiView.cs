using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace BoxLoader
{
	[RequireComponent(typeof(ObjectsView))]
	public sealed class OrderUiView : MonoBehaviourExt, IOrderUiView
	{
		private const int STROKE_HEIGHT = 30;
		
		private readonly List<GameObject> _strokes = new List<GameObject>();
		private readonly List<OrderStrokeUiView> _currentTasks = new List<OrderStrokeUiView>();
		
		[SerializeField] private TimerUiView _timerUiView;
		[SerializeField] private RectTransform _orderListRect;
		[SerializeField] private VerticalLayoutGroup _layoutGroup;
		
		private Sequence _timerTween;
		private int _currentListHeight;
		private OrderStrokeUiView _strokePrefab;
		private float _alarmTime;
		private Color _alarmColor;
		private Color _defaultStrokeColor;
		private string _noOrderLocalization;
		private bool _isInited;
		private Color _completeStrokeColor;
		private Color _defaultTimerColor;

		
		public void Initialize(OrderStrokeUiView strokePrefab, 
			Color defaultStrokeColor, 
			Color completeStrokeColor, 
			float alarmTime, 
			Color defaultTimerColor, 
			Color alarmTimerColor, 
			string noOrderLocalization)
		{
			_defaultTimerColor = defaultTimerColor;
			_completeStrokeColor = completeStrokeColor;
			_noOrderLocalization = noOrderLocalization;
			_defaultStrokeColor = defaultStrokeColor;
			_alarmColor = alarmTimerColor;
			_alarmTime = alarmTime;
			_strokePrefab = strokePrefab;
			_isInited = true;

			CreateMockStroke();
			
		}

		public void UpdateAnchors(Vector2 newPosition)
		{
			if(!_isInited)
				return;
			
			_orderListRect.SetHeight(_currentListHeight);
			_orderListRect.anchoredPosition = newPosition;
			
			var newTimerPosition = new Vector2(newPosition.x, newPosition.y + _currentListHeight);
			_timerUiView.SetPosition(newTimerPosition);
		}

		public void CreateOrderUi(List<BoxesOrder> boxes, float orderTimer)
		{
			RemoveCurrentOrder();
			
			foreach (var box in boxes)
			{
				var newStroke = Instantiate(_strokePrefab, _orderListRect);
				newStroke.name = box.BoxLocalization;
				newStroke.Label = box.BoxLocalization;
				newStroke.StrokeColor = _defaultStrokeColor;
				_strokes.Add(newStroke.gameObject);
				_currentTasks.Add(newStroke);
			}

			CalculateListHeight(boxes.Count); 
			SetOrderListHeight();
			SetTimer(orderTimer);
		}

		public void SetNextComplete()
		{
			if (_currentTasks.Count == 0)
				return;
			
			var first = _currentTasks.First();
			first.StrokeColor = _completeStrokeColor;
			_currentTasks.Remove(first);
		}

		public void RemoveCurrentOrder(bool isNeedCreateMock = false)
		{
			foreach (var stroke in _strokes)
				DestroyImmediate(stroke);

			_strokes.Clear();
			_currentTasks.Clear();
			ResetTimer();

			if (isNeedCreateMock)
				CreateMockStroke();
		}

		private void CreateMockStroke()
		{
			var newStroke = Instantiate(_strokePrefab, _orderListRect);
			newStroke.name = "NoOrderMock";
			newStroke.Label = _noOrderLocalization;
			newStroke.StrokeColor = _defaultStrokeColor;
			_strokes.Add(newStroke.gameObject);
			CalculateListHeight(_strokes.Count);
		}

		private void CalculateListHeight(int itemsCount)
		{
			_currentListHeight = (STROKE_HEIGHT + (int) _layoutGroup.spacing) * itemsCount;
		}

		private void ResetTimer()
		{
			_timerTween?.Kill();
			_timerUiView.ResetTimer(_defaultTimerColor);
		}
		
		private void SetTimer(float orderTimer)
		{
			_timerTween?.Kill();
			var sequence = DOTween.Sequence();
			sequence.Append(DOTween.To(() => 1f, x => _timerUiView.SetFillAmountTimer(x, _alarmTime, _alarmColor), 0f, orderTimer).SetEase(Ease.Linear))
				.OnComplete(() => _timerUiView.ResetTimer(_defaultTimerColor));
			_timerTween = sequence;
		}
		
		private void SetOrderListHeight()
		{
			var rect = _orderListRect.rect;
			_orderListRect.rect.Set(rect.x, rect.y, rect.width, _currentListHeight);
		}
		
	}
}