using UnityEditor;
namespace Calamity.SceneManagement {
/// <summary>
/// This class was auto generated from the SceneMenuListGenerator
/// </summary>
public class SceneListMenu
{
#if UNITY_EDITOR
        [MenuItem(" 🎬  Scenes/Test Environment")]
        public static void LoadTestEnvironment() { SceneMenuListGenerator.OpenScene("Assets/Scenes/Game Scenes/Test Environment.unity"); }
        [MenuItem(" 🎬  Scenes/Background Elements/BootLoader")]
        public static void LoadBootLoader() { SceneMenuListGenerator.OpenScene("Assets/Scenes/Game Scenes/Background Elements/BootLoader.unity"); }
        [MenuItem(" 🎬  Scenes/Background Elements/EventLogger")]
        public static void LoadEventLogger() { SceneMenuListGenerator.OpenScene("Assets/Scenes/Game Scenes/Background Elements/EventLogger.unity"); }
        [MenuItem(" 🎬  Scenes/Gameplay/FirstRoom")]
        public static void LoadFirstRoom() { SceneMenuListGenerator.OpenScene("Assets/Scenes/Game Scenes/Gameplay/FirstRoom.unity"); }
        [MenuItem(" 🎬  Scenes/UI/MainMenu")]
        public static void LoadMainMenu() { SceneMenuListGenerator.OpenScene("Assets/Scenes/Game Scenes/UI/MainMenu.unity"); }
#endif
}
}