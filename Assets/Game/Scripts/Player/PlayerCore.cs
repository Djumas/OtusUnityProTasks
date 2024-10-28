using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class PlayerCore
{
    public MoveComponent moveComponent;
    public RotationComponent rotationComponent;
    public ShootComponent shootComponent;
    public LifeComponent lifeComponent;
    public RootTransformComponent rootTransformComponent;
}