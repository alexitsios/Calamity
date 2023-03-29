using UnityEngine;

namespace Calamity.DebugTools
{
    /// <summary>
    /// Adds a Point Light to the player during runtime and toggles it on and off.
    /// </summary>
    public class AddPointLightToPlayer : MonoBehaviour
    {
        private static Light _light;

        public static bool LightEnabled { get; private set; }

        /// <summary>
        /// Initializes the script by adding the light component to the player object if it doesn't exist yet.
        /// </summary>
        public static void Initialize()
        {
            if (_light == null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    _light = player.AddComponent<Light>();
                    _light.type = LightType.Point;
                    _light.range = 10f;
                    _light.intensity = 2f;
                    _light.color = Color.white;
                    LightEnabled = true;
                }
                else
                {
                    Debug.LogError("No object found with tag 'Player'.");
                }
            }
        }

        /// <summary>
        /// Toggles the light component on and off.
        /// </summary>
        public static void ToggleLight()
        {
            if (_light == null)
            {
                Debug.LogError("Light component is not initialized.");
                return;
            }

            _light.enabled = !LightEnabled;
            LightEnabled = _light.enabled;
        }
    }
}
