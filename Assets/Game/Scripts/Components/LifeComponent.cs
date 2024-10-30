using System;
using Atomic.Elements;
using UnityEngine;

[Serializable]
public class LifeComponent
{
    public AtomicEvent<int> TakeDamageAction;
    public AtomicVariable<bool> isDead;
    
    [SerializeField] private int currentHP;
 
    public void Construct()
    {
        TakeDamageAction.Subscribe(TakeDamage);
        isDead.Value = false;
    }

    private void TakeDamage(int damage)
    {
        if(isDead.Value) return;
        currentHP -= damage;
        if (currentHP <= 0)
        {
            isDead.Value = true;
        }
    }
}
