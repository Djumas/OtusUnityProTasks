using System.Collections;
using System.Collections.Generic;
using GameEngine;
using UnityEngine;
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

        /*
        builder.RegisterComponentInHierarchy<HeroPopupView>().AsSelf();

        builder.Register<CharacterInfo>(Lifetime.Scoped).AsSelf();
        builder.Register<UserInfo>(Lifetime.Scoped).AsSelf();
        builder.Register<PlayerLevel>(Lifetime.Scoped).AsSelf();

        builder.Register<HeroPopupPresenter>(Lifetime.Scoped).AsSelf();*/
    }
}
