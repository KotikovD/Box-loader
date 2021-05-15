using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using Entitas.Unity;
using RSG;
using UnityEngine;
using UnityEngine.AI;


namespace BoxLoader
{
	[RequireComponent(typeof(EntityLink))]
	public sealed class CharacterView : MonoBehaviourExt, ICharacterView
	{
		[SerializeField] private NavMeshAgent _navMeshAgent;
		[SerializeField] private CharacterAnimationController _characterAnimationController;
		[SerializeField] private CarryPoint _carryPoint;
		
		private CharacterData _characterData;
		private NavMeshPath _navMeshPath;
		private Sequence _moveTween;
		private Sequence _animationTween;
		private float _currentSpeed;
		private float _wholePathTime;
		private bool _isInitialized;
		private Sequence _lookTween;
		private IPromiseTimer promiseTimer;
		private GameContext _gameContext;


		public Transform CarryPoint => _carryPoint.transform;
		
		public void InitializeView(GameEntity entity, GameContext gameContext)
		{
			_gameContext = gameContext;
			promiseTimer = new PromiseTimer();
			entity.AddCharacter(this);
			_characterData = entity.characterData.value;
			_navMeshPath = new NavMeshPath();
			_isInitialized = true;
		}
		
		private void FixedUpdate()
		{
			if(!_isInitialized) return;
			
			promiseTimer.Update(Time.deltaTime);
			_characterAnimationController.SetAnimationMoveSpeed(GetAnimationMoveSpeed());
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
		
		public IPromise Move(Vector3 destinationPoint)
		{
			var promise = new Promise();
			var corners = CalculatePathCorners(destinationPoint);
			if (corners.Length == 0)
				return Promise.Resolved();
			
			var length = CalculatePathLength(corners);
			SetMoveAcceleration(length);
			
			_moveTween?.Kill();
			var moveTween = DOTween.Sequence();
			moveTween.Append(transform.DOPath(corners, _wholePathTime, PathType.CatmullRom).SetLookAt(0.01f)).OnComplete(promise.Resolve);
			_moveTween = moveTween;
			
			return promise;
		}

		public IPromise Pickup(float animationEventTime)
		{
			_characterAnimationController.Pickup();
			return promiseTimer.WaitFor(animationEventTime);
		}
		
		public IPromise DropBox(float animationEventTime)
		{
			_characterAnimationController.DropBox();
			return promiseTimer.WaitFor(animationEventTime);
		}

		public IPromise LookAt(Vector3 target)
		{
			var promise = new Promise();
			_lookTween?.Kill();
			var lookTween = DOTween.Sequence();
			lookTween.Append(transform.DOLookAt(target, _gameContext.dataService.value.Constants.CharactersLookAtDuration, AxisConstraint.Y).OnComplete(promise.Resolve));
			_lookTween = lookTween;

			return promise;
		}

		public void DestroyCharacterComponent()
		{
			Destroy(this);
			gameObject.Unlink();
		}

	}
}