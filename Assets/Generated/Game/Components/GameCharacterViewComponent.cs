//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BoxLoader.CharacterViewComponent characterView { get { return (BoxLoader.CharacterViewComponent)GetComponent(GameComponentsLookup.CharacterView); } }
    public bool hasCharacterView { get { return HasComponent(GameComponentsLookup.CharacterView); } }

    public void AddCharacterView(BoxLoader.ICharacterView newValue) {
        var index = GameComponentsLookup.CharacterView;
        var component = (BoxLoader.CharacterViewComponent)CreateComponent(index, typeof(BoxLoader.CharacterViewComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCharacterView(BoxLoader.ICharacterView newValue) {
        var index = GameComponentsLookup.CharacterView;
        var component = (BoxLoader.CharacterViewComponent)CreateComponent(index, typeof(BoxLoader.CharacterViewComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCharacterView() {
        RemoveComponent(GameComponentsLookup.CharacterView);
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

    static Entitas.IMatcher<GameEntity> _matcherCharacterView;

    public static Entitas.IMatcher<GameEntity> CharacterView {
        get {
            if (_matcherCharacterView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CharacterView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharacterView = matcher;
            }

            return _matcherCharacterView;
        }
    }
}