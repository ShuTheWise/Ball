﻿using Entitas;
using Entitas.CodeGeneration.Attributes;
[Input, Unique]
public class InputComponent : IComponent
{
    public float horizontalAxis;
    public bool resetBall;
}