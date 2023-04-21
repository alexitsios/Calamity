using System;
using UnityEngine;
using Calamity.AssetOrganization;
using Calamity.EventSystem;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// An object to point to a scene file to be used in SceneCollections.
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.SceneManagementPath + "Scene Picker", fileName = "ScenePicker", order = AssetMenuSortOrders.SceneManagementOrder + 5)]
    public class ScenePicker : ScriptableObject
    {
        /// <summary>
        /// Static Scenes will not be unloaded automatically between scene changes.
        /// </summary>
        public bool StaticScene;

        /// <summary>
        /// The path to the Scene file. - Hide to overwrite with a custom inspector
        /// </summary>
        [HideInInspector]public string ScenePath;

        /// <summary>
        /// Event to call after scene has finished loading.
        /// </summary>
        public GameEvent SceneFinishedLoadingEvent;
    }
}