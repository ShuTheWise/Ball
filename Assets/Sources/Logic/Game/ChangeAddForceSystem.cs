using Entitas;
using System;
using System.Collections.Generic;
using static GameMatcher;
using System.Linq;
public class ChangeAddForceSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    public ChangeAddForceSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isColliding && entity.hasCollision;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log($"Executing {nameof(ChangeAddForceSystem)}");
        var group = m_contexts.game.GetGroup(AllOf(View, Rigidbody, Collidable)).GetEntities().ToList();
        UnityEngine.Debug.Log(group.Count);
        foreach (var item in group)
        {
            foreach (var entity in entities)
            {
                if (entity.collision.value.gameObject == item.view.value)
                {
                    item.AddAddForce(m_contexts.game.playerDetails.value.upForce);
                }
            }
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(Colliding, Collision));
    }
}