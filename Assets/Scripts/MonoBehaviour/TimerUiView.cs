using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace BoxLoader
{
	public sealed class TimerUiView : MonoBehaviourExt
	{
		private const float COLOR_CHANGE_DURATION = 1.5f;
		private const float TIMER_Y_SPACE = 3f;
		
		[SerializeField] private RectTransform _transform;
		[SerializeField] private Image _image;
		private bool _isSetAlarmColor;
		private Sequence _tween;


		public void SetPosition(Vector2 newPosition)
		{
			var yOffsetPosition = new Vector2(newPosition.x, newPosition.y + TIMER_Y_SPACE + _transform.rect.height / 2);
			_transform.anchoredPosition = yOffsetPosition;
		}

		public void ResetTimer(Color defaultColor)
		{
			_tween?.Kill();
			_isSetAlarmColor = false;
			_image.fillAmount = 0;
			_image.color = defaultColor;
		}
		
		public void SetFillAmountTimer(float value, float alarmTime, Color alarmColor)
		{
			_image.fillAmount = value;
			
			if(value < alarmTime && !_isSetAlarmColor)
			{
				_isSetAlarmColor = true;
				
				_tween?.Kill();
				_tween = DOTween.Sequence();
				_tween.Append(_image.DOColor(alarmColor, COLOR_CHANGE_DURATION));
			}
		}
		
	}
}