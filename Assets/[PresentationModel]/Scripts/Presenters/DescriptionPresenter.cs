using System;
using Lessons.Architecture.PM;
using UnityEngine;

public class DescriptionPresenter
{
    private readonly UserInfo _userInfo;
    private readonly DescriptionView _descriptionView;

    public DescriptionPresenter(UserInfo userInfo, DescriptionView descriptionView)
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

    public void Update()
    {
        _descriptionView.ShowDescription(_userInfo.Description);
    }

    ~DescriptionPresenter()
    {
        _userInfo.OnDescriptionChanged -= OnDescriptionChanged;
    }
}
