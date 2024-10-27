using System;
using UnityEngine;

[Serializable]
public class ZombieCore
{
    [SerializeField] public MoveComponent moveComponent;
    [SerializeField] public RotationComponent rotationComponent;
    [SerializeField] public LifeComponent lifeComponent;
}
