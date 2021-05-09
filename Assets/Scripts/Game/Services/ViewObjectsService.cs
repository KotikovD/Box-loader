using UnityEngine;

namespace BoxLoader
{
	public class ViewObjectsService : IViewObjectsService
	{
		private readonly IPrefabLoader _prefabLoader;
		private ISceneGameObjectsHierarchy _sceneGameObjectsHierarchy;

		public ViewObjectsService(PrefabLoader prefabLoader, ISceneGameObjectsHierarchy sceneGameObjectsHierarchy)
		{
			_sceneGameObjectsHierarchy = sceneGameObjectsHierarchy;
			_prefabLoader = prefabLoader;
		}
		
		public void CreateView(GameContext context, GameEntity entity)
		{
			var prefab = _prefabLoader.GetPrefab(entity.asset.Asset);
			var obj = Object.Instantiate(prefab);
			obj.name = entity.asset.Asset;
			var view = obj.GetComponent<ObjectsView>();
			var parent = _sceneGameObjectsHierarchy.GetParent(entity.asset.ParentTag);
			view.InitializeView(entity, parent);
		}

		public void DestroyView(GameEntity entity)
		{
			entity.objectsView.Value.DestroyView();
			entity.RemoveObjectsView();
		}
		
		public void SetParent(GameEntity entity)
		{
			throw new System.NotImplementedException(); //TODO
		}

		public void SetPosition(GameEntity entity)
		{
			entity.objectsView.Value.SetPosition(entity.position.value);
		}
	}
}