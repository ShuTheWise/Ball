using Entitas;
using System;
using System.Collections.Generic;
using static GameMatcher;
public class DetectCollisionSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    public DetectCollisionSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isCollidable && entity.hasView;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log($"Executing {nameof(DetectCollisionSystem)}");
        foreach (var entity in entities)
        {
            if (entity.view.value.GetComponent<CollisionBehaviour>() == null)
            {
                entity.view.value.AddComponent<CollisionBehaviour>();
            }
            entity.view.value.GetComponent<CollisionBehaviour>().LinkEntity(ref m_contexts, entity);
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(AllOf(Collidable, View));
    }
}