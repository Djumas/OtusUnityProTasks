using Sirenix.OdinInspector;
using UnityEngine;

public class HeroPopupView : MonoBehaviour
{
    [Button]
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    
    [Button]
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
