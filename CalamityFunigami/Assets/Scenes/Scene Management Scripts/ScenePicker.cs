using UnityEngine;
using Calamity.AssetOrganization;
using Calamity.EventSystem;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// An object to point to a scene file to be used in SceneCollections.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.SceneManagementPath + "Scene Picker", fileName = "ScenePicker", order = AssetMenuSortOrders.SceneManagementOrder + 2)]
    public class ScenePicker : ScriptableObject
    {
        /// <summary>
        /// Event to call after scene has finished loading.
        /// </summary>
        public GameEvent SceneFinishedLoadingEvent;

        [HideInInspector] public string ScenePath;
    }
}