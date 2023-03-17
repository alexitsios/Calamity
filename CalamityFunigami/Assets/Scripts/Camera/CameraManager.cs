using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera ActiveCamera { get; set; }
    public AudioListener ActiveListener { get; set; }

    private void Start()
    {
        ActiveCamera = Camera.main;
        ActiveListener = ActiveCamera.GetComponent<AudioListener>();
    }
}
