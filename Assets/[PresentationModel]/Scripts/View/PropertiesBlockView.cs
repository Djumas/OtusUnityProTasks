using PresentationModel;
using UnityEngine;

public class PropertiesBlockView : MonoBehaviour
{
    [SerializeField] private PropertyView[] propertyViews;

    public PropertyView[] GetPropertyViews()
    {
        return propertyViews;
    }
}
