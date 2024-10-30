using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class SeekTargetComponent : IAtomicUpdate
{
    public AtomicVariable<AtomicObject> target;
    public AtomicVariable<Transform> targetTransform;

    public void OnUpdate(float deltaTime)
    {
        SeekTarget();
    }

    private void SeekTarget()
    {
        if (target.Value && targetTransform.Value)
        {
            var playerIsDead = target.Value.Get<AtomicVariable<bool>>(LifeAPI.IsDead).Value;
            if(!playerIsDead) return;
        }
        
        var targetGO = GameObject.FindGameObjectWithTag("Player");
        
        if (targetGO)
        {
            target.Value = targetGO.GetComponent<AtomicObject>();
            var playerIsDead = target.Value.Get<AtomicVariable<bool>>(LifeAPI.IsDead).Value;
            if (playerIsDead)
            {
                target.Value = null;
                targetTransform.Value = null;
                return;  
            } 
            targetTransform.Value = target.Value.Get<AtomicVariable<Transform>>(MoveAPI.RootTransform).Value;
            if(!targetTransform.Value) Debug.LogWarning("No root transform found");
        }
        else
        {
            Debug.LogWarning("No Player found");
        }  
    }
}