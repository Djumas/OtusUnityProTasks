using GameEngine;
using VContainer;
using VContainer.Unity;

public class SaveLoaderSceneLifetimeScope : LifetimeScope 
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<UnitManager>(Lifetime.Scoped).AsSelf();
        builder.Register<ResourceService>(Lifetime.Scoped).AsSelf();
        builder.Register<SaveLoadManager>(Lifetime.Scoped).AsSelf();
        builder.Register<UnitSaveLoader>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.Register<ResourceSaveLoader>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.Register<SaveLoadEncryptorDecryptor>(Lifetime.Scoped).AsSelf();
    }
}
