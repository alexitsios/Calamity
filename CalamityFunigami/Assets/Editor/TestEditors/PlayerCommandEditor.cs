using UnityEngine;
using UnityEditor;
using System.IO;
using Calamity.AssetOrganization;
using System.Diagnostics;

namespace Calamity.CommandSystem.Editor
{
    public class PlayerCommandEditor : EditorWindow
    {
        private static string _commandName = "NewCommand";
        private static string _commandFolder = "Assets/Commands";
        private bool _isFolderLocked = true;

        [MenuItem(MenuItemSortOrders.CommandTools + "Player Command Editor", priority = MenuItemSortOrders.CommandToolsPriority + 1)]
        public static void ShowWindow()
        {
            GetWindow<PlayerCommandEditor>("Player Command Editor");            
        }

        private void OnGUI()
        {
            GUILayout.Label("Currently in development and test, not ready for use.", EditorStyles.boldLabel);
            EditorGUI.BeginDisabledGroup(true);
            GUILayout.Label("Create New Player Command", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Creating new Commands from this window adds a custom command folder, under the name you choose, to the commands folder, and a script with the template for a new command.", EditorStyles.wordWrappedMiniLabel);

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Command Name:", GUILayout.Width(90));
            _commandName = EditorGUILayout.TextField(_commandName);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Command Folder:", GUILayout.Width(90));

            EditorGUI.BeginDisabledGroup(_isFolderLocked);
            _commandFolder = EditorGUILayout.TextField(_commandFolder);
            EditorGUI.EndDisabledGroup();

            _isFolderLocked = GUILayout.Toggle(_isFolderLocked, new GUIContent("Lock", "Should be left as default in most cases."), "Button", GUILayout.Width(50));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            if (GUILayout.Button("Create Command"))
            {
                CreatePlayerCommand();
                //Close();
            }
            EditorGUI.EndDisabledGroup();
        }

        private void CreatePlayerCommand()
        {
            // Create the folder for the new command
            string commandFolderPath = $"{_commandFolder}/{_commandName}";
            if (!AssetDatabase.IsValidFolder(commandFolderPath))
            {
                AssetDatabase.CreateFolder(_commandFolder, _commandName);
            }

            // Create the script for the new command
            string scriptName = $"{_commandName}Command.cs";
            string scriptPath = $"{commandFolderPath}/{scriptName}";

            if (File.Exists(scriptPath))
            {
                UnityEngine.Debug.LogError($"A script with the name {scriptName} already exists at {commandFolderPath}. Please choose a different name.");
                return;
            }

            GenerateCommandScript(scriptPath);

            GeneratePingLink(scriptPath);

            AssetDatabase.Refresh();
        }

        private void GeneratePingLink(string scriptPath)
        {
            Object scriptObj = AssetDatabase.LoadAssetAtPath<Object>(scriptPath);

            // Create a label with a clickable link to ping the object
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.blue;
            style.hover.textColor = Color.blue;
            style.stretchWidth = false;
            GUILayout.Label("Ping MyScript", style, GUILayout.ExpandWidth(false));
            Rect labelRect = GUILayoutUtility.GetLastRect();
            if (Event.current.type == EventType.MouseDown && labelRect.Contains(Event.current.mousePosition))
            {
                EditorGUIUtility.PingObject(scriptObj);
                Event.current.Use();
            }
        }

        private void GenerateCommandScript(string scriptPath)
        {
            string _customScript =
                       "using System;\n" +
                       "using UnityEngine;\n" +
                       "using Calamity.AssetOrganization;\n" +
                        "\n" +
                       $"namespace Calamity.CommandSystem\n" +
                       "{\n" +
                       $"    [CreateAssetMenu(menuName = AssetMenuSortOrders.CommandsPath + \"{_commandName}Command\", fileName = \"{_commandName}Command\", order = AssetMenuSortOrders.CommandsOrder + 1)]\n" +
                       $"    public class {_commandName}Command : PlayerCommand\n" +
                       "    {\n" +
                       $"        private readonly Func<bool> {_commandName}Delegate;\n" +
                       "\n" +
                       $"        public {_commandName}Command()\n" +
                       "        {\n" +
                       $"            {_commandName}Delegate = new Func<bool>({_commandName}ToDo);\n" +
                       "        }\n" +
                       "\n" +
                       "        protected override bool ExecuteCommand()\n" +
                       "        {\n" +
                       $"            return {_commandName}Delegate();\n" +
                       "        }\n" +
                       "\n" +
                       $"        private bool {_commandName}ToDo()\n" +
                       "        {\n" +
                       "            // Placeholder execution code here\n" +
                       "            return true;\n" +
                       "        }\n" +
                       "    }\n" +
                       "}\n";

            using (StreamWriter sw = File.CreateText(scriptPath))
            {
                sw.Write(_customScript);
                sw.Close();
            }
        }
    }
}
