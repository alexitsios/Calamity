namespace Calamity.AssetOrganization
{
    /// <summary>
    /// Paths and sort order for custom asset items in the creation menu.
    /// </summary>
    public struct AssetMenuSortOrders
    {
        // Top level domains
        public const string AudioPath = "Audio/";
        public const string CommandsPath = "Commands/";
        public const string FeedbackCommandsPath = "Feedback Commands/";
        public const string GameEventsPath = "Game Events/";
        public const string MathPath = "Math/";
        public const string PrimitivesPath = "Primitives/";
        public const string SceneManagementPath = "Scene Management/";

        // Second level domains
        //public const string AudioEventsPath = AudioPath + "Events/";

        // Order for lowest level domains
        private const int StartingIndex = 150;

        public const int AudioOrder = StartingIndex + 1;
        public const int AudioEventOrder = StartingIndex + 2;
        public const int CommandsOrder = StartingIndex + 3;
        public const int FeedbackCommandsOrder = StartingIndex + 4;
        public const int GameEventsOrder = StartingIndex + 5;
        public const int MathOrder = StartingIndex + 6;
        public const int PrimitivesOrder = StartingIndex + 7;
        public const int SceneManagementOrder = StartingIndex + 8;
    }
}