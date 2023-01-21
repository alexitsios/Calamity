using UnityEngine;

public class SubscribeAnimator : MonoBehaviour
{
    void Start()
    {
        var playerMovement = GetComponentInParent<PlayerMovement>();
        if (playerMovement.Animator != null)
        {
            Debug.LogError("Too many animators are trying to subscribe to player movement.");
        }
        playerMovement.Animator = GetComponent<Animator>();
    }

    
}
