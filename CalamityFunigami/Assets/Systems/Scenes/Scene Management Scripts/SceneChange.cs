using Calamity.AssetOrganization;
using UnityEngine;

namespace Calamity.SceneManagement
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.SceneManagementPath + "Scene Change", fileName = "SceneChange", order = AssetMenuSortOrders.SceneManagementOrder + 3)]
    public class SceneChange : ScriptableObject
    {
        [Tooltip("ScenesPickers not marked Static will be unloaded between scene changes.")]
        public bool UnloadNonStaticScenes;
        public bool UseSplashScreen;

        public bool UseSceneCollection;
        public ScenePicker SceneToLoad;
        public SceneCollection SceneCollectionToLoad;
    }
}