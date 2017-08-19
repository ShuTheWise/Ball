using Entitas;
using UnityEngine;

public class ChangeDeltaTimeSystem : IExecuteSystem
{
    private Contexts _contexts;

    public ChangeDeltaTimeSystem(Contexts contexts)
    {
        UnityEngine.Debug.Log("Creating " + nameof(ChangeDeltaTimeSystem));
        _contexts = contexts;
        _contexts.game.CreateEntity().AddDeltaTime(0);
    }

    public void Execute()
    {
        _contexts.game.ReplaceDeltaTime(Time.deltaTime);
    }
}