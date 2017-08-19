using Entitas;
using UnityEngine;
public class InitializePlayerSystem : IInitializeSystem
{
    private Contexts m_contexts;

    public InitializePlayerSystem(Contexts contexts)
    {
        m_contexts = contexts;
    }
    public void Initialize()
    {
        var g = GameObject.Instantiate(m_contexts.game.playerDetails.value.prefab, m_contexts.game.playerDetails.value.initialPosition, Quaternion.identity);
        UnityEngine.Debug.Log($"Starting a {nameof(InitializePlayerSystem)}");
        var entity = m_contexts.game.CreateEntity();
        entity.AddPosition(m_contexts.game.playerDetails.value.initialPosition);
        entity.isPlayer = true;
        entity.isMoveable = true;
        entity.AddMove(Vector3.zero);
        entity.AddView(g);
    }
}