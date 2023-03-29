using UnityEngine;
using UnityEditor;
using Calamity.AssetOrganization;
using Seeker.Emojis;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// Enum for scene types
    /// </summary>
    public enum SceneType
    {
        BackgroundElements,
        Gameplay,
        UI
    }

    public class NewSceneTool : EditorWindow
    {
        private string _sceneTitle = "";
        private SceneType _sceneType = SceneType.Gameplay;

        private GUIStyle _boldLabelStyle;
              
        /// <summary>
        /// Initializes the editor window
        /// </summary>
        [MenuItem(MenuItemSortOrders.SceneModifications + Emoji.EmojiConstants.PlusSign + "Add New Scene", priority = 80)]
        private static void Init()
        {
            NewSceneTool window = (NewSceneTool)GetWindow(typeof(NewSceneTool));
            window.titleContent = new GUIContent("New Scene");
            window.minSize = new Vector2(250, 150);
            window.ShowUtility();
        }

        private void OnEnable()
        {
            _boldLabelStyle = new GUIStyle(EditorStyles.boldLabel);
            _boldLabelStyle.fontSize = 14;
            _boldLabelStyle.alignment = TextAnchor.MiddleCenter;
        }

        /// <summary>
        /// Draws the editor GUI
        /// </summary>
        private void OnGUI()
        {
            GUILayout.Space(10);

            GUILayout.Label("Set Scene Title", _boldLabelStyle);
            GUILayout.Space(5);
            GUILayout.Label("Examples: \"Cemetery, Laboratory, Morgue, Controls UI\"", EditorStyles.wordWrappedMiniLabel);
            GUILayout.Space(5);
            _sceneTitle = EditorGUILayout.TextField(_sceneTitle);

            GUILayout.Space(20);

            GUILayout.Label("Select Scene Type", _boldLabelStyle);
            GUILayout.Space(5);
            GUILayout.Label("The scene type determines the placement folder of this new scene.", EditorStyles.wordWrappedMiniLabel);
            GUILayout.Space(5);
            _sceneType = (SceneType)EditorGUILayout.EnumPopup(_sceneType);

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Create Scene", GUILayout.Height(30)))
            {
                CreateScene();

                // Regenerate scene list
                SceneMenuListGenerator.GenerateSceneLoadMenuCode();
                Close();
            }
        }

        private void CreateScene()
        {
            string scenePath = $"Assets/Systems/Scenes/Game Scenes/{_sceneType}/{_sceneTitle}.unity";
            UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo(); // Save the current scene
            UnityEditor.SceneManagement.EditorSceneManager.NewScene(UnityEditor.SceneManagement.NewSceneSetup.EmptyScene, UnityEditor.SceneManagement.NewSceneMode.Single); // Create a new empty scene
            UnityEditor.SceneManagement.EditorSceneManager.SaveScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene(), scenePath); // Save the new scene to the specified file path                       
        }
    }
}
