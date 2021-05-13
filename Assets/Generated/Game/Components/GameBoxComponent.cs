//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BoxLoader.BoxComponent box { get { return (BoxLoader.BoxComponent)GetComponent(GameComponentsLookup.Box); } }
    public bool hasBox { get { return HasComponent(GameComponentsLookup.Box); } }

    public void AddBox(BoxLoader.BoxType newValue) {
        var index = GameComponentsLookup.Box;
        var component = (BoxLoader.BoxComponent)CreateComponent(index, typeof(BoxLoader.BoxComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBox(BoxLoader.BoxType newValue) {
        var index = GameComponentsLookup.Box;
        var component = (BoxLoader.BoxComponent)CreateComponent(index, typeof(BoxLoader.BoxComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBox() {
        RemoveComponent(GameComponentsLookup.Box);
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

    static Entitas.IMatcher<GameEntity> _matcherBox;

    public static Entitas.IMatcher<GameEntity> Box {
        get {
            if (_matcherBox == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Box);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBox = matcher;
            }

            return _matcherBox;
        }
    }
}
