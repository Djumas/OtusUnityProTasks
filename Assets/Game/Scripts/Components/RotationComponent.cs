using System;
using System.Collections;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class RotationComponent : IAtomicUpdate
{
    public AtomicVariable<Vector3> rotationDirection;
    [SerializeField] private Transform root;
    [SerializeField] private bool enable = true;
    
    public void OnUpdate(float deltaTime)
    {
        if (enable)
        {
            if (rotationDirection.Value == Vector3.zero) return;
            var rotation = Quaternion.LookRotation(rotationDirection.Value, Vector3.up);
            root.rotation = rotation;
        }
    }
}
