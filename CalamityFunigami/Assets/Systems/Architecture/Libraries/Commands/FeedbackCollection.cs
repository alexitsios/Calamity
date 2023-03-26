using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.CommandSystem
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.FeedbackCommandsPath + "Feedback Collection", fileName = "FeedbackCollection", order = AssetMenuSortOrders.FeedbackCommandsOrder + 1)]
    public class FeedbackCollection : RuntimeSet<FeedbackCommand> { }
}