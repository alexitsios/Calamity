using UnityEngine;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// Attach to gameobject to prevent it from being destroyed between scene changes.
    /// </summary>
    public class DontDestroy : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(this);
    }
}