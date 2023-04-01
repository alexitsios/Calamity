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
        public static bool CollidersEnabled = false;
        /// <summary>
        /// Validation method for ToggleColliders();
        /// </summary>
        /*[MenuItem(MenuItemSortOrders.GameplayTools + "Toggle Untagged Colliders", false)]
        private static void ToggleCollidersValidation()
        {
            // Check if the application is playing
            if (!Application.isPlaying)
            {
                Debug.Log("Gameplay must be active to toggle colliders.");
                return;
            }
            ToggleColliders();
        }*/

        /// <summary>
        /// This method toggles the colliders for all untagged game objects in the scene.
        /// </summary>
        //[MenuItem(MenuItemSortOrders.GameplayTools + "Toggle Untagged Colliders", priority = MenuItemSortOrders.GameplayToolsPriority + 2)]
        public static void ToggleColliders()
        {
            // Check if any untagged objects have colliders enabled
            foreach (Collider collider in GameObject.FindObjectsOfType<Collider>())
            {
                if (collider.gameObject.CompareTag("Untagged") && collider.enabled)
                {
                    CollidersEnabled = true;
                    break;
                }
            }

            // Toggle the colliders
            foreach (Collider collider in GameObject.FindObjectsOfType<Collider>())
            {
                if (collider.gameObject.CompareTag("Untagged"))
                {
                    collider.enabled = !CollidersEnabled;
                }
            }
        }
    }
}