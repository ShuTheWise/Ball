using Entitas;

public class ResetBallSystem : IExecuteSystem
{
    private Contexts _contexts;

    public ResetBallSystem(Contexts contexts)
    {
        UnityEngine.Debug.Log("Creating " + nameof(ResetBallSystem));
        _contexts = contexts;
    }

    public void Execute()
    {
        if (_contexts.input.input.resetBall)
        {
            var g = _contexts.game.GetGroup(GameMatcher.Ball).GetEntities();
            foreach (var item in g)
            {
                item.flagDestroyed = true;
                item.flagDestroyView = true;
            }

            var ib = new InitializeBall(_contexts);
            ib.Initialize();
        }
    }
}