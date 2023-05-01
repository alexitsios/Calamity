using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Calamity.EventSystem
{
    /// <summary>
    /// Listens for game event and triggers callback.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        [FormerlySerializedAs("_gameEvent")]
        public GameEvent _GameEvent;
        [SerializeField] private UnityEvent _callbackEvent;

#if UNITY_EDITOR
#pragma warning disable 0414
        // Display notes field in the inspector.
        [Multiline, SerializeField]
        [FormerlySerializedAs("DeveloperNotes")]
        private string _developerNotes = "";
#pragma warning restore 0414
#endif

        // Register and deregister events
        private void Awake() => _GameEvent.RegisterListener(this);
        private void OnDestroy() => _GameEvent.DeregisterListener(this);

        // Invoke event
        public void RaiseEvent() => _callbackEvent.Invoke();
    }
}