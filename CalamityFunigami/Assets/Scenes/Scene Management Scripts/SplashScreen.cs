using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Calamity.SceneManagement
{
    /// <summary>
    /// Picks a random splash screen image to display and sets it to a random color.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class SplashScreen : MonoBehaviour
    {
        /// <summary>
        /// Sprites to choose from for randomized splash screen.
        /// </summary>
        [SerializeField] private List<Sprite> splashImages = new List<Sprite>();

        // An image object to hold splash screen
        private Image imageContainer;

        private void Awake()
        {
            imageContainer = GetComponent<Image>();
        }

        // Select image
        private void OnEnable() => PickImage();

        /// <summary>
        /// Selects a random image and sets it to a random color.
        /// </summary>
        private void PickImage()
        {
            if (splashImages.Count == 0)
                return;

            int randomImageID = Random.Range(0, splashImages.Count);
            imageContainer.sprite = splashImages[randomImageID];
            Color newColor = new Color(Random.value, Random.value, Random.value);
            imageContainer.color = newColor;
        }
    }
}