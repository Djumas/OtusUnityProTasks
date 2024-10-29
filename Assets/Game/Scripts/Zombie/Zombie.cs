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

    private void Awake()
    {
        //TODO: Перенести логику Core в соответствующий слой
        
        zombieCore.lifeComponent.Construct();
        zombieCore.lookAtTargetMechanics.Construct(_rotationDirection, _rootTransform, _targetTransform);
        zombieCore.pursueTargetMechanics.Construct(_moveDirection, _targetTransform, _rootTransform);
        
        zombieCore.zombieAIController.Construct(
            zombieCore.pursueTargetMechanics.isEnabled,
            zombieCore.cooldownMeleeAttackMechanics.isEnabled, 
            _isDead, 
            _targetTransform,
            _rootTransform);
        
        zombieCore.cooldownMeleeAttackMechanics.Construct(
            zombieCore.doDamageMechanics, 
            _target, 
            zombieCore.attackParametersComponent.damage,
            zombieCore.attackParametersComponent.coolDown);

        AddLogic(zombieCore.zombieAIController);
        AddLogic(zombieCore.moveComponent);
        AddLogic(zombieCore.rotationComponent);
        AddLogic(zombieCore.seekTargetComponent);
        AddLogic(zombieCore.lookAtTargetMechanics);
        AddLogic(zombieCore.pursueTargetMechanics);
        AddLogic(zombieCore.cooldownMeleeAttackMechanics);

        zombieCore.lookAtTargetMechanics.isEnabled.Value = true;
        
        _isDead.Subscribe(OnDeath);
    }

    private void OnDeath(bool value)
    {
        zombieCore.lookAtTargetMechanics.isEnabled.Value = false;
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