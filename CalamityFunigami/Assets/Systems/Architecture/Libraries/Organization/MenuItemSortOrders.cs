using Seeker.Emojis;
namespace Calamity.AssetOrganization
{
    /// <summary>
    /// Paths and sort order for menu items.
    /// </summary>
    public struct MenuItemSortOrders
    {
        // Top level domains
        public const string Scenes = Emoji.EmojiConstants.ClapperBoard + " Scenes/";
        public const string Tools = "Tools/";

        // Second level domains
        public const string SceneModifications = Scenes + Emoji.EmojiConstants.Wrench + " Modify/";
        public const string SceneSettings = Scenes + Emoji.EmojiConstants.Gear + " Settings/";
        public const string AudioTools = Tools + Emoji.EmojiConstants.Speaker + "Audio/";
        public const string CommandTools = Tools + Emoji.EmojiConstants.Scroll + "Commands/";
        public const string GameplayTools = Tools + Emoji.EmojiConstants.Controller + "Gameplay/";
        public const string OrganizationTools = Tools + Emoji.EmojiConstants.Folder + "Organization/";

        // Priorities
        public const int AudioToolsPriority = 10;
        public const int CommandToolsPriority = 20;
        public const int GameplayToolsPriority = 30;
        public const int OrganizationToolsPriority = 40;

        public const int SceneOpenPriority = 60;
        public const int SceneModificationsPriority = 80;
        public const int SceneSettingsPriority = 100;
    }
}