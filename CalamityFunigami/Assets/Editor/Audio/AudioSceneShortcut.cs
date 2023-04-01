using UnityEditor;
using Calamity.AssetOrganization;
using Calamity.SceneManagement;

namespace Calamity.Audio
{
    /// <summary>
    /// Adds a second option to open Audio scene from the Tools menu. Uses a manually set filepath.
    /// </summary>
    public class AudioSceneShortcut
    {
        private const string audioSceneFilePath = "Assets/Systems/Scenes/Game Scenes/BackgroundElements/Audio.unity";

        [MenuItem(MenuItemSortOrders.AudioTools + "Open Audio Scene", priority = MenuItemSortOrders.AudioToolsPriority + 2)]
        public static void LoadAudioScene()
        { SceneMenuListGenerator.OpenScene(audioSceneFilePath); }
    }
}   