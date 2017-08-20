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
        var firstScale = new Vector3(thickness, vec.y*2, vec.z);
        var secondScale = new Vector3(vec.x*2 + thickness*2, thickness, vec.z);

        //left and right
        Inst(new Vector3(xPos, 0, 0), firstScale);
        Inst(new Vector3(-xPos , 0, 0), firstScale);
        
        //top and bottom
        Inst(new Vector3(0, yPos, 0), secondScale);
        Inst(new Vector3(0, -yPos, 0), secondScale);

        Physics.gravity = new Vector3(0, -0.9f, 0);
    }
    private void Inst(Vector3 pos, Vector3 scale)
    {
        var g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        g.transform.position = pos;
        g.transform.localScale = scale;
        g.GetComponent<MeshRenderer>().sharedMaterial = m_contexts.game.globals.value.frameMaterial;
    }
}