using DG.Tweening;
using UnityEngine;

namespace BoxLoader
{
	public class LampYellowShineBehaviour : LampBehaviour
	{
		private Tween _tween;
		private Vector4 YELLOW_COLOR_ON = new Vector4(1f, 0.92f, 0.016f, 1f);
		private Vector4 COLOR_OFF = Color.black;
		private const float DURATION = 0.5f;
		
		public override void Activate(Light _light)
		{
			_light.enabled = true;
			_light.color = COLOR_OFF;
			_tween = _light.DOColor(YELLOW_COLOR_ON, DURATION).SetEase(Ease.Linear);
		}

		public override void Deactivate(Light _light)
		{
			_tween = _light.DOColor(COLOR_OFF, DURATION).SetEase(Ease.Linear);
			_light.enabled = false;
		}
		
	
	}
}