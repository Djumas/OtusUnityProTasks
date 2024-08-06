using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class HeroPopupView : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button levelUpButton;

    public Action onCloseButtonClicked;
    public Action onLevelUpButtonClicked;

    private void Awake()
    {
        closeButton.onClick.AddListener(onCloseButtonClicked.Invoke);
        levelUpButton.onClick.AddListener(onLevelUpButtonClicked.Invoke);
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
        closeButton.onClick.RemoveListener(onCloseButtonClicked.Invoke);
        levelUpButton.onClick.RemoveListener(onLevelUpButtonClicked.Invoke);
    }
}
