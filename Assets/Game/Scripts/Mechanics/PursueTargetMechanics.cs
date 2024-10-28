using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class PursueTargetMechanics : IAtomicUpdate
{
    [SerializeField, ReadOnly] private AtomicVariable<Vector3> moveDirection;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> targetTransform;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> rootTransform;
    [SerializeField, ReadOnly] private bool isEnabled;

    public void Construct(AtomicVariable<Vector3> _moveDirection, AtomicVariable<Transform> _target,
        AtomicVariable<Transform> _root)
    {
        moveDirection = _moveDirection;
        targetTransform = _target;
        rootTransform = _root;
    }

    public void Stop()
    {
        moveDirection.Value = Vector3.zero;
        isEnabled = false;
    }

    public void Start()
    {
        isEnabled = true;
    }

    public void OnUpdate(float deltaTime)
    {
        if (!isEnabled) return;
        
        if (targetTransform.Value && rootTransform.Value)
        {
            moveDirection.Value = (targetTransform.Value.position - rootTransform.Value.position).normalized;
        }
    }
}