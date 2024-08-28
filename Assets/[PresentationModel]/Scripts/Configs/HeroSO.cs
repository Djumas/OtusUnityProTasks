using System;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "HeroSO", menuName = "ScriptableObjects/HeroSO", order = 1)]
public class HeroSO : ScriptableObject
{
   public string nickName;
   public string description;
   public Sprite icon;
   public int level;
   public int experience;
   [SerializeField] public CharacterStat[] characterStats;

   [Button]
   public void AddRandomStats()
   {
      var characterStatsList = new List<CharacterStat>();
      var statTypes = Enum.GetValues(typeof(StatType));
      foreach (var statType in statTypes)
      {
         var stat = new CharacterStat(statType.ToString());
         stat.ChangeValue(Random.Range(0, 100));
         characterStatsList.Add(stat);
      }
      characterStats = characterStatsList.ToArray();
   }
}
