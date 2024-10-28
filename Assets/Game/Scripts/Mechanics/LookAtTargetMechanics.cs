using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class LookAtTargetMechanics : IAtomicUpdate
{
    [SerializeField, ReadOnly] private AtomicVariable<Vector3> rotationDirection;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> root;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> target;

    public void Construct(AtomicVariable<Vector3> _rotationDirection, AtomicVariable<Transform> _root, AtomicVariable<Transform> _target)
    {
        rotationDirection = _rotationDirection;
        root = _root;
        target = _target;
    }

    public void OnUpdate(float deltaTime)
    {
        if(root.Value && target.Value) rotationDirection.Value = (target.Value.position - root.Value.position).normalized;
    }
}
