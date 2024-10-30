using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class MoveComponent : IAtomicFixedUpdate
{
    public AtomicVariable<Vector3> moveDirection;
    public AtomicVariable<Vector3> moveDirectionRelative;
    public AtomicVariable<float> speed;
    [SerializeField] private Transform root;

    public void OnFixedUpdate(float deltaTime)
    {
        root.position += moveDirection.Value * (speed.Value * deltaTime);
        moveDirectionRelative.Value = root.InverseTransformDirection(moveDirection.Value);
    }
}