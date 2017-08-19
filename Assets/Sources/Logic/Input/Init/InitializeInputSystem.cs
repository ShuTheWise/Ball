using Entitas;

public class InitializeInputSystem : IInitializeSystem
{
    private Contexts m_contexts;

    public InitializeInputSystem(Contexts contexts)
    {
        m_contexts = contexts;
    }
    public void Initialize()
    {
        UnityEngine.Debug.Log($"Starting a {nameof(InitializeInputSystem)}");
        m_contexts.input.CreateEntity().AddInput(0);
    }
}