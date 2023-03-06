namespace Calamity.AssetOrganization
{
    /// <summary>
    /// Paths and sort order for custom asset items in the creation menu.
    /// </summary>
    public struct AssetMenuSortOrders
    {
        // Top level domains
        public const string CommandsPath = "Player Commands/";
        public const string GameEventsPath = "Events/";
        public const string SceneManagementPath = "Scene Management/";

        // Order for lowest level domains
        private const int StartingIndex = 150;

        public const int CommandsOrder = StartingIndex;
        public const int GameEventsOrder = StartingIndex;
        public const int SceneManagementOrder = StartingIndex;
    }
}