using UnityEditor;
using System;
using Calamity.AssetOrganization;

#if UNITY_EDITOR

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
        [MenuItem(MenuItemSortOrders.Tools + "Open Audio Mixer")]
        public static void OpenMixerWindow()
        {
            // Execute the menu item for opening the Audio Mixer window
            EditorApplication.ExecuteMenuItem("Window/Audio/Audio Mixer");

            // Get the AudioMixerWindow type using reflection
            Type audioMixerWindowType = Type.GetType("UnityEditor.AudioMixerWindow, UnityEditor");

            if (audioMixerWindowType != null)
            {
                EditorWindow mixerWindow = EditorWindow.GetWindow(audioMixerWindowType);

                mixerWindow.Show();
            }
        }
    }
}

#endif