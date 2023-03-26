using UnityEngine;
using Calamity.AssetOrganization;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Calamity.CommandSystem
{
    /// <summary>
    /// Player command to display controls rebind menu.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.CommandsPath + "RebindControls Command", fileName = "RebindControlsCommand", order = AssetMenuSortOrders.CommandsOrder + 3)]
    public class RebindControlsCommand : PlayerCommand
    {
        protected override bool ExecuteCommand()
        {
            return RebindControls();
        }

        /// <summary>
        /// Display menu for rebinding controls.
        /// </summary>
        /// <returns>Command success result.</returns>
        private bool RebindControls()
        {
            return true;
        }
    }
}