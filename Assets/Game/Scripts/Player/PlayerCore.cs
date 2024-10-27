using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class PlayerCore
{
    [SerializeField] public MoveComponent moveComponent;
    [SerializeField] public RotationComponent rotationComponent;
    [SerializeField] public ShootComponent shootComponent;
    [SerializeField] public LifeComponent lifeComponent;
}