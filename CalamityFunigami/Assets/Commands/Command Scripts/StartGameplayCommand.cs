using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.CommandSystem
{
    /// <summary>
    /// Handles gameplay initialization.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.CommandsPath + "StartGameplay Command", fileName = "StartGameplayCommand", order = AssetMenuSortOrders.CommandsOrder + 1)]
    public class StartGameplayCommand : PlayerCommand
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