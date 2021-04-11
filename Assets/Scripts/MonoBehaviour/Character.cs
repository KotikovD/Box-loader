using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.AI;


namespace BoxLoader
{
	[RequireComponent(typeof(EntityLink))]
	public sealed class Character : MonoBehaviourExt, ICharacter
	{
		[SerializeField] private NavMeshAgent _navMeshAgent;
		[SerializeField] private Animator _animator;
		
		private CharacterData _characterData;
		private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
		private NavMeshPath _navMeshPath;
		private Sequence _moveTween;
		private Sequence _animationTween;
		private float _currentSpeed;
		private float _wholePathTime;
		private bool _isInitialized;

		public void InitializeView(GameEntity entity)
		{
			entity.AddCharacter(this);
			_characterData = entity.characterData.value;
			_navMeshPath = new NavMeshPath();
			_isInitialized = true;
		}
		
		private void FixedUpdate()
		{
			if(!_isInitialized) return;
			
			_animator.SetFloat(MoveSpeed, GetAnimationMoveSpeed());
		}
		
		private Vector3[] CalculatePathCorners(Vector3 destination)
		{
			_navMeshAgent.CalculatePath(destination, _navMeshPath);
			var corners = _navMeshPath.corners;
			return corners;
		}
		
		private float GetAnimationMoveSpeed()
		{
			return _currentSpeed / _characterData.RunSpeed;
		}
		
		private float CalculatePathLength(Vector3[] corners)
		{
			var length = 0f;
			for (var i = 0; i < corners.Length; i++)
			{
				if (i + 1 < corners.Length)
					length += Vector3.Distance(corners[i], corners[i + 1]);
			}

			return length;
		}
		
		private void SetMoveAcceleration(float pathLenght)
		{
			var speed = pathLenght < _characterData.MinPathLengthForRun ? _characterData.WalkSpeed : _characterData.RunSpeed;
			_wholePathTime = pathLenght / speed;
			_currentSpeed = speed;

			_animationTween?.Kill();
			var animationTween = DOTween.Sequence();
			animationTween.PrependInterval(_wholePathTime - _characterData.StoppingTime);
			animationTween.Append(DOTween.To(() => _currentSpeed, x => _currentSpeed = x, 0f, _characterData.StoppingTime));
			_animationTween = animationTween;
		}

		private void MoveProduced(Vector3[] corners)
		{
			_moveTween?.Kill();
			var moveTween = DOTween.Sequence();
			moveTween.Append(transform.DOPath(corners, _wholePathTime, PathType.CatmullRom).SetLookAt(0.01f));
			_moveTween = moveTween;
		}
		
		public void Move(Vector3 destinationPoint)
		{
			var corners = CalculatePathCorners(destinationPoint);
			if(corners.Length == 0)
				return;
			
			var length = CalculatePathLength(corners);
			SetMoveAcceleration(length);
			MoveProduced(corners);
		}

		public void Use(Vector3 destinationPoint)
		{
			throw new System.NotImplementedException();
		}

		public void DestroyCharacterComponent()
		{
			Destroy(this);
			gameObject.Unlink();
		}

	}
}