using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
	public float Speed;
	public string AssetName;
	public Vector3 StartPosition;
	public Vector3 StartRotation;
}