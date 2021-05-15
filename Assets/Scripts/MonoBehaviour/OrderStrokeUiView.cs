using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace BoxLoader
{
	public sealed class OrderStrokeUiView : MonoBehaviourExt
	{
		private const float COLOR_CHANGE_DURATION = 1.5f;
		private Sequence _tween;
		
		[SerializeField] private TextMeshProUGUI _label;
		[SerializeField] private Image _image;
		
		public string Label
		{
			set => _label.text = value;
		}
		
		public Color StrokeColor
		{
			set
			{
				_tween?.Kill();
				_tween = DOTween.Sequence();
				_tween.Append(_image.DOColor(value, COLOR_CHANGE_DURATION));
			}
		}

		private void OnDestroy()
		{
			_tween?.Kill();
		}
	}
}