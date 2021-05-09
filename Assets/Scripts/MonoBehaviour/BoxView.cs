using System.Collections.Generic;
using DG.Tweening;
using RSG;
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
		private float _maxExtent;

		private void Start()
		{
			_bounds = _collider.bounds;
			_maxExtent = Mathf.Max(_bounds.extents.x,_bounds.extents.y,_bounds.extents.z);
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
		
		public List<Vector3> GetUsingPositions(float usingOffset)
		{
			var result = new List<Vector3>();
			
			var pivot = transform.localPosition;
			var offset = _maxExtent + usingOffset;
			var interactPointOneSide = new Vector3(offset * -1, pivot.y * -1, offset * -1);
			var interactPointSecondSide = new Vector3(offset, pivot.y * -1, offset);
			
			 result.Add(pivot + transform.forward.MultiplyTwoDirections(interactPointOneSide));
			 result.Add(pivot + transform.forward.MultiplyTwoDirections(interactPointSecondSide));

			var r0 = GameObject.CreatePrimitive(PrimitiveType.Sphere); //TODO remove
			r0.transform.position = result[0];

			var r1 = GameObject.CreatePrimitive(PrimitiveType.Sphere); //TODO remove
			r1.transform.position = result[1];
			
			return result;
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

		public IPromise DropAnimation(float speed)
		{
			var promise = new Promise();
			var tween = DOTween.Sequence();
			var target = transform.position + Vector3.down * 4f;
			
			tween.Append(transform.DOMove(target, speed)
					.SetSpeedBased()
					.SetEase(Ease.Linear))
				.SetAutoKill(true).OnComplete(promise.Resolve);

			return promise;
		}
		
	}
}