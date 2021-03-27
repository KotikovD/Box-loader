using UnityEngine;

namespace BoxLoader
{
	//TODO эта хуйня похоже на ObjectsView, как объеденить?
	public class ViewCharacterService : IViewCharacterService
	{
		private readonly IPrefabLoader _prefabLoader;
		public ViewCharacterService(PrefabLoader prefabLoader)
		{
			_prefabLoader = prefabLoader;
		}
		
		public void CreateView(GameContext context, GameEntity entity)
		{
			var prefab = _prefabLoader.GetPrefab(entity.asset.Value);
			var obj = Object.Instantiate(prefab);
			var view = obj.GetComponent<CharacterView>();
			view.InitializeView(entity);
		}

		public void DestroyView(GameEntity entity)
		{
			 if (!entity.hasCharacterView) return;
	
			 entity.characterView.Value.DestroyView();
			 entity.RemoveCharacterView();
		}
		
		public void SetParent(GameEntity entity)
		{
			throw new System.NotImplementedException(); //TODO
		}

		public void SetPosition(GameEntity entity)
		{
			 entity.characterView.Value.SetPosition(entity.position.value);
		}
	}
}