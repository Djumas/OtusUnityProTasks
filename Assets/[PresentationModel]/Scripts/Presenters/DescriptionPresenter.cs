using System;
using Lessons.Architecture.PM;
using Unity.VisualScripting;
using UnityEngine;

public class DescriptionPresenter
{
    private UserInfo _userInfo;
    private DescriptionView _descriptionView;
    private HeroPopupPresenter _heroPopupPresenter;

    public DescriptionPresenter(UserInfo userInfo, DescriptionView descriptionView, HeroPopupPresenter heroPopupPresenter)
    {
        _userInfo = userInfo;
        _userInfo.OnDescriptionChanged += OnDescriptionChanged;
        _descriptionView = descriptionView;
        _heroPopupPresenter = heroPopupPresenter;
        _heroPopupPresenter.OnShow += UpdateDescription;
    }

    private void OnDescriptionChanged(String newDescription)
    {
        Debug.Log("Changing Description");
        _descriptionView.ShowDescription(newDescription);
    }

    private void UpdateDescription()
    {
        _descriptionView.ShowDescription(_userInfo.Description);
    }

    ~DescriptionPresenter()
    {
        _userInfo.OnDescriptionChanged -= OnDescriptionChanged;
        _heroPopupPresenter.OnShow -= UpdateDescription;
    }
}
