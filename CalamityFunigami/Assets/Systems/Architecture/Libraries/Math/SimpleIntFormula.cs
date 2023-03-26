using UnityEngine;
using Calamity.AssetOrganization;
using Calamity.Primitives;

namespace Calamity.Math
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.MathPath + "SimpleIntFormula", fileName = "SimpleIntFormula", order = AssetMenuSortOrders.MathOrder + 6)]
    public class SimpleIntFormula : MathFormula<int>
    {
        [SerializeField] private IntReference _parameter1;
        [SerializeField] private BasicOperator _operator;
        [SerializeField] private IntReference _parameter2;

        public override int Value
        {
            get
            {
                return Result;
            }
        }

#if UNITY_EDITOR
        [SerializeField, TextArea]
        private string _developerNotes = "";
#endif

        private int Result
        {
            get
            {
                switch (_operator)
                {
                    case BasicOperator.Add:
                        return (_parameter1.Value + _parameter2.Value);

                    case BasicOperator.Subtract:
                        return (_parameter1.Value - _parameter2.Value);

                    case BasicOperator.Multiply:
                        return (_parameter1.Value * _parameter2.Value);

                    case BasicOperator.Divide:
                        return (_parameter1.Value / _parameter2.Value);
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