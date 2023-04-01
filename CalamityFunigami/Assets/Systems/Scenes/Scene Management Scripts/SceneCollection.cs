using System.Collections.Generic;
using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// Groups of ScenePickers.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.SceneManagementPath + "Scene Collection", fileName = "SceneCollection", order = AssetMenuSortOrders.SceneManagementOrder + 2)]
    public class SceneCollection : ScriptableObject
    {
        [SerializeField] public List<ScenePicker> Scenes;
    }
}