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
    private StatsBlockPresenter _statsBlockPresenter;

    [Inject]
    public HeroPopupPresenter(PlayerLevel playerLevel, HeroPopupView heroPopupView, StatsBlockPresenter statsBlockPresenter)
    {
        _playerLevel = playerLevel;
        _heroPopupView = heroPopupView;
        _statsBlockPresenter = statsBlockPresenter;

    }

    [Button]
    public void ShowPopup()
    {
        _heroPopupView.Show();
    }
    
    [Button]
    public void HidePopup()
    {
        _heroPopupView.Hide();
    }
}
