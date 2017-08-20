using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using Entitas;
[CreateAssetMenu, Game, Unique]
public class Globals : ScriptableObject
{
    public GameObject ballPrefab;
    public Vector3 gameArea;
    public Material frameMaterial;
    public float frameThickness;
    public float gravity;
}