using System;
using PresentationModel;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class ProgressBarView : MonoBehaviour
{
    [SerializeField] private BarView barView;
    [SerializeField] private TMP_Text text;

    [Button]
    public void ShowExperience(int currentExperience, int nextLevelExperience)
    {
        text.text = $"XP:{Math.Min(currentExperience, nextLevelExperience)}/{nextLevelExperience}";
        barView.SetValue((float)currentExperience/nextLevelExperience);
    }
}
