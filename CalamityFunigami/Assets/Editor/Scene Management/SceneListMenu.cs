using UnityEditor;
using Calamity.AssetOrganization;
namespace Calamity.SceneManagement {
/// <summary>
/// This class was auto generated from the SceneMenuListGenerator
/// </summary>
public class SceneListMenu
{
#if UNITY_EDITOR
        [MenuItem(" 🎬  Scenes/Open//Gameplay Test Area", priority = MenuItemSortOrders.SceneOpenPriority)]
        public static void LoadGameplayTestArea() { SceneMenuListGenerator.OpenScene("Assets/Systems/Scenes/Game Scenes/Gameplay Test Area.unity"); }
        [MenuItem(" 🎬  Scenes/Open//BackgroundElements/Audio", priority = MenuItemSortOrders.SceneOpenPriority)]
        public static void LoadAudio() { SceneMenuListGenerator.OpenScene("Assets/Systems/Scenes/Game Scenes/BackgroundElements/Audio.unity"); }
        [MenuItem(" 🎬  Scenes/Open//BackgroundElements/BootLoader", priority = MenuItemSortOrders.SceneOpenPriority)]
        public static void LoadBootLoader() { SceneMenuListGenerator.OpenScene("Assets/Systems/Scenes/Game Scenes/BackgroundElements/BootLoader.unity"); }
        [MenuItem(" 🎬  Scenes/Open//BackgroundElements/EventLogger", priority = MenuItemSortOrders.SceneOpenPriority)]
        public static void LoadEventLogger() { SceneMenuListGenerator.OpenScene("Assets/Systems/Scenes/Game Scenes/BackgroundElements/EventLogger.unity"); }
        [MenuItem(" 🎬  Scenes/Open//Cemetery", priority = MenuItemSortOrders.SceneOpenPriority)]
        public static void LoadCemetery() { SceneMenuListGenerator.OpenScene("Assets/Systems/Scenes/Game Scenes/Gameplay/Cemetery.unity"); }
        [MenuItem(" 🎬  Scenes/Open//Laboratory", priority = MenuItemSortOrders.SceneOpenPriority)]
        public static void LoadLaboratory() { SceneMenuListGenerator.OpenScene("Assets/Systems/Scenes/Game Scenes/Gameplay/Laboratory.unity"); }
        [MenuItem(" 🎬  Scenes/Open//Morgue", priority = MenuItemSortOrders.SceneOpenPriority)]
        public static void LoadMorgue() { SceneMenuListGenerator.OpenScene("Assets/Systems/Scenes/Game Scenes/Gameplay/Morgue.unity"); }
        [MenuItem(" 🎬  Scenes/Open//UI/MainMenu", priority = MenuItemSortOrders.SceneOpenPriority)]
        public static void LoadMainMenu() { SceneMenuListGenerator.OpenScene("Assets/Systems/Scenes/Game Scenes/UI/MainMenu.unity"); }
#endif
}
}