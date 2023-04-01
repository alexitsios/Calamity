using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Text;
using System.IO;
using UnityEngine;
using Seeker.Emojis;
using Calamity.AssetOrganization;

namespace Calamity.SceneManagement
{
#if UNITY_EDITOR
    public struct SceneMenuListGenerator
    {
        private const string PathToScenesFolder = "/Systems/Scenes/Game Scenes";
        private const string AssetPathToScenesFolder = "Assets" + PathToScenesFolder;
        private const string PathToOutputScript = "/Editor/Scene Management/SceneListMenu.cs";

        /// <summary>
        /// Generates the list of menu items that can be used to load Unity scenes.
        /// </summary>
        [MenuItem(MenuItemSortOrders.SceneSettings + Emoji.EmojiConstants.Recycle + "Refresh Scene List Menu", priority = MenuItemSortOrders.SceneSettingsPriority + 2)]
        public static void GenerateSceneLoadMenuCode()
        {
            StringBuilder result = new StringBuilder();
            string basePath = Application.dataPath + PathToScenesFolder;
            AddClassHeader(result);
            AddCodeForDirectory(new DirectoryInfo(basePath), result);
            AddClassFooter(result);

            string scriptPath = Application.dataPath + PathToOutputScript;
            File.WriteAllText(scriptPath, result.ToString());

            void AddCodeForDirectory(DirectoryInfo directoryInfo, StringBuilder result)
            {
                FileInfo[] fileInfoList = directoryInfo.GetFiles();
                for (int i = 0; i < fileInfoList.Length; i++)
                {
                    FileInfo fileInfo = fileInfoList[i];
                    if (fileInfo.Extension == ".unity")
                    {
                        AddCodeForFile(fileInfo, result);
                    }
                }
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                for (int i = 0; i < subDirectories.Length; i++)
                {
                    AddCodeForDirectory(subDirectories[i], result);
                }

                void AddCodeForFile(FileInfo fileInfo, StringBuilder result)
                {
                    string subPath = fileInfo.FullName.Replace('\\', '/').Replace(basePath, "");
                    string assetPath = AssetPathToScenesFolder + subPath;

                    string functionName = fileInfo.Name.Replace(".unity", "").Replace(" ", "").Replace("-", "");
                    string scenePrefix = "Scenes/Open/";

                    if (subPath.StartsWith("/Gameplay/"))
                    {
                        // Remove "Gameplay/" from the subPath to move it up one level
                        subPath = subPath.Replace("/Gameplay/", "/");
                    }

                    result.Append($"        [MenuItem(\"{Emoji.EmojiConstants.ClapperBoard} {scenePrefix}{subPath.Replace(".unity", "")}\", priority = MenuItemSortOrders.SceneOpenPriority)]").Append(Environment.NewLine);
                    result.Append("        public static void Load").Append(functionName).Append("() { SceneMenuListGenerator.OpenScene(\"").Append(assetPath).Append("\"); }").Append(Environment.NewLine);
                }
            }
            AssetDatabase.Refresh();
        }

        private static void AddClassHeader(StringBuilder result)
        {
            result.Append(@"using UnityEditor;
using Calamity.AssetOrganization;
namespace Calamity.SceneManagement {
/// <summary>
/// This class was auto generated from the SceneMenuListGenerator
/// </summary>
public class SceneListMenu
{
");
            result.Append(@"#if UNITY_EDITOR
");
        }

        private static void AddClassFooter(StringBuilder result)
        {
            result.Append(@"#endif
}
}");
        }

        /// <summary>
        /// Open the requested scene path.
        /// </summary>
        /// <param name="scenePath">File path to scene to open</param>
        public static void OpenScene(string scenePath)
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
        }
    }
#endif
}