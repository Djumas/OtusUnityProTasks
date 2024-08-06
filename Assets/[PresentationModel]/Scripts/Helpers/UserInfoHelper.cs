using System.Collections;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using CharacterInfo = UnityEngine.CharacterInfo;

public class UserInfoHelper : MonoBehaviour
{
    [ShowInInspector] private UserInfo _userInfo;

    [Inject]
    public void Construct(UserInfo userInfo)
    {
        _userInfo = userInfo;
    }
}
