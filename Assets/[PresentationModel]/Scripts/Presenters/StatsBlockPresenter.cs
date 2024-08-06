using System;
using Lessons.Architecture.PM;
using VContainer;

[Serializable]
public class StatsBlockPresenter
{
    private StatsBlockView _statsBlockView;
    private CharacterStat[] _characterStats;
 
    [Inject]
    public StatsBlockPresenter(StatsBlockView statsBlockView)
    {
        _statsBlockView = statsBlockView;
    }

    
    public void Initialize(CharacterStat[] characterStats)
    {
        _characterStats = characterStats;
    }
}
