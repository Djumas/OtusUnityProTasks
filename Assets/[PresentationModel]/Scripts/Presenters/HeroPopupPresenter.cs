using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class HeroPopupPresenter
{
    private Character _character;
    private HeroPopupView _heroPopupView;
    private StatsBlockPresenter _statsBlockPresenter;

    [Inject]
    public HeroPopupPresenter(Character character)
    {
        _character = character;
    }

    public void ShowPopup()
    {
        _heroPopupView.Show();
        _statsBlockPresenter.Initialize(_character.GetCharacterInfo().GetStats());
    }
}
