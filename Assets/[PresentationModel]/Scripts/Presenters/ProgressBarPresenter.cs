using System.Collections;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using UnityEngine;
using VContainer;

public class ProgressBarPresenter
{
    private ProgressBarView _progressBarView;
    private PlayerLevel _playerLevel;

    [Inject]
    private ProgressBarPresenter(PlayerLevel playerLevel, ProgressBarView progressBarView)
    {
        _playerLevel = playerLevel;
        _playerLevel.OnExperienceChanged += OnExperienceChanged;
        _playerLevel.OnLevelUp += OnLevelUp;
        _progressBarView = progressBarView;
    }

    private void OnExperienceChanged(int experience)
    {
        _progressBarView.ShowExperience(experience,_playerLevel.RequiredExperience);
    }

    private void OnLevelUp()
    {
        _progressBarView.ShowExperience(_playerLevel.CurrentExperience,_playerLevel.RequiredExperience);
    }

    ~ProgressBarPresenter()
    {
        _playerLevel.OnExperienceChanged -= OnExperienceChanged;
        _playerLevel.OnLevelUp -= OnLevelUp;
    }
}
