//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity viewCharacterServiceEntity { get { return GetGroup(GameMatcher.ViewCharacterService).GetSingleEntity(); } }
    public ViewCharacterServiceComponent viewCharacterService { get { return viewCharacterServiceEntity.viewCharacterService; } }
    public bool hasViewCharacterService { get { return viewCharacterServiceEntity != null; } }

    public GameEntity SetViewCharacterService(BoxLoader.IViewCharacterService newValue) {
        if (hasViewCharacterService) {
            throw new Entitas.EntitasException("Could not set ViewCharacterService!\n" + this + " already has an entity with ViewCharacterServiceComponent!",
                "You should check if the context already has a viewCharacterServiceEntity before setting it or use context.ReplaceViewCharacterService().");
        }
        var entity = CreateEntity();
        entity.AddViewCharacterService(newValue);
        return entity;
    }

    public void ReplaceViewCharacterService(BoxLoader.IViewCharacterService newValue) {
        var entity = viewCharacterServiceEntity;
        if (entity == null) {
            entity = SetViewCharacterService(newValue);
        } else {
            entity.ReplaceViewCharacterService(newValue);
        }
    }

    public void RemoveViewCharacterService() {
        viewCharacterServiceEntity.Destroy();
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

    public ViewCharacterServiceComponent viewCharacterService { get { return (ViewCharacterServiceComponent)GetComponent(GameComponentsLookup.ViewCharacterService); } }
    public bool hasViewCharacterService { get { return HasComponent(GameComponentsLookup.ViewCharacterService); } }

    public void AddViewCharacterService(BoxLoader.IViewCharacterService newValue) {
        var index = GameComponentsLookup.ViewCharacterService;
        var component = (ViewCharacterServiceComponent)CreateComponent(index, typeof(ViewCharacterServiceComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceViewCharacterService(BoxLoader.IViewCharacterService newValue) {
        var index = GameComponentsLookup.ViewCharacterService;
        var component = (ViewCharacterServiceComponent)CreateComponent(index, typeof(ViewCharacterServiceComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveViewCharacterService() {
        RemoveComponent(GameComponentsLookup.ViewCharacterService);
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

    static Entitas.IMatcher<GameEntity> _matcherViewCharacterService;

    public static Entitas.IMatcher<GameEntity> ViewCharacterService {
        get {
            if (_matcherViewCharacterService == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewCharacterService);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewCharacterService = matcher;
            }

            return _matcherViewCharacterService;
        }
    }
}
