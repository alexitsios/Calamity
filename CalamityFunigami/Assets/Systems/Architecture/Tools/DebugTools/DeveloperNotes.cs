#if UNITY_EDITOR
using UnityEngine;

namespace Calamity.DebugTools
{
    /// <summary>
    /// Attachable notes only used in the editor.
    /// </summary>
    public class DeveloperNotes : MonoBehaviour
    {
        [SerializeField, TextArea] private string _developerNotes;
    }
}
#endif