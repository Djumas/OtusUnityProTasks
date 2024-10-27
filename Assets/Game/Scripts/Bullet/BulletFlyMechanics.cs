using System;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class BulletFlyMechanics : IAtomicUpdate
{
    [SerializeField] private AtomicObject bullet;
    [SerializeField] private Transform root;

    public void OnUpdate(float deltaTime)
    {
        bullet.GetVariable<Vector3>(MoveAPI.MoveDirection).Value = root.forward;
    }
}
