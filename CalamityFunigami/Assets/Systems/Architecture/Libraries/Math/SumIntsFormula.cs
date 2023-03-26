using UnityEngine;
using Calamity.AssetOrganization;
using Calamity.Primitives;

namespace Calamity.Math
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.MathPath + "SumIntsFormula", fileName = "SumIntsFormula", order = AssetMenuSortOrders.MathOrder + 7)]
    public class SumIntsFormula : MathFormula<int>
    {
        [SerializeField] private IntReference[] _parametersToSumTogether;

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
                int subtotal = 0;
                for (int i = 0; i < _parametersToSumTogether.Length; i++)
                {
                    subtotal += _parametersToSumTogether[i].Value;
                }
                return subtotal;
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