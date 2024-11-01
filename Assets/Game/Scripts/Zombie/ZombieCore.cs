using System;
using Atomic.Objects;
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
    
    public UnitDeathController unitDeathController;

    public void Construct(Zombie zombie)
    {
        lifeComponent.Construct();
        lookAtTargetMechanics.Construct(zombie._rotationDirection, zombie._rootTransform, zombie._targetTransform);
        pursueTargetMechanics.Construct(zombie._moveDirection, zombie._targetTransform, zombie._rootTransform);
        zombieAIController.Construct( pursueTargetMechanics.isEnabled, cooldownMeleeAttackMechanics.isEnabled, zombie._isDead, zombie._targetTransform, zombie._rootTransform);
        cooldownMeleeAttackMechanics.Construct(doDamageMechanics, zombie._target, attackParametersComponent.damage, attackParametersComponent.coolDown);
        unitDeathController.Construct(lifeComponent.isDead,zombie);
        

        zombie.AddLogic(zombieAIController);
        zombie.AddLogic(moveComponent);
        zombie.AddLogic(rotationComponent);
        zombie.AddLogic(seekTargetComponent);
        zombie.AddLogic(lookAtTargetMechanics);
        zombie.AddLogic(pursueTargetMechanics);
        zombie.AddLogic(cooldownMeleeAttackMechanics);

        lookAtTargetMechanics.isEnabled.Value = true;
        
        zombie._isDead.Subscribe(OnDeath);
    }
    
    private void OnDeath(bool value)
    {
        lookAtTargetMechanics.isEnabled.Value = false;
    }
}
