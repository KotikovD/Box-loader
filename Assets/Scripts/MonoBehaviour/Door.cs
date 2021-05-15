using System;
using BoxLoader;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Door : MonoBehaviourExt
{
	[SerializeField] private Animator _animator;
	private readonly int _openAnim = Animator.StringToHash("Open");
	private readonly int _closeAnim = Animator.StringToHash("Close");
	private readonly float TOLERANCE = 0.2f;
	

	private void OnTriggerEnter(Collider other)
	{
		var box = other.GetComponent<BoxView>();
		if(Math.Abs(other.transform.up.y - 1) < TOLERANCE && box != null)
			_animator.SetTrigger(_openAnim);
	}

	private void OnTriggerExit(Collider other)
	{
		_animator.SetTrigger(_closeAnim);
	}
}