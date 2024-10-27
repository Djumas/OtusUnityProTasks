using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class DoDamageMechanics
{
    [SerializeField] private int damage;

    public void DoDamage(AtomicObject atomicObject)
    {
        atomicObject.Get<AtomicEvent<int>>(LifeAPI.TakeDamageAction).Invoke(damage);
    }
}