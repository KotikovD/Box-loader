using UnityEngine;

namespace BoxLoader
{
	public abstract class LampBehaviour
	{
		public abstract void Activate(Light _light);
		public abstract void Deactivate(Light _light);
		
	}
}