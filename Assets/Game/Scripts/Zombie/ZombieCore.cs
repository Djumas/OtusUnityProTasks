using System;
using UnityEngine;

[Serializable]
public class ZombieCore
{
    public ZombieAIController zombieAIController;
    
    public MoveComponent moveComponent;
    public RotationComponent rotationComponent;
    public LifeComponent lifeComponent;
    public RootTransformComponent rootTransformComponent;
    public SeekTargetComponent seekTargetComponent;
    public AttackParametersComponent attackParametersComponent;
    
    public LookAtTargetMechanics lookAtTargetMechanics;
    public PursueTargetMechanics pursueTargetMechanics;
    public DoDamageMechanics doDamageMechanics;
    public CooldownMeleeAttackMechanics cooldownMeleeAttackMechanics;
}
