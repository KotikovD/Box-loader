using BoxLoader;
using UnityEngine;

public interface IView
{
	Vector3 GetLocalPosition { get; }
	Quaternion GetLocalRotation { get; }
	string AssetName { get; }
	SceneParentName SceneParentName { get; }
}