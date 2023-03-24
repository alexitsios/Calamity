using UnityEditor;
using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.DebugTools
{
    /// <summary>
    /// This public static class contains a single private static method that toggles colliders for untagged game objects.
    /// </summary>
    public static class ToggleUnsetColliders
    {
        /// <summary>
        /// This method toggles the colliders for all untagged game objects in the scene.
        /// </summary>
        /// <remarks>
        /// This method is decorated with the [MenuItem] attribute, which allows it to be accessed through the Unity Editor's Tools menu. It first checks if the application is currently playing, and then searches for any untagged objects that have colliders enabled. If any such objects are found, the colliders are toggled (enabled or disabled) for all untagged objects.
        /// </remarks>
        [MenuItem(MenuItemSortOrders.Tools + "Toggle Untagged Colliders")]
        private static void ToggleColliders()
        {
            // Check if the application is playing
            if (!Application.isPlaying)
                return;

            bool collidersEnabled = false;

            // Check if any untagged objects have colliders enabled
            foreach (Collider collider in GameObject.FindObjectsOfType<Collider>())
            {
                if (collider.gameObject.CompareTag("Untagged") && collider.enabled)
                {
                    collidersEnabled = true;
                    break;
                }
            }

            // Toggle the colliders
            foreach (Collider collider in GameObject.FindObjectsOfType<Collider>())
            {
                if (collider.gameObject.CompareTag("Untagged"))
                {
                    collider.enabled = !collidersEnabled;
                }
            }
        }
    }

}
