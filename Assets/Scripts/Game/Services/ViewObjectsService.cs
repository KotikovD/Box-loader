using UnityEngine;

namespace BoxLoader
{
	public class ViewObjectsService : IViewObjectsService
	{
		private readonly IPrefabLoader _prefabLoader;
		public ViewObjectsService(PrefabLoader prefabLoader)
		{
			_prefabLoader = prefabLoader;
		}
		
		public void CreateView(GameContext context, GameEntity entity)
		{
			var prefab = _prefabLoader.GetPrefab(entity.asset.Value);
			var obj = Object.Instantiate(prefab);
			obj.name = entity.asset.Value;
			var view = obj.GetComponent<ObjectsView>();
			view.InitializeView(entity);
		}

		public void DestroyView(GameEntity entity)
		{
			if (!entity.hasCharacter) return;
	
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