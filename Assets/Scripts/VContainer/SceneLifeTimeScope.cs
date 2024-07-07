using ShootEmUp;
using VContainer;
using VContainer.Unity;


public class SceneLifeTimeScope: LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<GameManager>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<BulletPool>().AsSelf();
        builder.RegisterComponentInHierarchy<LevelBounds>().AsSelf();
        builder.RegisterComponentInHierarchy<EnemyPool>().AsSelf();
        builder.RegisterComponentInHierarchy<EnemySpawnController>().AsSelf();
        builder.Register<InputSystem>(Lifetime.Scoped).AsSelf();
        builder.Register<BulletSpawnSystem>(Lifetime.Scoped).AsSelf();
    }
}
