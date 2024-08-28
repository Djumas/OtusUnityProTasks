using System;
using Lessons.Architecture.PM;
using UnityEngine;

public class NickNamePresenter
{
    private readonly UserInfo _userInfo;
    private readonly NicknameView _nicknameView;
    
    public NickNamePresenter(UserInfo userInfo, NicknameView nicknameView)
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

    public void Update()
    {
        _nicknameView.ShowNickname(_userInfo.Name);
    }

    ~NickNamePresenter()
    {
        _userInfo.OnNameChanged -= OnNameChanged;
    }
}
