using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.CommandSystem
{
    /// <summary>
    /// Handles gameplay initialization.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.CommandsPath + "UIStartButtonCommand", fileName = "UIStartButtonCommand", order = AssetMenuSortOrders.CommandsOrder + 1)]
    public class UIStartButtonCommand : PlayerCommand
    {
        protected override bool ExecuteCommand()
        {
            return StartGameplay();
        }

        /// <summary>
        /// Initializes gameplay.
        /// </summary>
        /// <returns>Command success result.</returns>
        private bool StartGameplay()
        {
            // Placeholder - todo - more to come
            return true;
        }
    }
}