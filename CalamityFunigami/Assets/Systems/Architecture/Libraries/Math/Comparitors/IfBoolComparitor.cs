using UnityEngine;
using UnityEngine.Events;
using Calamity.AssetOrganization;
using Calamity.Primitives;

namespace Calamity.Math
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.MathPath + "IfBool Comparitor", fileName = "IfBoolComparitor", order = AssetMenuSortOrders.MathOrder + 1)]
    public class IfBoolComparitor : ScriptableObject
    {
        [SerializeField] private BoolReference _ifBool;
        [SerializeField] private UnityEvent _ifTrueCallback;
        [SerializeField] private UnityEvent _ifFalseCallback;

        public void Invoke()
        {
            if (_ifBool)
                _ifTrueCallback?.Invoke();
            else
                _ifFalseCallback?.Invoke();
        }
    }
}