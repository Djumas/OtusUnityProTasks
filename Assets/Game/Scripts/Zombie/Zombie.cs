using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

public class Zombie : AtomicObject
{
    [Get(MoveAPI.MoveDirection)] public AtomicVariable<Vector3> _moveDirection => zombieCore.moveComponent.moveDirection;
    [Get(MoveAPI.RotationDirection)] public AtomicVariable<Vector3> _rotationDirection => zombieCore.rotationComponent.rotationDirection;
    [Get(LifeAPI.TakeDamageAction)] public AtomicEvent<int> _takeDamageAction => zombieCore.lifeComponent.TakeDamageAction;
    
    [SerializeField] private ZombieCore zombieCore;

    private void Awake()
    {
        zombieCore.lifeComponent.Construct();
        
        AddLogic(zombieCore.moveComponent);
        AddLogic(zombieCore.rotationComponent);
    }

    void Update()
    {
        OnUpdate(Time.deltaTime);    
    }

    private void FixedUpdate()
    {
        OnFixedUpdate(Time.fixedDeltaTime);
    }
}
