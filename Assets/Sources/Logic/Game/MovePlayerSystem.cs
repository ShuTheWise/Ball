using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerSystem : IExecuteSystem
{
    private Contexts m_contexts;
    public MovePlayerSystem(Contexts contexts)
    {
        m_contexts = contexts;
    }
    public void Execute()
    {
        var hor = m_contexts.input.input.horizontalAxis;
        if (Mathf.Abs(hor) > 0.3f)
        {
            var newVec = Vector3.zero;
            if (hor > 0)
            {
                newVec = Vector3.right;
                //Debug.Log("right");
            }
            else
            {
                newVec = Vector3.left;
                //Debug.Log("left");
            }
            m_contexts.game.playerEntity.isMoving = true;
            m_contexts.game.playerEntity.ReplaceMove(newVec * m_contexts.game.deltaTime.value * m_contexts.game.playerDetails.value.speed);
        }
        else
        {
            m_contexts.game.playerEntity.isMoving = false;
        }
    }
}