using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Calamity.AssetOrganization
{
    /// <summary>
    /// Removes [FormerlySerializedAs] tags that are older than 30 days.
    /// </summary>
    public static class RemoveFormerlySerializedAsTags
    {
        [MenuItem(MenuItemSortOrders.OrganizationTools + "Remove [FormerlySerializedAs] Tags", priority = MenuItemSortOrders.OrganizationToolsPriority + 1)]
        public static void RemoveTags()
        {
            List<string> filesToModify = new List<string>();

            // Get all C# scripts in the Assets folder
            string[] scriptFiles = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories);
            foreach (string file in scriptFiles)
            {
                DateTime lastWriteTime = File.GetLastWriteTime(file);
                TimeSpan timeSinceWrite = DateTime.Now.Subtract(lastWriteTime);

                // Check if the file was last modified more than 30 days ago
                if (timeSinceWrite.TotalDays > 30)
                {
                    string contents = File.ReadAllText(file);

                    // Check if the file contains any [FormerlySerializedAs] tags
                    if (contents.Contains("[FormerlySerializedAs"))
                    {
                        // Remove the [FormerlySerializedAs] tags
                        contents = contents.Replace("[FormerlySerializedAs", "");
                        contents = contents.Replace("]", "");

                        File.WriteAllText(file, contents);

                        filesToModify.Add(file);
                    }
                }
            }

            if (filesToModify.Count > 0)
            {
                Debug.Log("Removed [FormerlySerializedAs] tags from the following files:");
                foreach (string file in filesToModify)
                {
                    Debug.Log(file);
                }
            }
            else
            {
                Debug.Log("No files found with [FormerlySerializedAs] tags that are more than 30 days old.");
            }
        }
    }
}
