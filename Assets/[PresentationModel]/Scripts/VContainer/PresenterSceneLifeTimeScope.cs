using VContainer;
using VContainer.Unity;

namespace PresentationModel
{
    public class PresenterSceneLifeTimeScope : SceneLifeTimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<Character>().AsSelf();
            builder.RegisterComponentInHierarchy<StatsBlockView>().AsSelf();
            builder.RegisterComponentInHierarchy<HeroPopupView>().AsSelf();
            builder.RegisterComponentInHierarchy<AvaView>().AsSelf();
            builder.RegisterComponentInHierarchy<DescriptionView>().AsSelf();
            builder.RegisterComponentInHierarchy<ProgressBarView>().AsSelf();
            builder.RegisterComponentInHierarchy<LevelView>().AsSelf();
            
            builder.Register<HeroPopupPresenter>(Lifetime.Scoped).AsSelf();
        }
    }
}

