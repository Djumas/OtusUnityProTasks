using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class ZombieAIController : IAtomicUpdate
{
    [SerializeField, ReadOnly] private AtomicVariable<bool> enablePursueTargetMechanics;
    [SerializeField, ReadOnly] private AtomicVariable<bool> enableAttackCooldownMechanics;
    
    //TODO: Implement attack behavior;
    [SerializeField, ReadOnly] private AtomicVariable<bool> isDead;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> targetTransform;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> rootTransform;
    [SerializeField] private float stoppingDistance = 1f;
    [SerializeField] private BehaviorState currentState = BehaviorState.Idle;

    public void Construct(
       AtomicVariable<bool> _enablePursueTargetMechanics,
       AtomicVariable<bool> _enableAttackCooldownMechanics,
        AtomicVariable<bool> _isDead,
        AtomicVariable<Transform> _targetTransform,
        AtomicVariable<Transform> _rootTransform)
    {
        enablePursueTargetMechanics = _enablePursueTargetMechanics;
        enableAttackCooldownMechanics = _enableAttackCooldownMechanics;
        isDead = _isDead;
        targetTransform = _targetTransform;
        rootTransform = _rootTransform;
    }

    public void OnUpdate(float deltaTime)
    {
        if (isDead.Value)
        {
            currentState = BehaviorState.Dead;
            enablePursueTargetMechanics.Value = false;
            enableAttackCooldownMechanics.Value = false;
        }
        
        if (currentState == BehaviorState.Dead) return;

        if (targetTransform.Value == null)
        {
            if (currentState != BehaviorState.Idle)
            {
                enablePursueTargetMechanics.Value = false;
                enableAttackCooldownMechanics.Value = false;
                currentState = BehaviorState.Idle;
            }
            return;
        }

        var distance = (targetTransform.Value.position - rootTransform.Value.position).magnitude;
        if (distance >= stoppingDistance)
        {
            if (currentState == BehaviorState.Pursue) return;
            currentState = BehaviorState.Pursue;
            enablePursueTargetMechanics.Value = true;
            enableAttackCooldownMechanics.Value = false;
        }
        else
        {
            currentState = BehaviorState.Attack;
            enablePursueTargetMechanics.Value = false;
            enableAttackCooldownMechanics.Value = true;
        }
    }
}

public enum BehaviorState
{
    Idle,
    Pursue,
    Attack,
    Dead
}