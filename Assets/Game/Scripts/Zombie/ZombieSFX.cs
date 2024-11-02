using System;
using UnityEngine;

[Serializable]
public class ZombieSFX
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip takeDamageClip;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip moveClip;
    
    public void Construct(ZombieCore zombieCore)
    {
        zombieCore.lifeComponent.TakeDamageAction.Subscribe(OnTakeDamage);
        zombieCore.lifeComponent.isDead.Subscribe(OnIsDeadChanged);
        zombieCore.moveComponent.moveDirection.Subscribe(OnMoveDirectionChanged);
    }
    
    private void OnMoveDirectionChanged(Vector3 moveDirectiom)
    {
        var isMoving = moveDirectiom.sqrMagnitude > 0;
        audioSource.clip = moveClip;
        if (!isMoving)
        {
            audioSource.Stop();
            return;
        }
        
        if (isMoving && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }

    private void OnTakeDamage(int obj)
    {
        audioSource.PlayOneShot(takeDamageClip);
    }
    
    private void OnIsDeadChanged(bool value)
    {
        if(!value) return;
        audioSource.PlayOneShot(deathClip);
    }
}