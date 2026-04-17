using UnityEngine;

public class LockpickTrigger : MonoBehaviour
{
    public CameraManager cameraManager;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !cameraManager.isTaskDone)
        {
            cameraManager.ShowLockpickView();
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !cameraManager.isTaskDone)
        {
            cameraManager.ShowFirstPersonView();
        }
    }
}