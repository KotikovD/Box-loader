//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly BoxLoader.WantToUseComponent wantToUseComponent = new BoxLoader.WantToUseComponent();

    public bool isWantToUse {
        get { return HasComponent(GameComponentsLookup.WantToUse); }
        set {
            if (value != isWantToUse) {
                var index = GameComponentsLookup.WantToUse;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : wantToUseComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherWantToUse;

    public static Entitas.IMatcher<GameEntity> WantToUse {
        get {
            if (_matcherWantToUse == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WantToUse);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWantToUse = matcher;
            }

            return _matcherWantToUse;
        }
    }
}
