using System.Collections.Generic;
using System.Linq;
using Lessons.Architecture.PM;
using PresentationModel;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class PropertiesBlockView : MonoBehaviour
{
    [SerializeField] private PropertyView[] propertyViews;

    public PropertyView[] GetPropertyViews()
    {
        return propertyViews;
    }
}
