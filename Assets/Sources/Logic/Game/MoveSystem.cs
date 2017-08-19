using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    public MoveSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasMove && entity.isMoveable && entity.isMoving;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        var maxInclination = m_contexts.game.playerDetails.value.maxInclination;
        UnityEngine.Debug.Log($"Executing {nameof(MoveSystem)}");
        foreach (var entity in entities)
        {
            var newPos = entity.position.value + entity.move.direction;
            newPos.x = Mathf.Clamp(newPos.x, -maxInclination, maxInclination);
            //entity.position.value = newPos;
            entity.ReplacePosition(newPos);
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Moveable, GameMatcher.Move));
    }
}