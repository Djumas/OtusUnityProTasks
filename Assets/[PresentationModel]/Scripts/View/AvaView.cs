using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class AvaView : MonoBehaviour
{
    [SerializeField] private Image heroAva;

    [Button]
    public void ShowAva(Sprite newAva)
    {
        heroAva.sprite = newAva;
    }
}
