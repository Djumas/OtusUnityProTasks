using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

public class HeroLoader : MonoBehaviour
{
    [SerializeField] private HeroSO heroSO;
    
    private CharacterInfo _characterInfo;
    private UserInfo _userInfo;
    private PlayerLevel _playerLevel;
    
    [Inject]
    public void Construct(CharacterInfo characterInfo, UserInfo userInfo, PlayerLevel playerLevel)
    {
        _characterInfo = characterInfo;
        _playerLevel = playerLevel;
        _userInfo = userInfo;
    }

    [Button]
    public void LoadHero()
    {
        _userInfo.ChangeName(heroSO.nickName);
        _userInfo.ChangeDescription(heroSO.description);
        _userInfo.ChangeIcon(heroSO.icon);

        foreach (var characterStat in heroSO.characterStats)
        {
            _characterInfo.AddStat(characterStat);
        }
        
        _playerLevel.SetLoadedLevel(heroSO.level);
        _playerLevel.SetLoadedExperience(heroSO.experience);
    }


}
