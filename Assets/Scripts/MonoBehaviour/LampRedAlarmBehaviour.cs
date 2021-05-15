using DG.Tweening;
using UnityEngine;

namespace BoxLoader
{
	public class LampRedAlarmBehaviour : LampBehaviour
	{
		private Tween _tween;
		private Vector4 RED_COLOR_ON = Color.red;
		private Vector4 RED_COLOR_OFF = Color.black;
		private const float DURATION = 0.5f;
		
		public override void Activate(Light _light)
		{
			_light.enabled = true;
			_light.color = RED_COLOR_ON;
			_tween = _light.DOColor(RED_COLOR_OFF, DURATION).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
		}

		public override void Deactivate(Light _light)
		{
			_tween.Kill();
			_light.enabled = false;
		}
	}
}