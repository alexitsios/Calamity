using UnityEngine;
using Calamity.AssetOrganization;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Calamity.CommandSystem
{
    /// <summary>
    /// Player command to quit the game.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.CommandsPath + "QuitGame Command", fileName = "QuitGameCommand", order = AssetMenuSortOrders.CommandsOrder + 2)]
    public class QuitGameCommand : PlayerCommand
    {
        protected override bool ExecuteCommand()
        {
            return QuitGame();
        }

        /// <summary>
        /// Quits the game or deactivates Play in Unity editor.
        /// </summary>
        /// <returns>Command success result.</returns>
        private bool QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.ExecuteMenuItem("Edit/Play");
#else
        Application.Quit();
#endif
            return true;
        }
    }
}