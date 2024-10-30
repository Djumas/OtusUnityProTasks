using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

public class Player : AtomicObject
{
    [Get(MoveAPI.MoveDirection)] public AtomicVariable<Vector3> _moveDirection => playerCore.moveComponent.moveDirection;
    [Get(MoveAPI.RotationDirection)] public AtomicVariable<Vector3> _rotationDirection => playerCore.rotationComponent.rotationDirection;
    [Get(MoveAPI.RootTransform)] public AtomicVariable<Transform> _rootTransform => playerCore.rootTransformComponent.rootTransform;
    [Get(ShootAPI.ShootRequest)] public AtomicEvent _shootRequest => playerCore.shootComponent.shootRequest;
    [Get(ShootAPI.ShootAction)] public AtomicEvent _shootAction => playerCore.shootComponent.shootAction;
    [Get(LifeAPI.TakeDamageAction)] public AtomicEvent<int> _takeDamageAction => playerCore.lifeComponent.TakeDamageAction;
    [Get(LifeAPI.IsDead)] public AtomicVariable<bool> _isDead => playerCore.lifeComponent.isDead;
    
    
    [SerializeField] private PlayerCore playerCore;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private PlayerVFX playerVFX;

    private void Awake()
    {
        playerCore.Construct(this);
        playerAnimation.Construct(playerCore);
        playerVFX.Construct(playerCore);
    }

    private void FixedUpdate()
    {
        OnFixedUpdate(Time.fixedDeltaTime);
    }
    
    private void Update()
    {
        OnUpdate(Time.deltaTime);
    }
}
