using Entitas;
using UnityEngine;

public class InitializeGameArea : IInitializeSystem
{
    private Contexts m_contexts;

    public InitializeGameArea(Contexts contexts)
    {
        m_contexts = contexts;
    }
    public void Initialize()
    {
        UnityEngine.Debug.Log($"Starting a {nameof(InitializeGameArea)}");
        var vec = m_contexts.game.globals.value.gameArea;
        float thickness = m_contexts.game.globals.value.frameThickness;

        var xPos = vec.x + thickness / 2;
        var yPos = vec.y + thickness / 2;
        var firstScale = new Vector3(thickness, vec.y * 2, vec.z);
        var secondScale = new Vector3(vec.x * 2 + thickness * 2, thickness, vec.z);

        //left and right
        InstFrame(new Vector3(xPos, 0, 0), firstScale);
        InstFrame(new Vector3(-xPos, 0, 0), firstScale);

        //top and bottom
        InstFrame(new Vector3(0, yPos, 0), secondScale);
        InstFrame(new Vector3(0, -yPos, 0), secondScale);

        //   Physics.gravity = new Vector3(0, -0.9f, 0);

        float bh = m_contexts.game.globals.value.blockScale.x;
        for (float i = -vec.x + bh / 2; i < vec.x; i += bh)
        {
            for (int j = 1; j <= m_contexts.game.globals.value.numberOfRows; j++)
            {
                InstBlock(new Vector3(i, (float)-j * m_contexts.game.globals.value.blockScale.y + m_contexts.game.globals.value.gameArea.y + m_contexts.game.globals.value.blockScale.y / 2));
            }
        }
    }
    private void InstBlock(Vector3 pos)
    {
        var g = GameObject.Instantiate(m_contexts.game.globals.value.blockPrefab);
        // ChangeScaleAndPos(ref g, pos, g.transform.localScale);

        var ent = m_contexts.game.CreateEntity();
        ent.AddPosition(pos);
        ent.AddView(g);
        ent.isBlock = true;
        ent.isCollidable = true;

       // ent.add
    }
    private void InstFrame(Vector3 pos, Vector3 scale)
    {
        var g = GameObject.Instantiate(m_contexts.game.globals.value.framePrefab);
        ChangeScaleAndPos(ref g, pos, scale);
    }
    private void ChangeScaleAndPos(ref GameObject g, Vector3 pos, Vector3 scale)
    {
        g.transform.position = pos;
        g.transform.localScale = scale;
    }
}