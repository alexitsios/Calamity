using Seeker.Emojis;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityToolbarExtender;

namespace Calamity.SceneManagement
{
#if UNITY_EDITOR
    /// <summary>
    /// Creates a button in Unity editor to toggle launch scene.
    /// </summary>
    [InitializeOnLoad()]
    public static class LaunchSceneActivationButton
    {
        private const string LaunchScenePath = "Assets/Systems/Scenes/Game Scenes/BackgroundElements/BootLoader.unity";
        private static bool isSet;

        /// <summary>
        /// Constructor
        /// </summary>
        static LaunchSceneActivationButton()
        {
            ToolbarExtender.RightToolbarGUI.Add(DrawLaunchSceneButtons);
        }

        /// <summary>
        /// Checks if the launch scene is activated and calls to draw appropriate toggle button.
        /// </summary>
        private static void DrawLaunchSceneButtons()
        {
            GUILayout.FlexibleSpace();
            isSet = (EditorSceneManager.playModeStartScene) ? true : false;

            if (isSet)
            {
                DrawDeactivationButton();
                return;
            }

            DrawActivationButton();
        }

        /// <summary>
        /// Draws activation button and sets launch scene when pressed
        /// </summary>
        private static void DrawActivationButton()
        {
            if (GUILayout.Button($"{Emoji.GetEmojiFromDictionary("star")} Activate Launch Scene"))
            {
                SetPlayModeStartScene(LaunchScenePath);
            }
        }

        /// <summary>
        /// Draws deactivation button and calls to log activation message when pressed.
        /// </summary>
        private static void DrawDeactivationButton()
        {
            if (GUILayout.Button($"{Emoji.GetEmojiFromDictionary("crossout")} Deactivate Launch Scene"))
            {
                EditorSceneManager.playModeStartScene = null;
                LogActivationMessage(false);
            }
        }

        /// <summary>
        /// Sets the play button in Unity to launch requested scene and calls to log activation message.
        /// </summary>
        /// <param name="scenePath">Launch scene target.</param>
        private static void SetPlayModeStartScene(string scenePath)
        {
            SceneAsset targetScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
            if (!targetScene)
            {
                Debug.LogAssertion("Could not find Scene " + scenePath);
                return;
            }
                           
            EditorSceneManager.playModeStartScene = targetScene;
            LogActivationMessage(true);
        }

        /// <summary>
        /// Builds activation message string and logs it to the console.
        /// </summary>
        /// <param name="activated">Current activation state of the launch scene.</param>
        private static void LogActivationMessage(bool activated)
        {
            string activationMessage =
                $"<size=12>" +
                        $"<b>" +
                            $"<color=yellow>{Emoji.GetEmojiFromDictionary("Caution")}</color>" +
                            $"Launch scene ";

            activationMessage += (activated) ?
                            $"<color=white>Activated</color> " +
                            $"<color=green>{Emoji.GetEmojiFromDictionary("checkmark")}</color>" +
                            $"<color=grey>" +
                                $" <i>({LaunchScenePath})</i>" +
                            $"</color>"
                            :
                            $"<color=white>Deactivated</color> " +
                            $"<color=red>{Emoji.GetEmojiFromDictionary("crossmark alt")}</color>";

            activationMessage +=
                        $"</b>" +
                    $"</size>";

            Debug.Log(activationMessage);
        }
    }
#endif
}