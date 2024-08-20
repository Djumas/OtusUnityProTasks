using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class PresentersDebugHolder : MonoBehaviour
{
    [ShowInInspector] private HeroPopupPresenter _heroPopupPresenter;
    [ShowInInspector] private PortraitPresenter _portraitPresenter;
    [ShowInInspector] private PropertiesBlockPresenter _propertiesBlockPresenter;
    [ShowInInspector] private ProgressBarPresenter _progressBarPresenter;
    [ShowInInspector] private DescriptionPresenter _descriptionPresenter;
    [ShowInInspector] private NickNamePresenter _nickNamePresenter;
    [ShowInInspector] private LevelPresenter _levelPresenter;

    [Inject]
    public void Construct(HeroPopupPresenter heroPopupPresenter, PortraitPresenter portraitPresenter,
        PropertiesBlockPresenter propertiesBlockPresenter, ProgressBarPresenter progressBarPresenter,
        DescriptionPresenter descriptionPresenter, NickNamePresenter nickNamePresenter, LevelPresenter levelPresenter)
    {
        _heroPopupPresenter = heroPopupPresenter;
        _portraitPresenter = portraitPresenter;
        _propertiesBlockPresenter = propertiesBlockPresenter;
        _progressBarPresenter = progressBarPresenter;
        _descriptionPresenter = descriptionPresenter;
        _nickNamePresenter = nickNamePresenter;
        _levelPresenter = levelPresenter;
    }
}