using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class NicknameView : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [Button]
    public void ShowNickname(string name)
    {
        text.text = name;
    }
}
