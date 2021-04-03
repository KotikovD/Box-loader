using Entitas;
using UnityEngine;

namespace BoxLoader
{
	public sealed class InitializeProcessInputSystem : IInitializeSystem, ITargetListener
	{
		readonly Contexts _contexts;
		private GameEntity _playerEntity;
		
		public InitializeProcessInputSystem(Contexts contexts)
		{
			_contexts = contexts;
		}
		
		public void Initialize()
		{
			_contexts.input.inputEntity.AddTargetListener(this);
			_playerEntity = _contexts.game.playerEntity;
		}

		public void OnTarget(InputEntity entity, Vector3 value)
		{
			_playerEntity.character.Value.Move(value);
		}
		
	}
}