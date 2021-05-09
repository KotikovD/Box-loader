using UnityEngine;


namespace BoxLoader
{
	public class CharacterAnimationController : MonoBehaviourExt
	{
		private readonly int _moveSpeed = Animator.StringToHash("MoveSpeed");
		private readonly int _actionPickObject = Animator.StringToHash("ActionPickObject");
		private readonly int _dropBoxObject = Animator.StringToHash("ActionDropObject");
		private readonly int _moveMode = Animator.StringToHash("MoveMode");
		private readonly int _actionMode = Animator.StringToHash("ActionMode");
		
		[SerializeField] private Animator _animator;
		
		
		public void SetAnimationMoveSpeed(float speed)
		{
			_animator.SetFloat(_moveSpeed, speed);
		}

		public void Pickup()
		{
			_animator.SetInteger(_moveMode, 1);
			_animator.SetInteger(_actionMode, 0);
			_animator.SetTrigger(_actionPickObject);
		}

		public void DropBox()
		{
			_animator.SetInteger(_moveMode, 0);
			_animator.SetInteger(_actionMode, 1);
			_animator.SetTrigger(_dropBoxObject);
		}
		

		#region Animation events

		public void PlaySoundStep()
		{
			//TODO
		}
		
		#endregion
		
	}
}