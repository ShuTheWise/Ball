using Entitas;
using UnityEngine;

public class GetInputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public GetInputSystem(Contexts contexts)
    {
        UnityEngine.Debug.Log("Creating " + nameof(GetInputSystem));
        _contexts = contexts;
    }

    public void Execute()
    {
        _contexts.input.input.resetBall = Input.GetKeyDown(KeyCode.Space);
        _contexts.input.input.horizontalAxis = Input.GetAxis("Horizontal");
    }
}