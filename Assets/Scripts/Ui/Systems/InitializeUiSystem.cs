using System.Collections.Generic;
using Entitas;


namespace BoxLoader
{
	public class InitializeScoreUiReactiveSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly Contexts _contexts;

		public InitializeScoreUiReactiveSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var gameUiData = _contexts.game.dataService.value.GameUiData;

			foreach (var someObject in gameUiData)
			{
				var someEntity = _contexts.game.CreateEntity();
				someEntity.AddAsset(someObject.AssetName, someObject.SceneParentName);
				someEntity.AddScore(0);
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ObjectsView.Added());
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasScore;
		}
		
		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				var view = entity.objectsView.Value.GameObject.GetComponent<UiView>();
				view.Label = Localization.GetKeyValue(view.LabelLocalizationKey);
				view.Count = "0";
				entity.AddUiView(view);
			}
		}
	}
}