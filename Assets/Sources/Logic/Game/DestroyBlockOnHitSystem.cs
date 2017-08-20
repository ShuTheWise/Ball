using Entitas;
using System;
using System.Collections.Generic;
using static GameMatcher;
public class DestroyBlockOnHitSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    public DestroyBlockOnHitSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isBlock && entity.isColliding;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log($"Executing {nameof(DestroyBlockOnHitSystem)}");
        foreach (var entity in entities)
        {
            entity.flagDestroyView = true;
            entity.flagDestroyed = true;
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(AllOf(Block, Colliding));
    }
}