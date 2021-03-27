using UnityEngine;

[CreateAssetMenu(menuName = "Data/Camera")]
public class Camera : ScriptableObject
{
	public float LerpSpeed;
	public Vector3 StartPosition;
	public Vector3 StartRotation;
}