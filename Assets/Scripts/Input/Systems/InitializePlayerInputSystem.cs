using Entitas;
using UnityEngine;


namespace BoxLoader
{
	public class InitializePlayerInputSystem : IInitializeSystem, ITearDownSystem
	{
		private readonly Contexts _contexts;
		private readonly int _layerMask;
		private const float RayDistance = 100f;
		
		private InputEntity _inputEntity;
		private InputMaster _input;
		private Camera _camera;

		public InitializePlayerInputSystem(Contexts contexts)
		{
			_contexts = contexts;
			_layerMask = LayerMask.NameToLayer(LayerNamesKeeper.Character);
		}

		public void Initialize()
		{
			_camera = _contexts.game.sceneService.value.Camera;
			
			_inputEntity = _contexts.input.CreateEntity();
			_inputEntity.isInput = true;
			
			_input = new InputMaster();
			_input.Player.Move.performed += context => Move(false);
			_input.Player.Use.performed += context => Move(true);
			_input.Enable();
		}
		
		private void Move(bool isUse)
		{
			var ray = _camera.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out var hit, RayDistance, ~_layerMask))
			{
				_inputEntity.ReplaceTarget(hit.point);
				_inputEntity.isUse = isUse;
				Debug.Log("Move to " + hit.point + " Use = " + isUse);
			}
		}
		
		public void TearDown()
		{
			_input.Disable();
		}
	}
}