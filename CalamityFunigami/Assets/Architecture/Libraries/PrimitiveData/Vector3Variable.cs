using UnityEngine;
using UnityEngine.Events;
using Calamity.AssetOrganization;

namespace Calamity.Primitives
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.PrimitivesPath + "Vector3", fileName = "Vector3", order = AssetMenuSortOrders.PrimitivesOrder + 6)]
    public class Vector3Variable : ScriptableObject
    {
        public Vector3 Value;
        public Vector3 DefaultValue;
        private Vector3 _lastValue;

        public UnityEvent OnValueChangeCallbackEvent;

#if UNITY_EDITOR
        [SerializeField, TextArea]
        private string _developerNotes = "";
#endif

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }

        public void SetValue(Vector3 value)
        {
            Value = value;
            ValueChanged();
        }

        public void SetValue(Vector3Variable value)
        {
            Value = value.Value;
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