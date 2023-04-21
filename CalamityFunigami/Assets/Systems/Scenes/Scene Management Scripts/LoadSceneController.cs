using System.IO;
using Calamity.EventSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Calamity.AssetOrganization;
using System.Threading.Tasks;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// The controller for loading scenes
    /// </summary>
    [CreateAssetMenu(menuName = AssetMenuSortOrders.SceneManagementPath + "Load Scene Controller", fileName = "LoadSceneController", order = AssetMenuSortOrders.SceneManagementOrder + 2)]
    public class LoadSceneController : ScriptableObject
    {
        [SerializeField] private ActiveScenesSet _activeLoadedScenes;

        private LoadingScenesModel _model;
        private ILoadingScreenView _view;

        /// <summary>
        /// Initializes on first use.
        /// </summary>
        public LoadingScenesModel Model
        {
            get
            {
                if (_model == null)
                {
                    // I'm not convinced this is the best way to initialize this.
                    // It seems restrictive to the first LoadingScreenView instance.
                    // Rather than the ILoadingScreenView interface.
                    _view = FindObjectOfType<LoadingScreenView>();  
                    _model = new LoadingScenesModel(_view);
                }
                return _model;
            }
        }

        // Scene Change
        public async void SceneChange(SceneChange sceneChange)
        {
            if (sceneChange.UnloadNonStaticScenes)
                await Task.Run(() => UnloadNonStaticScenes());
            await LoadSceneAdditive(sceneChange.SceneToLoad, sceneChange.UseSplashScreen);
        }

        /// <summary>
        /// Loads a ScenePicker
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="useSplashScreen"></param>
        private async Task LoadSceneAdditive(ScenePicker scene, bool useSplashScreen)
        {
            if (useSplashScreen)
                _view.DisplayLoadingScreen(true);

            GameEvent afterLoadingEvent = scene.SceneFinishedLoadingEvent;
            if (afterLoadingEvent)
                Model.EventsToInvokeAfterLoading.Add(afterLoadingEvent);

            string sceneName = Path.GetFileNameWithoutExtension(scene.ScenePath);
            Model.ScenesToLoad.Add(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive));
            _activeLoadedScenes.Add(scene);

            await Model.Loading(useSplashScreen);

            if (useSplashScreen)
                _view.DisplayLoadingScreen(useSplashScreen);
        }

        /// <summary>
        /// Loads a Scene Collection and display splash screen.
        /// </summary>
        /// <param name="sceneCollection">Collection of ScenePickers to load.</param>
        public async Task LoadSceneCollectionAdditive(SceneCollection sceneCollection, bool useSplashScreen)
        {
            int i;

            if (useSplashScreen)
                _view.DisplayLoadingScreen(true);

            for (i = 0; i < sceneCollection.Scenes.Count; i++)
            {
                GameEvent afterLoadingEvent = sceneCollection.Scenes[i].SceneFinishedLoadingEvent;
                if (afterLoadingEvent)
                    Model.EventsToInvokeAfterLoading.Add(afterLoadingEvent);

                string sceneName = Path.GetFileNameWithoutExtension(sceneCollection.Scenes[i].ScenePath);
                Model.ScenesToLoad.Add(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive));
                _activeLoadedScenes.Add(sceneCollection.Scenes[i]);
            }

            await Model.Loading(useSplashScreen);

            if (useSplashScreen)
                _view.DisplayLoadingScreen(useSplashScreen);
        }

        /// <summary>
        /// Unloads any scene not marked static from the RuntimeScenes runtime set. 
        /// </summary>
        public void UnloadNonStaticScenes()
        {
            int i;
            for (i = 0; i < _activeLoadedScenes.Items.Count; i++)
            {
                ScenePicker _scene = _activeLoadedScenes.Items[i];
                if (!_scene.StaticScene)
                    UnloadScene(_scene);
            }
        }

        /// <summary>
        /// Deactivate a single active scene.
        /// </summary>
        /// <param name="scene">Scene Picker to deactivate.</param>
        public void UnloadScene(ScenePicker scene)
        {
            string sceneName = Path.GetFileNameWithoutExtension(scene.ScenePath);
            SceneManager.UnloadSceneAsync(sceneName);
            _activeLoadedScenes.Remove(scene);
        }

        /// <summary>
        /// Deactivate a collection of scenes.
        /// </summary>
        /// <param name="sceneCollection">SceneCollection to deactivate.</param>
        public void UnloadSceneCollection(SceneCollection sceneCollection)
        {
            int i;
            for (i = 0; i < sceneCollection.Scenes.Count; i++)
            {
                string sceneName = Path.GetFileNameWithoutExtension(sceneCollection.Scenes[i].ScenePath);
                SceneManager.UnloadSceneAsync(sceneName);
                _activeLoadedScenes.Remove(sceneCollection.Scenes[i]);
            }
        }
    }
}