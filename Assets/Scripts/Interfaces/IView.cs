using UnityEngine;

public interface IView
{
	Vector3 GetPosition { get; }
	Quaternion GetRotation { get; }
	string AssetName { get; }
}