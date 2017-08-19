using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class CollisionComponent : IComponent
{
    public Collision value;
}