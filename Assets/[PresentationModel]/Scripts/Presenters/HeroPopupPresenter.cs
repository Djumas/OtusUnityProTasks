using System;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

[Serializable]
public class HeroPopupPresenter
{
    [ShowInInspector] private DescriptionPresenter _descriptionPresenter;
    [ShowInInspector] private LevelPresenter _levelPresenter;
    [ShowInInspector] private NickNamePresenter _nickNamePresenter;
    [ShowInInspector] private PortraitPresenter _portraitPresenter;
    [ShowInInspector] private ProgressBarPresenter _progressBarPresenter;
    [ShowInInspector] private PropertiesBlockPresenter _propertiesBlockPresenter;
    
    private PlayerLevel _playerLevel;
    private UserInfo _userInfo;
    private CharacterInfo _characterInfo;
    
    private HeroPopupView _heroPopupView;

    [Inject]
    public HeroPopupPresenter(PlayerLevel playerLevel, CharacterInfo characterInfo, UserInfo userInfo, HeroPopupView heroPopupView)
    {
        Debug.Log("Called heroPopupPresenter constructor");
        
        heroPopupView.SetPresenter(this);
        
        _descriptionPresenter = new DescriptionPresenter(userInfo, heroPopupView.DescriptionView);
        _levelPresenter = new LevelPresenter(playerLevel,heroPopupView.LevelView);
        _nickNamePresenter = new NickNamePresenter(userInfo,heroPopupView.NicknameView);
        _portraitPresenter = new PortraitPresenter(heroPopupView.PortraitView,userInfo);
        _progressBarPresenter = new ProgressBarPresenter(playerLevel, heroPopupView.ProgressBarView);
        _propertiesBlockPresenter = new PropertiesBlockPresenter(heroPopupView.PropertiesBlockView, characterInfo);
        
        _playerLevel = playerLevel;
        _playerLevel.OnLevelUp += OnLevelUp;
        _playerLevel.OnExperienceChanged += OnExperienceChanged;

        _heroPopupView = heroPopupView;

        _heroPopupView.OnCloseButtonClicked += OnCloseButtonClick;
        _heroPopupView.OnLevelUpButtonClicked += OnLevelUpButtonClick;
    }

    private void OnExperienceChanged(int experience)
    {
        Debug.Log("OnExperienceChanged in HeroPopupPresenter");
        UpdateLevelUpButton();
    }

    private void OnLevelUp()
    {
        Debug.Log("OnExperienceChanged in HeroPopupPresenter");
        UpdateLevelUpButton();
    }

    private void UpdateLevelUpButton()
    {
        Debug.Log($"CanLevelUp:{_playerLevel.CanLevelUp()}");
        if (_playerLevel.CanLevelUp())
        {
            _heroPopupView.EnableLevelUpButton();
            return;
        }

        _heroPopupView.DisableLevelUpButton();
    }

    private void OnCloseButtonClick()
    {
        Debug.Log("Pressed close button");
        HidePopup();
    }

    private void OnLevelUpButtonClick()
    {
        Debug.Log("Pressed levelup button");
        _playerLevel.LevelUp();
    }

    //[Button]
    public void ShowPopup()
    {
        _heroPopupView.Show();
        UpdateLevelUpButton();
        
        _descriptionPresenter.Update();
        _levelPresenter.Update();
        _nickNamePresenter.Update();
        _portraitPresenter.Update();
        _progressBarPresenter.Update();
        _propertiesBlockPresenter.Update();
    }

    //[Button]
    public void HidePopup()
    {
        _heroPopupView.Hide();
    }

    ~HeroPopupPresenter()
    {
        _playerLevel.OnLevelUp -= OnLevelUp;
        _playerLevel.OnExperienceChanged -= OnExperienceChanged;

        _heroPopupView.OnCloseButtonClicked -= OnCloseButtonClick;
        _heroPopupView.OnLevelUpButtonClicked -= OnLevelUpButtonClick;
    }
}