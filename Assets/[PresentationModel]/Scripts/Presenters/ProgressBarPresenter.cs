using System.Collections;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using UnityEngine;
using VContainer;

public class ProgressBarPresenter
{
    private ProgressBarView _progressBarView;
    private PlayerLevel _playerLevel;
    private HeroPopupPresenter _heroPopupPresenter;

    [Inject]
    private ProgressBarPresenter(PlayerLevel playerLevel, ProgressBarView progressBarView, HeroPopupPresenter heroPopupPresenter)
    {
        _playerLevel = playerLevel;
        _playerLevel.OnExperienceChanged += OnExperienceChanged;
        _playerLevel.OnLevelUp += OnLevelUp;
        _progressBarView = progressBarView;
        _heroPopupPresenter = heroPopupPresenter;
        _heroPopupPresenter.OnShow += UpdateProgressBar;
    }

    private void OnExperienceChanged(int experience)
    {
        _progressBarView.ShowExperience(experience,_playerLevel.RequiredExperience);
    }

    private void OnLevelUp()
    {
        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        _progressBarView.ShowExperience(_playerLevel.CurrentExperience,_playerLevel.RequiredExperience);
    }

    ~ProgressBarPresenter()
    {
        _playerLevel.OnExperienceChanged -= OnExperienceChanged;
        _playerLevel.OnLevelUp -= OnLevelUp;
        _heroPopupPresenter.OnShow -= UpdateProgressBar;
    }
}
