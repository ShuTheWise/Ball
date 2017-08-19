using Entitas.CodeGeneration.Attributes;
using UnityEngine;
[CreateAssetMenu, Game, Unique]
public class PlayerDetails : ScriptableObject
{
    public GameObject prefab;
    public Vector3 initialPosition;
    [Range(0,15)]
    public int maxInclination;
    [Range(0.01f, 10)]
    public float speed;
    public Vector3 upForce;
}
