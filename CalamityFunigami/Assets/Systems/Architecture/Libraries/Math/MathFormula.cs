using UnityEngine;

namespace Calamity.Math
{
    public abstract class MathFormula<T> : ScriptableObject
    {
        public abstract T Value { get; }

#if UNITY_EDITOR
        protected abstract void DebugLogResult();
#endif
    }
}
