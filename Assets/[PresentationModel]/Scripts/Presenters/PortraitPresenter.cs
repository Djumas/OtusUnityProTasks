using System;
using Lessons.Architecture.PM;
using UnityEngine;

[Serializable]
public class PortraitPresenter
{
    private readonly PortraitView _portraitView;
    private readonly UserInfo _userInfo;

    public PortraitPresenter(PortraitView portraitView, UserInfo userInfo)

    {
        _portraitView = portraitView;
        _userInfo = userInfo;
        _userInfo.OnIconChanged += OnIconChanged;
    }

    private void OnIconChanged(Sprite newIcon)
    {
        Debug.Log("ChangingAva");
        _portraitView.ShowAva(newIcon);
    }

    public void Update()
    {
        _portraitView.ShowAva(_userInfo.Icon);
    }

    ~PortraitPresenter()
    {
        _userInfo.OnIconChanged -= OnIconChanged; 
    }
}
