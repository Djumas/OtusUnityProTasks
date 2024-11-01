using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class PlayerCore
{
    public MoveComponent moveComponent;
    public RotationComponent rotationComponent;
    public ShootComponent shootComponent;
    public LifeComponent lifeComponent;
    public RootTransformComponent rootTransformComponent;

    public UnitDeathController unitDeathController;

    public void Construct(Player player)
    {
        shootComponent.Construct();
        lifeComponent.Construct();
        unitDeathController.Construct(lifeComponent.isDead,player);
        
        player.AddLogic(moveComponent);
        player.AddLogic(rotationComponent);
        player.AddLogic(shootComponent);
    }
}