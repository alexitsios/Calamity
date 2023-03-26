using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Calamity.EventSystem;

namespace Calamity.CommandSystem
{
    /// <summary>
    /// Base class for handling and tracking all player interactions.
    /// </summary>
    public abstract class PlayerCommand : ScriptableObject
    {
        /// <summary>
        /// Trigger events after executing command.
        /// </summary>
        [Header("*Optional")]
        [SerializeField] private List<GameEvent> _callbackEvents;
        [SerializeField] private FeedbackCollection _feedbackCollection;

#if UNITY_EDITOR
        // Display notes field in the inspector.
        [TextArea, SerializeField, Space(10)]
        [FormerlySerializedAs("DeveloperNotes")]
        private string _developerNotes = "";
#endif

        private CommandLogger _commandLogger;

        /// <summary>
        /// Invoke the command execution, log the result, then trigger callbacks.
        /// </summary>
        public void Invoke()
        {
            bool success = ExecuteCommand();

            if (!success)
            {
                LogFailure("Action Failure");
                return;
            }

            LogSuccess();
            InvokeCallbackEvents();
            InvokeFeedback();
        }

        /// <summary>
        /// Log a success message after executing command.
        /// </summary>
        private void LogSuccess() => LogEntry();

        /// <summary>
        /// Log a fail message after failing to execute command.
        /// </summary>
        /// <param name="failReason">Details of why the command execution failed.</param>
        private void LogFailure(string failReason) => LogEntry(false, failReason);

        /// <summary>
        /// Log the command execution to the console window.
        /// </summary>
        /// <param name="success">Execution success result.</param>
        /// <param name="explanation">Execution result details.</param>
        private void LogEntry(bool success = true, string explanation = "")
        {
            if (_commandLogger == null)
                SetupCommandLogger();

            string successMessage = (success) ? "Success" : "Failure";

            if (!explanation.Equals(string.Empty))
                successMessage += $" reason: {explanation}";

            _commandLogger?.LogCommand(this, successMessage);
        }

        /// <summary>
        /// Find the command logger on initial load.
        /// </summary>
        private void SetupCommandLogger()
        {
            GameObject actionLogGameObject = GameObject.FindGameObjectWithTag("CommandLog");
            _commandLogger = actionLogGameObject.GetComponent<CommandLogger>();
        }

        /// <summary>
        /// Trigger all attached callback events.
        /// </summary>
        private void InvokeCallbackEvents()
        {
            int i;
            for (i = 0; i < _callbackEvents?.Count; i++)
            {
                _callbackEvents?[i].Invoke();
            }
        }

        /// <summary>
        /// Triggers all items in feedback collection.
        /// </summary>
        private void InvokeFeedback()
        {
            int i;
            for (i = 0; i < _feedbackCollection?.Items.Count; i++)
            {
                _feedbackCollection?.Items[i].Invoke();
            }
        }

        /// <summary>
        /// Execute the requested command.
        /// </summary>
        /// <returns>Execution success result.</returns>
        protected abstract bool ExecuteCommand();
    }
}