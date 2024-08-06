using System.Collections.Generic;
using System.Linq;
using Lessons.Architecture.PM;
using PresentationModel;
using Sirenix.OdinInspector;
using UnityEngine;

public class StatsBlockView : MonoBehaviour
{
    [SerializeField] private StatView[] statViews;

    [Button]
    public void ShowStats(CharacterStat[] stats)
    {
        foreach (var statView in statViews)
        {
            statView.gameObject.SetActive(false);
        }
        for (int i = 0; i < stats.Length; i++)
        {
            if (i >= statViews.Length)
            {
                Debug.LogWarning("Stats count exceeds stat block capacity");
                return;
            }
            statViews[i].ShowStat(stats[i].Name,stats[i].Value);
            statViews[i].gameObject.SetActive(true);
        }
    }
}
