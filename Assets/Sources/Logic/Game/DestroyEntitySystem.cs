using Entitas;
using System;
using System.Collections.Generic;
using static GameMatcher;
public class DestroyEntitySystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    public DestroyEntitySystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.flagDestroyed;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log($"Executing {nameof(DestroyEntitySystem)}");
        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(Destroyed);
    }
}