using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.Primitives
{
	[CreateAssetMenu(menuName = AssetMenuSortOrders.PrimitivesPath + "Ranged Float", fileName = "RangedFloat", order = AssetMenuSortOrders.PrimitivesOrder + 5)]
	public class RangedFloatVariable : ScriptableObject
	{
		public FloatReference MinValue;
		public FloatReference MaxValue;
	}
}