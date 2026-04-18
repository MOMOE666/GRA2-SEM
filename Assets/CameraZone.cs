using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public Camera zoneCamera; // Tutaj przypisujesz kamerê lockpickingu

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCameraManager manager = other.GetComponent<PlayerCameraManager>();
            if (manager != null)
            {
                manager.RegisterSwapCamera(zoneCamera);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCameraManager manager = other.GetComponent<PlayerCameraManager>();
            if (manager != null)
            {
                manager.DeregisterSwapCamera(zoneCamera);
            }
        }
    }
}