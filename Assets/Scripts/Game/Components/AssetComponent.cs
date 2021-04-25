using Entitas;

namespace BoxLoader
{
	public sealed class AssetComponent : IComponent
	{
		public string Asset;
		public SceneParentName ParentTag;
	}
}