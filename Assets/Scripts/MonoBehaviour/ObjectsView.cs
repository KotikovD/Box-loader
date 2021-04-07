﻿using System;
using Entitas.Unity;
using UnityEngine;

namespace BoxLoader
{
	[RequireComponent(typeof(EntityLink))]
	public sealed class ObjectsView : MonoBehaviourExt, IObjectsView
	{
		private EntityLink _entityLink;

		public Transform Transform => transform;
		public GameObject GameObject => gameObject;
		public Vector3 GetPosition => transform.localPosition;
		public Quaternion GetRotation => transform.localRotation;
		public string AssetName => gameObject.name;
		public SceneTagNames SceneTagName => EnumUtil.Parse<SceneTagNames>(gameObject.GetComponentInParent<GameObject>().name);


		public void InitializeView(GameEntity entity, Transform parentTransform)
		{
			entity.AddObjectsView(this);
			_entityLink = gameObject.Link(entity);
			SetPosition(entity.position.value);
			SetRotation(entity.rotation.value);
			SetParent(parentTransform);
		}

		public void SetActive(bool isActive)
		{
			gameObject.SetActive(isActive);
		}

		public void SetParent(Transform parent, bool worldPositionStays = true)
		{
			transform.SetParent(parent, worldPositionStays);
		}

		public void SetPosition(Vector3 position)
		{
			transform.localPosition = position;
		}

		public void SetRotation(Quaternion rotation)
		{
			transform.rotation = rotation;
		}

		public void DestroyView()
		{
			Destroy(gameObject);
		}

		private void OnDestroy()
		{
			gameObject.Unlink();
		}
	}
}