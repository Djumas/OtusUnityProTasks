using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class HeroPopupHelper : MonoBehaviour
{
    [ShowInInspector] private HeroPopupPresenter _heroPopupPresenter;

    [Inject]
    private void Construct(HeroPopupPresenter heroPopupPresenter)
    {
        _heroPopupPresenter = heroPopupPresenter;
    }

    private void Awake()
    {
        HidePopup();
    }

    [Button]
    public void ShowPopup()
    {
        _heroPopupPresenter.ShowPopup();
    }
    
    [Button]
    public void HidePopup()
    {
        _heroPopupPresenter.HidePopup();
    }
}
