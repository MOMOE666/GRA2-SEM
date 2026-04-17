using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 1f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        // vertical rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // horizontal rotation
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
