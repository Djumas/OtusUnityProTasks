using System;
using Atomic.Elements;
using UnityEngine;

[Serializable]
public class LifeComponent
{
    [SerializeField] private int currentHP;
    
    public AtomicEvent<int> TakeDamageAction;
    public AtomicEvent DeathEvent;

    public void Construct()
    {
        TakeDamageAction.Subscribe(TakeDamage);
    }

    private void TakeDamage(int damage)
    {
        Debug.Log("Damage done");
        currentHP -= damage;
        if (currentHP <= 0)
        {
            DeathEvent.Invoke();
        }
    }
}
