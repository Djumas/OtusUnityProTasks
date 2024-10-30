using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

[Serializable]
public class PlayerCore
{
    public MoveComponent moveComponent;
    public RotationComponent rotationComponent;
    public ShootComponent shootComponent;
    public LifeComponent lifeComponent;
    public RootTransformComponent rootTransformComponent;

    public PlayerDeathController playerDeathController;

    public void Construct(Player player)
    {
        shootComponent.Construct();
        lifeComponent.Construct();
        playerDeathController.Construct(lifeComponent.isDead,player);
        
        player.AddLogic(moveComponent);
        player.AddLogic(rotationComponent);
        player.AddLogic(shootComponent);
    }
}