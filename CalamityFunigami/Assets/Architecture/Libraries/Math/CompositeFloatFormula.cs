using UnityEngine;
using Calamity.AssetOrganization;
using Calamity.Primitives;

namespace Calamity.Math
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.MathPath + "CompositeFloatFormula", fileName = "CompositeFloatFormula", order = AssetMenuSortOrders.MathOrder + 2)]
    public class CompositeFloatFormula : MathFormula<float>
    {
        [SerializeField] private VariableReference _parameter1;
        [SerializeField] private BasicOperator _operator;
        [SerializeField] private FloatReference _parameter2;

        public override float Value
        {
            get
            {
                return Result;
            }
        }

#if UNITY_EDITOR
#pragma warning disable 0414
        [SerializeField, TextArea]
        private string _developerNotes = "";
#pragma warning restore 0414
#endif

        private float Result
        {
            get
            {
                switch (_operator)
                {
                    case BasicOperator.Add:
                        return ((float)_parameter1.UntypedGlobalVariable.UntypedValue + _parameter2.Value);

                    case BasicOperator.Subtract:
                        return ((float)_parameter1.UntypedGlobalVariable.UntypedValue - _parameter2.Value);

                    case BasicOperator.Multiply:
                        return ((float)_parameter1.UntypedGlobalVariable.UntypedValue * _parameter2.Value);

                    case BasicOperator.Divide:
                        return ((float)_parameter1.UntypedGlobalVariable.UntypedValue / _parameter2.Value);
                    default: return 0;
                }
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