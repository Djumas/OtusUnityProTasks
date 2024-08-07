using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class HeroPopupView : MonoBehaviour
{
    public Button closeButton;
    public Button levelUpButton;

    public event Action OnCloseButtonClicked;
    public event Action OnLevelUpButtonClicked;

    private void Awake()
    {
        closeButton.onClick.AddListener(OnCloseButtonClicked.Invoke);
        levelUpButton.onClick.AddListener(OnLevelUpButtonClicked.Invoke);
    }
    
    

    public void EnableLevelUpButton()
    {
        levelUpButton.interactable = true;
    }
    
    public void DisableLevelUpButton()
    {
        levelUpButton.interactable = false;
    }

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

    private void OnDestroy()
    {
        closeButton.onClick.RemoveListener(OnCloseButtonClicked.Invoke);
        levelUpButton.onClick.RemoveListener(OnLevelUpButtonClicked.Invoke);
    }
}
