using System;
using UnityEngine;
using UnityEngine.Events;
using Calamity.AssetOrganization;

namespace Calamity.Primitives
{
    [Serializable, CreateAssetMenu(menuName = AssetMenuSortOrders.PrimitivesPath + "Int2", fileName = "Int2", order = AssetMenuSortOrders.PrimitivesOrder + 4)]
    public class Int2Variable : GlobalVariable<int>
    {
        //public int Value;
        public int DefaultValue;
        public IntReference MaximumValue;
        private int _lastValue;

        public UnityEvent OnValueChangeCallbackEvent;

#if UNITY_EDITOR
        [SerializeField, TextArea]
        private string _developerNotes = "";
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