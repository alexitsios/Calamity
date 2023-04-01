using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Calamity.AssetOrganization;
using Seeker.Emojis;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// Editor window for manually setting the scene that will be launched when pressing the Play button in Unity.
    /// </summary>
    public class EditLaunchSceneWindow : EditorWindow
    {
        private GUIContent LaunchSceneField = new GUIContent("Launch Scene");

        private void OnGUI() => SelectLaunchScene();

        /// <summary>
		/// Use the Object Picker to select the start SceneAsset.
		/// </summary>
        private void SelectLaunchScene()
        {
            EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(LaunchSceneField, EditorSceneManager.playModeStartScene, typeof(SceneAsset), false);
        }

        /// <summary>
        /// Display the launch scene window from menu item.
        /// </summary>
        [MenuItem(MenuItemSortOrders.SceneSettings + Emoji.EmojiConstants.Rocket + " Edit Launch Scene", priority = MenuItemSortOrders.SceneSettingsPriority + 1)]
        private static void OpenLaunchSceneWindow() => GetWindow<EditLaunchSceneWindow>();
    }
}