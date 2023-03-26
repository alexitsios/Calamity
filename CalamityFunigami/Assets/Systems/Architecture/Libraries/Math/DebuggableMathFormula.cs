using UnityEngine;

namespace Calamity.Math
{
    public class DebuggableMathFormula
    {
        protected string result;

        [ContextMenu("Log Calculated Result")]
        private void DebugLogResult()
        {
            Debug.Log(result);
        }
    }
}