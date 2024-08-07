
using System;
using Lessons.Architecture.PM;
using UnityEngine;
using VContainer;

[Serializable]
public class AvaPresenter
{
    private AvaView _avaView;
    private UserInfo _userInfo;
    private HeroPopupPresenter _heroPopupPresenter;

    [Inject]
    public AvaPresenter(AvaView avaView, UserInfo userInfo, HeroPopupPresenter heroPopupPresenter)

    {
        _avaView = avaView;
        _userInfo = userInfo;
        _userInfo.OnIconChanged += OnIconChanged;
        _heroPopupPresenter = heroPopupPresenter;
        _heroPopupPresenter.OnShow += UpdateAva;
    }

    private void OnIconChanged(Sprite newIcon)
    {
        Debug.Log("ChangingAva");
        _avaView.ShowAva(newIcon);
    }

    private void UpdateAva()
    {
        _avaView.ShowAva(_userInfo.Icon);
    }

    ~AvaPresenter()
    {
        _userInfo.OnIconChanged -= OnIconChanged; 
        _heroPopupPresenter.OnShow -= UpdateAva;
    }
}
