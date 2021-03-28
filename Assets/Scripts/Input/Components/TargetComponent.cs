using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BoxLoader
{
	[Input]
	[Event(EventTarget.Self)]
	public sealed class TargetComponent : IComponent
	{
		public Vector3 value;
	}
}