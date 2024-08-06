using System;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;
using Random = UnityEngine.Random;


[CreateAssetMenu(fileName = "CharacterSO", menuName = "ScriptableObjects/CharacterSO", order = 1)]
[Serializable]
public class CharacterSO : ScriptableObject
{
     public UserInfo userInfo = new();
     public CharacterInfo characterInfo = new();
     public PlayerLevel playerLevel = new();

     [Button]
     public void AddStat(StatType statName, int value)
     {
          var stat = new CharacterStat(statName.ToString());
          stat.ChangeValue(value);
          characterInfo.AddStat(stat);
     }
     
     [Button]
     public void SetRandomStats()
     {
          characterInfo = new CharacterInfo();
          
          var statTypes = Enum.GetValues(typeof(StatType));
          foreach (var statType in statTypes)
          {
               var stat = new CharacterStat(statType.ToString());
               stat.ChangeValue(Random.Range(0,100));
               characterInfo.AddStat(stat);
          }
     }
}

public enum StatType
{
     MoveSpeed,
     Stamina,
     Dexterity,
     Intelligence,
     Damage,
     Regeneration
}

