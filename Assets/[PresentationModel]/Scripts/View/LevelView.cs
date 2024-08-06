using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [Button]
    public void ShowLevel(int level)
    {
        text.text = $"Level:{level}";
    }
}
