using System;
using UnityEngine;

[Serializable]
public class PlayerAnimation
{
    private int _isMovingHash = Animator.StringToHash("isMoving");

    [SerializeField] private Animator _animator;

    public void Construct(PlayerCore core)
    {
        core.moveComponent.moveDirection.Subscribe(OnMoveDirectionChanged);
    }

    private void OnMoveDirectionChanged(Vector3 moveDirection)
    {
        var isMoving = moveDirection.sqrMagnitude > 0;
        _animator.SetBool(_isMovingHash,isMoving);
    }
}