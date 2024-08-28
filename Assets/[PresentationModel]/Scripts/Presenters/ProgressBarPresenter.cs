using Lessons.Architecture.PM;

public class ProgressBarPresenter
{
    private readonly ProgressBarView _progressBarView;
    private readonly PlayerLevel _playerLevel;

    public ProgressBarPresenter(PlayerLevel playerLevel, ProgressBarView progressBarView)
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
        Update();
    }

    public void Update()
    {
        _progressBarView.ShowExperience(_playerLevel.CurrentExperience,_playerLevel.RequiredExperience);
    }

    ~ProgressBarPresenter()
    {
        _playerLevel.OnExperienceChanged -= OnExperienceChanged;
        _playerLevel.OnLevelUp -= OnLevelUp;
    }
}
