//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity sceneServiceEntity { get { return GetGroup(GameMatcher.SceneService).GetSingleEntity(); } }
    public SceneServiceComponent sceneService { get { return sceneServiceEntity.sceneService; } }
    public bool hasSceneService { get { return sceneServiceEntity != null; } }

    public GameEntity SetSceneService(BoxLoader.ISceneService newValue) {
        if (hasSceneService) {
            throw new Entitas.EntitasException("Could not set SceneService!\n" + this + " already has an entity with SceneServiceComponent!",
                "You should check if the context already has a sceneServiceEntity before setting it or use context.ReplaceSceneService().");
        }
        var entity = CreateEntity();
        entity.AddSceneService(newValue);
        return entity;
    }

    public void ReplaceSceneService(BoxLoader.ISceneService newValue) {
        var entity = sceneServiceEntity;
        if (entity == null) {
            entity = SetSceneService(newValue);
        } else {
            entity.ReplaceSceneService(newValue);
        }
    }

    public void RemoveSceneService() {
        sceneServiceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SceneServiceComponent sceneService { get { return (SceneServiceComponent)GetComponent(GameComponentsLookup.SceneService); } }
    public bool hasSceneService { get { return HasComponent(GameComponentsLookup.SceneService); } }

    public void AddSceneService(BoxLoader.ISceneService newValue) {
        var index = GameComponentsLookup.SceneService;
        var component = (SceneServiceComponent)CreateComponent(index, typeof(SceneServiceComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSceneService(BoxLoader.ISceneService newValue) {
        var index = GameComponentsLookup.SceneService;
        var component = (SceneServiceComponent)CreateComponent(index, typeof(SceneServiceComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSceneService() {
        RemoveComponent(GameComponentsLookup.SceneService);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSceneService;

    public static Entitas.IMatcher<GameEntity> SceneService {
        get {
            if (_matcherSceneService == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SceneService);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSceneService = matcher;
            }

            return _matcherSceneService;
        }
    }
}
