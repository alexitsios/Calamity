using UnityEngine;

public class StaticCameraController : MonoBehaviour
{
    public Camera Camera { get; set; }
    public AudioListener Listener { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        var manager = other.gameObject.GetComponent<CameraManager>();
        manager.ActiveCamera.enabled = false;
        manager.ActiveListener.enabled = false;
        Camera.enabled = true;
        Listener.enabled = true;
        manager.ActiveCamera = Camera;
        manager.ActiveListener = Listener;
    }
}
