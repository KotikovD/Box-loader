﻿using System;
using Entitas.Unity;
using NaughtyAttributes;
using UnityEngine;


namespace BoxLoader
{
	[RequireComponent(typeof(ObjectsView))]
	public sealed class ConveyorView : MonoBehaviourExt
	{
		[Tooltip("Sets from script")]
		[ReadOnly] 
		[SerializeField] private ConveyorMode _conveyorMode;
		[SerializeField] private Renderer _movingBelt;
		[SerializeField] private Transform _innerPoint;
		[SerializeField] private Transform _outPoint;
		[SerializeField] private Table _table;

		private Material _beltMaterial;
		private int _beltScrollSpeedId;
		private ConveyorData _conveyorData;
		private Transform _destinationMovePoint;
		private Transform _startMovePoint;
		private float _workingSpeed;

		public Vector3 DestinationMovePoint => _destinationMovePoint.position;
		public Vector3 StartMovePoint => _startMovePoint.position;
		public Table Table => _table;

		public Vector3 GetLoadPoint(float usingOffset, float maxExtent)
		{
			//var pivot = transform.localPosition;
			var offset = maxExtent + usingOffset;
			var interactPointOneSide = new Vector3(offset, StartMovePoint.y, offset) * -1;
			
			var result = StartMovePoint + transform.forward.MultiplyTwoDirections(interactPointOneSide);
			
			var r0 = GameObject.CreatePrimitive(PrimitiveType.Sphere); //TODO remove
			r0.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			r0.transform.position = result;
			
			return result;
		}
		
		public Quaternion GetMovingDirectionRotation
		{
			get
			{
				_startMovePoint.LookAt(_destinationMovePoint.position);
				return _startMovePoint.rotation;
			}
		}

		public void InitializeView(GameEntity entity)
		{
			_beltMaterial = _movingBelt.material;
			_beltScrollSpeedId = Shader.PropertyToID("_ScrollYSpeed");
			_conveyorData = entity.conveyorData.value;
		}

		public void SetWorkingMode(ConveyorMode mode)
		{
			if(_conveyorMode == mode) return;
			
			_conveyorMode = mode;
			switch (mode)
			{
				case ConveyorMode.Submitter:
					_workingSpeed = _conveyorData.WorkingSpeed * -1;
					_destinationMovePoint = _innerPoint;
					_startMovePoint = _outPoint;
					break;
				
				case ConveyorMode.Receiver:
					_workingSpeed = _conveyorData.WorkingSpeed;
					_destinationMovePoint = _outPoint;
					_startMovePoint = _innerPoint;
					break;
				
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Activate()
		{
			_beltMaterial.SetFloat(_beltScrollSpeedId, _workingSpeed);
		}
		
		public void Stop()
		{
			_beltMaterial.SetFloat(_beltScrollSpeedId, 0f); //TODO плавная остановка
		}
		
	}
}