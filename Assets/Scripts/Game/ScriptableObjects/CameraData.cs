using UnityEngine;

[CreateAssetMenu(menuName = "Data/CameraData")]
public class CameraData : ScriptableObject
{
	public float LerpSpeed;
	public Vector3 OffsetByPlayer;
	public Vector3 StartRotation;
}