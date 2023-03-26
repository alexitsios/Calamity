using UnityEditor;
using System;
using Calamity.AssetOrganization;
using UnityEngine;

namespace Calamity.Audio
{
    /// <summary>
    /// Static class for creating a shortcut to open the Audio Mixer window in Unity Editor.
    /// </summary>
    public static class MixerMenuShortcut
    {
        /// <summary>
        /// MenuItem attribute used to create a menu item in the Tools menu of the Unity Editor.
        /// </summary>
        [MenuItem(MenuItemSortOrders.AudioTools + "Open Audio Mixer", priority = MenuItemSortOrders.AudioToolsPriority + 1)]
        public static void OpenMixerWindow()
        {
            // Execute the menu item for opening the Audio Mixer window
            EditorApplication.ExecuteMenuItem("Window/Audio/Audio Mixer");

            // Get the AudioMixerWindow type using reflection
            /*Type audioMixerWindowType = Type.GetType("UnityEditor.AudioMixerWindow, UnityEditor");

            EditorWindow mixerWindow = EditorWindow.GetWindow(audioMixerWindowType);

            // Maximize the mixer window to fill the screen
            mixerWindow.maximized = true;

            // Make the mixer window the priority window on the screen
            mixerWindow.Focus();*/
        }
    }
}
