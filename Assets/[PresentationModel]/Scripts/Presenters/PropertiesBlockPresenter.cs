using System;
using System.Collections.Generic;
using System.Linq;
using Lessons.Architecture.PM;
using PresentationModel;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

[Serializable]
public class PropertiesBlockPresenter
{
    private PropertiesBlockView _propertiesBlockView;
    private CharacterInfo _characterInfo;
    private HeroPopupPresenter _heroPopupPresenter;
    
    [ShowInInspector, ReadOnly] private List<PropertyView> _propertyViewsLeft;
    [ShowInInspector, ReadOnly] private List<PropertyView> _propertyViewsOccupied = new();
    [ShowInInspector, ReadOnly] private List<PropertyPresenter> _propertyPresenters = new();
 
    public PropertiesBlockPresenter(PropertiesBlockView propertiesBlockView, CharacterInfo characterInfo, HeroPopupPresenter heroPopupPresenter)
    {
        _propertiesBlockView = propertiesBlockView;
       
        _characterInfo = characterInfo;
        _characterInfo.OnStatAdded += OnPropertyAdded;
        _characterInfo.OnStatRemoved += OnPropertyRemoved;
        _heroPopupPresenter = heroPopupPresenter;
        _heroPopupPresenter.OnShow += UpdatePropertiesBlock;
        
        UpdatePropertiesBlock();
    }

    private void OnPropertyAdded(CharacterStat stat)
    {
        AddProperty(stat);
    }

    private void AddProperty(CharacterStat stat)
    {
        if (_propertyViewsLeft.Count == 0)
        {
            Debug.LogWarning("No views left to show the property");
            return;
        }

        var propertyView = _propertyViewsLeft[0];
        _propertyViewsLeft.Remove(propertyView);
        _propertyViewsOccupied.Add(propertyView);
        propertyView.Show();
        
        var propertyPresenter = new PropertyPresenter(stat, propertyView);
        _propertyPresenters.Add(propertyPresenter);
        propertyPresenter.UpdateProperty();
    }

    private void OnPropertyRemoved(CharacterStat stat)
    {
        foreach (var propertyPresenter in _propertyPresenters)
        {
            if (propertyPresenter.GetCharacterStat() == stat)
            {
                var propertyView = propertyPresenter.GetPropertyView();
                _propertyViewsLeft.Add(propertyView);
                _propertyViewsOccupied.Remove(propertyView);
                propertyView.Hide();
                _propertyPresenters.Remove(propertyPresenter);
                break;
            }
        }
    }

    private void UpdatePropertiesBlock()
    {
        Debug.Log("Properties Block Updated");
        _propertyViewsLeft = _propertiesBlockView.GetPropertyViews().ToList();
        foreach (var propertyView in _propertyViewsLeft)
        {
            propertyView.Hide();
        }
        _propertyViewsOccupied.Clear();
        _propertyPresenters.Clear();
        
        foreach (var characterStat in _characterInfo.GetStats())
        {
           AddProperty(characterStat); 
        }
    }

    ~PropertiesBlockPresenter()
    {
        _characterInfo.OnStatAdded -= OnPropertyAdded;
        _characterInfo.OnStatRemoved -= OnPropertyRemoved;
        _heroPopupPresenter.OnShow -= UpdatePropertiesBlock;
    }
}