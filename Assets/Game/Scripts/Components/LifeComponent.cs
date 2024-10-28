using System;
using Atomic.Elements;
using UnityEngine;

[Serializable]
public class LifeComponent
{
    [SerializeField] private int currentHP;
    
    public AtomicEvent<int> TakeDamageAction;
    public AtomicEvent DeathEvent;
    public AtomicVariable<bool> isDead;

    public void Construct()
    {
        TakeDamageAction.Subscribe(TakeDamage);
        isDead.Value = false;
    }

    private void TakeDamage(int damage)
    {
        if(isDead.Value) return;
        Debug.Log("Damage done");
        currentHP -= damage;
        if (currentHP <= 0)
        {
            DeathEvent.Invoke();
            isDead.Value = true;
        }
    }
}
