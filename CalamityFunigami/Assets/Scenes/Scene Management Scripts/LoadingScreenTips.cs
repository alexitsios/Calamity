using TMPro;
using UnityEngine;

namespace Calamity.SceneManagement {

    /// <summary>
    /// Displays text "tips" to player on loading screens.
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LoadingScreenTips : MonoBehaviour
    {
        [SerializeField] private string[] screenTips;
        private TextMeshProUGUI textContainer;

        private void Awake()
        {
            textContainer = GetComponent<TextMeshProUGUI>();
            textContainer.color = Color.white;
        }

        // Select a tip when enabled.
        private void OnEnable() => PickText();

        /// <summary>
        /// Choose and display a random tip from those available.
        /// </summary>
        private void PickText()
        {
            int screenTipCount = screenTips.Length;

            if (screenTipCount == 0)
                return;

            int randomScreenTipID = Random.Range(0, screenTipCount);
            textContainer.text = screenTips[randomScreenTipID];
        }
    }
}