using System;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using Random = UnityEngine.Random;

public class CharacterInfoHelper : MonoBehaviour
{
    public CharacterInfo characterInfo;

    [Inject]
    public void Construct(CharacterInfo mCharacterInfo)
    {
        this.characterInfo = mCharacterInfo;
    }

    [Button]
    public void AddStat(StatType statName, int value)
    {
        var stat = new CharacterStat(statName.ToString());
        stat.ChangeValue(value);
        characterInfo.AddStat(stat);
    }
    
    [Button]
    public void RemoveStat(StatType statName)
    {
        var stat = characterInfo.GetStat(statName.ToString());
        characterInfo.RemoveStat(stat);
    }

    [Button]
    public void AddRandomStats()
    {
        var statTypes = Enum.GetValues(typeof(StatType));
        foreach (var statType in statTypes)
        {
            var stat = new CharacterStat(statType.ToString());
            stat.ChangeValue(Random.Range(0, 100));
            
            characterInfo.AddStat(stat);
        }
    }
}