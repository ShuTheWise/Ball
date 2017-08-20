using Entitas;
using UnityEngine;

public class InitializeBall : IInitializeSystem
{
    private Contexts m_contexts;

    public InitializeBall(Contexts contexts)
    {
        m_contexts = contexts;
    }
    public void Initialize()
    {

        for (int i = 0; i < 1; i++)
        {
            UnityEngine.Debug.Log($"Starting a {nameof(InitializeBall)}");
            var g = GameObject.Instantiate(m_contexts.game.globals.value.ballPrefab);//, Vector3., Quaternion.identity);
            //        g.transform.localScale = Vector3.one * m_contexts.game.globals.value.ballScale;
            g.tag = "Ball";
            var ent = m_contexts.game.CreateEntity();
            ent.AddPosition(new Vector3(i, 2, 0));
            var rb = g.GetComponent<Rigidbody>();
          //  rb.angularDrag = .5f;

            ent.AddRigidbody(rb);
            ent.AddCollider(g.GetComponent<Collider>());
            ent.isCollidable = true;
            ent.isBall = true;
            ent.AddView(g);
            ent.rigidbody.value.velocity = new Vector3(-1, -3f);
        }
    }
}