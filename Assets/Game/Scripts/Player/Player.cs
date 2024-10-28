using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

public class Player : AtomicObject
{
    [Get(MoveAPI.MoveDirection)] public AtomicVariable<Vector3> _moveDirection => playerCore.moveComponent.moveDirection;
    [Get(MoveAPI.RotationDirection)] public AtomicVariable<Vector3> _rotationDirection => playerCore.rotationComponent.rotationDirection;
    [Get(ShootAPI.ShootRequest)] public AtomicEvent _shootRequest => playerCore.shootComponent.shootRequest;
    [Get(ShootAPI.ShootAction)] public AtomicEvent _shootAction => playerCore.shootComponent.shootAction;
    [Get(LifeAPI.TakeDamageAction)] public AtomicEvent<int> _takeDamageAction => playerCore.lifeComponent.TakeDamageAction;
    [Get(MoveAPI.RootTransform)] public AtomicVariable<Transform> _rootTransform => playerCore.rootTransformComponent.rootTransform;
    
    [SerializeField] private PlayerCore playerCore;

    private void Awake()
    {
        playerCore.shootComponent.Construct();
        playerCore.lifeComponent.Construct();
        
        AddLogic(playerCore.moveComponent);
        AddLogic(playerCore.rotationComponent);
        AddLogic(playerCore.shootComponent);
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
