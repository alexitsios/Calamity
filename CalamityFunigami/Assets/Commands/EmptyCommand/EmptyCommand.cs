using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.CommandSystem {

    /// <summary>
    /// A general command that triggers events but doesn't have specific functionality of its own.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.CommandsPath + "Empty Command", fileName = "EmptyCommand", order = AssetMenuSortOrders.CommandsOrder + 2)]
    public class EmptyCommand : PlayerCommand
    {
        protected override bool ExecuteCommand()
        {
            return true;
        }
    }
}