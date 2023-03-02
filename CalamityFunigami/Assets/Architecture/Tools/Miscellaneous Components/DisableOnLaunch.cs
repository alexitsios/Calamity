using UnityEngine;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// Disables the GameObject on awake.
    /// </summary>
    public class DisableOnLaunch : MonoBehaviour
    {
        private void Awake() => gameObject.SetActive(false);
    }
}