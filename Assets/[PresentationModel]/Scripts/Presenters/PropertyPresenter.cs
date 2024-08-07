using System;
using Lessons.Architecture.PM;
using PresentationModel;
using UnityEngine;

[Serializable]
public class PropertyPresenter
{
    private CharacterStat _characterStat;
    private PropertyView _propertyView;
    
    public PropertyPresenter(CharacterStat characterStat,PropertyView propertyView)
    {
        _propertyView = propertyView;
        _characterStat = characterStat;
        _characterStat.OnValueChanged += UpdateValue;
        UpdateValue(_characterStat.Value);
        UpdateName(_characterStat.Name);
        UpdateProperty();
    }

    public CharacterStat GetCharacterStat()
    {
        return _characterStat;
    }
    
    public PropertyView GetPropertyView()
    {
        return _propertyView;
    }

    private void UpdateValue(int newValue)
    {
        _propertyView.SetValue(newValue);
    }
    
    private void UpdateName(string newName)
    {
        _propertyView.SetName(newName);
    }

    public void UpdateProperty()
    {
        _propertyView.UpdateProperty();
    }

    ~PropertyPresenter()
    {
        Debug.Log("PropertyPresenter destroyed");
        _characterStat.OnValueChanged -= UpdateValue;
    }
}
