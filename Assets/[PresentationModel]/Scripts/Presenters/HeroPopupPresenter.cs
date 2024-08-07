using System;
using System.Collections;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

[Serializable]
public class HeroPopupPresenter
{
    private PlayerLevel _playerLevel;
    private HeroPopupView _heroPopupView;

    public event Action OnShow;

    [Inject]
    public HeroPopupPresenter(PlayerLevel playerLevel, HeroPopupView heroPopupView)
    {
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

    [Button]
    public void ShowPopup()
    {
        _heroPopupView.Show();
        UpdateLevelUpButton();
        OnShow?.Invoke();
    }

    [Button]
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