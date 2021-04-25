using System.Collections.Generic;
using Entitas;

namespace BoxLoader
{
	[Game]
	public sealed class BoxesComponent : IComponent
	{
		public List<GameEntity> value;
	}
}