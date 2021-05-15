//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BoxLoader.ConveyorComponent conveyor { get { return (BoxLoader.ConveyorComponent)GetComponent(GameComponentsLookup.Conveyor); } }
    public bool hasConveyor { get { return HasComponent(GameComponentsLookup.Conveyor); } }

    public void AddConveyor(GameEntity newValue) {
        var index = GameComponentsLookup.Conveyor;
        var component = (BoxLoader.ConveyorComponent)CreateComponent(index, typeof(BoxLoader.ConveyorComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceConveyor(GameEntity newValue) {
        var index = GameComponentsLookup.Conveyor;
        var component = (BoxLoader.ConveyorComponent)CreateComponent(index, typeof(BoxLoader.ConveyorComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveConveyor() {
        RemoveComponent(GameComponentsLookup.Conveyor);
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

    static Entitas.IMatcher<GameEntity> _matcherConveyor;

    public static Entitas.IMatcher<GameEntity> Conveyor {
        get {
            if (_matcherConveyor == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Conveyor);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherConveyor = matcher;
            }

            return _matcherConveyor;
        }
    }
}
