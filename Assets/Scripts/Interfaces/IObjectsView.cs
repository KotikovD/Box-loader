using UnityEngine;

public interface IObjectsView
{
	Transform Transform { get; }
	GameObject GameObject { get; }
	Vector3 GetPosition { get; }
	Quaternion GetRotation { get; }
	void InitializeView(GameEntity entity);
	void SetActive(bool isActive);
	void SetParent(Transform parent, bool worldPositionStays = true);
	void SetPosition(Vector3 position, bool isTween = false);
	void SetRotation(Quaternion rotation);
	void DestroyView();
}