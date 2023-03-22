using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Calamity.AssetOrganization;

namespace Calamity.Primitives
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.PrimitivesPath + "Float", fileName = "Float", order = AssetMenuSortOrders.PrimitivesOrder + 3)]
    public class FloatVariable : ScriptableObject
    {
        public float Value;
        private float _lastValue;
        public UnityEvent OnValueChangeCallbackEvent;

#if UNITY_EDITOR
        [SerializeField, TextArea]
        private string DeveloperNotes = "";
#endif

        public void SetValue(float value)
        {
            Value = value;
            ValueChanged();
        }

        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
            ValueChanged();
        }

        public void SetValue(Slider slider)
        {
            Value = slider.value;
            ValueChanged();
        }

        public void ApplyChange(float amount)
        {
            Value += amount;
            ValueChanged();
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
            ValueChanged();
        }

        void ValueChanged()
        {
            if (Value != _lastValue)
            {
                _lastValue = Value;
                OnValueChangeCallbackEvent?.Invoke();
            }
        }
    }
}