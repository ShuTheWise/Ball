using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Entitas;
public class CollisionBehaviour : MonoBehaviour
{
    private Contexts m_contexts;
    private GameEntity m_entity;

    public void LinkEntity(ref Contexts contexts, GameEntity ent)
    {
        m_entity = ent;
        m_contexts = contexts;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (m_entity != null)
        {
            if (!m_entity.hasCollision) m_entity.AddCollision(collision);
            else m_entity.ReplaceCollision(collision);
            m_entity.isColliding = true;
            if (m_entity.isBall)
            {
                switch (collision.gameObject.tag)
                {
                    case "Player":
                        m_entity.isCollidingWithPlayer = true;
                        break;
                    case "Block":
                        break;
                }
            }
        }

        //var all = m_contexts?.game?.GetGroup(GameMatcher.AllOf(GameMatcher.Collidable, GameMatcher.View)).GetEntities();
        //if (all != null)
        //{
        //    foreach (var rb in all)
        //    {
        //        if (rb.view.value == collision.gameObject)
        //        {
        //            rb.isColliding = true;
        //            if (gameObject.CompareTag("Player"))
        //            {
        //                rb.isCollidingWithPlayer = true;
        //            }
        //        }
        //    }
        //}
    }
    private void OnCollisionExit(Collision collision)
    {
        if (m_entity != null)
        {
            if (m_entity.hasCollision)
                m_entity.RemoveCollision();
            m_entity.isColliding = false;
            //if (gameObject.CompareTag("Player"))
            //{
            //    m_entity.isCollidingWithPlayer = false;
            //}
        }
    }
}
