using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BoxLoader
{
	[Unique]
	[Game]
	public class ScoreComponent : IComponent
	{
		public int value;
	}
}