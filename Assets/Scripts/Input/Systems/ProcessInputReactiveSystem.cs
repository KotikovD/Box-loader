using Entitas;
using UnityEngine;

namespace BoxLoader
{
	public sealed class ProcessInputReactiveSystem : IInitializeSystem, ITargetListener
	{
		readonly Contexts _contexts;

		public ProcessInputReactiveSystem(Contexts contexts)
		{
			_contexts = contexts;
		}


		public void Initialize()
		{
			_contexts.input.inputEntity.AddTargetListener(this);
		}

		public void OnTarget(InputEntity entity, Vector3 value)
		{
			_contexts.game.playerEntity.characterView.Value.Move(value);
		}
	}
}