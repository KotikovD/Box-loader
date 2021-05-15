using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace BoxLoader
{
	[Game]
	[Unique]
	public sealed class CameraComponent : IComponent
	{
		public Camera value;
	}
}