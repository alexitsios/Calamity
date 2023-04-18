using UnityEngine;

namespace Calamity.CommandSystem {
    public abstract class FeedbackCommand : ScriptableObject
    {
        public void Invoke() => Actions();
        public abstract void Actions();
    }
}