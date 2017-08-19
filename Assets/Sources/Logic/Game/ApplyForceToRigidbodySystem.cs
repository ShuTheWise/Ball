using Entitas;
using System;
using System.Collections.Generic;
using static GameMatcher;
public class ApplyForceToRigidbodySystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    public ApplyForceToRigidbodySystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAddForce;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.rigidbody.value.AddForce(entity.addForce.value);
            entity.RemoveAddForce();
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(AllOf(AddForce));
    }
}