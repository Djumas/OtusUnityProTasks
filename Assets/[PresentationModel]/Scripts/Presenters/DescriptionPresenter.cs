using System;
using Lessons.Architecture.PM;
using UnityEngine;

public class DescriptionPresenter
{
    private UserInfo _userInfo;
    private DescriptionView _descriptionView;

    private DescriptionPresenter(UserInfo userInfo, DescriptionView descriptionView)
    {
        _userInfo = userInfo;
        _userInfo.OnDescriptionChanged += OnDescriptionChanged;
        _descriptionView = descriptionView;
        
    }

    private void OnDescriptionChanged(String newDescription)
    {
        Debug.Log("Changing Description");
        _descriptionView.ShowDescription(newDescription);
    }

    ~DescriptionPresenter()
    {
        _userInfo.OnDescriptionChanged -= OnDescriptionChanged;
    }
}
