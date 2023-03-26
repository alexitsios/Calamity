using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscribeCamera : MonoBehaviour
{
    void Start()
    {
        var controller = GetComponentInParent<StaticCameraController>();
        if (controller.Camera != null)
        {
            Debug.LogError($"Too many cameras are trying to subscribe to a static camera prefab named {gameObject.name}");
        }
        controller.Camera = GetComponent<Camera>();
        controller.Listener = GetComponent<AudioListener>();
    }
}
