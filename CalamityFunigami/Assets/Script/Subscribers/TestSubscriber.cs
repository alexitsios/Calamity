using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSubscriber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerStateManager.Instance.AddSubscriber(PlayerState.Walking, OnPlayerMovement);
        PlayerStateManager.Instance.AddSubscriber(PlayerState.Idle, OnPlayerIdle);
	}

    private void OnPlayerMovement()
    {
        Debug.Log("I was notified the player is moving");
    }

    private void OnPlayerIdle()
    {
		Debug.Log("I was notified the player is idle");
	}
}
