using System;
using UnityEngine;

[Serializable]
public class PlayerVFX
{
    [SerializeField] private ParticleSystem _damageVFX;
    [SerializeField] private ParticleSystem _shootVFX;
    
    public void Construct(PlayerCore core)
    {
        core.lifeComponent.TakeDamageAction.Subscribe(OnTakeDamage);
        core.shootComponent.shootAction.Subscribe(OnShoot);
    }

    public void OnTakeDamage(int damage)
    {
        _damageVFX.Play();
    }
    
    public void OnShoot()
    {
        _shootVFX.Play();
    }
}