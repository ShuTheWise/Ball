using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Globals globals;
    public PlayerDetails playerDetails;
    private Systems m_systems;
    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        Contexts.sharedInstance.game.SetGlobals(globals);
        Contexts.sharedInstance.game.SetPlayerDetails(playerDetails);
        m_systems = CreateSystems(contexts);
        m_systems.Initialize();
    }
    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializePlayerSystem(contexts))
            .Add(new InitializeInputSystem(contexts))
            .Add(new InitializeBall(contexts))
            .Add(new InitializeGameArea(contexts))

            .Add(new ChangeDeltaTimeSystem(contexts))
            .Add(new BounceBallOfPlayerSystem(contexts))
            .Add(new ApplyForceToRigidbodySystem(contexts))

            .Add(new GetInputSystem(contexts))
            .Add(new MovePlayerSystem(contexts))
            .Add(new MoveSystem(contexts))
            .Add(new RenderPositionSystem(contexts));

    }
    private void Update() => m_systems.Execute();
}
