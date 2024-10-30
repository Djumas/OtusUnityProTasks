using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : AtomicObject
{
    [Get(MoveAPI.MoveDirection)] public AtomicVariable<Vector3> _moveDirection => _moveComponent.moveDirection;
    [Get(ShootAPI.BulletDamage)] public AtomicVariable<int> damage;
    [Get(MoveAPI.MoveSpeed)] public AtomicVariable<float> speed => _moveComponent.speed;

    [SerializeField] private MoveComponent _moveComponent;
    [SerializeField] private MoveForwardController moveForwardController;
    

    private readonly DoDamageMechanics _doDamageMechanics = new();


    private void Awake()
    {
        AddLogic(_moveComponent);
        AddLogic(moveForwardController);
    }

    private void Update()
    {
        OnUpdate(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        OnFixedUpdate(Time.fixedDeltaTime);
    }

    private void OnEnable()
    {
        Enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        var atomicObject = other.GetComponent<AtomicObject>();
        if (atomicObject)
        {
            var isDeadVariable = atomicObject.GetVariable<bool>(LifeAPI.IsDead);
            if (isDeadVariable != null)
            {
                if (atomicObject.GetVariable<bool>(LifeAPI.IsDead).Value) return;
                _doDamageMechanics.DoDamage(atomicObject, damage.Value);
            }
        }
        else Destroy(gameObject);
    }
}