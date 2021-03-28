using Entitas;
using UnityEngine;

namespace BoxLoader
{
	[Input]
	public sealed class TargetComponent : IComponent
	{
		public Vector3 value;
	}
}