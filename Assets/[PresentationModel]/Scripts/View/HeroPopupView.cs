using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class HeroPopupView : MonoBehaviour
{

    [SerializeField] private PortraitView portraitView;
    [SerializeField] private DescriptionView descriptionView;
    [SerializeField] private ProgressBarView progressBarView;
    [SerializeField] private NicknameView nicknameView;
    [SerializeField] private PropertiesBlockView propertiesBlockView;
    [SerializeField] private LevelView levelView;

    public PortraitView PortraitView => portraitView;
    public DescriptionView DescriptionView => descriptionView;
    public ProgressBarView ProgressBarView => progressBarView;
    public NicknameView NicknameView => nicknameView;
    public PropertiesBlockView PropertiesBlockView => propertiesBlockView;
    public LevelView LevelView => levelView;


    [ShowInInspector] private HeroPopupPresenter _heroPopupPresenter;

    public Button closeButton;
    public Button levelUpButton;

    public event Action OnCloseButtonClicked;
    public event Action OnLevelUpButtonClicked;

    public void SetPresenter(HeroPopupPresenter heroPopupPresenter)
    {
        _heroPopupPresenter = heroPopupPresenter;
    }

    private void Awake ()
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

    //[Button]
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    
    //[Button]
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
