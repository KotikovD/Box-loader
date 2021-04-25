using System;
using DG.Tweening;
using UnityEngine;

namespace BoxLoader
{
	[RequireComponent(typeof(ObjectsView))]
	[RequireComponent(typeof(BoxCollider))]
	public sealed class BoxView : MonoBehaviourExt
	{
		[SerializeField] private BoxCollider _collider;
		
		private Bounds _bounds;
		private Sequence _moveTween;
		private bool _isAnimationMove;

		private void Start()
		{
			_bounds = _collider.bounds;
		}

		public Vector3 ClosestPoint(Vector3 point)
		{
			var localPoint = _bounds.ClosestPoint(point);
			return transform.TransformPoint(localPoint);
		}
		
		public bool IsPointInsideBox(Vector3 point)
		{
			var localPos = transform.InverseTransformPoint(point);
			return _bounds.Contains(localPos);
		}
		
		public void StopAnimationMoving()
		{
			_moveTween?.Pause();
		}
		
		public void AnimationMove(Vector3 target, float speed)
		{
			if (_moveTween.IsActive())
			{
				_moveTween.Play();
			}
			else
			{
				_moveTween?.Kill();
				var tween = DOTween.Sequence();
				tween.Append(transform.DOMove(target, speed)
						.SetSpeedBased()
						.SetEase(Ease.Linear))
						.SetAutoKill(true);
			
				_moveTween = tween;
			}
			
		}
		
	}
}