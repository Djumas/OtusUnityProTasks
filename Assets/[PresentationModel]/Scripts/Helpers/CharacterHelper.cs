using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


public class CharacterHelper : MonoBehaviour
{
    [SerializeField] private Character currentCharacter;

    [Button]
    public void LoadCharacter(CharacterSO loadedCharacter)
    {
        currentCharacter.SetCharacterInfo(loadedCharacter.characterInfo);
        currentCharacter.SetPlayerLevel(loadedCharacter.playerLevel);
        currentCharacter.SetUserInfo(loadedCharacter.userInfo);
    }
}
