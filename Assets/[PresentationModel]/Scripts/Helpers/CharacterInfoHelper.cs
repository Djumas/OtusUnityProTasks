using System;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

public class CharacterInfoHelper : MonoBehaviour
{
    [ShowInInspector] public CharacterInfo _characterInfo;

    [Inject]
    public void Construct(CharacterInfo characterInfo)
    {
        _characterInfo = characterInfo;
    }

    [Button]
    public void AddStat(StatType statName, int value)
    {
        var stat = new CharacterStat(statName.ToString());
        stat.ChangeValue(value);
        _characterInfo.AddStat(stat);
    }
    
    [Button]
    public void RemoveStat(StatType statName)
    {
        var stat = _characterInfo.GetStat(statName.ToString());
        _characterInfo.RemoveStat(stat);
    }

    [Button]
    public void AddRandomStats()
    {
        var statTypes = Enum.GetValues(typeof(StatType));
        foreach (var statType in statTypes)
        {
            var stat = new CharacterStat(statType.ToString());
            stat.ChangeValue(Random.Range(0, 100));
            
            _characterInfo.AddStat(stat);
        }
    }
}