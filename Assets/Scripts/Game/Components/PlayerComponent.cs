using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BoxLoader
{
	[Game]
	[Unique]
	[Event(EventTarget.Any)]
	public sealed class PlayerComponent : IComponent
	{
	}
}