using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player")]
public class Player : ScriptableObject
{
	public float Speed;
	public string AssetName;
	public Vector3 StartPosition;
	public Vector3 StartRotation;
}