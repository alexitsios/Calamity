using UnityEngine;

public class StaticCameraController : MonoBehaviour
{
    public Camera Camera { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        var manager = other.gameObject.GetComponent<CameraManager>();
        manager.ActiveCamera.enabled = false;
        Camera.enabled = true;
        manager.ActiveCamera = Camera;
    }
}
