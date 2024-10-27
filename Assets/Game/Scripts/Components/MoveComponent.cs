using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class MoveComponent : IAtomicFixedUpdate
{
    public AtomicVariable<Vector3> moveDirection;
    [SerializeField] private Transform root;
    [SerializeField] private float speed = 0.5f;

    public void OnFixedUpdate(float deltaTime)
    {
        root.position += moveDirection.Value * (speed * deltaTime);
    }
}