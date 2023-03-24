using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.CommandSystem
{
    /// <summary>
    /// Starts new game.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.CommandsPath + "NewGame Command", fileName = "NewGameCommand", order = AssetMenuSortOrders.CommandsOrder + 3)]
    public class NewGameCommand : PlayerCommand
    {

        private GameObject warning;
        private GameObject mainMenu;
        protected override bool ExecuteCommand()
        {
            return NewGameWarning();
        }

        void Awake()
        {
            warning = GameObject.Find("Warning");
            mainMenu = GameObject.Find("Main Menu");
        }

        /// <summary>
        /// Initializes New Game Warning.
        /// </summary>
        /// <returns>Command success result.</returns>
        public void NewGameWarning()
        {
        Debug.Log("Warning");
            mainMenu.SetActive(false);
            warning.SetActive(true);
        }

        public void no()
        {
            warning.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
