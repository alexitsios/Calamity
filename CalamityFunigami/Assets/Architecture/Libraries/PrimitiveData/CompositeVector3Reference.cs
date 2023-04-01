using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.Primitives
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.PrimitivesPath + "Composite Vector3", fileName = "CompositeVector3", order = AssetMenuSortOrders.PrimitivesOrder + 2)]
    public class CompositeVector3Reference : ScriptableObject
    {
        public FloatReference X;
        public FloatReference Y;
        public FloatReference Z;
        private Vector3 _vector3 = new Vector3();

        public Vector3 Value
        {
            get
            {
                _vector3.Set(X.Value, Y.Value, Z.Value);
                return _vector3;
            }
        }
    }
}