using Entitas;
using System;
using System.Collections.Generic;
using static GameMatcher;
public class DestroyViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    public DestroyViewSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.flagDestroyView;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log($"Executing {nameof(DestroyViewSystem)}");
        foreach (var entity in entities)
        {
            UnityEngine.GameObject.Destroy(entity.view.value);
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(AllOf(View, DestroyView));
    }
}