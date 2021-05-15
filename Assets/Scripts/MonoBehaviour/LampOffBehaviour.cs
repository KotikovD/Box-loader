using UnityEngine;

namespace BoxLoader
{
	public class LampOffBehaviour : LampBehaviour
	{
		public override void Activate(Light _light)
		{
			_light.enabled = false;
		}

		public override void Deactivate(Light _light)
		{
			_light.enabled = true;
		}
	}
}