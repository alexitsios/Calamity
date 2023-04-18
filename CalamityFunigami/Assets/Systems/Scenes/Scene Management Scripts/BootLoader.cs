using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Calamity.EventSystem;
using UnityEngine.Serialization;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// Loads abstracted scene elements asynchronously and compiles them into active gameplay.
    /// </summary>
    public class BootLoader : MonoBehaviour
    {

        [SerializeField]
        private ActiveScenesSet _activeLoadedScenes;

        [FormerlySerializedAs("bootScenes")]
        [SerializeField]
        private SceneCollection _bootScenes;

        [FormerlySerializedAs("bootEvent")]
        [SerializeField]
        private GameEvent _bootEvent;

        [FormerlySerializedAs("eventLogger")]
        [SerializeField]
        private ScenePicker _eventLogger;

        [FormerlySerializedAs("loadingScreenPrefab")]
        [SerializeField]
        private GameObject _loadingScreenPrefab;

        [FormerlySerializedAs("loadingProgressBar")]
        [SerializeField]
        private Image _loadingProgressBar;

        private List<AsyncOperation> _scenesToLoad = new List<AsyncOperation>();
        private List<GameEvent> _eventsToInvokeAfterLoading = new List<GameEvent>();

        // Boot
        private void Awake() => PreloadEventLoger();
        private void Start() => Boot();

        private void Boot()
        {
            _activeLoadedScenes.Items.Clear();
            _bootEvent?.Invoke();
            LoadSceneCollectionAdditive(_bootScenes);
        }

        // Load the event logger before anything else so all events are captured.
        private void PreloadEventLoger()
        {
            string eventLoggerName = Path.GetFileNameWithoutExtension(_eventLogger.ScenePath);
            _scenesToLoad.Add(SceneManager.LoadSceneAsync(eventLoggerName, LoadSceneMode.Additive));
            _activeLoadedScenes.Add(_eventLogger);
        }

        /// <summary>
        /// Loads a ScenePicker without a splash screen.
        /// </summary>
        /// <param name="scene">Scene Picker object to load.</param>
        public void LoadSceneAdditiveWithoutSplashScreen(ScenePicker scene)
        {
            GameEvent afterLoadingEvent = scene.SceneFinishedLoadingEvent;
            if (afterLoadingEvent)
                _eventsToInvokeAfterLoading.Add(afterLoadingEvent);

            string sceneName = Path.GetFileNameWithoutExtension(scene.ScenePath);
            _scenesToLoad.Add(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive));
            _activeLoadedScenes.Add(scene);
            StartCoroutine(LoadingWithoutSplashScreen());
        }

        /// <summary>
        /// Display splash screen while loading Scene Picker object.
        /// </summary>
        /// <param name="scene">Scene Picker object to load.</param>
        public void LoadSceneAdditiveWithSplashScreen(ScenePicker scene)
        {
            ShowLoadingScreen();

            GameEvent afterLoadingEvent = scene.SceneFinishedLoadingEvent;
            if (afterLoadingEvent)
                _eventsToInvokeAfterLoading.Add(afterLoadingEvent);

            string sceneName = Path.GetFileNameWithoutExtension(scene.ScenePath);
            _scenesToLoad.Add(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive));
            _activeLoadedScenes.Add(scene);
            StartCoroutine(LoadingWithSplashScreen());
        }

        /// <summary>
        /// Loads a Scene Collection and display splash screen.
        /// </summary>
        /// <param name="sceneCollection">Collection of ScenePickers to load.</param>
        public void LoadSceneCollectionAdditive(SceneCollection sceneCollection)
        {
            int i;

            ShowLoadingScreen();

            for (i = 0; i < sceneCollection.Scenes.Count; i++)
            {
                GameEvent afterLoadingEvent = sceneCollection.Scenes[i].SceneFinishedLoadingEvent;
                if (afterLoadingEvent)
                    _eventsToInvokeAfterLoading.Add(afterLoadingEvent);

                string sceneName = Path.GetFileNameWithoutExtension(sceneCollection.Scenes[i].ScenePath);
                _scenesToLoad.Add(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive));
                _activeLoadedScenes.Add(sceneCollection.Scenes[i]);
            }

            StartCoroutine(LoadingWithSplashScreen());
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
        /// Unloads any scene not marked static from the RuntimeScenes runtime set. 
        /// </summary>
        public void UnloadNonStaticScenes()
        {
            int i;
            for(i = 0; i < _activeLoadedScenes.Items.Count; i++)
            {
                ScenePicker _scene = _activeLoadedScenes.Items[i];
                if (!_scene.StaticScene)
                    UnloadScene(_scene);
            }
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

        /// <summary>
        /// Display loading screen prefab.
        /// </summary>
        private void ShowLoadingScreen()
        {
            _loadingScreenPrefab.SetActive(true);
        }

        /// <summary>
        /// Hide loading screen prefab.
        /// </summary>
        private void HideLoadingScreen()
        {
            _loadingScreenPrefab.SetActive(false);
        }

        /// <summary>
        /// Load scenes in background.
        /// </summary>
        /// <returns>null</returns>
        private IEnumerator LoadingWithoutSplashScreen()
        {
            int i;
            int sceneCount = _scenesToLoad.Count;

            for (i = 0; i < sceneCount; i++)
            {
                while (!_scenesToLoad[i].isDone)
                {
                    yield return null;
                }
            }

            InvokeSceneLoadedEvents();
        }

        /// <summary>
        /// Load scenes in foreground, display splash screen. Close when finished.
        /// </summary>
        /// <returns>null</returns>
        private IEnumerator LoadingWithSplashScreen()
        {
            int i;
            float totalProgress = 0;
            int sceneCount = _scenesToLoad.Count;

            for (i = 0; i < sceneCount; i++)
            {
                while (!_scenesToLoad[i].isDone)
                {
                    totalProgress += _scenesToLoad[i].progress;
                    _loadingProgressBar.fillAmount = totalProgress / sceneCount;
                    yield return null;
                }
            }
            HideLoadingScreen();
            InvokeSceneLoadedEvents();
        }

        /// <summary>
        /// Event callbacks after scene has been loaded.
        /// </summary>
        private void InvokeSceneLoadedEvents()
        {
            int i;
            for (i = 0; i < _eventsToInvokeAfterLoading.Count; i++)
            {
                _eventsToInvokeAfterLoading[i]?.Invoke();
            }
            _eventsToInvokeAfterLoading.Clear();
        }
    }
}