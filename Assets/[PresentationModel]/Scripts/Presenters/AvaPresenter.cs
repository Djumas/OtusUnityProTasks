
using Lessons.Architecture.PM;
using UnityEngine;
using VContainer;

public class AvaPresenter
{
    private AvaView _avaView;
    private UserInfo _userInfo;

    [Inject]
    public AvaPresenter(AvaView avaView, UserInfo userInfo)

    {
        _avaView = avaView;
        _userInfo = userInfo;
        _userInfo.OnIconChanged += OnIconChanged;
    }

    private void OnIconChanged(Sprite newIcon)
    {
        _avaView.ShowAva(newIcon);
    }

    ~AvaPresenter()
    {
        _userInfo.OnIconChanged -= OnIconChanged; 
    }
}
