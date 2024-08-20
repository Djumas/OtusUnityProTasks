
using System;
using Lessons.Architecture.PM;
using UnityEngine;
using VContainer;

[Serializable]
public class AvaPresenter
{
    private PortraitView _portraitView;
    private UserInfo _userInfo;
    private HeroPopupPresenter _heroPopupPresenter;

    [Inject]
    public AvaPresenter(PortraitView portraitView, UserInfo userInfo, HeroPopupPresenter heroPopupPresenter)

    {
        _portraitView = portraitView;
        _userInfo = userInfo;
        _userInfo.OnIconChanged += OnIconChanged;
        _heroPopupPresenter = heroPopupPresenter;
        _heroPopupPresenter.OnShow += UpdateAva;
    }

    private void OnIconChanged(Sprite newIcon)
    {
        Debug.Log("ChangingAva");
        _portraitView.ShowAva(newIcon);
    }

    private void UpdateAva()
    {
        _portraitView.ShowAva(_userInfo.Icon);
    }

    ~AvaPresenter()
    {
        _userInfo.OnIconChanged -= OnIconChanged; 
        _heroPopupPresenter.OnShow -= UpdateAva;
    }
}
