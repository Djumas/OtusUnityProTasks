using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Unity.Collections;
using UnityEngine;

public class Zombie : AtomicObject
{
    [Get(MoveAPI.MoveDirection)]
    public AtomicVariable<Vector3> _moveDirection => zombieCore.moveComponent.moveDirection;

    [Get(MoveAPI.RotationDirection)]
    public AtomicVariable<Vector3> _rotationDirection => zombieCore.rotationComponent.rotationDirection;

    [Get(LifeAPI.TakeDamageAction)]
    public AtomicEvent<int> _takeDamageAction => zombieCore.lifeComponent.TakeDamageAction;

    [Get(LifeAPI.IsDead)] public AtomicVariable<bool> _isDead => zombieCore.lifeComponent.isDead;

    [Get(MoveAPI.RootTransform)]
    public AtomicVariable<Transform> _rootTransform => zombieCore.rootTransformComponent.rootTransform;

    [Get(AttackAPI.Target)] public AtomicVariable<AtomicObject> _target => zombieCore.seekTargetComponent.target;

    [Get(AttackAPI.TargetTransform)]
    public AtomicVariable<Transform> _targetTransform => zombieCore.seekTargetComponent.targetTransform;

    [SerializeField] private ZombieCore zombieCore;
    [SerializeField] private ZombieAnimation zombieAnimation;
    [SerializeField] private ZombieVFX zombieVFX;

    private void Awake()
    {
        zombieCore.Construct(this);
        zombieAnimation.Construct(zombieCore);
        zombieVFX.Construct(zombieCore);
    }

    private void Update()
    {
        OnUpdate(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        OnFixedUpdate(Time.fixedDeltaTime);
    }
}