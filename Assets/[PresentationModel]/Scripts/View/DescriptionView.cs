using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class DescriptionView : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [Button]
    public void ShowDescription(string description)
    {
        text.text = description;
    }
}
