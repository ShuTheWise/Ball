using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using Entitas;
[CreateAssetMenu, Game, Unique]
public class Globals : ScriptableObject
{
    public GameObject ballPrefab;

    public Vector3 gameArea;
    public GameObject framePrefab;
    public float frameThickness;

    public GameObject blockPrefab;
    public Vector3 blockScale;

    public int numberOfRows;
}