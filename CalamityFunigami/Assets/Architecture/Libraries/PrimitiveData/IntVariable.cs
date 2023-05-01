using UnityEngine;
using UnityEngine.Events;
using Calamity.AssetOrganization;

namespace Calamity.Primitives
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.PrimitivesPath + "Int", fileName = "Int", order = AssetMenuSortOrders.PrimitivesOrder + 4)]
    public class IntVariable : ScriptableObject
    {
        public int Value;
        public int DefaultValue;
        public IntReference MaximumValue;
        private int _lastValue;

        public UnityEvent OnValueChangeCallbackEvent;

#if UNITY_EDITOR
#pragma warning disable 0414
        [SerializeField, TextArea]
        string DeveloperNotes = "";
#pragma warning restore 0414
#endif

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }

        public void SetValue(int value)
        {
            Value = value;
            ValueChanged();
        }

        public void SetValue(IntVariable value)
        {
            Value = value.Value;
            ValueChanged();
        }

        public void ApplyChange(int amount)
        {
            ApplyChangeCommit(amount);
        }

        public void ApplyChange(IntVariable amount)
        {
            ApplyChangeCommit(amount.Value);
        }

        private void ApplyChangeCommit(int amount)
        {
            if (MaximumValue.Value > 0 && Value + amount > MaximumValue.Value)
                return;

            Value += amount;
            ValueChanged();
        }

        private void ValueChanged()
        {
            if (Value != _lastValue)
            {
                _lastValue = Value;
                OnValueChangeCallbackEvent?.Invoke();
            }
        }
    }
}