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
		public Quaternion GetLocalRotation => transform.localRotation;
		public string AssetName => gameObject.name;
		public SceneParentName SceneParentName => CustomUtils.ParseEnum<SceneParentName>(gameObject.GetComponentInParent<GameObject>().name);


		public void InitializeView(GameEntity entity, Transform parentTransform)
		{
			entity.AddObjectsView(this);
			_entityLink = gameObject.Link(entity);
			
			if(entity.hasPosition)
				SetPosition(entity.position.value);
			
			if(entity.hasRotation)
				SetRotation(entity.rotation.value);
			
			//SetParent(parentTransform);
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

		public Quaternion LookAt(Vector3 target)
		{
			transform.LookAt(target, Vector3.up);
			return transform.localRotation;
		}
		
		public void DestroyView()
		{
			gameObject.Unlink();
			Destroy(gameObject);
		}
		

		
	}
}