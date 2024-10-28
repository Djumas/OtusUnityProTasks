using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class ZombieAIController : IAtomicUpdate
{
    [SerializeField, ReadOnly] private AtomicObject atomicObject;
    [SerializeField, ReadOnly] private PursueTargetMechanics pursueTargetMechanics;
    //TODO: Implement attack behavior;
    [SerializeField, ReadOnly] private AtomicVariable<bool> isDead;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> targetTransform;
    [SerializeField, ReadOnly] private AtomicVariable<Transform> rootTransform;
    [SerializeField] private float stoppingDistance = 1f;
    [SerializeField] private float attackCoolDown = 1f;
    [SerializeField] private BehaviorState currentState = BehaviorState.Idle;

    public void Construct(
        AtomicObject _atomicObject,
        PursueTargetMechanics _pursueTargetMechanics,
        AtomicVariable<bool> _isDead,
        AtomicVariable<Transform> _targetTransform,
        AtomicVariable<Transform> _rootTransform)
    {
        atomicObject = _atomicObject;
        pursueTargetMechanics = _pursueTargetMechanics;
        isDead = _isDead;
        targetTransform = _targetTransform;
        rootTransform = _rootTransform;
    }

    public void OnUpdate(float deltaTime)
    {
        if (isDead.Value)
        {
            currentState = BehaviorState.Dead;
            pursueTargetMechanics.Stop();
        }
        
        if (currentState == BehaviorState.Dead) return;

        if (targetTransform.Value == null)
        {
            if (currentState != BehaviorState.Idle)
            {
                pursueTargetMechanics.Stop();
                currentState = BehaviorState.Idle;
            }
            return;
        }

        var distance = (targetTransform.Value.position - rootTransform.Value.position).magnitude;
        if (distance >= stoppingDistance)
        {
            if (currentState == BehaviorState.Pursue) return;
            currentState = BehaviorState.Pursue;
            pursueTargetMechanics.Start();
        }
        else
        {
            currentState = BehaviorState.Attack;
            pursueTargetMechanics.Stop();
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