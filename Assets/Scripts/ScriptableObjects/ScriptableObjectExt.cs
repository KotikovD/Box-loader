using BoxLoader;
using UnityEngine;

public abstract class ScriptableObjectExt : ScriptableObject, IView
{
	public abstract Vector3 GetPosition { get; }
	public abstract Quaternion GetLocalRotation { get; }
	public abstract string AssetName { get; }
	public abstract SceneParentName SceneParentName { get; }
}