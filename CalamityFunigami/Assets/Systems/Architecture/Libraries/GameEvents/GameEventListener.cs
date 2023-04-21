using UnityEngine;
using UnityEngine.Events;

namespace Calamity.EventSystem
{
    /// <summary>
    /// Listens for game event and triggers callback.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent TargetGameEvent;
        public UnityEvent CallbackEvent;

#if UNITY_EDITOR
        // Display notes field in the inspector.
        [TextArea, SerializeField]
        private string _developerNotes = "";     
#endif

        // Register and deregister events
        private void Awake() => TargetGameEvent.RegisterListener(this);
        private void OnDestroy() => TargetGameEvent.DeregisterListener(this);

        // Invoke event
        public void RaiseEvent() => CallbackEvent.Invoke();
    }
}