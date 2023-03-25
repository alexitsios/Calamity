using UnityEngine;
using Calamity.AssetOrganization;
using Calamity.Primitives;

namespace Calamity.Math
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.MathPath + "CompareFloatsReturnValue", fileName = "CompareFloatsReturnValue", order = AssetMenuSortOrders.MathOrder + 1)]
    public class CompareFloatsReturnValue : MathFormula<float>
    {
        [SerializeField] private FloatReference _ifValue;
        [SerializeField] private Comparitor _comparitor;
        [SerializeField] private FloatReference _comparisonValue;

        [SerializeField] private FloatReference _returnIfTrue;
        [SerializeField] private FloatReference _returnIfFalse;

#if UNITY_EDITOR
        [SerializeField, TextArea]
        private string _developerNotes = "";
#endif

        public override float Value
        {
            get
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

                FloatReference returnValue = (result) ? _returnIfTrue : _returnIfFalse;

                return returnValue.Value;
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Log Calculated Result")]
        protected override void DebugLogResult()
        {            
            Debug.Log($"Value of <color=teal><b>{name}</b></color> is <color=cyan>{Value}</a>", this);
        }
#endif
    }
}