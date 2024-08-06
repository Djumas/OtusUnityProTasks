using Lessons.Architecture.PM;
using VContainer;
using VContainer.Unity;

namespace PresentationModel
{
    public class PresenterSceneLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<StatsBlockView>().AsSelf();
            builder.RegisterComponentInHierarchy<HeroPopupView>().AsSelf();
            builder.RegisterComponentInHierarchy<AvaView>().AsSelf();
            builder.RegisterComponentInHierarchy<DescriptionView>().AsSelf();
            builder.RegisterComponentInHierarchy<ProgressBarView>().AsSelf();
            builder.RegisterComponentInHierarchy<LevelView>().AsSelf();
            builder.RegisterComponentInHierarchy<NicknameView>().AsSelf();
            
            builder.Register<CharacterInfo>(Lifetime.Scoped).AsSelf();
            builder.Register<UserInfo>(Lifetime.Scoped).AsSelf();
            builder.Register<PlayerLevel>(Lifetime.Scoped).AsSelf();
           
            builder.Register<HeroPopupPresenter>(Lifetime.Scoped).AsSelf();
            builder.Register<StatsBlockPresenter>(Lifetime.Scoped).AsSelf();
            builder.Register<AvaPresenter>(Lifetime.Scoped).AsSelf();
            builder.Register<DescriptionPresenter>(Lifetime.Scoped).AsSelf();
            builder.Register<ProgressBarPresenter>(Lifetime.Scoped).AsSelf();
            builder.Register<NickNamePresenter>(Lifetime.Scoped).AsSelf();

        }
    }
}
