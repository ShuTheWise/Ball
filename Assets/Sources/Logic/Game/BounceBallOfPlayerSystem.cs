using Entitas;
using System;
using System.Collections.Generic;
using static GameMatcher;
using System.Linq;
using UnityEngine;

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
           var vel = ent.rigidbody.value.velocity;
            var y = vel.y * 1.25f;
            var x = vel.x * 1.25f;
            ent.rigidbody.value.velocity = new Vector3(
                Mathf.Clamp(x, -20f, 20f), 
                Mathf.Clamp(y, -20f, 20f)
                );
         //   ent.AddAddForce(m_contexts.game.playerDetails.value.upForce);
         //   ent.isColliding = false;
         //   ent.isCollidingWithPlayer = false;
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(Ball, Collidable, Colliding, CollidingWithPlayer));
    }
}