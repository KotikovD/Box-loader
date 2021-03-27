//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BoxLoader.ObjectsViewComponent objectsView { get { return (BoxLoader.ObjectsViewComponent)GetComponent(GameComponentsLookup.ObjectsView); } }
    public bool hasObjectsView { get { return HasComponent(GameComponentsLookup.ObjectsView); } }

    public void AddObjectsView(BoxLoader.ObjectsView newValue) {
        var index = GameComponentsLookup.ObjectsView;
        var component = (BoxLoader.ObjectsViewComponent)CreateComponent(index, typeof(BoxLoader.ObjectsViewComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceObjectsView(BoxLoader.ObjectsView newValue) {
        var index = GameComponentsLookup.ObjectsView;
        var component = (BoxLoader.ObjectsViewComponent)CreateComponent(index, typeof(BoxLoader.ObjectsViewComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveObjectsView() {
        RemoveComponent(GameComponentsLookup.ObjectsView);
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

    static Entitas.IMatcher<GameEntity> _matcherObjectsView;

    public static Entitas.IMatcher<GameEntity> ObjectsView {
        get {
            if (_matcherObjectsView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ObjectsView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherObjectsView = matcher;
            }

            return _matcherObjectsView;
        }
    }
}
