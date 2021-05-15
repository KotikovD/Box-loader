using TMPro;
using UnityEngine;


namespace BoxLoader
{
	[RequireComponent(typeof(ObjectsView))]
	public sealed class UiView : MonoBehaviourExt
	{
		[SerializeField] private TextMeshProUGUI _label;
		[SerializeField] private string _labelLocalizationKey;
		[SerializeField] private TextMeshProUGUI _count;
		
		public string LabelLocalizationKey => _labelLocalizationKey;

		public string Label
		{
			set => _label.text = value;
		}
		
		public string Count
		{
			set => _count.text = value;
		}
	}
}