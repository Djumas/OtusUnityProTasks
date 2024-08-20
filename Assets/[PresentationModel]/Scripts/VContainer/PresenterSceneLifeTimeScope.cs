using Lessons.Architecture.PM;
using VContainer;
using VContainer.Unity;

namespace PresentationModel
{
    public class PresenterSceneLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<HeroPopupView>().AsSelf();
            
            builder.Register<CharacterInfo>(Lifetime.Scoped).AsSelf();
            builder.Register<UserInfo>(Lifetime.Scoped).AsSelf();
            builder.Register<PlayerLevel>(Lifetime.Scoped).AsSelf();
           
            builder.Register<HeroPopupPresenter>(Lifetime.Scoped).AsSelf();
        }
    }
}

