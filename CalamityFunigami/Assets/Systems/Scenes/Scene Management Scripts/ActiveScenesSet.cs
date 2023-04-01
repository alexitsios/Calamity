using UnityEngine;
using Calamity.SceneManagement;
using Calamity.AssetOrganization;

/// <summary>
/// Runtime set of the active loaded scenes.
/// </summary>
[CreateAssetMenu(menuName = AssetMenuSortOrders.SceneManagementPath + "ActiveSceneCollection", fileName = "ActiveSceneCollection", order = AssetMenuSortOrders.SceneManagementOrder + 1)]
public class ActiveScenesSet : RuntimeSet<ScenePicker>
{    
}