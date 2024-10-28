using System;
using Atomic.Elements;
using Atomic.Objects;

[Serializable]
public class DoDamageMechanics
{
    public void DoDamage(AtomicObject atomicObject, int damage)
    {
        atomicObject.Get<AtomicEvent<int>>(LifeAPI.TakeDamageAction).Invoke(damage);
    }
}