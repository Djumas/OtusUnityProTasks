using System;
using UnityEngine;

[Serializable]
public class ZombieVFX
{
    [SerializeField] private ParticleSystem _damageVFX;
    
    public void Construct(ZombieCore core)
    {
        core.lifeComponent.TakeDamageAction.Subscribe(OnTakeDamage);
    }

    public void OnTakeDamage(int damage)
    {
        _damageVFX.Play();
    }
}