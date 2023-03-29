using System;
using Calamity.AssetOrganization;
using UnityEditor;
using UnityEngine;

namespace Calamity.DebugTools
{
    /// <summary>
    /// Creates a window for the Gameplay tools. Pin the window in the editor to use during gameplay.
    /// </summary>
    public class GameplayToolsWindow : EditorWindow
    {
        private enum DebugTools
        {
            PointLightOnPlayer,
            UntaggedColliders,
            SwitchToNextCamera,
            GoToNextGameplayScene,
            FPSCounter,
            UIVisibility,
            MusicMasterMixer,
            SoundEffectsMasterMixer,
            VoiceOverMasterMixer,
            CemeteryBackgroundMusic,
            CreditsMenuMusic,
            LaboratoryBackgroundMusic,
            MainMenuMusic,
            MorgueBackgroundMusic,
            PauseMenuMusic,
            AmbientBackgroundNoise,
            MenuInteractionSfx,
            GunshotOneSfx,
            KnifeAttackOneSfx,
        }

        private bool _toggleOptionsOpen = true;
        private bool _nonToggleButtonsOpen = false;
        private bool _audioOptionsOpen = false;

        private bool _initTools;

        // Show the window
        [MenuItem(MenuItemSortOrders.GameplayTools + "Show Gameplay Tools Window")]
        public static void ShowWindow()
        {
            // Get existing open window or if none, make a new one
            GameplayToolsWindow window = (GameplayToolsWindow)GetWindow(typeof(GameplayToolsWindow));
            window.titleContent = new GUIContent("Gameplay Tools (Develop)");
            window.Show();
        }

        private void InitTools()
        {
            if (_initTools)
                return;

            _initTools = true;

            AddPointLightToPlayer.Initialize();
        }

        // Draw the window contents
        private void OnGUI()
        {
            GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
            boxStyle.fontSize = 14;
            boxStyle.normal.textColor = Color.white;

            GUILayout.Label("Currently in development and test, not ready for use.", EditorStyles.boldLabel);
            EditorGUI.BeginDisabledGroup(true);

            GUILayout.Box("Gameplay Debug Tools", boxStyle);

            if (!Application.isPlaying)
            {
                GUILayout.Space(5);
                GUILayout.Label("Application is not running");
                GUILayout.Space(5);
            }

            // Toggle Options Accordion
            _toggleOptionsOpen = EditorGUILayout.BeginFoldoutHeaderGroup(_toggleOptionsOpen, "Gameplay Effects");
            if (_toggleOptionsOpen)
            {
                EditorGUI.BeginDisabledGroup(!Application.isPlaying);
                GUILayout.Space(5);

                if (GUILayout.Button(DebugTools.PointLightOnPlayer.ToString()))
                {
                    InitTools();
                    AddPointLightToPlayer.ToggleLight();
                    EditorApplication.Beep();
                }

                if (GUILayout.Button(DebugTools.UntaggedColliders.ToString()))
                {
                    ToggleUnsetColliders.ToggleColliders();
                    EditorApplication.Beep();
                }

                /*if (GUILayout.Button(DebugTools.FPSCounter.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.UIVisibility.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }*/

                GUILayout.Space(5);
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            GUILayout.Space(5);

            // Non-Toggle Buttons Accordion
            /*_nonToggleButtonsOpen = EditorGUILayout.BeginFoldoutHeaderGroup(_nonToggleButtonsOpen, "Scene Effects");
            if (_nonToggleButtonsOpen)
            {
                EditorGUI.BeginDisabledGroup(!Application.isPlaying);
                GUILayout.Space(5);

                GUI.enabled = false;
                if (GUILayout.Button(DebugTools.SwitchToNextCamera.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.GoToNextGameplayScene.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }
                GUI.enabled = true;

                GUILayout.Space(5);
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            GUILayout.Space(5);

            // Audio Options Accordion
            _audioOptionsOpen = EditorGUILayout.BeginFoldoutHeaderGroup(_audioOptionsOpen, "Audio Mixers");
            if (_audioOptionsOpen)
            {
                EditorGUI.BeginDisabledGroup(!Application.isPlaying);
                GUILayout.Space(5);

                GUILayout.Space(5);
                GUILayout.Label("Music");
                GUILayout.Space(5);
                if (GUILayout.Button(DebugTools.MusicMasterMixer.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }                                

                if (GUILayout.Button(DebugTools.CemeteryBackgroundMusic.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.CreditsMenuMusic.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.LaboratoryBackgroundMusic.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.MainMenuMusic.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.MorgueBackgroundMusic.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.PauseMenuMusic.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                GUILayout.Space(5);
                GUILayout.Label("Sound Effects");
                GUILayout.Space(5);

                if (GUILayout.Button(DebugTools.SoundEffectsMasterMixer.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.AmbientBackgroundNoise.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.MenuInteractionSfx.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.GunshotOneSfx.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                if (GUILayout.Button(DebugTools.KnifeAttackOneSfx.ToString()))
                {
                    throw new NotSupportedException("This button is not yet implemented");
                }

                GUILayout.Space(5);
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            */

            GUILayout.Space(10);
            EditorGUI.EndDisabledGroup();
        }
    }
}