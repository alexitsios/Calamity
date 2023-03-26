using UnityEngine;
using Calamity.AssetOrganization;
using Calamity.Primitives;

namespace Calamity.Math
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.MathPath + "Log10 Value", fileName = "Log10Value", order = AssetMenuSortOrders.MathOrder + 3)]
    public class Log10Value : MathFormula<float>
    {
        [SerializeField] private FloatReference baseValue;

        public override float Value
        {
            get
            {
                return Mathf.Log10(baseValue.Value);
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