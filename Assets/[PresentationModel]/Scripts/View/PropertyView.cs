using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace PresentationModel
{
    public class PropertyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private string _name;
        private int _value;

        [Button]
        public void UpdateProperty()
        {
            text.text = $"{_name}:{_value}";
        }

        public void SetName(string newName)
        {
            _name = newName;
            UpdateProperty();
        }
        
        public void SetValue(int newValue)
        {
            _value = newValue;
            UpdateProperty();
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
            UpdateProperty();
        }
        
        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}

