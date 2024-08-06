using System;
using Lessons.Architecture.PM;
using UnityEngine;
using VContainer;

public class NickNamePresenter
{
    private UserInfo _userInfo;
    private NicknameView _nicknameView;

    [Inject]
    private NickNamePresenter(UserInfo userInfo, NicknameView nicknameView)
    {
        _userInfo = userInfo;
        _userInfo.OnNameChanged += OnNameChanged;
        _nicknameView = nicknameView;
    }

    private void OnNameChanged(String newName)
    {
        Debug.Log("Changing Name");
        _nicknameView.ShowNickname(newName);
    }

    ~NickNamePresenter()
    {
        _userInfo.OnNameChanged -= OnNameChanged;
    }
}
