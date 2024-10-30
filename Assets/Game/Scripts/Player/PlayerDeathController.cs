using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class PlayerDeathController
{
    [SerializeField, ReadOnly] private AtomicObject player;
    
    public void Construct(AtomicVariable<bool> isDead, AtomicObject _player)
    {
        isDead.Subscribe(OnDeath);
        player = _player;
    }

    private void OnDeath(bool isDeadValue)
    {
        if (isDeadValue)
        {
            player.RemoveAllLogic<IAtomicLogic>();
        }
    }
}