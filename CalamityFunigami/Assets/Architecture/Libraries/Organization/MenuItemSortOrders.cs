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
        public const string SceneSettings = Scenes + Emoji.EmojiConstants.Gear + " Settings/";
    }
}