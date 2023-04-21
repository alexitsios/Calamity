using System.IO;
using System.Threading.Tasks;
using Calamity.EventSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// Loads abstracted scene elements asynchronously and compiles them into active gameplay.
    /// </summary>
    public class BootLoader : MonoBehaviour
    {
        [SerializeField] private LoadSceneController _loadSceneController;
        [SerializeField] private ActiveScenesSet _activeLoadedScenes;
        [SerializeField] private GameEvent _bootEvent;
        [SerializeField] private ScenePicker _bootLoader;
        [SerializeField] private ScenePicker _eventLogger;
        [SerializeField] private ScenePicker _sceneLoadingManager;
        [SerializeField] private SceneCollection _bootScenes;

        // Load the event logger before anything else so all events are captured.
        private void PreloadBootScenes()
        {
            // boot scene
            _activeLoadedScenes.Add(_bootLoader);

            // scene loading manager
            string sceneLoadingManagerName = Path.GetFileNameWithoutExtension(_sceneLoadingManager.ScenePath);
            _loadSceneController.Model.ScenesToLoad.Add(SceneManager.LoadSceneAsync(sceneLoadingManagerName, LoadSceneMode.Additive));
            _activeLoadedScenes.Add(_sceneLoadingManager);

            // event logger
            string eventLoggerName = Path.GetFileNameWithoutExtension(_eventLogger.ScenePath);
            _loadSceneController.Model.ScenesToLoad.Add(SceneManager.LoadSceneAsync(eventLoggerName, LoadSceneMode.Additive));
            _activeLoadedScenes.Add(_eventLogger);
        }

        // Boot
        private void Awake() => PreloadBootScenes();
        private async void Start() => await Boot();

        private async Task Boot()
        {
            _activeLoadedScenes.Items.Clear();
            _bootEvent?.Invoke();
            await _loadSceneController.LoadSceneCollectionAdditive(_bootScenes, false);
        }
    }
}