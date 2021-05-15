using Entitas;
using UnityEngine;


namespace BoxLoader
{
	[Game]
	public sealed class StandByTimerComponent : IComponent
	{
		public float startTime;
		public float duration;
	}
}