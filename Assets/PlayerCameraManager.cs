using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{
    public Camera MainCamera;

    private Camera swapCamera;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && swapCamera != null)
        {
            ToggleCameras();
        }
    }

    void ToggleCameras()
    {
        MainCamera.enabled = !MainCamera.enabled;
        swapCamera.enabled = !swapCamera.enabled;

        if (controller != null)
        {
            controller.enabled = MainCamera.enabled;
        }

        Cursor.visible = !MainCamera.enabled;
        Cursor.lockState = MainCamera.enabled ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void RegisterSwapCamera(Camera camera)
    {
        swapCamera = camera;
    }

    public void DeregisterSwapCamera(Camera camera)
    {
        if (swapCamera == camera)
        {
            if (swapCamera.enabled)
            {
                ToggleCameras();
            }
            swapCamera = null;
        }
    }
}