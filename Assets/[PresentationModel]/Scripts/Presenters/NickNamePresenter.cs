using System;
using Lessons.Architecture.PM;
using UnityEngine;
using VContainer;

public class NickNamePresenter
{
    private UserInfo _userInfo;
    private NicknameView _nicknameView;
    private HeroPopupPresenter _heroPopupPresenter;

    [Inject]
    private NickNamePresenter(UserInfo userInfo, NicknameView nicknameView, HeroPopupPresenter heroPopupPresenter)
    {
        _userInfo = userInfo;
        _userInfo.OnNameChanged += OnNameChanged;
        _nicknameView = nicknameView;
        _heroPopupPresenter = heroPopupPresenter;
        _heroPopupPresenter.OnShow += UpdateName;
    }

    private void OnNameChanged(String newName)
    {
        Debug.Log("Changing Name");
        _nicknameView.ShowNickname(newName);
    }

    private void UpdateName()
    {
        _nicknameView.ShowNickname(_userInfo.Name);
    }

    ~NickNamePresenter()
    {
        _userInfo.OnNameChanged -= OnNameChanged;
        _heroPopupPresenter.OnShow -= UpdateName;
    }
}
