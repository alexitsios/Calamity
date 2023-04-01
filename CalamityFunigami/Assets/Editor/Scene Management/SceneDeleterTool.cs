using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using Calamity.AssetOrganization;
using Seeker.Emojis;

namespace Calamity.SceneManagement
{
    public class SceneDeleterTool : EditorWindow
    {
        private List<string> _scenePaths;
        private Dictionary<string, bool> _sceneSelections = new Dictionary<string, bool>();
        private List<string> _otherScenePaths = new List<string>();

        private Vector2 _sceneScrollPosition;
        private Vector2 _otherSceneScrollPosition;

        [MenuItem(MenuItemSortOrders.SceneModifications + Emoji.EmojiConstants.MinusSign + "Delete Scenes", priority = MenuItemSortOrders.SceneModificationsPriority + 2)]
        private static void Init()
        {
            SceneDeleterTool window = GetWindow<SceneDeleterTool>();
            window.titleContent = new GUIContent("Scene Deleter");
            window.Show();
        }

        private void OnEnable()
        {
            _scenePaths = GetScenePaths();
            foreach (string path in _scenePaths)
            {
                _sceneSelections[path] = false;
            }

            _otherScenePaths.Clear(); // Clear any previous entries

            // Get all the scene files that were not found in the initial search
            string[] allScenes = AssetDatabase.FindAssets("t:Scene");
            foreach (string scene in allScenes)
            {
                string path = AssetDatabase.GUIDToAssetPath(scene);
                if (!_scenePaths.Contains(path))
                {
                    _otherScenePaths.Add(path);
                    _sceneSelections[path] = false;
                }
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("Game Scenes", EditorStyles.boldLabel);
            GUILayout.Space(5);

            // Create a scroll view for the scene list
            _sceneScrollPosition = GUILayout.BeginScrollView(_sceneScrollPosition);

            foreach (string scenePath in _scenePaths)
            {
                string sceneName = Path.GetFileNameWithoutExtension(scenePath);
                string[] pathFolders = scenePath.Split(Path.DirectorySeparatorChar);
                string lastFolder = pathFolders[pathFolders.Length - 2]; // Get the second-to-last folder in the path

                GUILayout.BeginHorizontal();

                // Create a toggle for selecting the scene
                _sceneSelections[scenePath] = GUILayout.Toggle(_sceneSelections[scenePath], "", GUILayout.Width(20));

                // Create a label for the scene name that can be clicked to highlight the scene file in the project window
                GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
                labelStyle.normal.textColor = Color.magenta;
                if (GUILayout.Button(lastFolder + "/" + sceneName, labelStyle))
                {
                    UnityEngine.Object sceneObject = AssetDatabase.LoadAssetAtPath(scenePath, typeof(SceneAsset));
                    Selection.activeObject = sceneObject;
                    EditorGUIUtility.PingObject(sceneObject);
                }

                GUILayout.EndHorizontal();
            }

            GUILayout.EndScrollView();

            GUILayout.Space(5);

            // Create a label for the other scenes
            GUILayout.Label("Other Scenes", EditorStyles.boldLabel);
            GUILayout.Space(5);

            // Get all the scene files that were not found in the initial search
            string[] allScenes = AssetDatabase.FindAssets("t:Scene");
            foreach (string scene in allScenes)
            {
                string path = AssetDatabase.GUIDToAssetPath(scene);
                if (!_scenePaths.Contains(path) && !_otherScenePaths.Contains(path))
                {
                    _otherScenePaths.Add(path);
                    _sceneSelections[path] = false;
                }
            }

            // Create a scroll view for the other scene list
            _otherSceneScrollPosition = GUILayout.BeginScrollView(_otherSceneScrollPosition);

            foreach (string scenePath in _otherScenePaths)
            {
                string sceneName = Path.GetFileNameWithoutExtension(scenePath);
                string[] pathFolders = scenePath.Split(Path.DirectorySeparatorChar);
                string lastFolder = pathFolders[pathFolders.Length - 2]; // Get the second-to-last folder in the path

                GUILayout.BeginHorizontal();

                // Create a toggle for selecting the scene
                _sceneSelections[scenePath] = GUILayout.Toggle(_sceneSelections[scenePath], "", GUILayout.Width(20));

                // Create a label for the scene name that can be clicked to highlight the scene file in the project window
                GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
                labelStyle.normal.textColor = Color.magenta;
                if (GUILayout.Button(lastFolder + "/" + sceneName, labelStyle))
                {
                    UnityEngine.Object sceneObject = AssetDatabase.LoadAssetAtPath(scenePath, typeof(SceneAsset));
                    Selection.activeObject = sceneObject;
                    EditorGUIUtility.PingObject(sceneObject);
                }

                GUILayout.EndHorizontal();
            }

            GUILayout.EndScrollView();

            GUILayout.Space(5);

            // Create a button for deleting the selected scenes
            if (GUILayout.Button("Delete Selected Scenes"))
            {
                if (EditorUtility.DisplayDialog("Delete Scenes", "Are you sure you want to delete the selected scenes? This is permanent and deleted scenes cannot be recovered.", "Delete", "Cancel"))
                {
                    // Delete the selected scenes
                    foreach (KeyValuePair<string, bool> selection in _sceneSelections)
                    {
                        if (selection.Value)
                        {
                            AssetDatabase.DeleteAsset(selection.Key);
                        }
                    }

                    // Generate the scene load menu code and close the window
                    SceneMenuListGenerator.GenerateSceneLoadMenuCode();
                    Close();
                }
            }
        }

        private List<string> GetScenePaths()
        {
            List<string> scenePaths = new List<string>();

            string sceneDirectoryPath = "Assets/Systems/Scenes/Game Scenes/";

            // Get all the scene files under the scene directory
            string[] files = Directory.GetFiles(sceneDirectoryPath, "*.unity", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                // Add the scene file path to the scene paths list
                scenePaths.Add(file);
            }

            // Add any additional scenes that were not found in the scene directory
            SceneAsset[] allScenes = Resources.FindObjectsOfTypeAll<SceneAsset>();
            foreach (SceneAsset sceneAsset in allScenes)
            {
                string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
                if (!scenePaths.Contains(scenePath))
                {
                    scenePaths.Add(scenePath);
                }
            }

            return scenePaths;
        }
    }
}
