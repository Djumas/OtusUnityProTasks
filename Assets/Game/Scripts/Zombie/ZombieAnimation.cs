using System;
using UnityEngine;

[Serializable]
public class ZombieAnimation
{
    [SerializeField] private Animator _animator;

    private int _isMovingHash = Animator.StringToHash("isMoving");
    private int _takeDamageHash = Animator.StringToHash("TakeDamage");
    private int _isDeadHash = Animator.StringToHash("IsDead");
    private int _AttackHash = Animator.StringToHash("Attack");
    
    public void Construct(ZombieCore core)
    {
        core.moveComponent.moveDirection.Subscribe(OnMoveDirectionChanged);
        core.lifeComponent.TakeDamageAction.Subscribe(OnTakeDamage);
        core.lifeComponent.isDead.Subscribe(OnIsDeadChanged);
        core.cooldownMeleeAttackMechanics.attackEvent.Subscribe(OnAttack);
    }

    private void OnAttack()
    {
        _animator.SetTrigger(_AttackHash);
    }

    private void OnMoveDirectionChanged(Vector3 moveDirection)
    {
        var isMoving = moveDirection.sqrMagnitude > 0;
        _animator.SetBool(_isMovingHash,isMoving);
    }
    
    private void OnTakeDamage(int damage)
    {
        _animator.SetTrigger(_takeDamageHash);
    }
    
    private void OnIsDeadChanged(bool isDead)
    {
        _animator.SetBool(_isDeadHash,isDead);
    }

}