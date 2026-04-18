using UnityEngine;

public class cameratest1 : MonoBehaviour
{
    [Header("Cams")]
    public Camera mainCamera;      
    public Camera cameratest; 

    private bool isUnlocked = false; 

    
    public void SetUnlocked()
    {
        isUnlocked = true;
        ShowFirstPerson(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !isUnlocked)
        {
            ShowLockpick();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            ShowFirstPerson();
        }
    }

    void ShowLockpick()
    {
        mainCamera.enabled = false;
        cameratest.enabled = true;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

    void ShowFirstPerson()
    {
        mainCamera.enabled = true;
        cameratest.enabled = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
}