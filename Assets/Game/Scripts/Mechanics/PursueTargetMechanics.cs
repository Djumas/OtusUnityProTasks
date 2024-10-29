using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class PursueTargetMechanics : IAtomicUpdate
{
    public AtomicVariable<bool> isEnabled;
    [SerializeField, ReadOnly] private AtomicVariable<Vector3> moveDirection;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> targetTransform;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> rootTransform;
    

    public void Construct(AtomicVariable<Vector3> _moveDirection, AtomicVariable<Transform> _target,
        AtomicVariable<Transform> _root)
    {
        moveDirection = _moveDirection;
        targetTransform = _target;
        rootTransform = _root;
        
        isEnabled.Subscribe(OnEnableChanged);
    }


    public void OnEnableChanged(bool value)
    {
        if (!value) moveDirection.Value = Vector3.zero;

    }

    public void OnUpdate(float deltaTime)
    {
        if (!isEnabled.Value) return;
        
        if (targetTransform.Value && rootTransform.Value)
        {
            moveDirection.Value = (targetTransform.Value.position - rootTransform.Value.position).normalized;
        }
    }
}