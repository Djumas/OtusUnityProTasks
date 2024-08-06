using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace PresentationModel
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        [Button]
        public void ShowStat(string statName, int value)
        {
            text.text = $"{statName}:{value}";
        }
    }
}

