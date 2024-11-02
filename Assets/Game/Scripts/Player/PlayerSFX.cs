using System;
using Atomic.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class PlayerSFX
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip takeDamageClip;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip moveClip;
    public void Construct(PlayerCore playerCore)
    {
        playerCore.lifeComponent.TakeDamageAction.Subscribe(OnTakeDamage);
        playerCore.lifeComponent.isDead.Subscribe(OnIsDeadChanged);
        playerCore.shootComponent.shootAction.Subscribe(OnShoot);
        playerCore.moveComponent.moveDirection.Subscribe(OnMoveDirectionChanged);
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
    
    private void OnShoot()
    {
        audioSource.PlayOneShot(shootClip);
    }
    
    
}