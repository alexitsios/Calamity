using UnityEngine;
using UnityEngine.UI;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// An ILoadingScreenView to display loading screen prefab. Supports multiple variations of ILoadingScreenView.
    /// </summary>
    public class LoadingScreenView : MonoBehaviour, ILoadingScreenView
    {
        [SerializeField] private GameObject _loadingScreenPrefab;
        [SerializeField] private Image _loadingProgressBar;

        public void DisplayLoadingScreen(bool visible)
        {
            _loadingScreenPrefab.SetActive(visible);
        }

        public void OnProgressUpdate(float progress)
        {
            _loadingProgressBar.fillAmount = progress;
        }
    }    
}