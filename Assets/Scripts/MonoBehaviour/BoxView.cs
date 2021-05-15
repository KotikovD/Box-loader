using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
		private Sequence _moveTweenSubmitter;
		private bool _isAnimationMove;
		private float _maxExtent;
		private TweenerCore<Vector3, Vector3, VectorOptions> _moveTweenerReceiver;
		private TweenerCore<Vector3, Vector3, VectorOptions> _moveTween2;
		public float MaxExtent => _maxExtent;

		private void Start()
		{
			_bounds = _collider.bounds;
			_maxExtent = Mathf.Max(_bounds.extents.x, _bounds.extents.y, _bounds.extents.z);
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
			var interactPointOneSide = new Vector3(offset, pivot.y, offset) * -1;
			var interactPointSecondSide = new Vector3(offset, pivot.y * -1, offset);
			
			 result.Add(pivot + transform.forward.MultiplyTwoDirections(interactPointOneSide));
			 result.Add(pivot + transform.forward.MultiplyTwoDirections(interactPointSecondSide));

			var r0 = GameObject.CreatePrimitive(PrimitiveType.Sphere); //TODO remove
			r0.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			r0.transform.position = result[0];

			var r1 = GameObject.CreatePrimitive(PrimitiveType.Sphere); //TODO remove
			r1.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			r1.transform.position = result[1];
			
			return result;
		}


		
		public void StopAnimationMoving()
		{
			_moveTweenerReceiver?.Pause();
			_moveTweenSubmitter?.Pause();
		}

		public void AnimationMove(Vector3 target, float speed)
		{
			if (_moveTweenerReceiver.IsActive())
			{
				_moveTweenerReceiver.Play();
			}
			else
			{
				_moveTweenerReceiver = transform.DOMove(target, speed).SetEase(Ease.Linear);
				_moveTweenerReceiver.ChangeStartValue(transform.position);
			}
			
		}

		public void SubmitterAnimationMove(Vector3 target, float speed)
		{
			if (_moveTweenSubmitter.IsActive())
			{
				_moveTweenSubmitter.Play();
			}
			else
			{
				_moveTweenSubmitter?.Kill();
				var tween = DOTween.Sequence();
				tween.Append(transform.DOMove(target, speed).SetEase(Ease.Linear));
				_moveTweenSubmitter = tween;
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