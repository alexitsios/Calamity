using UnityEngine;
using UnityEngine.Events;
using Calamity.AssetOrganization;
using Calamity.Primitives;

namespace Calamity.Math
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.MathPath + "IfFloatValues Comparitor", fileName = "IfFloatValuesComparitor", order = AssetMenuSortOrders.MathOrder + 2)]
    public class IfFloatValuesComparitor : ScriptableObject
    {
        [SerializeField] private FloatReference _ifValue;
        [SerializeField] private Comparitor _comparitor;
        [SerializeField] private FloatReference _comparisonValue;

        [SerializeField] private UnityEvent _ifTrueCallback;
        [SerializeField] private UnityEvent _ifFalseCallback;

#if UNITY_EDITOR
        [SerializeField, TextArea]
        private string _developerNotes = "";
#endif

        public void RunComparison()
        {
            bool result = false;
            switch (_comparitor)
            {
                case Comparitor.Equals:
                    result = (_ifValue.Value == _comparisonValue.Value);
                    break;

                case Comparitor.GreaterThan:
                    result = (_ifValue.Value > _comparisonValue.Value);
                    break;

                case Comparitor.LessThan:
                    result = (_ifValue.Value < _comparisonValue.Value);
                    break;

                case Comparitor.GreaterOrEqual:
                    result = (_ifValue.Value >= _comparisonValue.Value);
                    break;

                case Comparitor.LessOrEqual:
                    result = (_ifValue.Value <= _comparisonValue.Value);
                    break;
            }

            if (result)
                _ifTrueCallback?.Invoke();
            else
                _ifFalseCallback?.Invoke();
        }
    }
}