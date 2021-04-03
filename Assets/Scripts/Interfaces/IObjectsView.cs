using UnityEngine;

public interface IObjectsView : IView
{
	Transform Transform { get; }
	GameObject GameObject { get; }
	void InitializeView(GameEntity entity);
	void SetActive(bool isActive);
	void SetParent(Transform parent, bool worldPositionStays = true);
	void SetPosition(Vector3 position);
	void SetRotation(Quaternion rotation);
	void DestroyView();
}