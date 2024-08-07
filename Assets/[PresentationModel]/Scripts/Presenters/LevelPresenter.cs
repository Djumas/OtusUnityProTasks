using Lessons.Architecture.PM;
using UnityEngine;
using VContainer;

public class LevelPresenter
{
    private PlayerLevel _playerLevel;
    private LevelView _levelView;
    private HeroPopupPresenter _heroPopupPresenter;

    [Inject]
    private LevelPresenter(PlayerLevel playerLevel, LevelView levelView, HeroPopupPresenter heroPopupPresenter)
    {
        _playerLevel = playerLevel;
        _playerLevel.OnLevelUp += OnLevelUp;
        _levelView = levelView;
        _heroPopupPresenter = heroPopupPresenter;
        _heroPopupPresenter.OnShow += UpdateLevel;
    }

    private void OnLevelUp()
    {
        Debug.Log("Level up");
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        Debug.Log("Level updated");
        _levelView.ShowLevel(_playerLevel.CurrentLevel);
    }

    ~LevelPresenter()
    {
        _playerLevel.OnLevelUp -= OnLevelUp;
        _heroPopupPresenter.OnShow -= UpdateLevel;
    }
}
