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
        closeButton.onClick.AddListener(OnCloseButtonClickedHandler);
        levelUpButton.onClick.AddListener(OnLevelUpButtonClickedHandler);
    }

    private void OnCloseButtonClickedHandler()
    {
        OnCloseButtonClicked?.Invoke();
    }
    
    private void OnLevelUpButtonClickedHandler()
    {
        OnLevelUpButtonClicked?.Invoke();
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
        closeButton.onClick.RemoveListener(OnCloseButtonClickedHandler);
        levelUpButton.onClick.RemoveListener(OnLevelUpButtonClickedHandler);
    }
}
