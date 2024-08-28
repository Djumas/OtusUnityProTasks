using Lessons.Architecture.PM;
using UnityEngine;

public class LevelPresenter
{
    private readonly PlayerLevel _playerLevel;
    private readonly LevelView _levelView;
    
    public LevelPresenter(PlayerLevel playerLevel, LevelView levelView)
    {
        _playerLevel = playerLevel;
        _playerLevel.OnLevelUp += OnLevelUp;
        _levelView = levelView;
    }

    private void OnLevelUp()
    {
        Debug.Log("Level up");
        Update();
    }

    public void Update()
    {
        Debug.Log("Level updated");
        _levelView.ShowLevel(_playerLevel.CurrentLevel);
    }

    ~LevelPresenter()
    {
        _playerLevel.OnLevelUp -= OnLevelUp;
    }
}
