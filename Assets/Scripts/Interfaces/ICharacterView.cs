using UnityEngine;
using UnityEngine.AI;


namespace BoxLoader
{
	public interface ICharacterView
	{
		Vector3 GetPosition { get; }
		Quaternion GetRotation { get; }
		void InitializeView(GameEntity entity);
		void SetActive(bool isActive);
		void SetParent(Transform parent, bool worldPositionStays = true);
		void SetPosition(Vector3 position, bool isTween = false);
		void SetRotation(Quaternion rotation);
		void Move(Vector3 destinationPoint);
		void Use(Vector3 destinationPoint);
		void DestroyView();
	}
}