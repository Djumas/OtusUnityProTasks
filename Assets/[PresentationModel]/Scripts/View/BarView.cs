using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UniRx;

namespace PresentationModel
{
    public class BarView : MonoBehaviour
    {
        [SerializeField] private Image barImage;
        [SerializeField] private Image barImageCompleted;
        [ShowInInspector, ReadOnly] private ReactiveProperty<float> _currentValue = new FloatReactiveProperty(0.5f);
        [ShowInInspector, ReadOnly] private bool isCompleted;

        private void Awake()
        {
            _currentValue.Subscribe(CurrentValueListener);
        }

        private void CurrentValueListener(float value)
        {
            UpdateBar();
        }

        [Button]
        public void SetValue(float value)
        {
            _currentValue.Value = Mathf.Clamp(value, 0, 1);
        }

        public void UpdateBar()
        {
            if (_currentValue.Value >= 1 && !isCompleted)
            {
                isCompleted = true;
                barImageCompleted.gameObject.SetActive(true);
                barImage.gameObject.SetActive(false);
                return;
            }

            if (isCompleted)
            {
                isCompleted = false;
                barImageCompleted.gameObject.SetActive(false);
                barImage.gameObject.SetActive(true);
            }

            barImage.rectTransform.anchorMax = new Vector2(_currentValue.Value, 1);
        }
    }
}