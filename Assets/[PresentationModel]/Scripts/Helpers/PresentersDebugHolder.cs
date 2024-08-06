using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class PresentersDebugHolder : MonoBehaviour
{
    [ShowInInspector] private HeroPopupPresenter _heroPopupPresenter;
    [ShowInInspector] private AvaPresenter _avaPresenter;
    [ShowInInspector] private StatsBlockPresenter _statsBlockPresenter;
    [ShowInInspector] private ProgressBarPresenter _progressBarPresenter;
    [ShowInInspector] private DescriptionPresenter _descriptionPresenter;
    [ShowInInspector] private NickNamePresenter _nickNamePresenter;

    [Inject]
    public void Construct(HeroPopupPresenter heroPopupPresenter, AvaPresenter avaPresenter,
        StatsBlockPresenter statsBlockPresenter, ProgressBarPresenter progressBarPresenter,
        DescriptionPresenter descriptionPresenter, NickNamePresenter nickNamePresenter)
    {
        _heroPopupPresenter = heroPopupPresenter;
        _avaPresenter = avaPresenter;
        _statsBlockPresenter = statsBlockPresenter;
        _progressBarPresenter = progressBarPresenter;
        _descriptionPresenter = descriptionPresenter;
        _nickNamePresenter = nickNamePresenter;
    }
}