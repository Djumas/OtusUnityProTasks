using System.Collections;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

public class Character : MonoBehaviour
{
    [ShowInInspector] private UserInfo _userInfo = new();
    [ShowInInspector] private CharacterInfo _characterInfo = new();
    [ShowInInspector] private PlayerLevel _playerLevel = new();

    
    
    public void SetCharacterInfo(CharacterInfo characterInfo)
    {
        _characterInfo = characterInfo;
    }
    
    public void SetUserInfo(UserInfo userInfo)
    {
        _userInfo = userInfo;
    }
    
    public void SetPlayerLevel(PlayerLevel playerLevel)
    {
        _playerLevel = playerLevel;
    }

    public CharacterInfo GetCharacterInfo()
    {
        return _characterInfo;
    }
    
    public UserInfo getUserInfo()
    {
        return _userInfo;
    }
    
    public PlayerLevel getPlayerLevel()
    {
        return _playerLevel;
    }
}
