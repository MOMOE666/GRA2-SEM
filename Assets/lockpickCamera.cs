using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera lockpickCamera;

    
    public bool isTaskDone = false;

    public void ShowLockpickView()
    {
        
        if (!isTaskDone)
        {
            mainCamera.enabled = false;
            lockpickCamera.enabled = true;

            
            Cursor.lockState = CursorLockMode.None; 
        }
    }

    public void ShowFirstPersonView()
    {
        mainCamera.enabled = true;
        lockpickCamera.enabled = false;

        
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    public void FinishQuest()
    {
        isTaskDone = true;
        ShowFirstPersonView();
    }
}