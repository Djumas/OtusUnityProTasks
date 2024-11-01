using System;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class MoveForwardController : IAtomicEnable
{
    [SerializeField] private AtomicObject bullet;
    [SerializeField] private Transform root;

    public void Enable()
    {
        bullet.GetVariable<Vector3>(MoveAPI.MoveDirection).Value = root.forward;
    }
}
