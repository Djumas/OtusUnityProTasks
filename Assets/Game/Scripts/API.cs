using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class MoveAPI
{
    public const string MoveDirection = nameof(MoveDirection);
    public const string RotationDirection = nameof(RotationDirection);
    public const string RootTransform = nameof(RootTransform);
}

public class ShootAPI
{
    public const string ShootRequest = nameof(ShootRequest);
    public const string ShootAction = nameof(ShootAction);
}

public class LifeAPI
{
    public const string TakeDamageAction = nameof(TakeDamageAction);
    public const string DeathEvent = nameof(DeathEvent);
    public const string IsDead = nameof(IsDead);
}

public class AttackAPI
{
    public const string Target = nameof(Target);
    public const string TargetTransform = nameof(TargetTransform);
}
