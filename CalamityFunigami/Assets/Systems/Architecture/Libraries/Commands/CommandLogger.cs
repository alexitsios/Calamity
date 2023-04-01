using UnityEngine;

namespace Calamity.CommandSystem
{
    /// <summary>
    /// Log all player commands to the console window.
    /// </summary>
    public class CommandLogger : MonoBehaviour
    {
        /// <summary>
        /// Debugging tool - Raise an assertion alert if command is triggered.
        /// </summary>
        [Header("*Optional")]
        [SerializeField] private PlayerCommand watchForCommand;

        /// <summary>
        /// Log player command to console.
        /// </summary>
        /// <param name="command">Player command to log.</param>
        /// <param name="successMessage">Execution success result message.</param>
        public void LogCommand(PlayerCommand command, string successMessage)
        {
            if (watchForCommand != null && command.name.Equals(watchForCommand.name))
            {
                Debug.LogAssertion($"{command.name}, {successMessage}", this);
                return;
            }

            Debug.Log($"{command.name}, {successMessage}", this);
        }
    }
}