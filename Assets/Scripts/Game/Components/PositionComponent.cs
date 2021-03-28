using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BoxLoader
{
	[Game]
	[Event(EventTarget.Self)]
	public sealed class PositionComponent : IComponent
	{
		public Vector3 value;
	}
}

