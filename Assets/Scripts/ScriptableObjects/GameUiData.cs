using BoxLoader;
using NaughtyAttributes;
using UnityEngine;


[CreateAssetMenu(menuName = "GameData/GameUiData", fileName = "GameUiData")]
public sealed class GameUiData : ScriptableObjectExt
{
	[Header("View")]
	[ReadOnly] [SerializeField]
	private SceneParentName _sceneParentName = SceneParentName.Ui;
	[SerializeField] 
	private string _uiPrefub;

	
	public override Vector3 GetPosition => Vector3.zero;
	public override Quaternion GetLocalRotation => Quaternion.identity;
	public override string AssetName => _uiPrefub;
	public override SceneParentName SceneParentName => _sceneParentName;
}