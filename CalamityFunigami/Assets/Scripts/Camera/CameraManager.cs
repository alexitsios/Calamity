using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera ActiveCamera { get; set; }

    private void Start()
    {
        ActiveCamera = Camera.main;
    }
}
