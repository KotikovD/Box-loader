using System.Collections.Generic;
using Entitas;


namespace BoxLoader
{
	[Game]
	public sealed class OrderComponent : IComponent
	{
		public List<BoxesOrder> value;
		public int duration;
		public float startTime;
	}
}