//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class TargetEventSystem : Entitas.ReactiveSystem<InputEntity> {

    readonly System.Collections.Generic.List<ITargetListener> _listenerBuffer;

    public TargetEventSystem(Contexts contexts) : base(contexts.input) {
        _listenerBuffer = new System.Collections.Generic.List<ITargetListener>();
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(InputMatcher.Target)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasTarget && entity.hasTargetListener;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            var component = e.target;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.targetListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnTarget(e, component.value);
            }
        }
    }
}