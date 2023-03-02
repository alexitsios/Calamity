using UnityEngine;
using UnityEngine.Events;

namespace Calamity.EventSystem
{
    /// <summary>
    /// Listens for game event and triggers callback.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityEvent _callbackEvent;

#if UNITY_EDITOR
        // Display notes field in the inspector.
        [Multiline, SerializeField]
        private string DeveloperNotes = "";     
#endif

        // Register and deregister events
        private void Awake() => _gameEvent.RegisterListener(this);
        private void OnDestroy() => _gameEvent.DeregisterListener(this);

        // Invoke event
        public void RaiseEvent() => _callbackEvent.Invoke();
    }
}