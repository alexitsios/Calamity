using System.Collections.Generic;
using System.Threading.Tasks;
using Calamity.EventSystem;
using UnityEngine;

namespace Calamity.SceneManagement
{
    /// <summary>
    ///  The data and business logic of the loading system.
    /// </summary>
    public class LoadingScenesModel
    {
        public List<GameEvent> EventsToInvokeAfterLoading { get; private set; } = new List<GameEvent>();
        public List<AsyncOperation> ScenesToLoad { get; private set; } = new List<AsyncOperation>();

        private readonly ILoadingScreenView _loadingScreenView;

        public LoadingScenesModel(ILoadingScreenView loadingScreenView)
        {
            _loadingScreenView = loadingScreenView;
        }

        public async Task Loading(bool useSpashScreen = false)
        {
            int i;
            int sceneCount = ScenesToLoad.Count;
            float totalProgress = 0;

            for (i = 0; i < sceneCount; i++)
            {
                while (!ScenesToLoad[i].isDone)
                {
                    if (useSpashScreen)
                    {
                        totalProgress += ScenesToLoad[i].progress;
                        float fillAmount = totalProgress / sceneCount;
                        _loadingScreenView.OnProgressUpdate(fillAmount);
                    }

                    await Task.Yield();
                }
            }
                        
            InvokeSceneLoadedEvents();
        }

        private void InvokeSceneLoadedEvents()
        {
            int i;
            for (i = 0; i < EventsToInvokeAfterLoading.Count; i++)
            {
                EventsToInvokeAfterLoading[i]?.Invoke();
            }
            EventsToInvokeAfterLoading.Clear();
        }        
    }
}