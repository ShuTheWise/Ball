using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GameMatcher;
public class RenderPositionSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    public RenderPositionSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition;
    }
    protected override void Execute(List<GameEntity> entities)
    {
         UnityEngine.Debug.Log($"Executing {nameof(RenderPositionSystem)}");
        foreach (var entity in entities)
        {
            entity.view.value.transform.position = new Vector3(entity.position.value.x, entity.position.value.y, 0);
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(AllOf(Position));
    }
}