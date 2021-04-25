using BoxLoader;
using NaughtyAttributes;
using UnityEngine;


[CreateAssetMenu(menuName = "GameData/BoxData", fileName = "BoxData")]
public sealed class BoxData : ScriptableObjectExt
{
	[Header("View")] 
	[ReadOnly, Tooltip("For this object field uses only from code ")]
	[SerializeField] private Vector3 _startPosition;
	[ReadOnly, Tooltip("For this object field uses only from code ")]
	[SerializeField] private Vector3 _startRotation;
	[SerializeField] private SceneParentName _sceneParentName;

	public override Vector3 GetLocalPosition => _startPosition;
	public override Quaternion GetLocalRotation => Quaternion.Euler(_startRotation);
	public override string AssetName => _boxType.ToString();
	public override SceneParentName SceneParentName => _sceneParentName;
	public  BoxType BoxType => _boxType;

	[Header("Box")] 
	[SerializeField] private BoxType _boxType;
	
}