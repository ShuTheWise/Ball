using Entitas;
using System;
using System.Collections.Generic;
using static GameMatcher;
using System.Linq;
public class BounceBallOfPlayerSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    public BounceBallOfPlayerSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isBall && entity.isCollidingWithPlayer && entity.isColliding && entity.isCollidable;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var ent in entities)
        {
            ent.AddAddForce(m_contexts.game.playerDetails.value.upForce);
            ent.isColliding = false;
            ent.isCollidingWithPlayer = false;
            //    ent.isCollidingWithPlayer = false;
        }
        //UnityEngine.Debug.Log($"Executing {nameof(ChangeAddForceSystem)}");
        //var group = m_contexts.game.GetGroup(AllOf(View, Rigidbody, Collidable)).GetEntities().ToList();
        //UnityEngine.Debug.Log(group.Count);
        //foreach (var item in group)
        //{
        //    foreach (var entity in entities)
        //    {
        //        if (entity.collision.value.gameObject == item.view.value)
        //        {
        //            item.AddAddForce(m_contexts.game.playerDetails.value.upForce);
        //        }
        //    }
        //}
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(Ball, Collidable, Colliding, CollidingWithPlayer));
    }
}