using ShootEmUp;
using UnityEngine;
using VContainer;
using VContainer.Unity;


public class SceneLifeTimeScope: LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<GameManager>().AsImplementedInterfaces().AsSelf();
        builder.Register<InputSystem>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
        builder.Register<BulletSpawnSystem>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<BulletPool>().AsSelf();
        builder.RegisterComponentInHierarchy<LevelBounds>().AsSelf();
        builder.RegisterComponentInHierarchy<EnemyPool>().AsSelf();
        builder.RegisterComponentInHierarchy<EnemySpawnController>().AsSelf();
        builder.RegisterComponentInHierarchy<LevelBackground>().AsSelf().AsImplementedInterfaces();
    
        ConfigureListeners(builder);
    }

    private void ConfigureListeners(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<EnemyCoolDownSpawner>().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<CharacterHpObserver>().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<CharacterMoveController>().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<CharacterWeaponController>().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<MoveComponent>().AsImplementedInterfaces();
    }
}
